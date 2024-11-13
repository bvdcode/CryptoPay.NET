using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using CryptoPay.Responses;
using CryptoPay.Extensions;
using CryptoPay.Exceptions;
using System.Threading.Tasks;
using CryptoPay.Requests.Base;

namespace CryptoPay
{
    /// <summary>
    /// The main class for interacting with the CryptoPay service.
    /// </summary>
    public class CryptoPayClient : ICryptoPayClient
    {
        private readonly HttpClient _httpClient;
        private const string defaultCryptoBotApiUrl = "https://pay.crypt.bot/";

        /// <summary>
        /// Create <see cref="ICryptoPayClient" /> instance.
        /// </summary>
        /// <param name="token">Your application token from CryptoPay.</param>
        /// <param name="httpClient">Optional. <see cref="HttpClient" />.</param>
        /// <param name="apiUrl">
        /// Optional. Default value is <see cref="defaultCryptoBotApiUrl" /> main api url.
        /// </param>
        /// <exception cref="ArgumentNullException">If token is null.</exception>
        public CryptoPayClient(string token, HttpClient? httpClient = null, string? apiUrl = default)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentNullException(nameof(token));
            }
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.BaseAddress = new Uri(apiUrl ?? defaultCryptoBotApiUrl);
            _httpClient.DefaultRequestHeaders.Add("Crypto-Pay-API-Token", token);
        }

        /// <summary>
        /// Create <see cref="ICryptoPayClient" /> instance.
        /// </summary>
        /// <param name="token">Your application token from CryptoPay.</param>
        /// <exception cref="ArgumentNullException">If token is null.</exception>
        public CryptoPayClient(string token) : this(token, null, null) { }

        /// <summary>
        /// Create <see cref="ICryptoPayClient" /> instance.
        /// </summary>
        /// <param name="token">Your application token from CryptoPay.</param>
        /// <param name="useTestnet">If true, then use testnet url: <code>https://testnet-pay.crypt.bot/</code>, otherwise use main url: <code>https://pay.crypt.bot/</code>.</param>
        public CryptoPayClient(string token, bool useTestnet)
            : this(token, null, useTestnet ? "https://testnet-pay.crypt.bot/" : null) { }

        /// <summary>
        /// Create <see cref="ICryptoPayClient" /> instance with custom <see cref="HttpClient" />.
        /// Note: You should set base address and headers by yourself.
        /// This constructor was left for backward compatibility.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/></param>
        public CryptoPayClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Make raw request to CryptoPay service.
        /// </summary>
        /// <param name="request">Type of request <see cref="IRequest" /></param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of
        /// cancellation.
        /// </param>
        /// <returns>Instance type of TResponse</returns>
        /// <exception cref="RequestException">This exception can be thrown if request is not successful.</exception>
        /// <exception cref="ArgumentNullException">If request is null.</exception>
        public async Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken = default)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var url = $"{_httpClient.BaseAddress}api/{request.MethodName}";

            using HttpRequestMessage httpRequest = new HttpRequestMessage(request.Method, url);
            httpRequest.Content = request.ToHttpContent();

            using var httpResponse = await SendRequestAsync(
                    _httpClient,
                    httpRequest,
                    cancellationToken)
                .ConfigureAwait(false);

            string json = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                await httpResponse
                    .DeserializeContentAsync<ApiResponseWithError>(response =>
                            response.Ok == false,
                        cancellationToken)
                    .ConfigureAwait(false);
            }

            var apiResponse = await httpResponse
                .DeserializeContentAsync<ApiResponse<TResponse>>(response =>
                        response.Ok == false ||
                        response.Result is null,
                    cancellationToken)
                .ConfigureAwait(false);

            return apiResponse.Result!;
        }

        private static async Task<HttpResponseMessage> SendRequestAsync(HttpClient httpClient, HttpRequestMessage httpRequest, CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await httpClient
                    .SendAsync(httpRequest, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (TaskCanceledException exception)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }

                throw new Exception("Request timed out", exception);
            }
            catch (Exception exception)
            {
                throw new Exception(
                    "Exception during making request",
                    exception
                );
            }

            return httpResponse;
        }
    }
}
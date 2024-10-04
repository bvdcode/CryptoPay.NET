﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using CryptoPay.Responses;
using CryptoPay.Extensions;
using System.Threading.Tasks;
using CryptoPay.Requests.Base;
using System.Runtime.CompilerServices;

namespace CryptoPay
{
    /// <inheritdoc />
    public class CryptoPayClient : ICryptoPayClient
    {
        #region Private Fields

        private readonly HttpClient httpClient;
        private const string defaultCryptoBotApiUrl = "https://pay.crypt.bot/";

        #endregion

        #region Constructors

        /// <summary>
        /// Create <see cref="ICryptoPayClient" /> instance.
        /// </summary>
        /// <param name="token">Your application token from CryptoPay.</param>
        /// <param name="httpClient">Optional. <see cref="HttpClient" />.</param>
        /// <param name="apiUrl">
        /// Optional. Default value is <see cref="defaultCryptoBotApiUrl" /> main api url.
        /// Test api url is <code>https://testnet-pay.crypt.bot/</code>.
        /// </param>
        /// <exception cref="ArgumentNullException">If token is null.</exception>
        public CryptoPayClient(string token, HttpClient? httpClient = null, string? apiUrl = default)
        {
            this.httpClient = httpClient ?? new HttpClient();
            this.httpClient.BaseAddress = new Uri(apiUrl ?? defaultCryptoBotApiUrl);
            this.httpClient.DefaultRequestHeaders.Add(
                "Crypto-Pay-API-Token",
                string.IsNullOrEmpty(token)
                    ? throw new ArgumentNullException(nameof(token))
                    : token);
        }

        /// <summary>
        /// Create <see cref="ICryptoPayClient" /> instance.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/></param>
        public CryptoPayClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public async Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken = default)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var url = $"{this.httpClient.BaseAddress}api/{request.MethodName}";

            using HttpRequestMessage httpRequest = new HttpRequestMessage(request.Method, url);
            httpRequest.Content = request.ToHttpContent();

            using var httpResponse = await SendRequestAsync(
                    this.httpClient,
                    httpRequest,
                    cancellationToken)
                .ConfigureAwait(false);

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        #endregion

        #region Private Methods

        private static long GetApplicationId(string token)
        {
            ReadOnlySpan<char> dataAsSpan = token;
            var endInd = token.IndexOf(":", StringComparison.Ordinal);
            return long.Parse(dataAsSpan.Slice(0, endInd));
        }

        #endregion
    }
}
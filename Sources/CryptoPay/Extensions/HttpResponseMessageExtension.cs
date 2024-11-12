using System;
using System.IO;
using CryptoPay.Types;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using CryptoPay.Responses;
using CryptoPay.Exceptions;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices;

namespace CryptoPay.Extensions
{
    /// <summary>
    /// HttpResponseMessage extension class.
    /// </summary>
    public static class HttpResponseMessageExtensions
    {
        private static async Task<T> DeserializeJsonFromStreamAsync<T>(this Stream stream, CancellationToken cancellationToken)
            where T : class
        {
            if (stream is null || !stream.CanRead)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
            };

            return await JsonSerializer.DeserializeAsync<T>(stream, options, cancellationToken)
                ?? throw new ArgumentNullException(nameof(stream));
        }

        /// <summary>
        /// Deserialize body from HttpContent into <typeparamref name="T" />.
        /// </summary>
        /// <param name="httpResponse"><see cref="HttpResponseMessage" /> instance.</param>
        /// <param name="guard"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T">Type of the resulting object.</typeparam>
        /// <returns></returns>
        /// <exception cref="RequestException">
        /// Thrown when body in the response can not be deserialized into <typeparamref name="T" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static async Task<T> DeserializeContentAsync<T>(
            this HttpResponseMessage httpResponse,
            Func<T, bool> guard,
            CancellationToken cancellationToken)
            where T : class
        {
            Stream? contentStream = null;

            if (httpResponse.Content is null)
            {
                throw new RequestException(
                    "Response doesn't contain any content",
                    new Error(0, nameof(NullReferenceException)),
                    httpResponse.StatusCode
                );
            }

            try
            {
                T deserializedObject;
                try
                {
                    contentStream = await httpResponse.Content
                        .ReadAsStreamAsync()
                        .ConfigureAwait(false);

                    deserializedObject = await contentStream
                        .DeserializeJsonFromStreamAsync<T>(cancellationToken);
                }
                catch (Exception exception)
                {
                    throw CreateRequestException(
                        httpResponse,
                        exception: exception);
                }

                if (deserializedObject is null)
                {
                    throw CreateRequestException(
                        httpResponse,
                        message: "Required properties not found in response");
                }

                if (guard(deserializedObject))
                {
                    throw CreateRequestException(
                        httpResponse,
                        (deserializedObject as ApiResponseWithError)?.Error ?? new Error(0, "Unknown"));
                }

                return deserializedObject;
            }
            finally
            {
                if (contentStream != null)
                {
                    await contentStream
                        .DisposeAsync()
                        .ConfigureAwait(false);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static RequestException CreateRequestException(
            HttpResponseMessage httpResponse,
            Error? error = null,
            string? message = null,
            Exception? exception = null
        ) =>
            exception is null
                ? new RequestException(
                    message ?? "Unknown",
                    error ?? new Error(0, "Unknown"),
                    httpResponse.StatusCode
                )
                : new RequestException(
                    exception.Message,
                    httpResponse.StatusCode,
                    exception
                );
    }
}

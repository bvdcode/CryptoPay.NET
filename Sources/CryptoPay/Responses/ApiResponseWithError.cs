using CryptoPay.Types;
using System.Text.Json.Serialization;

namespace CryptoPay.Responses
{
    /// <summary>
    /// Response with <see cref="Error"/>.
    /// </summary>
    internal class ApiResponseWithError : IResponse
    {
        /// <summary>
        /// Initializes an instance of <see cref="ApiResponseWithError" />
        /// </summary>
        /// <param name="error">Instanse of <see cref="Error"/>.</param>
        public ApiResponseWithError(Error error)
        {
            Ok = false;
            Error = error;
        }

        [JsonConstructor]
        private ApiResponseWithError() { }

        /// <inheritdoc cref="IResponse.Ok"/>
        [JsonRequired]
        public bool Ok { get; set; }

        /// <summary>
        /// Instance of <see cref="Error"/>.
        /// </summary>
        [JsonRequired]
        public Error Error { get; set; } = new Error(0, "Unknown");
    }
}

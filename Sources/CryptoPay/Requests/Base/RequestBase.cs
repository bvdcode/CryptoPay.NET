using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoPay.Requests.Base
{
    /// <summary>
    /// Base class for all requests.
    /// </summary>
    public class RequestBase<TResponse> : IRequest<TResponse>
    {
        /// <summary>
        /// Convert request to <see cref="HttpContent"/>.
        /// </summary>
        public HttpContent ToHttpContent()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
            };

            var payload = JsonSerializer.Serialize(this, GetType(), options);
            return new StringContent(payload, Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Initializes an instance of request.
        /// </summary>
        /// <param name="methodName">Bot API method</param>
        protected RequestBase(string methodName)
            : this(methodName, HttpMethod.Post) { }

        /// <summary>
        /// Initializes an instance of request.
        /// </summary>
        /// <param name="methodName">Bot API method.</param>
        /// <param name="method">HTTP method to use.</param>
        protected RequestBase(string methodName, HttpMethod method)
        {
            MethodName = methodName;
            Method = method;
        }

        /// <summary>
        /// HTTP method to use.
        /// </summary>
        public HttpMethod Method { get; }

        /// <summary>
        /// Bot API method.
        /// </summary>
        public string MethodName { get; }
    }
}
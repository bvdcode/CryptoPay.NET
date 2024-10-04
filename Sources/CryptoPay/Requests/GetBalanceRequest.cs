using CryptoPay.Types;
using CryptoPay.Requests.Base;
using System.Collections.Generic;

namespace CryptoPay.Requests
{
    /// <summary>
    /// Use this class to create <see cref="Balance"/> request.
    /// </summary>
    internal sealed class GetBalanceRequest : ParameterlessRequest<List<Balance>>
    {
        /// <summary>
        /// Initializes a new request to get <see cref="Balance"/>.
        /// </summary>
        public GetBalanceRequest()
            : base("getBalance") { }
    }
}

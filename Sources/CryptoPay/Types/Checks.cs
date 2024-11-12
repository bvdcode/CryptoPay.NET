using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace CryptoPay.Types
{
    /// <summary>
    /// Object include list of <see cref="Check"/>.
    /// </summary>
    public class Checks
    {
        /// <summary>
        /// List of <see cref="Check"/>.
        /// </summary>
        [JsonRequired]
        public IEnumerable<Check> Items { get; set; } = Enumerable.Empty<Check>();
    }
}
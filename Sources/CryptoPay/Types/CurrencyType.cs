using System.Text.Json.Serialization;

namespace CryptoPay.Types
{
    /// <summary>
    /// Type of the price, can be <see cref="CurrencyType.Crypto"/> or <see cref="CurrencyType.Fiat"/>.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CurrencyType
    {
        /// <summary>
        /// Crypto currency.
        /// </summary>
        [JsonPropertyName("crypto")]
        Crypto,

        /// <summary>
        /// Fiat currency.
        /// </summary>
        [JsonPropertyName("fiat")]
        Fiat
    }
}
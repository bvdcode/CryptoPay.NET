using System.Text.Json.Serialization;

namespace CryptoPay.Types
{
    /// <summary>
    /// Status of invoices to be returned.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InvoiceStatus
    {
        /// <summary>
        /// The invoice is active.
        /// </summary>
        [JsonPropertyName("active")]
        Active,

        /// <summary>
        /// The invoice is paid.
        /// </summary>
        [JsonPropertyName("paid")]
        Paid,

        /// <summary>
        /// The invoice is expired.
        /// </summary>
        [JsonPropertyName("expired")]
        Expired
    }
}
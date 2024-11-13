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
        [JsonStringEnumMemberName("active")]
        Active,

        /// <summary>
        /// The invoice is paid.
        /// </summary>
        [JsonStringEnumMemberName("paid")]
        Paid,

        /// <summary>
        /// The invoice is expired.
        /// </summary>
        [JsonStringEnumMemberName("expired")]
        Expired
    }
}
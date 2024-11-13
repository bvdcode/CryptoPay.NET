using System.Text.Json.Serialization;

namespace CryptoPay.Types
{
    /// <summary>
    /// Status of the transfer.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransferStatus
    {
        /// <summary>
        /// The transfer is completed.
        /// </summary>
        [JsonStringEnumMemberName("completed")]
        Completed = 0
    }
}
using System.Text.Json.Serialization;

namespace CryptoPay.Types
{
    /// <summary>
    /// Buttons that will be shown to a user after the invoice is paid.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaidButtonName

    {
        /// <summary>
        /// View item button.
        /// </summary>
        [JsonPropertyName("viewItem")]
        ViewItem,

        /// <summary>
        /// Open channel button.
        /// </summary>
        [JsonPropertyName("openChannel")]
        OpenChannel,

        /// <summary>
        /// Open bot button.
        /// </summary>
        [JsonPropertyName("openBot")]
        OpenBot,

        /// <summary>
        /// Callback button.
        /// </summary>
        [JsonPropertyName("callback")]
        Callback
    }
}
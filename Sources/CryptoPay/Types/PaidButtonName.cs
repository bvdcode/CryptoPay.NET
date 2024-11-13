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
        [JsonStringEnumMemberName("viewItem")]
        ViewItem,

        /// <summary>
        /// Open channel button.
        /// </summary>
        [JsonStringEnumMemberName("openChannel")]
        OpenChannel,

        /// <summary>
        /// Open bot button.
        /// </summary>
        [JsonStringEnumMemberName("openBot")]
        OpenBot,

        /// <summary>
        /// Callback button.
        /// </summary>
        [JsonStringEnumMemberName("callback")]
        Callback
    }
}
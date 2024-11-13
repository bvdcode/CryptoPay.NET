using System;
using System.Text.Json.Serialization;

namespace CryptoPay.Types
{
    /// <inheritdoc />
    public class Transfer : ITransfer
    {
        /// <summary>
        /// Unique ID for this transfer.
        /// </summary>
        [JsonRequired]
        public long TransferId { get; set; }

        /// <summary>
        /// Optional. Unique UTF-8 string. 
        /// </summary>
        public string SpendId { get; set; } = string.Empty;

        /// <inheritdoc/>
        [JsonRequired]
        public long UserId { get; set; }

        /// <inheritdoc/>
        [JsonRequired]
        public string Asset { get; set; } = string.Empty;

        /// <inheritdoc/>
        [JsonRequired]
        public double Amount { get; set; }

        /// <summary>
        /// Status of the transfer, can be “completed”.
        /// </summary>
        [JsonRequired]
        public TransferStatus Status { get; set; }

        /// <summary>
        /// Date the transfer was completed in ISO 8601 format.
        /// </summary>
        [JsonRequired]
        public DateTime CompletedAt { get; set; }

        /// <summary>
        /// Optional. Comment for this transfer.
        /// </summary>
        public string? Comment { get; set; } = string.Empty;
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoPay.Types
{
    /// <inheritdoc />
    public class Invoice : IInvoice
    {
        /// <summary>
        /// Unique ID for this invoice.
        /// </summary>
        [JsonRequired]
        public long InvoiceId { get; set; }

        /// <summary>
        /// Status of the invoice, can be either “active”, “paid” or “expired”.
        /// </summary>
        [JsonRequired]
        public InvoiceStatus Status { get; set; }

        /// <summary>
        /// Hash of the invoice.
        /// </summary>
        [JsonRequired]
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// URL should be presented to the user to pay the invoice.
        /// </summary>
        [Obsolete("The field PayUrl is now deprecated, use the new field BotInvoiceUrl instead")]
        public string PayUrl { get; set; } = string.Empty;

        /// <summary>
        /// Date the invoice was created in ISO 8601 format.
        /// </summary>
        [JsonRequired]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// True, if the user can pay the invoice anonymously.
        /// </summary>
        public bool? AllowAnonymous { get; set; }

        /// <summary>
        /// Optional. Date the invoice expires in Unix time.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Optional. Date the invoice was paid in Unix time.
        /// </summary>
        public DateTime? PaidAt { get; set; }

        /// <summary>
        /// True, if the invoice was paid anonymously.
        /// </summary>
        public bool? PaidAnonymously { get; set; }

        /// <summary>
        /// Optional. Comment to the payment from the user.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Asset of the invoice. Currently, can be one of <see cref="Assets"/>.
        /// </summary>
        public string? Asset { get; set; }

        /// <summary>
        /// Amount of the invoice.
        /// </summary>
        [JsonRequired]
        public double Amount { get; set; }

        /// <summary>
        /// Description of the invoice.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Allow the user to leave a comment.
        /// </summary>
        public bool? AllowComments { get; set; }

        /// <summary>
        /// Optional. Hidden message for the invoice.
        /// </summary>
        public string? HiddenMessage { get; set; }

        /// <summary>
        /// Optional. Previously provided data for this invoice.
        /// </summary>
        public string? Payload { get; set; }

        /// <summary>
        /// Optional. Name of the button, can be one of <see cref="PaidButtonName"/>.
        /// </summary>
        public PaidButtonName? PaidBtnName { get; set; }

        /// <summary>
        /// Optional. URL of the button.
        /// </summary>
        public string? PaidBtnUrl { get; set; }

        /// <summary>
        /// Type of the price, can be one of <see cref="Types.CurrencyType"/>.
        /// </summary>
        public CurrencyType CurrencyType { get; set; }

        /// <summary>
        /// Optional. List of assets which can be used to pay the invoice.
        /// </summary>
        public IEnumerable<string>? AcceptedAssets { get; set; }

        /// <summary>
        /// Optional. Amount of charged service fees.
        /// </summary>
        [Obsolete("The field Fee in the Webhook update payload is now deprecated, use the new field FeeAmount instead")]
        public string Fee { get; set; } = string.Empty;

        /// <summary>
        /// Optional. Price of the asset in USD at the time the invoice was paid.
        /// </summary>
        [Obsolete("The field UsdRate in the Webhook update payload is now deprecated, use the new field PaidUsdRate instead")]
        public string UsdRate { get; set; } = string.Empty;

        /// <summary>
        /// URL should be provided to the user to pay the invoice.
        /// </summary>
        [JsonRequired]
        public string BotInvoiceUrl { get; set; } = string.Empty;

        /// <summary>
        /// Optional. Price of the asset in USD. Available only if status is <see cref="InvoiceStatus.Paid"/>.
        /// </summary>
        public string PaidUsdRate { get; set; } = string.Empty;

        /// <summary>
        /// Optional. Amount of service fees charged when the invoice was paid.
        /// Available only if status is <see cref="InvoiceStatus.Paid"/>.
        /// </summary>
        public double FeeAmount { get; set; }

        /// <summary>
        /// Optional. Fiat currency code. Available only if the value of the field <see cref="CurrencyType"/> is <see cref="CurrencyType.Fiat"/>.
        /// Currently one of fiat from <see cref="Assets"/>.
        /// </summary>
        public string? Fiat { get; set; }

        /// <summary>
        /// Optional. Cryptocurrency alphabetic code for which the invoice was paid.
        /// Available only if <see cref="CurrencyType"/> is <see cref="CurrencyType.Fiat"/> and status is <see cref="InvoiceStatus.Paid"/>.
        /// </summary>
        public string PaidAsset { get; set; } = string.Empty;

        /// <summary>
        /// Optional. Amount of the invoice for which the invoice was paid.
        /// Available only if <see cref="CurrencyType"/> is <see cref="CurrencyType.Fiat"/> and status is <see cref="InvoiceStatus.Paid"/>.
        /// </summary>
        public string PaidAmount { get; set; } = string.Empty;

        /// <summary>
        /// Optional. The rate of the paid_asset valued in the fiat currency.
        /// Available only if the value of the field <see cref="CurrencyType"/> is <see cref="CurrencyType.Fiat"/> and the value of the field status is <see cref="InvoiceStatus.Paid"/>.
        /// </summary>
        public string PaidFiatRate { get; set; } = string.Empty;

        /// <summary>
        /// Optional. Asset of service fees charged when the invoice was paid.
        /// Available only if status is <see cref="InvoiceStatus.Paid"/>.
        /// </summary>
        public string FeeAsset { get; set; } = string.Empty;

        /// <summary>
        /// Use this URL to pay an invoice to the Telegram Mini App version.
        /// </summary>
        [JsonRequired]
        public string MiniAppInvoiceUrl { get; set; } = string.Empty;

        /// <summary>
        /// Use this URL to pay an invoice to the Web version of Crypto Bot.
        /// </summary>
        [JsonRequired]
        public string WebAppInvoiceUrl { get; set; } = string.Empty;
    }
}
﻿using CryptoPay.Types;
using CryptoPay.Converters;
using CryptoPay.Requests.Base;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoPay.Requests
{
    /// <summary>
    /// Use this class to create <see cref="Invoice"/> request.
    /// </summary>
    public class CreateInvoiceRequest
        : ParameterlessRequest<Invoice>,
            IInvoice
    {
        /// <summary>
        /// Initializes a new request to create <see cref="Invoice"/>
        /// </summary>
        /// <param name="amount">Amount of the invoice in float. For example: 125.50</param>
        /// <param name="currencyType">Optional. Type of the price, can be <see cref="CurrencyType.Crypto"/> or <see cref="CurrencyType.Fiat"/>. Defaults to crypto.</param>
        /// <param name="asset">Currency code.
        /// <remarks>Due to the fact that the list of available currencies in the CryptoPay service is constantly changing, utilizing <see cref="Assets"/> becomes ineffective. However, you can resort to using Assets.BTC.ToString() instead.</remarks>
        /// </param>
        /// <param name="fiat">Optional. Required if currencyType is <see cref="CurrencyType.Fiat"/>. Fiat currency code. Supported fiat currencies from <see cref="Assets"/></param>
        /// <param name="acceptedAssets">
        /// Optional. List of cryptocurrency alphabetic codes. Assets which can be used to pay the invoice.
        /// Available only if currencyType is <see cref="CurrencyType.Fiat"/>. Supported assets from <see cref="Assets"/>.
        /// Defaults to all currencies.
        /// </param>
        /// <param name="description">Optional. Description for the invoice. User will see this description when they pay the invoice. Up to 1024 characters.</param>
        /// <param name="hiddenMessage">Optional. Text of the message that will be shown to a user after the invoice is paid. Up to 2048 characters.</param>
        /// <param name="paidBtnName">Optional. Name of the button that will be shown to a user after the invoice is paid. <see cref="PaidButtonName" /></param>
        /// <param name="paidBtnUrl">
        /// Optional. Required if <see cref="PaidButtonName">paidBtnName</see> is used. URL to be opened when the button is pressed.
        /// You can set any success link (for example, a link to your bot). Starts with https or http.
        /// </param>
        /// <param name="payload">Optional.Any data you want to attach to the invoice (for example, user ID, payment ID, ect). Up to 4kb.</param>
        /// <param name="allowComments">Optional. Allow a user to add a comment to the payment. Default is true.</param>
        /// <param name="allowAnonymous">Optional. Allow a user to pay the invoice anonymously. Default is <c>true</c>.</param>
        /// <param name="expiresIn">You can set a payment time limit for the invoice in <b>seconds</b>. Values between 1-2678400 are accepted.</param>
        public CreateInvoiceRequest(
            double amount,
            CurrencyType currencyType = CurrencyType.Crypto,
            string? asset = null,
            string? fiat = null,
            IEnumerable<string>? acceptedAssets = null,
            string? description = null,
            string? hiddenMessage = null,
            PaidButtonName? paidBtnName = null,
            string? paidBtnUrl = null,
            string? payload = null,
            bool allowComments = true,
            bool allowAnonymous = true,
            int expiresIn = 2678400)
            : base("createInvoice")
        {
            CurrencyType = currencyType;
            Amount = amount;
            Asset = asset;
            Fiat = fiat;
            AcceptedAssets = acceptedAssets;
            Description = description;
            HiddenMessage = hiddenMessage;
            PaidBtnName = paidBtnName;
            PaidBtnUrl = paidBtnUrl;
            Payload = payload;
            AllowComments = allowComments;
            AllowAnonymous = allowAnonymous;
            ExpiresIn = expiresIn;
        }

        /// <summary>
        /// Currency code. Currently, can be one of <see cref="Assets"/>.
        /// </summary>
        public string? Asset { get; set; }

        /// <summary>
        /// Fiat currency code. Supported fiat currencies from <see cref="Assets"/>
        /// </summary>
        public string? Fiat { get; set; }

        /// <summary>
        /// Amount of the invoice in float. For example: 125.50
        /// </summary>
        [JsonRequired]
        public double Amount { get; set; }

        /// <summary>
        /// Description for the invoice. User will see this description when they pay the invoice. Up to 1024 characters.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Text of the message that will be shown to a user after the invoice is paid. Up to 2048 characters.
        /// </summary>
        public string? HiddenMessage { get; set; }

        /// <summary>
        /// Name of the button that will be shown to a user after the invoice is paid.
        /// </summary>
        public PaidButtonName? PaidBtnName { get; set; }

        /// <summary>
        /// URL to be opened when the button is pressed.
        /// </summary>
        public string? PaidBtnUrl { get; set; }

        /// <summary>
        /// Optional. Any data you want to attach to the invoice (for example, user ID, payment ID, ect). Up to 4kb.
        /// </summary>
        public string? Payload { get; set; }

        /// <summary>
        /// Optional. Allow a user to add a comment to the payment. Default is true.
        /// </summary>
        public bool? AllowComments { get; set; }

        /// <summary>
        /// Type of the price, can be <see cref="CurrencyType.Crypto"/> or <see cref="CurrencyType.Fiat"/>. Defaults to crypto.
        /// </summary>
        [JsonRequired]
        public CurrencyType CurrencyType { get; set; }

        /// <summary>
        /// List of cryptocurrency alphabetic codes. Assets which can be used to pay the invoice.
        /// </summary>
        [JsonConverter(typeof(ArrayToStringConverter))]
        public IEnumerable<string>? AcceptedAssets { get; set; }

        /// <summary>
        /// Optional. Allow a user to pay the invoice anonymously. Default is true.
        /// </summary>
        public bool? AllowAnonymous { get; set; }

        /// <summary>
        /// Optional. You can set a payment time limit for the invoice in seconds. Values between 1-2678400 are accepted.
        /// </summary>
        public int ExpiresIn { get; set; }
    }
}
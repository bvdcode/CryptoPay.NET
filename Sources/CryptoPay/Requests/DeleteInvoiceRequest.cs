﻿using CryptoPay.Requests.Base;
using System.Text.Json.Serialization;

namespace CryptoPay.Requests
{
    /// <summary>
    /// Use this method to delete invoices created by your app.
    /// </summary>
    public class DeleteInvoiceRequest
        : ParameterlessRequest<bool>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new request delete invoices created by your app.
        /// </summary>
        /// <param name="invoiceId">Invoice ID to be deleted.</param>
        public DeleteInvoiceRequest(long invoiceId)
            : base("deleteInvoice")
        {
            this.InvoiceId = invoiceId;
        }

        #endregion

        #region Public Fields

        /// <summary>
        /// Unique ID for this invoice.
        /// </summary>
        [JsonRequired]
        public long InvoiceId { get; set; }

        #endregion
    }
}

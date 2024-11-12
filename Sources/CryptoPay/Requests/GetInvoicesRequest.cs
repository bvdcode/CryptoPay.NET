using CryptoPay.Types;
using CryptoPay.Requests.Base;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoPay.Requests
{
    /// <summary>
    /// Use this class to get <see cref="Invoices"/> request.
    /// </summary>
    internal class GetInvoicesRequest : ParameterlessRequest<Invoices>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new request to get <see cref="Invoices"/>
        /// </summary>
        /// <param name="assets">Optional. Currency codes. Supported assets: <see cref="Assets" /></param>
        /// <param name="invoiceIds">Optional. Invoice IDs.</param>
        /// <param name="status">Optional. Status of invoices to be returned. Available statuses: <see cref="InvoiceStatus.Active"/> and <see cref="InvoiceStatus.Paid"/>. Defaults to all statuses.</param>
        /// <param name="offset">Optional. Offset needed to return a specific subset of invoices. Default is 0.</param>
        /// <param name="count">Optional. Number of invoices to be returned. Values between 1-1000 are accepted. Defaults to 100.</param>
        public GetInvoicesRequest(
            IEnumerable<string>? assets = null,
            IEnumerable<long>? invoiceIds = null,
            InvoiceStatus? status = default,
            int offset = 0,
            int count = 100)
            : base("getInvoices")
        {
            Assets = assets;
            InvoiceIds = invoiceIds;
            Status = status;
            Offset = offset;
            Count = count;
        }

        #endregion

        /// <summary>
        /// Optional. Currency codes.
        /// Supported assets: <see cref="Assets"/>.
        /// Defaults to all assets.
        /// </summary>
        public IEnumerable<string>? Assets { get; set; }

        /// <summary>
        /// Optional. Invoice IDs.
        /// </summary>
        public IEnumerable<long>? InvoiceIds { get; set; }

        /// <summary>
        /// Optional. Status of invoices to be returned. Available statuses: <see cref="InvoiceStatus"/>.
        /// Defaults to all statuses.
        /// </summary>
        public InvoiceStatus? Status { get; set; }

        /// <summary>
        /// Optional. Offset needed to return a specific subset of invoices.
        /// Default is 0.
        /// </summary>
        [JsonRequired]
        public int Offset { get; set; }

        /// <summary>
        /// Optional. Number of invoices to be returned. Values between 1-1000 are accepted.
        /// Defaults to 100.
        /// </summary>
        [JsonRequired]
        public int Count { get; set; }
    }
}

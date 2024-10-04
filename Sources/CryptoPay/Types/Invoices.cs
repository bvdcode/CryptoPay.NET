using System.Collections.Generic;
using System.Linq;

namespace CryptoPay.Types
{
    /// <summary>
    /// List of <see cref="Invoice"/>. You can get invoices use <see cref="CryptoPay.CryptoPayExtensions.GetInvoicesAsync"/>
    /// </summary>
    public sealed class Invoices
    {
        /// <summary>
        /// List of <see cref="Invoice"/>.
        /// </summary>
        public IEnumerable<Invoice> Items { get; set; } = Enumerable.Empty<Invoice>();
    }
}
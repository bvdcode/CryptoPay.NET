using System;
using System.Text;
using CryptoPay.Types;
using System.Security.Cryptography;

namespace CryptoPay
{
    /// <summary>
    /// Helper for main <see cref="CryptoPayClient"/>.
    /// </summary>
    public static class CryptoPayHelper
    {
        /// <summary>
        /// This method verify the integrity of the received data.
        /// </summary>
        /// <param name="signature">Sting from header parameter <c>crypto-pay-api-signature</c>.</param>
        /// <param name="token">Your application token from CryptoPay.</param>
        /// <param name="body">Response <see cref="Update">body</see>.</param>
        /// <returns><c>true</c> if the header parameter crypto-pay-api-signature equals hash of request body.</returns>
        public static bool CheckSignature(string signature, string token, Update body)
        {
            using var sha256Hash = SHA256.Create();
            byte[] secret = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(token));
            using var hmac = new HMACSHA256(secret);
            byte[] checkString = Encoding.UTF8.GetBytes(body.ToString());
            byte[] hash = hmac.ComputeHash(checkString);
            string hashHex = BitConverter.ToString(hash).Replace("-", "").ToLower();
            return hashHex == signature;
        }
    }
}

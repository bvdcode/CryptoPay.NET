using System;
using CryptoPay.Types;
using CryptoPay.Requests.Base;
using System.Text.Json.Serialization;

namespace CryptoPay.Requests
{
    /// <summary>
    ///  Use this request to get application statistics. On success, returns <see cref="AppStats"/>.
    /// </summary>
    public class GetStatsRequest : ParameterlessRequest<AppStats>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new request to get <see cref="AppStats">application</see> statistics.
        /// </summary>
        /// <param name="startAt"></param>
        /// <param name="endAt"></param>
        public GetStatsRequest(
            DateTime? startAt,
            DateTime? endAt)
            : base("getStats")
        {
            var dt = DateTime.UtcNow;
            this.StartAt = startAt ?? dt.AddHours(-24);
            this.EndAt = endAt ?? dt;
        }

        #endregion

        #region Public Fields

        /// <summary>
        /// Optional. Date from which start calculating statistics in ISO 8601 format. Defaults is current date minus 24 hours.
        /// </summary>
        [JsonRequired]
        public DateTime StartAt { get; set; }

        /// <summary>
        /// Optional. The date on which to finish calculating statistics in ISO 8601 format. Defaults is current date.
        /// </summary>
        [JsonRequired]
        public DateTime EndAt { get; set; }

        #endregion
    }
}

using System;
using System.Net;
using CryptoPay.Requests;
using CryptoPay.Types;
using Xunit;

namespace CryptoPay.Tests.TestData;

public class GetStatsData : TheoryData<HttpStatusCode, Error?, GetStatsRequest>
{
    public GetStatsData()
    {
        this.Add(
            default,
            default,
            new GetStatsRequest(default, default)
        );

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "INTERVAL_TOO_BIG"),
            new GetStatsRequest(
                DateTime.UtcNow.AddYears(-3),
                DateTime.UtcNow.AddMonths(-3))
        );

        this.Add(
            default,
            default,
            new GetStatsRequest(
                DateTime.UtcNow.AddYears(-2),
                DateTime.UtcNow.AddYears(-1))
        );
    }
}
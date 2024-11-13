using Xunit;
using System.Net;
using CryptoPay.Types;

namespace CryptoPay.Tests.TestData;

public class CryptoPayClientData : TheoryData<HttpStatusCode?, Error?, string?, string?>
{
    public CryptoPayClientData()
    {
        Add(default, default, default, default);
        Add(default, default, CryptoPayTestHelper.Token, CryptoPayTestHelper.ApiUrl);
        Add(HttpStatusCode.Unauthorized,
            new Error(401, "UNAUTHORIZED"),
            CryptoPayTestHelper.Token + "abc",
            CryptoPayTestHelper.ApiUrl);
        Add(HttpStatusCode.MethodNotAllowed,
            new Error(405, "METHOD_NOT_FOUND"),
            CryptoPayTestHelper.Token,
            CryptoPayTestHelper.ApiUrl + "abc");
    }
}
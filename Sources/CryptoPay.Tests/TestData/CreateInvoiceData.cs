using System.Net;
using CryptoPay.Requests;
using CryptoPay.Types;
using Xunit;

namespace CryptoPay.Tests.TestData;

public class CreateInvoiceData : TheoryData<HttpStatusCode, Error?, CreateInvoiceRequest>
{
    public CreateInvoiceData()
    {
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                5.105,
                asset: Assets.TON.ToString())
        );
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                1.105,
                CurrencyTypes.fiat,
                fiat: Assets.USD.ToString())
        );
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                5.105,
                asset: Assets.TON.ToString(),
                description: "description",
                hiddenMessage: "hiddenMessage",
                paidBtnName: PaidButtonName.Callback,
                paidBtnUrl: "https://t.me/paidBtnUrl",
                payload: "payload",
                allowComments: false,
                allowAnonymous: false,
                expiresIn: 1800)
        );
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                2.35,
                CurrencyTypes.fiat,
                default,
                Assets.EUR.ToString(),
                default,
                "description",
                "hiddenMessage",
                PaidButtonName.Callback,
                "https://t.me/paidBtnUrl",
                "payload",
                true,
                false,
                360)
        );

        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                0.0234,
                CurrencyTypes.crypto,
                Assets.BNB.ToString(),
                default,
                default,
                "description",
                "hiddenMessage",
                PaidButtonName.Callback,
                "https://t.me/paidBtnUrl",
                "payload",
                true,
                false,
                360)
        );
        
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                1.23,
                CurrencyTypes.fiat,
                default,
                Assets.EUR.ToString(),
                new []{ Assets.TON.ToString(), Assets.USDT.ToString() },
                "description",
                "hiddenMessage")
        );

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "PAID_BTN_URL_REQUIRED"),
            new CreateInvoiceRequest(
                0.105,
                asset: Assets.TON.ToString(),
                paidBtnName: PaidButtonName.Callback)
        );
        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "UNSUPPORTED_ASSET"),
            new CreateInvoiceRequest(
                0.123,
                asset: "FFF",
                paidBtnName: PaidButtonName.Callback)
        );
    }
}
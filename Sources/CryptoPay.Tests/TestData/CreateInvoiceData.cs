﻿using System.Net;
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
                CurrencyType.Fiat,
                fiat: Assets.USD.ToString())
        );
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                0.205,
                asset: Assets.USDT.ToString(),
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
                CurrencyType.Fiat,
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
                CurrencyType.Crypto,
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
                CurrencyType.Fiat,
                default,
                Assets.EUR.ToString(),
                [Assets.TON.ToString(), Assets.USDT.ToString()],
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
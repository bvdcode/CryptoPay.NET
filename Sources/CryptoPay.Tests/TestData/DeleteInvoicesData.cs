﻿using System.Net;
using CryptoPay.Requests;
using CryptoPay.Types;
using Xunit;

namespace CryptoPay.Tests.TestData;

public class DeleteInvoicesData : TheoryData<HttpStatusCode, Error?, CreateInvoiceRequest>
{
    public DeleteInvoicesData()
    {
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
                allowAnonymous: false, expiresIn: 1800)
        );

        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                2.35,
                currencyType: CurrencyType.Fiat,
                asset: default,
                fiat: Assets.EUR.ToString(),
                acceptedAssets: default,
                description: "description",
                hiddenMessage: "hiddenMessage",
                paidBtnName: PaidButtonName.Callback,
                paidBtnUrl: "https://t.me/paidBtnUrl",
                payload: "payload",
                allowComments: true,
                allowAnonymous: false,
                expiresIn: 360)
        );
    }
}
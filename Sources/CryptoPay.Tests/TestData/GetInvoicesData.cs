﻿using System.Collections.Generic;
using System.Net;
using CryptoPay.Types;
using Xunit;

namespace CryptoPay.Tests.TestData;

public class GetInvoicesData
    : TheoryData<
        HttpStatusCode,
        Error?,
        IList<string>?, // assets
        IList<long>?, // invoiceIds
        InvoiceStatus?, //status
        int, // offset 
        int> // count
{
    public GetInvoicesData()
    {
        this.Add(default, default, default, default, default, 0, 100);
        this.Add(default, default, default, default, default, 10, 100);
        this.Add(default, default, default, default, InvoiceStatus.Paid, 0, 10);
        this.Add(
            default,
            default,
            new List<string>(),
            default,
            InvoiceStatus.Active,
            5,
            15
        );
        this.Add(
            default,
            default,
            new List<string>
            {
                Assets.TON.ToString(),
                Assets.BNB.ToString()
            },
            default,
            InvoiceStatus.Active,
            0,
            10
        );
        this.Add(
            default,
            default,
            default,
            new List<long>()
            {
                00000,
                11111
            },
            default,
            0,
            100
        );
        this.Add(
            HttpStatusCode.InternalServerError,
            new Error(500, "APP_ERROR"),
            default,
            default,
            default,
            -10,
            100
        );
        this.Add(
            HttpStatusCode.InternalServerError,
            new Error(500, "APP_ERROR"),
            default,
            default,
            default,
            5,
            -30
        );
    }
}
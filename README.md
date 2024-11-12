[![GitHub](https://img.shields.io/github/license/bvdcode/CryptoPay.NET)](https://github.com/bvdcode/CryptoPay.NET/blob/main/LICENSE.md)
[![Nuget](https://img.shields.io/nuget/dt/CryptoPay.NET?color=%239100ff)](https://www.nuget.org/packages/CryptoPay.NET/)
[![Static Badge](https://img.shields.io/badge/fuget-f88445?logo=readme&logoColor=white)](https://www.fuget.org/packages/CryptoPay.NET)
[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/bvdcode/CryptoPay.NET/.github%2Fworkflows%2Fpublish-release.yml)](https://github.com/bvdcode/CryptoPay.NET/actions)
[![NuGet version (CryptoPay.NET)](https://img.shields.io/nuget/v/CryptoPay.NET.svg?label=stable)](https://www.nuget.org/packages/CryptoPay.NET/)
[![CodeFactor](https://www.codefactor.io/repository/github/bvdcode/CryptoPay.NET/badge)](https://www.codefactor.io/repository/github/bvdcode/CryptoPay.NET)
![GitHub repo size](https://img.shields.io/github/repo-size/bvdcode/CryptoPay.NET)


# CryptoPay.NET

.NET Standard cryptocurrency payment library for Telegram bot @cryptobot.


> **Note:** This repository was cloned because the original author irresponsibly corrupted his code.


# Code Example

```csharp
var client = new CryptoPayClient(apiKey);

var invoice = await cryptoPayClient.CreateInvoiceAsync(
    Assets.BNB,
    1.505,
    description: "test",
    paid_btn_name: PaidButtonNames.viewItem,
    paid_btn_url: "https://example.com/success",
    cancellationToken: cancellationToken);
```

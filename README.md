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


# Usage

1. Install the [NuGet package](https://www.nuget.org/packages/CryptoPay.NET/):

```bash
dotnet add package CryptoPay.NET
```

2. Create a new instance of the `CryptoPayClient` class:

```csharp
const string apiKey = "your-api-key";
var client = new CryptoPayClient(apiKey);
// or with custom base URL
var client = new CryptoPayClient(apiKey, apiUrl: "https://testnet-pay.crypt.bot/");
```

3. Create an invoice

```csharp
var invoice = await client.CreateInvoiceAsync(
    Assets.BNB,
    1.1,
    description: "test",
    paid_btn_name: PaidButtonNames.viewItem,
    paid_btn_url: "https://example.com/success",
    cancellationToken: cancellationToken);
```

4. Get an invoice and handle the payment

```csharp
while (true)
{
    var invoices = await client.GetInvoicesAsync(invoiceIds: new[] { invoice.Id });
    var invoice = invoices.Items.FirstOrDefault();
    if (invoice == null)
    {
        continue;
    }
    if (invoice.Status == CryptoPay.Types.Statuses.paid)
    {
        // Invoice is paid
        HandlePaidInvoice(invoice);
        break;
    }
    await Task.Delay(1000);
}

void HandlePaidInvoice(Invoice invoice)
{
    // Handle paid invoice
}
```


# License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/bvdcode/CryptoPay.NET/blob/main/LICENSE.md) file for details.

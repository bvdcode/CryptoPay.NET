using System;

namespace CryptoPay.Tests;

public static class DateTimeExtensions
{
    public static bool IsCloseTo(this DateTime dateTime, DateTime otherDateTime, TimeSpan tolerance)
        => Math.Abs((dateTime - otherDateTime).TotalMilliseconds) <= tolerance.TotalMilliseconds;
}
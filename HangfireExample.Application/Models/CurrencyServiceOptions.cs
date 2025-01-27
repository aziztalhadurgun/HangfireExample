namespace HangfireExample.Application.Models;

public sealed record CurrencyServiceOptions
{
    public required string Address { get; init; }
    public int TimeoutSeconds { get; init; }
}
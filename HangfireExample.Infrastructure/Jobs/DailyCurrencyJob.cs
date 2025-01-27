using System.Net;
using HangfireExample.Application.Interfaces;
using HangfireExample.Application.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HangfireExample.Infrastructure.Jobs;

public class DailyCurrencyJob(ILogger<DailyCurrencyJob> logger, IOptions<CurrencyServiceOptions> options) : IJob
{
    private readonly ILogger<DailyCurrencyJob> _logger = logger;
    private readonly CurrencyServiceOptions _options = options.Value;

    public async Task Execute()
    {
        try
        {
            string address = $"{_options.Address}/Currency/FetchAndSaveCurrencies"; 

            using var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(address, null);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError("Currency service request failed with status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Currency service request failed with status code: {response.StatusCode}");
            }

            _logger.LogInformation("Currency service request completed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while executing DailyCurrencyJob");
            throw;
        }
    }
}

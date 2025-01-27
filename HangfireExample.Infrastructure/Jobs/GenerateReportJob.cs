using HangfireExample.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace HangfireExample.Infrastructure.Jobs;

public sealed class GenerateReportJob(ILogger<GenerateReportJob> logger) : IJob
{
    private readonly ILogger<GenerateReportJob> _logger = logger;

    public async Task Execute()
    {
        _logger.LogInformation("Rapor oluşturma işlemi başladı - {time}", DateTime.Now);

        await GenerateReport();

        _logger.LogInformation("Rapor oluşturma işlemi tamamlandı - {time}", DateTime.Now);
    }

    private static Task GenerateReport()
    {    
        Console.WriteLine("GenerateReportJob: Rapor oluşturuldu.");
        return Task.CompletedTask;
    }
}

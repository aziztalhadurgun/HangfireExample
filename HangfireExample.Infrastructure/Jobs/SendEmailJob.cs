using HangfireExample.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace HangfireExample.Infrastructure.Jobs;

public sealed class SendEmailJob(ILogger<SendEmailJob> logger) : IJob
{
    private readonly ILogger<SendEmailJob> _logger = logger;

    public async Task Execute()
    {
        _logger.LogInformation("E-posta gönderme işlemi başladı - {time}", DateTime.Now);

        await GenerateReport();

        _logger.LogInformation("E-posta gönderme işlemi tamamlandı - {time}", DateTime.Now);
    }

    private static Task GenerateReport()
    {    
        Console.WriteLine("SendEmailJob: E-posta gönderildi.");
        return Task.CompletedTask;
    }
}

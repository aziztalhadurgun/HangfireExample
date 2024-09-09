namespace HangfireExample.Core.Jobs;

public class GenerateReportJob : IJob
{
    public void Execute()
    {
        Console.WriteLine("GenerateReportJob: Rapor oluşturuldu.");
    }
}
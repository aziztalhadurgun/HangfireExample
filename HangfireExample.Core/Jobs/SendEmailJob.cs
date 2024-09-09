namespace HangfireExample.Core.Jobs;

public class SendEmailJob : IJob
{
    public void Execute()
    {
        Console.WriteLine("SendEmailJob: E-posta gönderildi.");
    }
}

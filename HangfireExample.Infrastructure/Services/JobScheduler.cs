using Hangfire;
using HangfireExample.Application.Interfaces;
using HangfireExample.Core.Jobs;

namespace HangfireExample.Infrastructure.Services;

public class JobScheduler : IJobScheduler
{
    public void EnqueueJob<T>() where T : IJob
    {
        BackgroundJob.Enqueue<T>(job => job.Execute());
    }

    public void ScheduleJob<T>(TimeSpan delay) where T : IJob
    {
        BackgroundJob.Schedule<T>(job => job.Execute(), delay);
    }

    public void AddRecurringJob<T>(string cronExpression) where T : IJob
    {
        RecurringJob.AddOrUpdate<T>("recurring-job", job => job.Execute(), cronExpression);
    }

    public void AddContinuationJob<TParent, TContinuation>() where TParent : IJob where TContinuation : IJob
    {
        var parentJobId = BackgroundJob.Enqueue<TParent>(job => job.Execute());
        BackgroundJob.ContinueJobWith<TContinuation>(parentJobId, job => job.Execute());
    }
}
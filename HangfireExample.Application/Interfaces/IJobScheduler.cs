using HangfireExample.Core.Jobs;

namespace HangfireExample.Application.Interfaces;

public interface IJobScheduler
{
    void EnqueueJob<T>() where T : IJob;
    void ScheduleJob<T>(TimeSpan delay) where T : IJob;
    void AddRecurringJob<T>(string cronExpression) where T : IJob;
    void AddContinuationJob<TParent, TContinuation>() where TParent : IJob where TContinuation : IJob;
}

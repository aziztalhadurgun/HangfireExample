using HangfireExample.Application.Interfaces;
using HangfireExample.Infrastructure.Jobs;
using Microsoft.AspNetCore.Mvc;


namespace HangfireExample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController(IJobScheduler _jobScheduler) : ControllerBase
{

    [HttpPost("enqueue")]
    public IActionResult EnqueueJob()
    {
        _jobScheduler.EnqueueJob<SendEmailJob>();
        return Ok("Job enqueued.");
    }

    [HttpPost("DailyCurrencyJob")]
    public IActionResult DailyCurrencyJob()
    {
        _jobScheduler.EnqueueJob<DailyCurrencyJob>();
        return Ok("Job enqueued.");
    }

    [HttpPost("schedule")]
    public IActionResult ScheduleJob([FromQuery] int delayInMinutes)
    {
        _jobScheduler.ScheduleJob<SendEmailJob>(TimeSpan.FromMinutes(delayInMinutes));
        return Ok($"Job scheduled to run after {delayInMinutes} minutes.");
    }

    [HttpPost("recurring")]
    public IActionResult AddRecurringJob([FromQuery] string cronExpression)
    {
        _jobScheduler.AddRecurringJob<GenerateReportJob>("GenerateReportJob",cronExpression);
        return Ok("Recurring job added.");
    }

    [HttpPost("continuation")]
    public IActionResult AddContinuationJob()
    {
        _jobScheduler.AddContinuationJob<GenerateReportJob, SendEmailJob>();
        return Ok("Continuation job added: GenerateReportJob -> SendEmailJob.");
    }


    [HttpPost("DailyCurrencyRecurringJob")]
    public IActionResult DailyCurrencyRecurringJob([FromQuery]string jobName, string cronExpression)
    {
        _jobScheduler.AddRecurringJob<DailyCurrencyJob>(jobName, cronExpression);
        return Ok("Recurring job added.");
    }

    [HttpPost("HourlyCurrencyRecurringJob")]
    public IActionResult HourlyCurrencyRecurringJob([FromQuery]string jobName, string cronExpression)
    {
        _jobScheduler.AddRecurringJob<HourlyCurrencyJob>(jobName, cronExpression);
        return Ok("Recurring job added.");
    }

}

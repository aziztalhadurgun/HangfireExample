using HangfireExample.Application.Interfaces;
using HangfireExample.Core.Jobs;
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

    [HttpPost("schedule")]
    public IActionResult ScheduleJob([FromQuery] int delayInMinutes)
    {
        _jobScheduler.ScheduleJob<SendEmailJob>(TimeSpan.FromMinutes(delayInMinutes));
        return Ok($"Job scheduled to run after {delayInMinutes} minutes.");
    }

    [HttpPost("recurring")]
    public IActionResult AddRecurringJob([FromQuery] string cronExpression)
    {
        _jobScheduler.AddRecurringJob<GenerateReportJob>(cronExpression);
        return Ok("Recurring job added.");
    }

    [HttpPost("continuation")]
    public IActionResult AddContinuationJob()
    {
        _jobScheduler.AddContinuationJob<GenerateReportJob, SendEmailJob>();
        return Ok("Continuation job added: GenerateReportJob -> SendEmailJob.");
    }
}

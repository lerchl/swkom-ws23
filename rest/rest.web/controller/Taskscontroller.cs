using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Rest.Web.Model;

namespace Rest.Web.Controllers;

[ApiController]
[Route("/api")]
public class TasksController : ControllerBase
{
    private readonly ILogger<TasksController> _logger;

    public TasksController(ILogger<TasksController> logger)
    {
        _logger = logger;
    }

    [HttpGet("tasks")]
    public IActionResult GetTasks()
    {
        Random rand = new Random();
        int count = 10;

        return Ok(Builder<Model.Task>.CreateListOfSize(count)
                        .All()
                        .With(p => p.Type = Model.TaskType.file)
                        .With(p => p.DateCreated = DateTimeOffset.Now.AddDays(rand.Next(-10, 0)))
                        .With(p => p.DateDone = DateTimeOffset.Now.AddDays(rand.Next(-10, 0)))
                        .Build());
    }

    [HttpPost("acknowledge_tasks")]
    public IActionResult AckTasks([FromBody] AckTasksRequest task)
    {
        _logger.LogInformation($"Acknowledge tasks: {string.Join(", ", task.Tasks)}");
        return Ok();
    }
}


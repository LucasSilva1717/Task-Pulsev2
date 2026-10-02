using MediatR;
using TaskPulse.Application.UseCases.Tasks.CreateTask;
using TaskPulse.Application.UseCases.Tasks.Query;

namespace TaskPulse.Api;

public static class TaskEndpoints
{
    public static RouteGroupBuilder MapTaskEndpoints(this WebApplication app)
    {
        var tasksGroup = app.MapGroup("/api/tasks")
                            .WithTags("Tasks");

        tasksGroup.MapPost("/", async (CreateTaskCommand command, ISender sender) =>
        {
            var taskId = await sender.Send(command);

            return Results.Created($"/api/tasks/{taskId}", new { id = taskId, message = "Tarefa criada com sucesso!" });
        })
        .WithName("CreateTask")
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

        tasksGroup.MapGet("/", async (ISender sender) =>
        {
            var tasks = await sender.Send(new GetTasksQuery());
            return Results.Ok(tasks);
        })
        .WithName("GetTasks")
        .Produces<IEnumerable<TaskDto>>(StatusCodes.Status200OK);

        return tasksGroup;
    }
}

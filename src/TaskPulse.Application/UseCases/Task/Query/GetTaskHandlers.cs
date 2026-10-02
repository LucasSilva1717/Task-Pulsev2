using MediatR;
using TaskPulse.Domain.Repositories;

namespace TaskPulse.Application.UseCases.Tasks.Query;

public record GetTasksQuery : IRequest<IEnumerable<TaskDto>>;

public record TaskDto(Guid Id, string Title, string? Description, int Priority, int State, DateTime CreatedAt);

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<TaskDto>>
{
    private readonly ITaskRepository _taskRepository;

    public GetTasksQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAllAsync(cancellationToken);

        return tasks.Select(t => new TaskDto(
            t.Id,
            t.Title,
            t.Description,
            (int)t.Priority,
            (int)t.State,
            t.CreatedAt
        ));
    }
}

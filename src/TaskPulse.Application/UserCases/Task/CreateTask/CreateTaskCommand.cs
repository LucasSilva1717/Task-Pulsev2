using MediatR;
using TaskPulse.Domain.Enums;

namespace TaskPulse.Application.UseCases.Tasks.CreateTask;

public record CreateTaskCommand(
    string Title,
    string Description,
    TaskPriority Priority,
    Guid ProjectId
) : IRequest<Guid>;
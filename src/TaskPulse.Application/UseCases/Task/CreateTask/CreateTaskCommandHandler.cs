using MediatR;
using TaskPulse.Domain.Enums;
using TaskPulse.Domain.Entities;
using TaskPulse.Domain.Exceptions;
using TaskPulse.Domain.Repositories;

namespace TaskPulse.Application.UseCases.Tasks.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(
        ITaskRepository taskRepository,
        IProjectRepository projectRepository,
        IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.ProjectId, cancellationToken);
        if (project is null)
        {
            throw new DomainException("Projeto não encontrado.");
        }

        var task = new TaskItem(
            request.Title,
            request.Description,
            request.Priority,
            TaskState.Pending,
            request.ProjectId,
            null
        );

        await _taskRepository.AddAsync(task, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return task.Id;
    }
}
using TaskPulse.Domain.Enums;

namespace TaskPulse.Domain.Entities;

public class TaskItem
{
    public Guid Id {get; private set;}
    public string Title {get; private set;} = string.Empty;
    public string Description {get; private set;} = string.Empty;
    public TaskPriority Priority {get; private set;}
    public TaskState State {get; private set;}
    public Guid ProjectId {get; private set;}
    public Guid? AssignedUserId {get; private set;}
    public DateTime CreatedAt {get; private set;}
    public DateTime UpdatedAt {get; private set;}
    public DateTime? CompletedAt {get; private set;}

    public TaskItem (){}

    public TaskItem (string title, string description, TaskPriority priority, TaskState state, Guid projectId, Guid? AssignedUserId)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new DomainException("O título da tarefa não pode ser vazio.");
        }

        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Priority = priority;
        State = state;
        ProjectId = projectId;
        AssignedUserId = AssignedUserId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateStatus(TaskState newState)
    {
        State = newState;
        if (newState == TaskState.Completed)
        {
            CompletedAt = DateTime.UtcNow;
        }
    }
    public void AssignUser(Guid userId)
    {
        AssignedUserId = userId;
    }
}

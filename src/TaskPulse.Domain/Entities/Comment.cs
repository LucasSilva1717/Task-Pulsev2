using TaskPulse.Domain.Exceptions;

namespace TaskPulse.Domain.Entities;

public class Comment
{
    public Guid Id { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public Guid TaskId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public Comment() { }   

    public Comment(String name, String content, Guid taskId, Guid userId)
    {
        if (String.IsNullOrWhiteSpace(content))
        {
            throw new DomainException("O conteúdo do comentário não pode ser vazio.");
        }

    Id = Guid.NewGuid();
    Content = content;
    TaskId = taskId;
    UserId = userId;
    CreatedAt = DateTime.UtcNow;
    UpdatedAt = DateTime.UtcNow;
    }
}
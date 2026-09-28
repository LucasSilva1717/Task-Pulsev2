using TaskPulse.Domain.Exceptions;

namespace TaskPulse.Domain.Entities;

public class Project
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Guid OwnerId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public Project() { }

    public Project(string name, string description, Guid ownerId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("O nome do projeto não pode ser vazio.");
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new DomainException("A descrição do projeto não pode ser vazia.");
        }
        if (ownerId == Guid.Empty)
        {
            throw new DomainException("O proprietário do projeto não pode ser vazio.");
        }

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        OwnerId = ownerId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}

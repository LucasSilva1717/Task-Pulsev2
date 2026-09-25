namespace TaskPulse.Domain.Entities;

public class User
{
    public Guid Id {get; private set;}
    public string Name {get; private set;} = string.Empty;
    public string Email {get; private set;} = string.Empty;
    public string PasswordHash {get; private set;} = string.Empty;
    public DateTime CreatedAt {get; private set;}

    public User (){}

    public User (String name, String email, String passwordHash)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
    }
}


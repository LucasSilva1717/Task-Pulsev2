using Microsoft.EntityFrameworkCore;
using TaskPulse.Domain.Entities;
using TaskPulse.Domain.Repositories;

namespace TaskPulse.Infrastructure.Persistence;

public class AppDbContext : DbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Comment> Comments => Set<Comment>();

    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        var affectedRows = await SaveChangesAsync(cancellationToken);
        return affectedRows > 0;
    }
}
using Microsoft.EntityFrameworkCore;
using TaskPulse.Domain.Entities; 

namespace TaskPulse.Application.Common.Interface;

public interface IAppDbContext
{
    DbSet<TaskItem> Tasks { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
using Microsoft.EntityFrameworkCore;
using TaskPulse.Infrastructure.Repositories; // Ajustar o namespace conforme a sua pasta
using TaskPulse.Domain.Entities;
using TaskPulse.Domain.Repositories;
using TaskPulse.Infrastructure.Persistence;

namespace TaskPulse.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user, cancellationToken);
    }
    
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
    return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
}
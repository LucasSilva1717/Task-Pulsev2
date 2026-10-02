using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskPulse.Application.DTOs;
using TaskPulse.Application.Common.Interface;

public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskResponseDto?>
{
    private readonly IAppDbContext _context;

    public GetTaskByIdHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskResponseDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == request.id, cancellationToken);

        if (task == null) return null;

        return new TaskResponseDto(task.Id, task.Title, task.Description);
    }
}


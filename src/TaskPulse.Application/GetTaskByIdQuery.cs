using MediatR;
using TaskPulse.Application.DTOs;

public record GetTaskByIdQuery(Guid id) : IRequest <TaskResponseDto?>
{

}
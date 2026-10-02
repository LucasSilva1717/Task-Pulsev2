namespace TaskPulse.Application.DTOs;

public record TaskResponseDto(Guid Id, string Title, string? Description);
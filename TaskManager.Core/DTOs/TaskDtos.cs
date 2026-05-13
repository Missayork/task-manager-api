namespace TaskManager.Core.DTOs;

public record CreateTaskDto(
    string Title,
    string? Description,
    DateTime? DueDate,
    int Priority = 1
);

public record UpdateTaskDto(
    string Title,
    string? Description,
    bool IsCompleted,
    DateTime? DueDate,
    int Priority
);

public record TaskResponseDto(
    int Id,
    string Title,
    string? Description,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? DueDate,
    string Priority
);
using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.DTOs;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repo;

    public TasksController(ITaskRepository repo) => _repo = repo;

    /// GET api/tasks — obtener todas las tareas
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] bool? completed)
    {
        var tasks = completed.HasValue
            ? await _repo.GetByStatusAsync(completed.Value)
            : await _repo.GetAllAsync();

        var response = tasks.Select(ToDto);
        return Ok(response);
    }

    /// GET api/tasks/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _repo.GetByIdAsync(id);
        return task is null ? NotFound() : Ok(ToDto(task));
    }

    /// POST api/tasks
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            return BadRequest("Title is required");

        var task = new TaskItem
        {
            Title       = dto.Title,
            Description = dto.Description,
            DueDate     = dto.DueDate,
            Priority    = (Priority)dto.Priority
        };

        var created = await _repo.CreateAsync(task);
        return CreatedAtAction(nameof(GetById),
            new { id = created.Id }, ToDto(created));
    }

    /// PUT api/tasks/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskDto dto)
    {
        var updated = await _repo.UpdateAsync(id, new TaskItem
        {
            Title       = dto.Title,
            Description = dto.Description,
            IsCompleted = dto.IsCompleted,
            DueDate     = dto.DueDate,
            Priority    = (Priority)dto.Priority
        });

        return updated is null ? NotFound() : Ok(ToDto(updated));
    }

    /// DELETE api/tasks/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repo.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }

    private static TaskResponseDto ToDto(TaskItem t) => new(
        t.Id, t.Title, t.Description, t.IsCompleted,
        t.CreatedAt, t.DueDate, t.Priority.ToString()
    );
}
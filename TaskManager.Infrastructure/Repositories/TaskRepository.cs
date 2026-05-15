using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _ctx;
    public TaskRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<IEnumerable<TaskItem>> GetAllAsync() =>
        await _ctx.Tasks.AsNoTracking().ToListAsync();

    public async Task<TaskItem?> GetByIdAsync(int id) =>
        await _ctx.Tasks.FindAsync(id);

    public async Task<TaskItem> CreateAsync(TaskItem task)
    {
        _ctx.Tasks.Add(task);
        await _ctx.SaveChangesAsync();
        return task;
    }

    public async Task<TaskItem?> UpdateAsync(int id, TaskItem task)
    {
        var existing = await _ctx.Tasks.FindAsync(id);
        if (existing is null) return null;

        existing.Title = task.Title;
        existing.Description = task.Description;
        existing.IsCompleted = task.IsCompleted;
        existing.DueDate = task.DueDate;
        existing.Priority = task.Priority;

        await _ctx.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _ctx.Tasks.FindAsync(id);
        if (task is null) return false;
        _ctx.Tasks.Remove(task);
        await _ctx.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<TaskItem>> GetByStatusAsync(bool isCompleted) =>
        await _ctx.Tasks
            .Where(t => t.IsCompleted == isCompleted)
            .AsNoTracking()
            .ToListAsync();
}

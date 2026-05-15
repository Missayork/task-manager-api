using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Interfaces;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() {
        Title = "Task Manager API",
        Version = "v1",
        Description = "REST API para gestión de tareas — Edgar Hernandez"
    });
});

// Base de datos SQLite
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=taskmanager.db"));

// Dependency Injection
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

// Crear DB automáticamente al iniciar
using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.EnsureCreated();

// Swagger siempre activo
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager API v1"));

app.MapControllers();
app.Run();
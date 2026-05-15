# 📋 Task Manager API

A RESTful API for task management built with **.NET 8**, **Entity Framework Core**, and **SQLite**.
Designed with Clean Architecture principles: separation between API, Core, and Infrastructure layers.

## 🚀 Features

- ✅ Full CRUD for tasks (Create, Read, Update, Delete)
- ✅ Filter tasks by completion status
- ✅ Task priorities (Low, Medium, High)
- ✅ Due date support
- ✅ Swagger/OpenAPI documentation
- ✅ Entity Framework Core with SQLite
- ✅ Clean Architecture (3-layer structure)
- ✅ Dependency Injection pattern
- ✅ Async/await throughout

## 🛠 Tech Stack

| Layer          | Technology                    |
|----------------|-------------------------------|
| API            | ASP.NET Core 9, Swagger       |
| Business Logic | C# Records, DTOs, Interfaces  |
| Data Access    | Entity Framework Core, SQLite |
| Architecture   | Clean Architecture, DI        |

## 📁 Project Structure

```
task-manager-api/
├── TaskManager.API/          # Controllers, Program.cs
├── TaskManager.Core/         # Entities, DTOs, Interfaces
└── TaskManager.Infrastructure/ # DbContext, Repositories
```

## ⚡ Getting Started

```bash
git clone https://github.com/Missayork/task-manager-api.git
cd task-manager-api
dotnet restore
cd TaskManager.API
dotnet run
```

Open http://localhost:5000/swagger to explore the API.

## 📡 API Endpoints

| Method | Endpoint              | Description              |
|--------|-----------------------|--------------------------|
| GET    | /api/tasks            | Get all tasks            |
| GET    | /api/tasks?completed=true | Get by status        |
| GET    | /api/tasks/{id}       | Get task by ID           |
| POST   | /api/tasks            | Create new task          |
| PUT    | /api/tasks/{id}       | Update task              |
| DELETE | /api/tasks/{id}       | Delete task              |

## 📝 Example Request

```json
POST /api/tasks
{
  "title": "Complete the project",
  "description": "Finish the Task Manager API",
  "dueDate": "2025-12-31",
  "priority": 2
}
```

## 👤 Author

**Edgar Hernandez** — Junior Software Developer
- LinkedIn: [linkedin.com/in/edgar-hernandezz](https://linkedin.com/in/edgar-hernandezz)
- GitHub: [@Missayork](https://github.com/Missayork)
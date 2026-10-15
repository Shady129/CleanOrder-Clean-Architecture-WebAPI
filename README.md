# CleanOrder — ASP.NET Core Web API with Clean Architecture

A small educational ASP.NET Core Web API project demonstrating how to organize an application using **Clean Architecture**.

The project focuses on separation of concerns, dependency inversion, business rules, and database operations.

## Technologies

- C# / .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Dependency Injection
- Swagger / OpenAPI

## Architecture

The solution is divided into four projects:

| Project | Responsibility |
|---|---|
| CleanOrder.Domain | Order entity, status enum, and business rules |
| CleanOrder.Application | Application services, repository interfaces, and DTOs |
| CleanOrder.Infrastructure | EF Core DbContext, repository implementation, and database migrations |
| CleanOrder.API | HTTP endpoints, dependency injection configuration, and exception-handling middleware |

The Domain layer is independent of the other layers. The Application layer defines the repository contract, which is implemented by Infrastructure.

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/Orders` | Create a new order |
| GET | `/api/Orders` | Retrieve all orders |
| GET | `/api/Orders/{id}` | Retrieve an order by ID |
| PUT | `/api/Orders/{id}/ship` | Ship an order |
| PUT | `/api/Orders/{id}/cancel` | Cancel an order |

## Business Rules

- New orders start with the `Pending` status.
- A cancelled order cannot be shipped.
- A shipped order cannot be cancelled.
- Order statuses are returned as readable strings in JSON responses.

## Additional Features

- DTO mapping for order responses
- Basic order ID validation
- Centralized exception handling using custom ASP.NET Core middleware
- Asynchronous repository operations
- Entity Framework Core migrations
- SQL Server integration

## Getting Started

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Configure a SQL Server connection string using ASP.NET Core User Secrets in the API project, under `ConnectionStrings:DefaultConnection`.
4. Apply the included Entity Framework Core migrations to create the database.
5. Run `CleanOrder.API`.
6. Use Swagger to explore and test the endpoints.

## Project Purpose

This project was built to practice Clean Architecture concepts through a small, working application rather than a production-scale order management system.

The primary goal is to understand the responsibilities of each layer, the direction of dependencies, and the flow of a request through an ASP.NET Core application.

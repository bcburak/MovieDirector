# MovieDirectorApp

MovieDirectorApp is a sample application built with .NET 8 and following Clean Architecture principles.
It is designed for managing movies and directors, using CQRS (Command Query Responsibility Segregation) and the MediatR library to handle request/response workflows.

# Project Structure (Layers)
1. API (MovieDirector.API)

Entry point of the project.

Contains Controllers.

Handles HTTP requests and delegates them to the proper Command/Query via MediatR.

Provides documentation through Swagger/OpenAPI.

2. Application

Contains business logic of the application.

Organized with CQRS: Commands and Queries.

Uses MediatR to connect requests to handlers.

Supports simple validation.

3. Domain

The core layer, containing Entities and domain rules.

Has no dependency on external frameworks – pure C# objects.

Example entities: Movie, Director.

4. Infrastructure

Responsible for database and third-party service integrations.

Contains MongoDB context and repository implementations.

Redis caching and other infrastructure services are defined here.

CQRS & MediatR Usage

The project follows the CQRS pattern:

Commands → Write operations (CreateMovieCommand, UpdateDirectorCommand, etc.)

Queries → Read operations (GetAllMoviesQuery, etc.)

All handled via MediatR, which provides:

Clean and thin controllers.

Centralized business logic.

Improved testability.

Added Global Exception Handling & Logging Middleware

NuGet Packages Used

MediatR → CQRS implementation

MongoDB.Driver → MongoDB database access

Swashbuckle.AspNetCore → Swagger/OpenAPI support

Microsoft.Extensions.Caching.StackExchangeRedis → Redis caching

xUnit → Unit testing framework

🚀 Running the Project
Development
dotnet build
dotnet run --project MovieDirector.API


API will be available at:
👉 https://localhost:5001/swagger

Docker

docker build -t moviedirectorapp .

docker run -d -p 8080:8080 moviedirectorapp


# Future Improvements

✅ Add advanced DTO & FluentValidation rules

✅ Implement Authentication & Authorization (JWT, IdentityServer, etc.)

✅ Extend Unit & Integration Tests

✅ Setup CI/CD pipelines (GitHub Actions, Azure DevOps, GitLab CI, etc.)

✅ To run with Redis Distributed, orchestrate two or more container with compose or Kubernates (GitHub Actions, Azure DevOps, GitLab CI, etc.)

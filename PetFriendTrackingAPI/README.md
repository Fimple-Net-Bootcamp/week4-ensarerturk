# Pet Friend Tracking API

This project includes an API for tracking pets. The API offers pet owners the possibility to manage information such as their pet's health status, activities, eating habits and social interactions.

## Getting started

You can follow the steps below to run the project.

#### Requirements

- .NET 5.0 SDK
- PostgreSQL
- Visual Studio Code or any popular IDE

#### Installation

1. Open the terminal in the project directory.
2. Build the project with `dotnet build` command.
3. Update the database with `dotnet ef database update` command.
4. Start the project with the `dotnet run` command.

## Project Structure

The project has the following main components:

- `Repositories`: Contains classes that perform database operations.
- `Services`: Contains service classes that focus on business logic.
- `Controllers`: Contains classes that manage API endpoints.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- PostgreSQL (Database)
- AutoMapper
- FluentValidation

## API Endpoints

- **/api/v1/activities**: Used for activity management.
- **/api/v1/foods**: Used for food management.
- **/api/v1/petanimals**: Used for pet management.
- **/api/v1/users**: Used for user management.
- **/api/v1/healthstatus**: Used for health status management.
- **/api/v1/trainings**: Used for training management.
- **/api/v1/socialinteractions**: Used for social interaction management.

## API Documentation

For API documentation, please visit [Swagger UI](/swagger).

## Contributing

1. Fork this repository.
2. Create a new feature branch: `git checkout -b new-feature`
3. Commit your changes: `git commit -m 'New feature added'`
4. Push your branch: `go push origin new-feature`
5. Create a Pull Request.
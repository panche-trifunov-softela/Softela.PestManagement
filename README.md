# Softela Pest Management

This repository contains the source code for the Softela Pest Management system, built with .NET 9 and C# 13.0.

## Projects

- **Softela.PestManagement.API**: ASP.NET Core Web API entry point.
- **Softela.PestManagement.Application**: Application layer, including commands, queries, and business logic.
- **Softela.PestManagement.Domain**: Domain entities and core models.
- **Softela.PestManagement.Infrastructure**: Database access, repositories, and migration scripts.

## Getting Started

1. **Clone the repository**
2. **Restore NuGet packages**
3. **Update connection strings in `appsettings.json`**
4. **Run database migrations**
5. **Start the API project**

## Database

- SQL Server
- Migration scripts located in `Softela.PestManagement.Infrastructure\Database\Scripts`

## Technologies

- .NET 9
- C# 13.0
- MediatR
- Dapper

## Contributing

Pull requests are welcome. For major changes, please open an issue first.

## License

Distributed under the MIT License.
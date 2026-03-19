# EmployeeCrud.API
A simple but professional end-to-end CRUD Web API demonstrating core backend development skills with .NET 8, C#, clean project structure, simple API key auth, Docker, basic Azure DevOps pipeline, and more.

## Features
- **.NET 8** & **C# 12**
- **ASP.NET Core Web API**: RESTful endpoints for Employee management (CRUD).
- **Entity Framework Core (InMemory)**: Used as a simple persistent store for development, easily interchangeable with SQL Server/Azure SQL.
- **API Key Authentication**: Simple custom header-based filter (`X-Api-Key`).
- **Health Checks**: Ready-to-use `/api/health` endpoint.
- **Logging**: Structured logging using **Serilog**.
- **Containerization**: Included `Dockerfile` and `.dockerignore`.
- **CI/CD**: Provided starting Azure DevOps YAML pipeline in `devops/azure-pipelines.yml` to deploy to an Azure App Service.
- **Testing**: Basic unit testing with xUnit.

## Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio / VS Code

## Getting Started
1. **Clone & Restore**
   ```bash
   git clone <repository_url>
   cd EmployeeCrud
   dotnet restore
   ```
2. **Run**
   ```bash
   cd EmployeeCrud.API
   dotnet run
   ```
3. **Use the API**
   Navigate to `http://localhost:5000/swagger` or `https://localhost:5001/swagger` to view the Swagger UI.
   Click "Authorize" and enter `SuperSecretApiKey123`. Try out the CRUD operations.

## Architecture
The API employs a typical N-Tier architecture logic:
- **Models**: EF Core Code-First entity `Employee.cs`.
- **Data**: The application EF `DbContext`.
- **Services**: `IEmployeeService` representing the business logic interface and its implementation isolating the Data access from the Controllers.
- **Controllers**: Thin API endpoints.
- **Authentication**: Contains the API auth filter middleware.

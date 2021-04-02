# About The Project

This project is being developed to conclude the course of analysis and systems development. This API is dedicated to serving the solution's front-end and is not concerned with integrations with other applications.<br><br>

# Getting Started

### 1. Install .NET 5.0

Make sure that .NET 5.0 is installed. If necessary, [download](https://dotnet.microsoft.com/download/dotnet/5.0) and [install](https://docs.microsoft.com/pt-br/dotnet/core/install/).

```sh
dotnet --list-sdks
```

### 2. Clone the repository
```sh
git clone https://github.com/alycecristines/restaurant-api.git
```

### 3. Run the application
```sh
setx ASPNETCORE_ENVIRONMENT "Production"
dotnet run --no-launch-profile -p restaurant-api/src/Restaurant.Api
```

### 4. Usage
The application can be used with any client api. The Swagger interface is also available at: `https://localhost:5001/swagger/index.html`.

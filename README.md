# About The Project

This project is being developed to conclude the course of analysis and systems development. This API is dedicated to serving the [solution's front-end](https://github.com/alycecristines/restaurant-front) and is not concerned with integrations with other applications.<br><br>

# Getting Started

### 1. Install .NET 5.0

Make sure that .NET 5.0 is installed. If necessary, [download](https://dotnet.microsoft.com/download/dotnet/5.0) and [install](https://docs.microsoft.com/pt-br/dotnet/core/install/).

```sh
dotnet --list-sdks
```

### 2. Install and configure MySQL Server

If necessary, visit the [official documentation](https://dev.mysql.com/doc/mysql-getting-started/en/) for help.

### 3. Clone the repository
```sh
git clone https://github.com/alycecristines/restaurant-api.git
```

### 4. Configure the application

Create an `appsettings.Production.json` file with the necessary settings following the same structure as the `appsettings.Development.json` file.

### 5. Run the application

```sh
sudo dotnet run -p src/Restaurant.Api --launch-profile Production
```

### 6. Usage
The application can be used with any client api. The Swagger interface is also available at: [`https://localhost/swagger`](https://localhost/swagger).

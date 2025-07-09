# Loan Management API
### A backend API for managing loans, built with ASP.NET Core 9, Entity Framework Core, and Docker.

## Tech Stack
* ASP.NET Core 9
* Entity Framework Core
* FluentValidation
* xUnit + Coverlet
* Docker + Docker Compose

## Run unit tests
`dotnet test --collect:"XPlat Code Coverage"`

## To generate a coverage report (optional):
* `dotnet tool install -g dotnet-reportgenerator-globaltool`

* `reportgenerator -reports:**/coverage.cobertura.xml -targetdir:coverage-report -reporttypes:Html`

## Running the Backend with Docker
Make sure Docker is installed and running.
From the root of the repository, run:

`docker-compose up --build`

# This will:

* Build and start the API on port 5001
* Start a SQL Server container on port 1433

# API Endpoint
Once running, you can test the API with:
`https://localhost:59731/swagger/index.html`
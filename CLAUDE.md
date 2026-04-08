# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**Moneito** is a financial advisor application built with .NET 10 and ASP.NET Core minimal APIs.

## Commands

```bash
# Build the solution
dotnet build api/Moneiro.slnx

# Run the API (HTTP on localhost:5040)
dotnet run --project api/MoneiroAPI

# Run with HTTPS (localhost:7026)
dotnet run --project api/MoneiroAPI --launch-profile https
```

There are currently no tests configured. When tests are added, they will likely use `dotnet test`.

## Architecture

The solution (`api/Moneiro.slnx`) contains a single project: `api/MoneiroAPI/`.

**Stack:**
- .NET 10 / ASP.NET Core minimal APIs
- `Microsoft.AspNetCore.OpenApi` for OpenAPI docs (served at `/openapi/v1.json` in Development)
- `api/Infra/compose.yml` — Docker Compose with Postgres 16 (user/pass/db: `moneiro`, port `5432`)

**Entry point:** `api/MoneiroAPI/Program.cs` — configures services and maps routes using top-level statements and minimal API style (no controllers).

**Configuration:**
- `appsettings.json` — production defaults
- `appsettings.Development.json` — development overrides
- `api/MoneiroAPI/Properties/launchSettings.json` — defines `http` (port 5040) and `https` (port 7026) profiles

**HTTP test file:** `api/MoneiroAPI/MoneiroAPI.http` — can be used with VS Code REST Client extension to test endpoints against `localhost:5040`.

## Current State

The project is early-stage. The only endpoint is the scaffolded `GET /weatherforecast`. Real financial domain models, database integration, authentication, and business logic are yet to be implemented. The `compose.yml` is empty and ready for database/infrastructure services.

## Conventions

- Nullable reference types are enabled — always handle nullability explicitly.
- Implicit usings are enabled — no need to add common `using` directives manually.
- Follow minimal API patterns (route handlers in `Program.cs` or extension methods) rather than adding MVC controllers unless the project explicitly adopts that pattern.

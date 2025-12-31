# Code Examples Directory

This directory contains code snippets extracted from the actual codebase, organized by architectural layer.

## Directory Structure

```
code-examples/
├── domain/           # Domain layer entities, value objects, enums
├── application/      # DTOs, validators, mappers, interfaces
├── infrastructure/   # Database contexts, service implementations
├── api/              # Controllers, middleware, configuration
└── sql/              # SQL queries and schema definitions
```

## Usage

These code examples are referenced throughout the diploma documentation. Each file contains:
- Complete, working code from the project
- Comments explaining key concepts
- References to the documentation sections where they're used

## Extraction Guidelines

When extracting code for documentation:
1. Include complete class/method definitions
2. Add explanatory comments
3. Remove sensitive information (connection strings, keys)
4. Ensure code compiles and is up-to-date
5. Reference the source file location

## File Naming Convention

Use descriptive names that match the documentation:
- `domain/car-entity.cs`
- `application/car-dto.cs`
- `infrastructure/ad-service.cs`
- `api/dynamic-ads-controller.cs`
- `sql/ltree-queries.sql`

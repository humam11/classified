# PostgreSQL Configuration - Database First Approach

This folder contains PostgreSQL/EF Core configuration using a **database-first approach** with snake_case naming convention.

## Overview

We use **database-first** approach where:
- PostgreSQL tables are created first using SQL scripts
- EF Core entities map to existing database tables
- All tables use **plural names** (e.g., `users`, `categories`)
- All columns use **snake_case** (e.g., `user_id`, `first_name`)

| C# Property (PascalCase) | PostgreSQL Column (snake_case) |
|---------------------------|--------------------------------|
| `UserID` | `user_id` |
| `FirstName` | `first_name` |
| `CreatedAt` | `created_at` |
| `LocationSource` | `location_source` |

## Database-First Approach

### Why Database-First?

1. **Database is the source of truth** - Schema defined in SQL files
2. **No migrations needed** - Tables already exist
3. **Direct control** - Full control over PostgreSQL features
4. **Performance** - Optimized indexes and constraints in SQL

### EF Core Configuration Purpose

Since tables already exist, EF Core configuration only needs to:

✅ **`.ToTable("table_name")`** - Maps C# class name to PostgreSQL table name
   - Example: `User` class → `users` table

✅ **`.HasKey(e => e.PropertyName)`** - Identifies the primary key property
   - Example: `entity.HasKey(e => e.UserID)` → maps to `user_id` column

✅ **`.HasColumnName("column_name")`** - Maps PascalCase property to snake_case column
   - Example: `FirstName` property → `first_name` column
   - **Required for every property** since C# uses PascalCase and DB uses snake_case

✅ **`.HasColumnType("type")`** - Specifies PostgreSQL-specific data types
   - Example: `.HasColumnType("ltree")` for hierarchical paths
   - Example: `.HasColumnType("decimal(2,1)")` for precise decimal types

✅ **`.HasConversion<T>()`** - Converts between C# enums and database integers
   - Example: `.HasConversion<short>()` converts enum to SMALLINT
   - Required for all enum properties

✅ **`.HasOne()` / `.WithMany()` / `.HasForeignKey()`** - Defines entity relationships
   - Tells EF Core how entities relate to each other
   - Example: User has many BugReports, BugReport belongs to one User

### What We DON'T Configure

Since we use database-first, these are **already in the database**:

❌ `.HasMaxLength()` - VARCHAR length defined in SQL
❌ `.IsRequired()` - NOT NULL constraint defined in SQL  
❌ `.HasDefaultValue()` - DEFAULT values defined in SQL
❌ `.HasComputedColumnSql()` - Computed columns defined in SQL
❌ `.ValueGeneratedOnAdd()` - SERIAL/UUID generation defined in SQL
❌ `.HasIndex()` - Indexes already created in SQL
❌ `.OnDelete(DeleteBehavior)` - Foreign key behavior defined in SQL

## Database Schema

### Tables (plural, snake_case)

- `locations` - Hierarchical location data (City → District → Neighborhood)
- `users` - User accounts and profiles
- `user_reports` - User-to-user reports for moderation
- `bug_reports` - Technical bug reports from users
- `user_reviews` - User ratings and reviews (1-5 stars)
- `categories` - Hierarchical category structure for ads
- `brand_models` - Brand and model hierarchy (Brand → Model)
- `model_releases` - Model release years (sub-models)

### Example: User Table

**PostgreSQL Table (created first):**
```sql
CREATE TABLE users (
    user_id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50),
    email VARCHAR(100),
    created_at TIMESTAMPTZ NOT NULL DEFAULT TIMEZONE('UTC', NOW())
);
```

**C# Entity (maps to existing table):**
```csharp
public class User
{
    public Guid UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

**EF Core Configuration (mapping only):**
```csharp
private void ConfigureUser(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>(entity =>
    {
        // Map class to table
        entity.ToTable("users");
        entity.HasKey(e => e.UserID);

        // Map each property to its column
        entity.Property(e => e.UserID).HasColumnName("user_id");
        entity.Property(e => e.FirstName).HasColumnName("first_name");
        entity.Property(e => e.LastName).HasColumnName("last_name");
        entity.Property(e => e.Email).HasColumnName("email");
        entity.Property(e => e.CreatedAt).HasColumnName("created_at");
    });
}
```

## Usage

### Querying with EF Core

```csharp
// C# code uses PascalCase properties
var users = await _context.Users
    .Where(u => u.FirstName == "Ahmed")
    .OrderBy(u => u.CreatedAt)
    .ToListAsync();

// EF Core generates SQL with snake_case columns
// SELECT * FROM users 
// WHERE first_name = 'Ahmed' 
// ORDER BY created_at
```

### Raw SQL Queries

When writing raw SQL, use snake_case column names:

```csharp
var users = await _context.Users
    .FromSqlRaw(@"
        SELECT * FROM users 
        WHERE first_name = {0} 
        AND created_at > {1}
    ", firstName, date)
    .ToListAsync();
```

### Understanding the Mapping

```csharp
// In C# code - use PascalCase
var user = new User 
{
    FirstName = "Ahmed",      // C# property
    LastName = "Ali",
    Email = "ahmed@example.com"
};

await _context.Users.AddAsync(user);
await _context.SaveChangesAsync();

// EF Core translates to SQL with snake_case
// INSERT INTO users (first_name, last_name, email) 
// VALUES ('Ahmed', 'Ali', 'ahmed@example.com')
```

## Configuration

### Connection String

Add PostgreSQL connection string to `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "PostgreSQL": "Host=localhost;Database=classified;Username=postgres;Password=yourpassword"
  }
}
```

### Database Setup (Database-First)

Since we use database-first approach, create the database using SQL scripts:

```bash
# 1. Create database and tables
psql -U postgres -f SQL/Tables.sql

# 2. Insert category data
psql -U postgres -d classified -f SQL/Inserting-data/category_inserts.sql

# 3. Insert location data (if available)
psql -U postgres -d classified -f SQL/Inserting-data/location_inserts.sql
```

### No Migrations Needed

⚠️ **Important**: We do NOT use EF Core migrations because:
- Tables are created manually using SQL scripts
- Database schema is managed in `SQL/Tables.sql`
- EF Core only maps to existing tables

## EF Core Configuration Examples

### Basic Property Mapping

```csharp
// Maps PascalCase property to snake_case column
entity.Property(e => e.FirstName).HasColumnName("first_name");
```

### PostgreSQL-Specific Types

```csharp
// LTREE type for hierarchical paths
entity.Property(e => e.HierarchyPath)
    .HasColumnName("hierarchy_path")
    .HasColumnType("ltree");

// DECIMAL with precision
entity.Property(e => e.AverageRating)
    .HasColumnName("average_rating")
    .HasColumnType("decimal(2,1)");
```

### Enum Conversions

```csharp
// Convert C# enum to PostgreSQL SMALLINT
entity.Property(e => e.LocationSource)
    .HasColumnName("location_source")
    .HasConversion<short>();

// In C# code
public enum LocationSource : short
{
    GPS = 0,
    IP = 1,
    Manual = 2
}
```

### Relationships

```csharp
// One-to-Many: User has many BugReports
entity.HasOne(e => e.User)
    .WithMany(e => e.BugReports)
    .HasForeignKey(e => e.UserID);

// Self-referencing: Category has parent Category
entity.HasOne(e => e.Parent)
    .WithMany(e => e.Children)
    .HasForeignKey(e => e.ParentID);
```

## Benefits of Database-First

1. **Full PostgreSQL Control** - Use all PostgreSQL features directly
2. **Performance** - Optimize indexes, constraints, and triggers in SQL
3. **Type Safety** - Use C# PascalCase in code, PostgreSQL snake_case in DB
4. **Clear Separation** - Database schema in SQL files, mapping in C#
5. **No Migration Conflicts** - No EF Core migration files to manage
6. **Team Collaboration** - DBAs can work on SQL, developers on C#

## Naming Conventions

### Tables
- **Plural names**: `users`, `categories`, `locations`
- **Lowercase**: All table names are lowercase
- **Snake_case for multi-word**: `user_reports`, `bug_reports`

### Columns
- **Snake_case**: `user_id`, `first_name`, `created_at`
- **Lowercase**: All column names are lowercase
- **Descriptive**: `location_source`, `hierarchy_path`

### Indexes
- **Prefix**: `ix_` for indexes
- **Format**: `ix_tablename_columnname`
- **Example**: `ix_users_email`, `ix_categories_hierarchy_path`

### Constraints
- **Foreign Keys**: `fk_tablename_referencedtable`
- **Unique**: `uq_tablename_columnname`
- **Check**: `chk_tablename_description`

## SQL Files

- `SQL/Tables.sql` - Complete database schema with snake_case naming
- `SQL/Inserting-data/category_generator.py` - Python script to generate category inserts
- `SQL/Inserting-data/category_inserts.sql` - Generated category data

## Quick Reference

| Configuration | Purpose | Example |
|--------------|---------|---------|
| `.ToTable()` | Map class to table | `entity.ToTable("users")` |
| `.HasKey()` | Define primary key | `entity.HasKey(e => e.UserID)` |
| `.HasColumnName()` | Map property to column | `.HasColumnName("user_id")` |
| `.HasColumnType()` | Specify PostgreSQL type | `.HasColumnType("ltree")` |
| `.HasConversion<T>()` | Convert enum to int | `.HasConversion<short>()` |
| `.HasOne()` | Define relationship | `.HasOne(e => e.User)` |
| `.WithMany()` | Define collection side | `.WithMany(e => e.Reports)` |
| `.HasForeignKey()` | Specify FK property | `.HasForeignKey(e => e.UserID)` |

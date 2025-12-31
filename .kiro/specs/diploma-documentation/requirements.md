# Requirements Document - Diploma Documentation for Classified Ads System

## Introduction

This document outlines the requirements for creating comprehensive diploma documentation for a multilingual classified ads platform. The system is built using ASP.NET Core with Clean Architecture principles, utilizing a hybrid database approach (PostgreSQL for relational data and MongoDB for document storage). The platform supports Arabic and Kurdish languages and handles various ad categories including vehicles, electronics, real estate, jobs, and miscellaneous items.

## Glossary

- **Clean Architecture**: A software design philosophy that separates concerns into layers (Domain, Application, Infrastructure, API) to achieve independence of frameworks, testability, and maintainability
- **Hybrid Database System**: An architecture that uses both relational (PostgreSQL) and document (MongoDB) databases to optimize for different data access patterns
- **LTREE**: PostgreSQL extension for hierarchical tree-like structures used for categories, locations, and brand/model relationships
- **Discriminator Pattern**: MongoDB pattern using a type field to distinguish between different entity types stored in the same collection
- **DTO (Data Transfer Object)**: Objects used to transfer data between application layers
- **Multilingual System**: Application supporting multiple languages (English and Russian) with language-specific routing and data
- **Slug**: URL-friendly string identifier derived from titles or names
- **Value Object**: Domain-driven design pattern for objects defined by their attributes rather than identity

## Requirements

### Requirement 1

**User Story:** As a diploma reader, I want to understand the database architecture, so that I can comprehend how data is structured and relationships are maintained.

#### Acceptance Criteria

1. WHEN the documentation presents the PostgreSQL schema THEN the system SHALL include a visual database diagram showing all tables and relationships
2. WHEN describing each table THEN the documentation SHALL explain the purpose, primary keys, foreign keys, and constraints
3. WHEN presenting hierarchical structures THEN the documentation SHALL explain the LTREE extension usage for locations, categories, and brands/models
4. WHEN documenting the hybrid approach THEN the documentation SHALL explain why PostgreSQL is used for relational data (users, categories, locations, brands) and MongoDB for ads
5. WHEN showing MongoDB structure THEN the documentation SHALL provide example documents for each ad type (Car, Laptop, CV, House, etc.)

### Requirement 2

**User Story:** As a diploma reader, I want to understand the Clean Architecture implementation, so that I can see how the application layers are organized and interact.

#### Acceptance Criteria

1. WHEN presenting the architecture THEN the documentation SHALL describe all four layers: Domain, Application, Infrastructure, and API
2. WHEN explaining the Domain layer THEN the documentation SHALL show entity models, value objects, and enums with code examples
3. WHEN explaining the Application layer THEN the documentation SHALL describe DTOs, mappers, validators, and service interfaces
4. WHEN explaining the Infrastructure layer THEN the documentation SHALL show database contexts, service implementations, and dependency injection configuration
5. WHEN explaining the API layer THEN the documentation SHALL describe controllers, routing patterns, and middleware
6. WHEN discussing layer dependencies THEN the documentation SHALL illustrate the dependency flow (API → Application → Infrastructure → Domain)
7. WHEN presenting Clean Architecture benefits THEN the documentation SHALL explain testability, maintainability, and framework independence

### Requirement 3

**User Story:** As a diploma reader, I want to see the multilingual implementation, so that I can understand how the system handles Arabic and Kurdish languages.

#### Acceptance Criteria

1. WHEN documenting language support THEN the documentation SHALL explain the routing pattern using language prefixes (en/ru)
2. WHEN showing enum handling THEN the documentation SHALL demonstrate how enums are localized with attributes
3. WHEN presenting category slugs THEN the documentation SHALL show how language-specific slugs are stored and used
4. WHEN explaining validation THEN the documentation SHALL describe multilingual validation messages using FluentValidation
5. WHEN showing API examples THEN the documentation SHALL include requests in both English and Russian contexts
6. WHEN explaining DTO patterns THEN the documentation SHALL describe the hierarchy from AdDto to CreateAdDto for input operations

### Requirement 4

**User Story:** As a diploma reader, I want to understand the dynamic routing system, so that I can see how SEO-friendly URLs are constructed and handled.

#### Acceptance Criteria

1. WHEN documenting URL patterns THEN the documentation SHALL show examples for category-based, brand/model-based, and release-year-based routes
2. WHEN explaining the HandleCategoryRoute method THEN the documentation SHALL describe how the catch-all route parameter is parsed
3. WHEN showing canonical URLs THEN the documentation SHALL explain how the most specific URL is built for each ad
4. WHEN presenting slug generation THEN the documentation SHALL describe the algorithm for creating URL-safe identifiers
5. WHEN documenting search endpoints THEN the documentation SHALL show how category hierarchies are traversed

### Requirement 5

**User Story:** As a diploma reader, I want to see the MongoDB document structure, so that I can understand the polymorphic storage pattern and discriminators.

#### Acceptance Criteria

1. WHEN presenting MongoDB collections THEN the documentation SHALL list all three collections (ads, conversations, messages)
2. WHEN showing ad documents THEN the documentation SHALL provide complete JSON examples demonstrating inheritance: base Ad, Transport (intermediate), and Car (specific)
3. WHEN explaining discriminators THEN the documentation SHALL show how the BsonDiscriminator attribute enables polymorphic queries
4. WHEN documenting nested structures THEN the documentation SHALL explain value objects like Price, LocationAd, and AdImage
5. WHEN showing inheritance THEN the documentation SHALL illustrate the three-level hierarchy (Ad → Transport → Car) to demonstrate the inheritance pattern

### Requirement 6

**User Story:** As a diploma reader, I want to understand the image handling system, so that I can see how file uploads and storage are managed.

#### Acceptance Criteria

1. WHEN documenting image upload THEN the documentation SHALL explain the multipart/form-data handling with size limits (50MB)
2. WHEN showing image storage THEN the documentation SHALL describe the file system structure (wwwroot/images/ads/{adId})
3. WHEN explaining image processing THEN the documentation SHALL mention the SixLabors.ImageSharp library usage
4. WHEN presenting image metadata THEN the documentation SHALL show the AdImage value object structure
5. WHEN documenting image deletion THEN the documentation SHALL explain the cleanup process when ads are deleted

### Requirement 7

**User Story:** As a diploma reader, I want to see the validation strategy, so that I can understand how data integrity is maintained.

#### Acceptance Criteria

1. WHEN presenting validation THEN the documentation SHALL show FluentValidation usage in the Application layer
2. WHEN documenting DTO validation THEN the documentation SHALL provide examples of validator classes
3. WHEN explaining enum validation THEN the documentation SHALL show custom validation extensions for multilingual enums
4. WHEN showing database constraints THEN the documentation SHALL list CHECK constraints, UNIQUE constraints, and foreign keys
5. WHEN presenting error handling THEN the documentation SHALL describe how validation errors are returned to clients

### Requirement 8

**User Story:** As a diploma reader, I want to understand the technology stack, so that I can see all frameworks, libraries, and tools used.

#### Acceptance Criteria

1. WHEN listing technologies THEN the documentation SHALL include .NET 9.0, ASP.NET Core, Entity Framework Core, and MongoDB Driver
2. WHEN showing NuGet packages THEN the documentation SHALL list all dependencies with versions from .csproj files
3. WHEN documenting PostgreSQL features THEN the documentation SHALL mention LTREE extension, UUID v7, and GIST indexes
4. WHEN presenting MongoDB features THEN the documentation SHALL describe BSON serialization, discriminators, and conventions
5. WHEN showing development tools THEN the documentation SHALL mention any code generation scripts or utilities

### Requirement 9

**User Story:** As a diploma reader, I want to see activity diagrams and use cases, so that I can understand system workflows and user interactions.

#### Acceptance Criteria

1. WHEN presenting use cases THEN the documentation SHALL include at least 5 primary use cases (Create Ad, Search Ads, Update Ad, Delete Ad, Browse Categories)
2. WHEN showing activity diagrams THEN the documentation SHALL illustrate the flow for creating an ad with image uploads
3. WHEN documenting search flow THEN the documentation SHALL show the decision tree for routing (category vs brand/model vs release)
4. WHEN presenting user interactions THEN the documentation SHALL include sequence diagrams for API calls
5. WHEN showing data flow THEN the documentation SHALL illustrate how data moves through architecture layers

### Requirement 10

**User Story:** As a diploma reader, I want to see the API endpoint documentation, so that I can understand all available operations.

#### Acceptance Criteria

1. WHEN documenting endpoints THEN the documentation SHALL list all HTTP methods (GET, POST, PATCH, DELETE) with route patterns
2. WHEN showing request examples THEN the documentation SHALL include sample JSON/form-data for each endpoint
3. WHEN presenting response formats THEN the documentation SHALL show successful responses and error responses
4. WHEN explaining query parameters THEN the documentation SHALL describe filtering, sorting, and pagination options
5. WHEN documenting authentication THEN the documentation SHALL explain any security requirements (if implemented)

## Document Structure Outline

The diploma documentation should follow this structure (maximum two-level hierarchy):

### Chapter 1: Introduction
- 1.1 Project Overview
- 1.2 Problem Statement
- 1.3 Objectives
- 1.4 Scope and Limitations
- 1.5 Technology Stack

### Chapter 2: System Requirements and Use Cases
- 2.1 Functional Requirements
- 2.2 Non-Functional Requirements
- 2.3 Actor Identification
- 2.4 Use Case Diagrams
- 2.5 Use Case Descriptions

### Chapter 3: Database Design
- 3.1 Hybrid Database Architecture
- 3.2 PostgreSQL Schema Design
- 3.3 Entity Relationship Diagram
- 3.4 Table Descriptions and Relationships
- 3.5 Hierarchical Structures with LTREE
- 3.6 MongoDB Collection Design
- 3.7 Document Structure Examples
- 3.8 Discriminator Pattern Implementation

### Chapter 4: Application Architecture
- 4.1 Clean Architecture Overview
- 4.2 Domain Layer Design
- 4.3 Application Layer Design
- 4.4 Infrastructure Layer Design
- 4.5 API Layer Design
- 4.6 Dependency Flow and Injection

### Chapter 5: Key Features Implementation
- 5.1 Multilingual Support System
- 5.2 Dynamic SEO-Friendly Routing
- 5.3 Image Upload and Management
- 5.4 Data Validation Strategy
- 5.5 Error Handling Approach

### Chapter 6: API Documentation
- 6.1 Endpoint Overview
- 6.2 Create Ad Operations
- 6.3 Retrieve and Search Operations
- 6.4 Update Ad Operations
- 6.5 Delete Ad Operations
- 6.6 Request and Response Examples

### Chapter 7: Activity Diagrams and Workflows
- 7.1 Create Ad Workflow
- 7.2 Search and Browse Workflow
- 7.3 Update Ad Workflow
- 7.4 Category Navigation Workflow
- 7.5 Image Upload Workflow

### Chapter 8: Conclusion
- 8.1 Project Summary
- 8.2 Key Achievements
- 8.3 Challenges and Solutions
- 8.4 Future Enhancements

### Appendices
- Appendix A: Complete Database Schema
- Appendix B: MongoDB Document Examples
- Appendix C: API Endpoint Reference
- Appendix D: Code Samples

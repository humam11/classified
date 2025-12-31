# Chapter 3: Database Design

## 3.1 Hybrid Database Architecture

[To be written: Explanation of why hybrid approach was chosen]

**PostgreSQL for Relational Data**:
- Users, categories, locations, brands/models
- ACID compliance required
- Complex relationships and referential integrity
- Small record counts (thousands)

**MongoDB for Document Data**:
- Ads with varying attributes
- Schema flexibility for polymorphic storage
- Fast reads for large datasets
- Potentially millions of ads

**Why Hybrid Works**:
- Different data access patterns optimized separately
- Small PostgreSQL tables mean joins are efficient
- MongoDB handles schema variations efficiently

---

## 3.2 PostgreSQL Schema Design

[To be written: Detailed PostgreSQL schema explanation]

**Self-Referencing Tables Pattern**:
- `locations`: City → District → Neighborhood
- `categories`: Parent → Child → Leaf
- `brands_models`: Brand → Model

**Benefits**:
- Minimizes schema complexity
- Flexible depth without schema changes
- Efficient with small datasets

**LTREE Extension**:
- Stores hierarchical paths (e.g., '1.15.150')
- Enables fast ancestor/descendant queries
- GIST indexes for performance

---

## 3.3 Entity Relationship Diagram

[To be created: Complete PostgreSQL ER diagram]

**Diagram**: PostgreSQL ER Diagram (to be created)

---

## 3.4 Table Descriptions and Relationships

[To be written: Detailed table descriptions]

### Users Table
- UUID v7 primary keys
- Location reference
- Rating and review count

### Locations Table
- Hierarchical location data (3 levels)
- Multilingual names
- LTREE hierarchy_path

### Categories Table
- Product/service categories (3 levels)
- Multilingual names and slugs
- is_leaf flag

### Brands_Models Table
- Brand and model hierarchy (2 levels)
- is_brand flag
- Category linkage

### Releases Table
- Model release years
- Links to models

---

## 3.5 Hierarchical Structures with LTREE

[To be written: LTREE usage and examples]

**What is LTREE**:
- PostgreSQL extension for tree structures
- Dot-separated integer paths

**Query Advantages**:
- Find descendants: `WHERE hierarchy_path <@ '1.5'`
- Find ancestors: `WHERE hierarchy_path @> '1.5.23'`
- Find siblings: `WHERE parent_id = X`

**Use Cases**:
- Location navigation
- Category browsing
- Brand/model filtering

---

## 3.6 MongoDB Collection Design

[To be written: MongoDB collections explanation]

**Three Collections**:
1. `ads`: All advertisement types
2. `conversations`: Chat conversations
3. `messages`: Individual messages

**Single Collection for Ads**:
- Enables polymorphic queries
- Simplifies application code
- Better cross-category search performance

**Discriminator Pattern**:
- Type field identifies ad category
- Base: "Ad"
- Intermediate: "Transport", "Electronic", "RealEstate"
- Specific: "Car", "Laptop", "House"

---

## 3.7 Document Structure Examples

[To be written: Complete JSON examples]

**Three-Level Inheritance**:
1. Base Ad (common fields)
2. Transport (vehicle-specific)
3. Car (car-specific)

[Include complete JSON examples from design document]

---

## 3.8 Discriminator Pattern Implementation

[To be written: How discriminators work in code]

**C# Attributes**:
- `[BsonDiscriminator("Car")]`

**MongoDB Field**:
- `_t` field stores discriminator

**Polymorphic Queries**:
- Query base type, get all subtypes
- Filter by discriminator for specific types

---

**Transition**: With the relational schema established, we now examine how MongoDB complements PostgreSQL by storing the variable-structure ad documents. Now that both database systems are designed, the next chapter will explain how we connect to these databases and structure our application code using Clean Architecture.

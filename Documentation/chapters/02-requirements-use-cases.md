# Chapter 2: System Requirements and Use Cases

## 2.1 Functional Requirements

[To be written: Detailed functional requirements]

**Key Functional Requirements**:
1. User Management
   - User registration and authentication
   - Profile management
   - User ratings and reviews

2. Ad Management
   - Create classified ads with images
   - Update existing ads
   - Delete ads
   - View ad details

3. Search and Browse
   - Search ads by category
   - Filter by brand/model/release
   - Browse category hierarchy
   - Location-based filtering

4. Multilingual Support
   - English and Russian interfaces
   - Language-specific routing
   - Localized content

5. Image Management
   - Upload multiple images per ad
   - Image storage and retrieval
   - Image deletion

---

## 2.2 Non-Functional Requirements

[To be written: Quality attributes and constraints]

**Performance**:
- Response time < 200ms for search queries
- Support for 100,000+ concurrent ads
- Image upload < 5 seconds for 10MB files

**Scalability**:
- Horizontal scaling capability
- Database partitioning support
- Efficient indexing strategies

**Security**:
- Input validation and sanitization
- SQL injection prevention
- XSS protection
- Secure file upload handling

**Maintainability**:
- Clean Architecture for testability
- Comprehensive documentation
- Code modularity and reusability

**Usability**:
- Intuitive API design
- Clear error messages
- RESTful conventions

---

## 2.3 Actor Identification

[To be written: System actors and their roles]

**Primary Actors**:
1. **End User**: Creates, searches, and manages ads
2. **Administrator**: Manages system, moderates content

**Secondary Actors**:
1. **System**: Automated processes (cleanup, notifications)

---

## 2.4 Use Case Diagrams

[To be created: Use case diagram showing actors and their interactions]

**Diagram**: System Use Case Diagram (to be created)

---

## 2.5 Use Case Descriptions

[To be written: Detailed use case descriptions]

### UC-01: Create Classified Ad

**Actor**: End User  
**Preconditions**: User is authenticated  
**Main Flow**:
1. User selects category
2. User fills in ad details (title, description, price)
3. User uploads images
4. User submits ad
5. System validates input
6. System saves ad to database
7. System returns success confirmation

**Alternative Flows**:
- A1: Validation fails → Display error messages
- A2: Image upload fails → Retry or skip images

**Postconditions**: Ad is created and visible in search results

---

### UC-02: Search Ads by Category

**Actor**: End User  
**Preconditions**: None  
**Main Flow**:
1. User navigates to category
2. User optionally applies filters (brand, model, price range)
3. System retrieves matching ads
4. System displays results

**Alternative Flows**:
- A1: No results found → Display "no results" message

**Postconditions**: User sees list of matching ads

---

### UC-03: Update Existing Ad

**Actor**: End User  
**Preconditions**: User owns the ad  
**Main Flow**:
1. User navigates to their ad
2. User modifies fields
3. User submits changes
4. System validates input
5. System updates ad in database
6. System returns success confirmation

**Alternative Flows**:
- A1: Validation fails → Display error messages
- A2: User not authorized → Return 403 Forbidden

**Postconditions**: Ad is updated with new information

---

### UC-04: Delete Ad

**Actor**: End User  
**Preconditions**: User owns the ad  
**Main Flow**:
1. User selects ad to delete
2. User confirms deletion
3. System removes ad from database
4. System deletes associated images
5. System returns success confirmation

**Alternative Flows**:
- A1: User not authorized → Return 403 Forbidden

**Postconditions**: Ad is removed from system

---

### UC-05: Browse Category Hierarchy

**Actor**: End User  
**Preconditions**: None  
**Main Flow**:
1. User views top-level categories
2. User selects a category
3. System displays subcategories
4. User navigates through hierarchy
5. User reaches leaf category
6. System displays ads in that category

**Alternative Flows**:
- A1: Category has no ads → Display "no ads" message

**Postconditions**: User views ads in selected category

---

**Transition**: Having defined what the system must accomplish, Chapter 3 will present the database design that enables these requirements.

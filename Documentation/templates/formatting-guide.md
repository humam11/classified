# Formatting Guide for Diploma Documentation

## Academic Writing Standards

### Language and Tone
- Use formal, technical language
- Write in third person (avoid "I", "we", "you")
- Use present tense for describing the system
- Use past tense for implementation decisions
- Be precise and avoid ambiguity

### Structure
- Each chapter should be self-contained but connected
- Use consistent numbering (1.1, 1.2, 2.1, etc.)
- Include transitions between sections
- Maintain logical flow from general to specific

## Typography

### Headings
```markdown
# Chapter 1: Introduction (H1 - Chapter level)
## 1.1 Project Overview (H2 - Section level)
### 1.1.1 Background (H3 - Subsection level)
```

### Text Formatting
- **Bold**: Key terms, important concepts, emphasis
- *Italic*: Foreign words, emphasis, titles of works
- `Code`: Technical terms, file names, commands, code snippets
- > Blockquote: Important notes or quotes

### Lists
**Unordered Lists** (for non-sequential items):
```markdown
- First item
- Second item
  - Nested item
  - Another nested item
- Third item
```

**Ordered Lists** (for sequential steps):
```markdown
1. First step
2. Second step
   1. Sub-step
   2. Another sub-step
3. Third step
```

## Code Examples

### Inline Code
Use backticks for inline code: `ClassName`, `methodName()`, `variable`

### Code Blocks
Always specify the language for syntax highlighting:

**C# Example**:
```csharp
public class Example
{
    public string Property { get; set; }
    
    public void Method()
    {
        // Implementation
    }
}
```

**SQL Example**:
```sql
CREATE TABLE users (
    user_id UUID PRIMARY KEY,
    username VARCHAR(50) NOT NULL
);
```

**JSON Example**:
```json
{
  "_id": "507f1f77bcf86cd799439041",
  "title": "Example Ad",
  "price": {
    "value": 1000.00,
    "currency": "USD"
  }
}
```

### Code Comments
- Add comments to explain complex logic
- Keep comments concise and relevant
- Use comments to highlight key concepts

## Diagrams and Figures

### Diagram Placement
- Place diagrams immediately after the text that references them
- Use descriptive captions
- Number diagrams sequentially within chapters

### Diagram Format
```markdown
![ER Diagram](../diagrams/images/er-diagram.png)
*Figure 3.1: Entity Relationship Diagram showing PostgreSQL schema*
```

### Diagram Types
- **ER Diagrams**: Database relationships
- **Class Diagrams**: Object-oriented structure
- **Sequence Diagrams**: Interaction flows
- **Activity Diagrams**: Process workflows
- **Architecture Diagrams**: System layers and components

## Tables

### Simple Table
```markdown
| Column 1 | Column 2 | Column 3 |
|----------|----------|----------|
| Data 1   | Data 2   | Data 3   |
| Data 4   | Data 5   | Data 6   |
```

### Aligned Table
```markdown
| Left Aligned | Center Aligned | Right Aligned |
|:-------------|:--------------:|--------------:|
| Text         | Text           | 123           |
| More text    | More text      | 456           |
```

### Complex Table (for API endpoints)
```markdown
| Method | Endpoint | Description | Status Codes |
|--------|----------|-------------|--------------|
| GET    | /api/en/categories/{path} | Search ads | 200, 400, 404 |
| POST   | /api/en/categories/{path} | Create ad | 201, 400, 500 |
```

## References and Citations

### Requirement References
Link to requirements document:
```markdown
This feature addresses Requirements 1.1, 1.2, and 1.3.
```

### Code References
Reference actual code files:
```markdown
(See `ClassifiedAds.Domain/Entities/Ads/Car.cs`)
```

### External References
Use footnotes for external sources:
```markdown
Clean Architecture principles[^1] guide the system design.

[^1]: Martin, Robert C. "Clean Architecture: A Craftsman's Guide to Software Structure and Design." 2017.
```

## Sections and Transitions

### Section Structure
Each major section should include:
1. **Purpose statement**: What this section covers
2. **Content**: Main information
3. **Examples**: Code or diagrams
4. **Transition**: Connection to next section

### Transition Examples
```markdown
**Transition**: "With the database schema established, Chapter 4 will demonstrate how the application layers interact with these data structures."

**Transition**: "Having explored the domain entities, we now examine how the application layer transforms this data for API consumption."

**Transition**: "Now that the routing system is understood, the next section details how images are uploaded and managed."
```

## Appendices

### Appendix Format
```markdown
# Appendix A: Complete Database Schema

## A.1 PostgreSQL Tables

### A.1.1 Users Table
[Content]

### A.1.2 Categories Table
[Content]
```

## Page Breaks (for PDF export)

Use HTML comments for page breaks when converting to PDF:
```markdown
<!-- pagebreak -->
```

## Checklist for Each Chapter

Before completing a chapter, verify:
- [ ] All headings are properly numbered
- [ ] Code examples are tested and accurate
- [ ] Diagrams are referenced and captioned
- [ ] Transitions connect to next section
- [ ] Requirements are referenced
- [ ] Technical terms are defined
- [ ] Examples are clear and relevant
- [ ] Grammar and spelling are correct
- [ ] Formatting is consistent

## Common Mistakes to Avoid

1. **Inconsistent terminology** - Use the same terms throughout
2. **Missing code language tags** - Always specify language in code blocks
3. **Broken diagram references** - Verify all image paths
4. **Unclear transitions** - Connect sections logically
5. **Missing requirement references** - Link features to requirements
6. **Overly casual language** - Maintain academic tone
7. **Incomplete code examples** - Show full, working code
8. **Missing captions** - Label all figures and tables

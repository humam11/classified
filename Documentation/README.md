# Diploma Documentation - Multilingual Classified Ads Platform

This directory contains the comprehensive diploma documentation for the multilingual classified ads platform built with ASP.NET Core, PostgreSQL, and MongoDB.

## Document Structure

The documentation follows an academic structure with the following chapters:

1. **Introduction** - Project overview, problem statement, objectives, and technology stack
2. **System Requirements and Use Cases** - Functional/non-functional requirements and use case diagrams
3. **Database Design** - PostgreSQL schema and MongoDB collections with ER diagrams
4. **Application Architecture** - Clean Architecture implementation across all layers
5. **Key Features Implementation** - Multilingual support, routing, images, and validation
6. **API Documentation** - Complete endpoint reference with examples
7. **Activity Diagrams and Workflows** - Visual representation of system processes
8. **Conclusion** - Summary, achievements, challenges, and future work

## Folder Structure

```
Documentation/
├── README.md                          # This file
├── diploma-document.md                # Main documentation file (Markdown)
├── chapters/                          # Individual chapter files
│   ├── 01-introduction.md
│   ├── 02-requirements-use-cases.md
│   ├── 03-database-design.md
│   ├── 04-application-architecture.md
│   ├── 05-key-features.md
│   ├── 06-api-documentation.md
│   ├── 07-activity-diagrams.md
│   └── 08-conclusion.md
├── diagrams/                          # All diagrams and visual aids
│   ├── mermaid/                       # Mermaid diagram source files
│   ├── images/                        # Exported diagram images (PNG/SVG)
│   └── README.md                      # Diagram creation guide
├── code-examples/                     # Code snippets referenced in documentation
│   ├── domain/
│   ├── application/
│   ├── infrastructure/
│   ├── api/
│   └── sql/
├── appendices/                        # Supplementary materials
│   ├── appendix-a-database-schema.md
│   ├── appendix-b-mongodb-examples.md
│   ├── appendix-c-api-reference.md
│   └── appendix-d-code-samples.md
└── templates/                         # Document templates and formatting
    ├── document-template.md
    └── formatting-guide.md
```

## Tools and Technologies

### Diagram Creation
- **Mermaid** - For flowcharts, sequence diagrams, ER diagrams, and class diagrams
- **Draw.io** - For complex architectural diagrams (optional)
- **PlantUML** - Alternative for UML diagrams (optional)

### Document Format
- **Markdown** - Primary format for easy version control and editing
- **Pandoc** - For converting Markdown to Word/PDF (optional)

### Code Formatting
- **Syntax Highlighting** - Using Markdown code blocks with language tags
- **C# Examples** - Extracted from actual codebase
- **SQL Examples** - From database schema files

## Writing Guidelines

1. **Academic Tone** - Formal, technical, and precise language
2. **Clear Structure** - Logical flow from database to API layer
3. **Visual Aids** - Include diagrams for every major concept
4. **Code Examples** - Use real code from the project, properly formatted
5. **Cross-References** - Link related sections and requirements
6. **Consistency** - Maintain consistent terminology throughout

## Building the Document

### Markdown to PDF (using Pandoc)
```bash
pandoc diploma-document.md -o diploma-document.pdf --toc --number-sections
```

### Markdown to Word
```bash
pandoc diploma-document.md -o diploma-document.docx --toc --number-sections
```

## Progress Tracking

- [ ] Chapter 1: Introduction
- [ ] Chapter 2: System Requirements and Use Cases
- [ ] Chapter 3: Database Design
- [ ] Chapter 4: Application Architecture
- [ ] Chapter 5: Key Features Implementation
- [ ] Chapter 6: API Documentation
- [ ] Chapter 7: Activity Diagrams and Workflows
- [ ] Chapter 8: Conclusion
- [ ] Appendices
- [ ] Final Review and Formatting

## References

- ASP.NET Core Documentation: https://docs.microsoft.com/aspnet/core
- Clean Architecture: https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html
- PostgreSQL LTREE: https://www.postgresql.org/docs/current/ltree.html
- MongoDB Documentation: https://docs.mongodb.com/

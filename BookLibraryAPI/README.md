# HW5: Book Library API

**Student Name**: [Your Name]
**Course**: CSCI 6323 - Server Web Development
**Semester**: Spring 2026

## Project Description

A RESTful Book Library Management API built with ASP.NET Core Web API.

## Features

- ✅ Get all books
- ✅ Get single book by ID
- ✅ Search books by title and/or author
- ✅ Create new books
- ✅ Update existing books
- ✅ Delete books
- ✅ Get library statistics

## How to Run

```bash
dotnet run
```

Then open: https://localhost:7001/swagger

API Endpoints
Method Endpoint Description
GET /api/books Get all books
GET /api/books/{id} Get book by ID
GET /api/books/search Search books (query params: title, author)
POST /api/books Create new book
PUT /api/books/{id} Update book
DELETE /api/books/{id} Delete book
GET /api/books/stats Get library statistics
Project Structure
BookLibraryAPI/
├── Controllers/
│ └── BooksController.cs # API endpoints
├── Models/
│ └── Book.cs # Book model
├── Services/
│ ├── IBookService.cs # Service interface
│ └── BookService.cs # Service implementation
└── Program.cs # App configuration & DI
Technologies Used
ASP.NET Core 8.0 Web API
C# 12
Dependency Injection
Swagger/OpenAPI
LINQ

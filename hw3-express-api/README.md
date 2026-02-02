# HW3: Express Router & Middleware

**Student Name:** Cung Nguyen
**Course:** CSCI 6323 - Server Web Development
**Date:** February 2, 2026

## How to Run

1. Install dependencies: `npm install`
2. Start server: `node server.js`
3. API available at: http://localhost:3000

## Project Structure

- `server.js` - Main application with middleware pipeline
- `routes/` - Express routers for tasks and categories
- `middleware/` - Custom middleware (logger, validator, error handler)
- `data/` - In-memory data storage

## API Endpoints

### Tasks

- GET /api/tasks - Get all tasks
- GET /api/tasks?completed=true - Filter completed tasks
- GET /api/tasks?category=1 - Filter by category
- GET /api/tasks/:id - Get specific task
- POST /api/tasks - Create task
- PUT /api/tasks/:id - Update task
- DELETE /api/tasks/:id - Delete task

### Categories

- GET /api/categories - Get all categories
- POST /api/categories - Create category

## Middleware Used

1. **express.json()** - Parses JSON request bodies
2. **logger** - Logs all requests with timestamp
3. **validateTask** - Validates task data before POST/PUT
4. **validateCategory** - Validates category data before POST
5. **notFoundHandler** - Returns 404 for unknown routes
6. **errorHandler** - Catches and formats errors

## Notes

Everything was explained in great detail by Professor Bobby; simply following the instructions will lead to successful server deployment.

const express = require('express');
const logger = require('./middleware/logger');
const { errorHandler, notFoundHandler } = require('./middleware/errorHandler');
const tasksRouter = require('./routes/tasks');
const categoriesRouter = require('./routes/categories');

const app = express();
const PORT = 3000;

// ===== MIDDLEWARE PIPELINE =====

// 1. Built-in middleware to parse JSON
app.use(express.json());

// 2. Custom logger middleware (runs on every request)
app.use(logger);

// ===== ROUTES =====

// Root route
app.get('/', (req, res) => {
    res.json({
        message: 'Task Management API',
        version: '1.0.0',
        endpoints: {
            tasks: {
                'GET /api/tasks': 'Get all tasks (supports ?completed=true&category=1)',
                'GET /api/tasks/:id': 'Get task by id',
                'POST /api/tasks': 'Create new task',
                'PUT /api/tasks/:id': 'Update task',
                'DELETE /api/tasks/:id': 'Delete task'
            },
            categories: {
                'GET /api/categories': 'Get all categories',
                'POST /api/categories': 'Create new category'
            }
        }
    });
});

// Mount routers
app.use('/api/tasks', tasksRouter);
app.use('/api/categories', categoriesRouter);

// ===== ERROR HANDLING =====

// 404 handler (must come after all routes)
app.use(notFoundHandler);

// Error handler (must be last)
app.use(errorHandler);

// ===== START SERVER =====

app.listen(PORT, () => {
    console.log(`Server running at http://localhost:${PORT}/`);
    console.log('Available endpoints:');
    console.log('  GET    /');
    console.log('  GET    /api/tasks');
    console.log('  GET    /api/tasks/:id');
    console.log('  POST   /api/tasks');
    console.log('  PUT    /api/tasks/:id');
    console.log('  DELETE /api/tasks/:id');
    console.log('  GET    /api/categories');
    console.log('  POST   /api/categories');
});
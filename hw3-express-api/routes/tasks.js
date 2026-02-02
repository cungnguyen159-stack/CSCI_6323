const express = require('express');
const router = express.Router();
const storage = require('../data/storage');
const { validateTask } = require('../middleware/validator');

// GET /api/tasks - Get all tasks (with optional filtering)
router.get('/', (req, res) => {
    let tasks = storage.getAllTasks();

    // Filter by completed status if query param exists
    // Example: /api/tasks?completed=true
    if (req.query.completed !== undefined) {
        const isCompleted = req.query.completed === 'true';
        tasks = tasks.filter(t => t.completed === isCompleted);
    }

    // Filter by category if query param exists
    // Example: /api/tasks?category=1
    if (req.query.category) {
        const categoryId = parseInt(req.query.category);
        tasks = tasks.filter(t => t.categoryId === categoryId);
    }

    res.json({
        count: tasks.length,
        tasks: tasks
    });
});

// GET /api/tasks/:id - Get a specific task
router.get('/:id', (req, res) => {
    const task = storage.getTaskById(req.params.id);

    if (!task) {
        return res.status(404).json({
            error: 'Not Found',
            message: `Task with id ${req.params.id} not found`
        });
    }

    res.json(task);
});

// POST /api/tasks - Create a new task (with validation)
router.post('/', validateTask, (req, res) => {
    const { title, description, categoryId, completed } = req.body;

    const newTask = storage.createTask({
        title,
        description,
        categoryId,
        completed
    });

    res.status(201).json(newTask);
});

// PUT /api/tasks/:id - Update a task (with validation)
router.put('/:id', validateTask, (req, res) => {
    const { title, description, categoryId, completed } = req.body;

    const updatedTask = storage.updateTask(req.params.id, {
        title,
        description,
        categoryId,
        completed
    });

    if (!updatedTask) {
        return res.status(404).json({
            error: 'Not Found',
            message: `Task with id ${req.params.id} not found`
        });
    }

    res.json(updatedTask);
});

// DELETE /api/tasks/:id - Delete a task
router.delete('/:id', (req, res) => {
    const deleted = storage.deleteTask(req.params.id);

    if (!deleted) {
        return res.status(404).json({
            error: 'Not Found',
            message: `Task with id ${req.params.id} not found`
        });
    }

    res.json({
        message: 'Task deleted successfully',
        task: deleted
    });
});

module.exports = router;
// Validation middleware functions

// Validate task data
const validateTask = (req, res, next) => {
    const { title, description, categoryId } = req.body;

    // Check required fields
    if (!title || title.trim() === '') {
        return res.status(400).json({
            error: 'Validation Error',
            message: 'Title is required'
        });
    }

    if (title.length > 100) {
        return res.status(400).json({
            error: 'Validation Error',
            message: 'Title must be less than 100 characters'
        });
    }

    if (description && description.length > 500) {
        return res.status(400).json({
            error: 'Validation Error',
            message: 'Description must be less than 500 characters'
        });
    }

    if (categoryId && typeof categoryId !== 'number') {
        return res.status(400).json({
            error: 'Validation Error',
            message: 'CategoryId must be a number'
        });
    }

    // If validation passes, continue
    next();
};

// Validate category data
const validateCategory = (req, res, next) => {
    const { name } = req.body;

    if (!name || name.trim() === '') {
        return res.status(400).json({
            error: 'Validation Error',
            message: 'Name is required'
        });
    }

    if (name.length > 50) {
        return res.status(400).json({
            error: 'Validation Error',
            message: 'Name must be less than 50 characters'
        });
    }

    next();
};

module.exports = {
    validateTask,
    validateCategory
};
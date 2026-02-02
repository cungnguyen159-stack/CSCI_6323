const express = require('express');
const router = express.Router();
const storage = require('../data/storage');
const { validateCategory } = require('../middleware/validator');

// GET /api/categories - Get all categories
router.get('/', (req, res) => {
    const categories = storage.getAllCategories();
    res.json({
        count: categories.length,
        categories: categories
    });
});

// POST /api/categories - Create a new category
router.post('/', validateCategory, (req, res) => {
    const { name } = req.body;

    const newCategory = storage.createCategory({ name });

    res.status(201).json(newCategory);
});

module.exports = router;
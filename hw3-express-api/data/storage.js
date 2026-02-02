// In-memory data storage (will be reset when server restarts)

let tasks = [
    {
        id: 1,
        title: "Complete HW2",
        description: "Finish the Node.js HTTP server assignment",
        completed: true,
        categoryId: 1,
        createdAt: new Date().toISOString()
    },
    {
        id: 2,
        title: "Study Express.js",
        description: "Learn about routers and middleware",
        completed: false,
        categoryId: 1,
        createdAt: new Date().toISOString()
    }
];

let categories = [
    { id: 1, name: "School" },
    { id: 2, name: "Personal" }
];

let nextTaskId = 3;
let nextCategoryId = 3;

// Export functions to manipulate data
module.exports = {
    // Task functions
    getAllTasks: () => tasks,
    getTaskById: (id) => tasks.find(t => t.id === parseInt(id)),
    createTask: (task) => {
        const newTask = {
            id: nextTaskId++,
            ...task,
            completed: task.completed || false,
            createdAt: new Date().toISOString()
        };
        tasks.push(newTask);
        return newTask;
    },
    updateTask: (id, updates) => {
        const index = tasks.findIndex(t => t.id === parseInt(id));
        if (index === -1) return null;
        tasks[index] = { ...tasks[index], ...updates };
        return tasks[index];
    },
    deleteTask: (id) => {
        const index = tasks.findIndex(t => t.id === parseInt(id));
        if (index === -1) return null;
        const deleted = tasks[index];
        tasks.splice(index, 1);
        return deleted;
    },

    // Category functions
    getAllCategories: () => categories,
    getCategoryById: (id) => categories.find(c => c.id === parseInt(id)),
    createCategory: (category) => {
        const newCategory = {
            id: nextCategoryId++,
            ...category
        };
        categories.push(newCategory);
        return newCategory;
    }
};
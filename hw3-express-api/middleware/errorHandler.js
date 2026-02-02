// Error handling middleware
// This should be the LAST middleware in your app

const errorHandler = (err, req, res, next) => {
    console.error('Error:', err);

    // Default to 500 server error
    const statusCode = err.statusCode || 500;
    const message = err.message || 'Internal Server Error';

    res.status(statusCode).json({
        error: 'Error',
        message: message,
        ...(process.env.NODE_ENV === 'development' && { stack: err.stack })
    });
};

// 404 Not Found handler
const notFoundHandler = (req, res) => {
    res.status(404).json({
        error: 'Not Found',
        message: `Cannot ${req.method} ${req.url}`
    });
};

module.exports = {
    errorHandler,
    notFoundHandler
};
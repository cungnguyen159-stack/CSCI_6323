// Request logging middleware
const logger = (req, res, next) => {
    const timestamp = new Date().toISOString();
    const method = req.method;
    const url = req.url;

    console.log(`[${timestamp}] ${method} ${url}`);

    // Call next() to pass control to the next middleware
    next();
};

module.exports = logger;
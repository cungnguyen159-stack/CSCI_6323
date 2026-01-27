const http = require('http');

const fs = require('fs').promises;

const path = require('path');

const PORT = 3000;

// Helper function to get content type based on file extension

function getContentType(filePath) {

    const ext = path.extname(filePath);

    const contentTypes = {

        '.html': 'text/html',

        '.css': 'text/css',

        '.js': 'text/javascript',

        '.json': 'application/json',

        '.png': 'image/png',

        '.jpg': 'image/jpeg',

        '.jpeg': 'image/jpeg',

        '.gif': 'image/gif',

    };

    return contentTypes[ext] || 'text/plain';

}

// Helper function to serve static files

async function serveStaticFile(filePath, res) {

    try {

        const data = await fs.readFile(filePath);

        const contentType = getContentType(filePath);

        res.writeHead(200, { 'Content-Type': contentType });

        res.end(data);

    } catch (error) {

        res.writeHead(404, { 'Content-Type': 'text/html' });

        res.end('<h1>404 - File Not Found</h1>');

    }

}

// Create the server

const server = http.createServer(async (req, res) => {

    const url = req.url;

    const method = req.method;

    console.log(`${method} ${url}`);

    // Handle GET requests

    if (method === 'GET') {

        // Route: Home page

        if (url === '/') {

            await serveStaticFile(path.join(__dirname, 'public', 'index.html'), res);

        }

        // Route: About page

        else if (url === '/about') {

            await serveStaticFile(path.join(__dirname, 'public', 'about.html'), res);

        }

        // Route: Projects page

        else if (url === '/projects') {

            await serveStaticFile(path.join(__dirname, 'public', 'projects.html'), res);

        }

        // Route: Contact page

        else if (url === '/contact') {

            await serveStaticFile(path.join(__dirname, 'public', 'contact.html'), res);

        }

        // Route: API data (JSON)

        else if (url === '/api/data') {

            const data = {

                message: "Hello from the API!",

                timestamp: new Date().toISOString(),

                student: "Your Name Here",

                course: "CSCI 6323"

            };

            res.writeHead(200, { 'Content-Type': 'application/json' });

            res.end(JSON.stringify(data, null, 2));

        }

        // Serve static files (CSS, images, etc.)

        else if (url.startsWith('/style.css') || url.startsWith('/images/')) {

            const filePath = path.join(__dirname, 'public', url);

            await serveStaticFile(filePath, res);

        }

        // 404 for unknown routes

        else {

            res.writeHead(404, { 'Content-Type': 'text/html' });

            res.end('<h1>404 - Page Not Found</h1><p>The page you are looking for does not exist.</p>');

        }

    }

    // Handle POST requests

    else if (method === 'POST') {

        if (url === '/api/contact') {

            let body = '';

            // Collect data chunks

            req.on('data', chunk => {

                body += chunk.toString();

            });

            // When all data is received

            req.on('end', () => {

                console.log('Contact form submitted:');

                console.log(body);

                // Parse the form data (x-www-form-urlencoded)

                const params = new URLSearchParams(body);

                const formData = {

                    name: params.get('name'),

                    email: params.get('email'),

                    message: params.get('message')

                };

                console.log('Parsed form data:', formData);

                // Send success response

                res.writeHead(200, { 'Content-Type': 'text/html' });

                res.end(`

                    <html>

                    <head>

                        <title>Message Sent</title>

                        <link rel="stylesheet" href="/style.css">

                    </head>

                    <body>

                        <nav>

                            <a href="/">Home</a>

                            <a href="/about">About</a>

                            <a href="/projects">Projects</a>

                            <a href="/contact">Contact</a>

                        </nav>

                        <main>

                            <h1>Message Sent!</h1>

                            <p>Thank you, ${formData.name}! Your message has been received.</p>

                            <p><a href="/">Return to Home</a></p>

                        </main>

                    </body>

                    </html>

                `);

            });

        } else {

            res.writeHead(404, { 'Content-Type': 'text/html' });

            res.end('<h1>404 - Endpoint Not Found</h1>');

        }

    }

    // Handle other methods

    else {

        res.writeHead(405, { 'Content-Type': 'text/html' });

        res.end('<h1>405 - Method Not Allowed</h1>');

    }

});

// Start the server

server.listen(PORT, () => {

    console.log(`Server running at http://localhost:${PORT}/`);

    console.log('Available routes:');

    console.log('  - GET  /');

    console.log('  - GET  /about');

    console.log('  - GET  /projects');

    console.log('  - GET  /contact');

    console.log('  - GET  /api/data');

    console.log('  - POST /api/contact');

});
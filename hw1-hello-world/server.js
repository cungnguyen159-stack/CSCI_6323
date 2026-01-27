// Import the http module

const http = require('http');

// Define the port

const PORT = 3000;

// Create the server

const server = http.createServer((req, res) => {

    // Set response headers

    res.writeHead(200, { 'Content-Type': 'text/html' });

    // Send response

    res.end(`

        <html>

            <head>
                <meta charset="UTF-8">
                <title>HW1 - Hello World</title>

                <style>

                    body {

                        font-family: Arial, sans-serif;

                        display: flex;

                        justify-content: center;

                        align-items: center;

                        height: 100vh;

                        margin: 0;

                        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);

                        color: white;

                    }

                    .container {

                        text-align: center;

                    }

                    h1 {

                        font-size: 3em;

                        margin: 0;

                    }

                    p {

                        font-size: 1.2em;

                    }

                </style>

            </head>

            <body>

                <div class="container">

                    <h1>🚀 Hello World!</h1>

                    <p>Node.js server is running successfully</p>

                    <p><strong>Student:</strong> Cung Nguyen</p>

                    <p><strong>Course:</strong> CSCI 6323 - Server Web Development</p>

                </div>

            </body>

        </html>

    `);

});

// Start the server

server.listen(PORT, () => {

    console.log(`Server running at http://localhost:${PORT}/`);

});
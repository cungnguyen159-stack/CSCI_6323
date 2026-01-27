import http from 'http'

const server = http.createServer((req, res) => {
    //req = incoming request from the client

    //res = response we send back

    res.writeHead(200, { 'Content-Type': 'text/plain'});

    //Send response
    res.end('Hello from Node.js server');
});

const PORT = 3000;
server.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
    console.log(`Server is running on http://localhost:${PORT}`);
})
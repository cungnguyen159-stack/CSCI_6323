import express from 'express';

const app = express();
const PORT = process.env.PORT || 3000;

//Send response
app.get('/', (req, res) => {
    res.send('Hello from Express.js server');
});


server.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
})
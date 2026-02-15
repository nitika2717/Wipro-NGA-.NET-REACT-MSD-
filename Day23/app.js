const express = require('express');
const app = express();

const PORT = process.env.PORT || 3000;

app.get('/', (req, res) => {
    res.send('Hello, World!');
});

app.get('/about', (req, res) => {
    res.send('This is the about page.');
});

app.get('/user/:name', (req, res) => {
    res.send(`Hello, ${req.params.name}!`);
});

app.get('/api/user', (req, res) => {
    res.json({
        id: 1,
        name: 'John Doe',
        email: 'john.doe@example.com'
    });
});

app.listen(PORT, () => {
    console.log(`Server running at http://localhost:${PORT}`); 
});

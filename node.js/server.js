const express = require('express');
const sqlite3 = require('sqlite3').verbose();
const bodyParser = require('body-parser');

const app = express();
const db = new sqlite3.Database(':memory:'); // Используем базу данных в памяти

app.use(bodyParser.json());

db.serialize(() => {
    // Создание таблицы для хранения данных о времени
    db.run("CREATE TABLE TimeEntries (id INTEGER PRIMARY KEY AUTOINCREMENT, category TEXT, timeSpent REAL)");

    // Обработка POST-запросов для сохранения времени
    app.post('/saveTime', (req, res) => {
        const { category, timeSpent } = req.body;
        db.run("INSERT INTO TimeEntries (category, timeSpent) VALUES (?, ?)", [category, timeSpent], function(err) {
            if (err) {
                return res.status(500).send(err.message);
            }
            res.status(200).send(`Entry added with ID: ${this.lastID}`);
        });
    });

    // Запуск сервера
    app.listen(3000, () => {
        console.log('Server is running on port 3000');
    });
});
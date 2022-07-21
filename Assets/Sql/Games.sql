CREATE TABLE IF NOT EXISTS Games(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    NAME TEXT NOT NULL,
    info TEXT,
    path TEXT,
    evaluation TEXT,
    favoriteId TEXT
)
CREATE TABLE IF NOT EXISTS Games(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    NAME TEXT NOT NULL,
    info TEXT,
    path TEXT,
    barImgPath TEXT,
    coverImgPath TEXT,
    evaluation TEXT,
    favoriteId INTEGER
)
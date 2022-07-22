CREATE TABLE IF NOT EXISTS Games_Tags(
    gameId TEXT,
    tagId TEXT NOT NULL,
    PRIMARY KEY(gameId,tagId),
    FOREIGN KEY (gameId) REFERENCES Games(id),
    FOREIGN KEY (tagId) REFERENCES Tags(id)
)
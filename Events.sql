create Database EventsDatabase

CREATE TABLE Events (
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(60) NOT NULL,
    Location VARCHAR(60) NOT NULL,
    Date DATETIME NOT NULL
);

go

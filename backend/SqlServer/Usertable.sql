CREATE TABLE 	Users (
	Username varchar(63) NOT NULL,
    Postalcode varchar(5),
    EMail varchar(255),
    Age varchar(63),
    Picture varchar(255),
    Target int,
    Laufniveau int,
    PasswordHash varchar(64),
    Salt long,
    PRIMARY KEY (Username)
);

CREATE TABLE Tokens (
	Token long NOT NULL,
    Username varchar(63) NOT NULL,
    PRIMARY KEY (Username),
	FOREIGN KEY (Username) REFERENCES Users(Username)
    );

INSERT INTO Users
VALUES ('testBoy','1', '123','123','123',1,1,'123' );

INSERT INTO Tokens
VALUES (12345,'testBoy' );

SELECT * FROM users
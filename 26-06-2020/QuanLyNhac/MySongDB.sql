CREATE DATABASE MySongs;
CREATE TABlE Songs(
	ID INT PRIMARY KEY IDENTITY,
	Title VARCHAR(500) NOT NULL,
	ArtistName VARCHAR(500) NOT NULL,
	GenreID INT,
);

CREATE TABlE Genre(
	ID INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(500) NOT NULL	
);

INSERT INTO Songs(Title, ArtistName, GenreID)
VALUES('Nhac tre', 'Nghe si A', 1);
INSERT INTO Songs(Title, ArtistName, GenreID)
VALUES('Nhac tre 11', 'Nghe si B', 2);
INSERT INTO Songs(Title, ArtistName, GenreID)
VALUES('Nhac tre 22', 'Nghe si C', 1);
SELECT * FROM Songs;

INSERT INTO Genre(GenreName)
VALUES('The loai A');
INSERT INTO Genre(GenreName)
VALUES('The loai B');

SELECT * FROM Genre;
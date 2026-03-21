CREATE DATABASE MusicHub;
USE MusicHub;

CREATE TABLE Artists
(
    ArtistId INT AUTO_INCREMENT PRIMARY KEY,
    Name     VARCHAR(100) NOT NULL,
    Country  VARCHAR(50),
    Genre    VARCHAR(50)  NOT NULL
);

CREATE TABLE Albums
(
    AlbumId     INT AUTO_INCREMENT PRIMARY KEY,
    Title       VARCHAR(100) NOT NULL,
    ReleaseYear INT          NOT NULL,
    ArtistId    INT          NOT NULL,
    FOREIGN KEY (ArtistId) REFERENCES Artists (ArtistId)
);

CREATE TABLE Songs
(
    SongId   INT AUTO_INCREMENT PRIMARY KEY,
    Title    VARCHAR(100) NOT NULL,
    Duration INT          NOT NULL,
    AlbumId  INT          NOT NULL,
    FOREIGN KEY (AlbumId) REFERENCES Albums (AlbumId)
);

CREATE TABLE Playlists
(
    PlaylistId  INT AUTO_INCREMENT PRIMARY KEY,
    Name        VARCHAR(100) NOT NULL,
    CreatedDate DATE         NOT NULL
);

CREATE TABLE PlaylistSongs
(
    PlaylistId INT NOT NULL,
    SongId     INT NOT NULL,
    PRIMARY KEY (PlaylistId, SongId),
    FOREIGN KEY (PlaylistId) REFERENCES Playlists (PlaylistId),
    FOREIGN KEY (SongId) REFERENCES Songs (SongId)
);

CREATE TABLE Users
(
    UserId   INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50)  NOT NULL UNIQUE,
    Email    VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE UserPlaylists
(
    UserId     INT NOT NULL,
    PlaylistId INT NOT NULL,
    PRIMARY KEY (UserId, PlaylistId),
    FOREIGN KEY (UserId) REFERENCES Users (UserId),
    FOREIGN KEY (PlaylistId) REFERENCES Playlists (PlaylistId)
);
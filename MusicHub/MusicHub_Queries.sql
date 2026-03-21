-- 1. Първите 5 артисти подредени по имена
SELECT * FROM Artists AS a
ORDER BY a.Name
LIMIT 5;

-- 2. Всички албуми излезли след 2015 година
SELECT * FROM Albums
WHERE ReleaseYear > 2015;

-- 3. Всички песни по-дълги от 300 секунди (5 минути)
SELECT * FROM Songs
WHERE Duration > 300;

-- 4. Всички плейлисти с броя песни във всеки
SELECT p.Name, COUNT(ps.SongId) AS SongCount
FROM Playlists AS p
         JOIN PlaylistSongs AS ps ON p.PlaylistId = ps.PlaylistId
GROUP BY p.PlaylistId;

-- 5. Всички песни на "Ed Sheeran"
SELECT s.Title, a.Title AS Album
FROM Songs AS s
         JOIN Albums AS a ON s.AlbumId = a.AlbumId
         JOIN Artists AS ar ON a.ArtistId = ar.ArtistId
WHERE ar.Name = 'Ed Sheeran';

-- 6. Потребители с повече от 2 плейлиста
SELECT u.Username, COUNT(up.PlaylistId) AS PlaylistCount
FROM Users AS u
         JOIN UserPlaylists AS up ON u.UserId = up.UserId
GROUP BY u.UserId
HAVING COUNT(up.PlaylistId) > 2;

-- 7. Плейлисти съдържащи песни на "Adele"
SELECT DISTINCT p.Name
FROM Playlists AS p
         JOIN PlaylistSongs AS ps ON p.PlaylistId = ps.PlaylistId
         JOIN Songs AS s ON ps.SongId = s.SongId
         JOIN Albums AS a ON s.AlbumId = a.AlbumId
         JOIN Artists AS ar ON a.ArtistId = ar.ArtistId
WHERE ar.Name = 'Adele';

-- 8. Средната продължителност на песните във всеки албум, топ 10 по средна продължителност
SELECT a.Title AS Album, AVG(s.Duration) AS AvgDuration
FROM Albums AS a
         JOIN Songs AS s ON a.AlbumId = s.AlbumId
GROUP BY a.AlbumId
ORDER BY AvgDuration DESC
LIMIT 10;

-- 9. Списък на всички потребители и общия брой песни в плейлистите им, топ 10 по брой песни
SELECT u.Username, COUNT(ps.SongId) AS TotalSongs
FROM Users AS u
         JOIN UserPlaylists AS up ON u.UserId = up.UserId
         JOIN PlaylistSongs AS ps ON up.PlaylistId = ps.PlaylistId
GROUP BY u.UserId
ORDER BY TotalSongs DESC
LIMIT 10;

-- 10. Артисти с поне 2 албума
SELECT ar.Name, COUNT(a.AlbumId) AS AlbumCount
FROM Artists AS ar
         JOIN Albums AS a ON ar.ArtistId = a.ArtistId
GROUP BY ar.ArtistId
HAVING COUNT(a.AlbumId) >= 2;

-- 11. Плейлисти съдържащи поне една песен по-дълга от 280 секунди (04:40)
SELECT DISTINCT p.Name
FROM Playlists AS p
         JOIN PlaylistSongs AS ps ON p.PlaylistId = ps.PlaylistId
         JOIN Songs AS s ON ps.SongId = s.SongId
WHERE s.Duration > 280;

-- 12. Топ 5 най-дълги песни
SELECT s.Title, s.Duration
FROM Songs AS s
ORDER BY s.Duration DESC
LIMIT 5;

-- 13. Всички песни в плейлиста 'Top Hits' подредени по продължение
SELECT s.Title, s.Duration
FROM Songs AS s
         JOIN PlaylistSongs AS ps ON s.SongId = ps.SongId
         JOIN Playlists AS p ON ps.PlaylistId = p.PlaylistId
WHERE p.Name = 'Top Hits'
ORDER BY s.Duration DESC;

-- 14. Всички потребители с техните плейлисти, топ 15 по азбучен ред
SELECT u.Username, p.Name AS PlaylistName
FROM Users AS u
         JOIN UserPlaylists AS up ON u.UserId = up.UserId
         JOIN Playlists AS p ON up.PlaylistId = p.PlaylistId
ORDER BY u.Username
LIMIT 15;

-- 15. Общия брой песни за всеки артист, топ 15
SELECT ar.Name, COUNT(s.SongId) AS SongCount
FROM Artists AS ar
         JOIN Albums AS a ON ar.ArtistId = a.ArtistId
         JOIN Songs AS s ON a.AlbumId = s.AlbumId
GROUP BY ar.ArtistId
LIMIT 15;

-- 16. Артисти, които имат албум с повече от 2 песни
SELECT Name
FROM Artists
WHERE ArtistId IN (
    SELECT a.ArtistId
    FROM Albums AS a
             JOIN Songs AS s ON a.AlbumId = s.AlbumId
    GROUP BY a.AlbumId
    HAVING COUNT(s.SongId) > 2
);

-- 17. Плейлисти, съдържащи най-дългата песен в базата
SELECT DISTINCT p.Name
FROM Playlists AS p
         JOIN PlaylistSongs AS ps ON p.PlaylistId = ps.PlaylistId
WHERE ps.SongId = (
    SELECT s.SongId
    FROM Songs AS s
    ORDER BY s.Duration DESC
    LIMIT 1
);

-- 18. Потребители, които имат поне един плейлист с повече от 5 песни в него
SELECT DISTINCT u.Username
FROM Users AS u
         JOIN UserPlaylists AS up ON u.UserId = up.UserId
         JOIN PlaylistSongs AS ps ON up.PlaylistId = ps.PlaylistId
GROUP BY u.UserId, up.PlaylistId
HAVING COUNT(ps.SongId) > 5;
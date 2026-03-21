using MusicHub.Data.Models;

namespace NUnitTest_MusicHub
{

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestClassPlaylistIdThrowException()
        {
            Playlist playlist = new Playlist();
            ArgumentException argumentException = Assert.Throws<ArgumentException>(() => playlist.PlaylistId = -1);

        }

        [Test]
        public void TestClassPlaylistIdCorrectValue()
        {

            Playlist playlist = new Playlist();
            playlist.PlaylistId = 1;
            Assert.That(playlist.PlaylistId, Is.EqualTo(1));

        }
        [Test]
        public void TestClassPlaylistCreatedDateThrowException()
        {
            Playlist playlist = new Playlist();
            DateOnly specificDate = new DateOnly(2027, 12, 31);
            ArgumentException argumentException = Assert.Throws<ArgumentException>(() => playlist.CreatedDate = specificDate);

        }

        [Test]
        public void TestClassPlaylistCreatedDateCorrectValue()
        {

            Playlist playlist = new Playlist();
            DateOnly specificDate = new DateOnly(2023, 12, 31);
            playlist.CreatedDate = specificDate;
            Assert.That(playlist.CreatedDate, Is.EqualTo(specificDate));

        }

        [Test]
        public void TestClassAlbumIdThrowException()
        {
            Album album = new Album();
            ArgumentException argumentException = Assert.Throws<ArgumentException>(() => album.AlbumId = -1);


        }

        [Test]
        public void TestClassAlbumIdCorrectValue()
        {
            Album album = new Album();
            album.AlbumId = 1;
            Assert.That(album.AlbumId, Is.EqualTo(1));

        }

        [Test]
        public void TestClassAlbumReleaseYearThrowException()
        {
            Album album = new Album();
            ArgumentException argumentException = Assert.Throws<ArgumentException>(() => album.ReleaseYear = 2027);


        }

        [Test]
        public void TestClassAlbumReleaseYearCorrectValue()
        {
            Album album = new Album();
            album.ReleaseYear = 2025;
            Assert.That(album.ReleaseYear, Is.EqualTo(2025));

        }

        [Test]
        public void TestClassArtistIdThrowException()
        {
            Artist artist = new Artist();
            ArgumentException argumentException = Assert.Throws<ArgumentException>(() => artist.ArtistId = -1);


        }

        [Test]
        public void TestClassArtistIdCorrectValue()
        {
            Artist artist = new Artist();
            artist.ArtistId = 1;
            Assert.That(artist.ArtistId, Is.EqualTo(1));

        }

        [Test]
        public void TestClassArtistCountryThrowException()
        {
            Artist artist = new Artist();
            ArgumentException argumentException = Assert.Throws<ArgumentException>(() => artist.Country = "Bulgariaaaaaaaaaaaaaaaaaaaaaaaaaa");


        }

        [Test]
        public void TestClassArtistCountryCorrectValue()
        {
            Artist artist = new Artist();
            artist.Country = "Bulgaria";
            Assert.That(artist.Country, Is.EqualTo("Bulgaria"));

        }

        [Test]
        public void TestClassSongIdThrowException()
        {
            Song song = new Song();
            ArgumentException argumentException = Assert.Throws<ArgumentException>(() => song.SongId = -1);


        }

        [Test]
        public void TestClassSongIdCorrectValue()
        {
            Song song = new Song();
            song.SongId = 1;
            Assert.That(song.SongId, Is.EqualTo(1));

        }

        [Test]
        public void TestClassSongDurationThrowException()
        {
            Song song = new Song();
            ArgumentException argumentException = Assert.Throws<ArgumentException>(() => song.Duration = 500);


        }

        [Test]
        public void TestClassSongDurationCorrectValue()
        {
            Song song = new Song();
            song.Duration = 350;
            Assert.That(song.Duration, Is.EqualTo(350));

        }

        [Test]
        public void TestClassUserIdThrowException()
        {
            User user = new User();
            ArgumentException argumentException = Assert.Throws<ArgumentException>(() => user.UserId = -1);


        }

        [Test]
        public void TestClassUserIdCorrectValue()
        {
            User user = new User();
            user.UserId = 1;
            Assert.That(user.UserId, Is.EqualTo(1));

        }
    }
}
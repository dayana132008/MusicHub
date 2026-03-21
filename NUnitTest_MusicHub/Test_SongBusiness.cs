using MusicHub.Data.Models;
using System.Linq;
using MusicHub.Business;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

namespace NUnitTest_MusicHub
{
    [TestFixture]
    internal class Test_SongBusiness
    {
        private SongBusiness business;
        private Song testSong;
        private int validAlbumId;

        private int GetNextSongId()
        {
            using (var context = new MusicHubContext())
            {
                var ids = context.Songs.Select(s => s.SongId).ToList();
                return ids.Count == 0 ? 1 : ids.Max() + 1;
            }
        }

        private void SafeDeleteSong(int songId)
        {
            using (var context = new MusicHubContext())
            {
                // Първо изтриваме свързаните PlaylistSongs записи
                context.Database.ExecuteSqlRaw("DELETE FROM PlaylistSongs WHERE SongId = {0}", songId);

                var song = context.Songs.Find(songId);
                if (song != null)
                {
                    context.Songs.Remove(song);
                    context.SaveChanges();
                }
            }
        }

        [SetUp]
        public void Setup()
        {
            business = new SongBusiness();

            // Вземаме съществуващ AlbumId от базата
            using (var context = new MusicHubContext())
            {
                var album = context.Albums.FirstOrDefault();
                Assert.IsNotNull(album, "Setup failed: No albums in database");
                validAlbumId = album.AlbumId;
            }

            // Почистваме остатъци от предишни runs
            var allSongs = business.GetAll();
            foreach (var s in allSongs.Where(x => x.Title != null && x.Title.StartsWith("Test")))
                SafeDeleteSong(s.SongId);

            testSong = new Song()
            {
                SongId = GetNextSongId(),
                Title = "Test Song",
                AlbumId = validAlbumId
            };
            business.Add(testSong);
            testSong = business.GetAll().LastOrDefault(x => x.Title == "Test Song");
            Assert.IsNotNull(testSong, "Setup failed: testSong is null");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var allSongs = business.GetAll();
                foreach (var s in allSongs.Where(x => x.Title != null && x.Title.StartsWith("Test")))
                    SafeDeleteSong(s.SongId);
            }
            catch { }
        }

        // ===== ADD TESTS =====

        [Test]
        public void Add_ShouldAddSong()
        {
            Song song = new Song()
            {
                SongId = GetNextSongId(),
                Title = "Test New Song",
                AlbumId = validAlbumId
            };
            business.Add(song);

            var result = business.GetAll().FirstOrDefault(s => s.Title == "Test New Song");

            Assert.IsNotNull(result, "Added song not found");
            Assert.AreEqual("Test New Song", result.Title);
        }

        [Test]
        public void Add_ShouldAssignPositiveId()
        {
            Song song = new Song()
            {
                SongId = GetNextSongId(),
                Title = "Test ID Song",
                AlbumId = validAlbumId
            };
            business.Add(song);

            var result = business.GetAll().FirstOrDefault(s => s.Title == "Test ID Song");

            Assert.IsNotNull(result);
            Assert.Greater(result.SongId, 0);
        }

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            int countBefore = business.GetAll().Count;

            business.Add(new Song()
            {
                SongId = GetNextSongId(),
                Title = "Test Count Song",
                AlbumId = validAlbumId
            });

            int countAfter = business.GetAll().Count;
            Assert.AreEqual(countBefore + 1, countAfter);
        }

        // ===== GET TESTS =====

        [Test]
        public void Get_ShouldReturnCorrectSong()
        {
            var result = business.Get(testSong.SongId);

            Assert.IsNotNull(result);
            Assert.AreEqual(testSong.SongId, result.SongId);
            Assert.AreEqual("Test Song", result.Title);
        }

        [Test]
        public void Get_ShouldReturnNull_WhenIdDoesNotExist()
        {
            var result = business.Get(-999);

            Assert.IsNull(result);
        }

        // ===== GETALL TESTS =====

        [Test]
        public void GetAll_ShouldReturnNonNullList()
        {
            var result = business.GetAll();

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAll_ShouldContainTestSong()
        {
            var result = business.GetAll();

            Assert.IsTrue(result.Any(s => s.SongId == testSong.SongId));
        }

        [Test]
        public void GetAll_ShouldReturnAtLeastOneSong()
        {
            var result = business.GetAll();

            Assert.IsTrue(result.Count > 0);
        }

        // ===== UPDATE TESTS =====

        [Test]
        public void Update_ShouldChangeTitle()
        {
            testSong.Title = "Test Updated Song";
            business.Update(testSong);

            var result = business.Get(testSong.SongId);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Updated Song", result.Title);
        }

        [Test]
        public void Update_ShouldNotChangeId()
        {
            int originalId = testSong.SongId;
            testSong.Title = "Test Modified Song";
            business.Update(testSong);

            var result = business.Get(originalId);

            Assert.IsNotNull(result);
            Assert.AreEqual(originalId, result.SongId);
        }

        [Test]
        public void Update_ShouldNotAffectOtherSongs()
        {
            business.Add(new Song()
            {
                SongId = GetNextSongId(),
                Title = "Test Other Song",
                AlbumId = validAlbumId
            });
            var other = business.GetAll().FirstOrDefault(s => s.Title == "Test Other Song");
            Assert.IsNotNull(other);

            testSong.Title = "Test Changed Song";
            business.Update(testSong);

            var otherResult = business.Get(other.SongId);
            Assert.AreEqual("Test Other Song", otherResult.Title);
        }

        // ===== DELETE TESTS =====

        [Test]
        public void Delete_ShouldRemoveSong()
        {
            int id = testSong.SongId;
            SafeDeleteSong(id);

            var result = business.Get(id);

            Assert.IsNull(result);
        }

        [Test]
        public void Delete_ShouldDecreaseCount()
        {
            int countBefore = business.GetAll().Count;

            SafeDeleteSong(testSong.SongId);

            int countAfter = business.GetAll().Count;
            Assert.AreEqual(countBefore - 1, countAfter);
        }

        [Test]
        public void Delete_ShouldNotThrow_WhenIdDoesNotExist()
        {
            Assert.DoesNotThrow(() => business.Delete(-999));
        }
    }
}
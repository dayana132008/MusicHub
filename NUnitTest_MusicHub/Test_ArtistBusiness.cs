using MusicHub.Data.Models;
using System.Linq;
using MusicHub.Business;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

namespace NUnitTest_MusicHub
{
    [TestFixture]
    internal class Test_ArtistBusiness
    {
        private ArtistBusiness business;
        private Artist testArtist;

        private int GetNextArtistId()
        {
            using (var context = new MusicHubContext())
            {
                var ids = context.Artists.Select(a => a.ArtistId).ToList();
                return ids.Count == 0 ? 1 : ids.Max() + 1;
            }
        }

        private void SafeDeleteArtist(int artistId)
        {
            using (var context = new MusicHubContext())
            {
                // Първо изтриваме свързаните Songs към Albums на този артист
                var albumIds = context.Albums
                    .Where(a => a.ArtistId == artistId)
                    .Select(a => a.AlbumId)
                    .ToList();

                foreach (var albumId in albumIds)
                {
                    var songIds = context.Songs
                        .Where(s => s.AlbumId == albumId)
                        .Select(s => s.SongId)
                        .ToList();

                    foreach (var songId in songIds)
                        context.Database.ExecuteSqlRaw("DELETE FROM PlaylistSongs WHERE SongId = {0}", songId);

                    context.Database.ExecuteSqlRaw("DELETE FROM Songs WHERE AlbumId = {0}", albumId);
                }

                // После изтриваме Albums
                context.Database.ExecuteSqlRaw("DELETE FROM Albums WHERE ArtistId = {0}", artistId);

                // Накрая изтриваме Artist
                var artist = context.Artists.Find(artistId);
                if (artist != null)
                {
                    context.Artists.Remove(artist);
                    context.SaveChanges();
                }
            }
        }

        [SetUp]
        public void Setup()
        {
            business = new ArtistBusiness();

            // Почистваме остатъци от предишни runs
            var allArtists = business.GetAll();
            foreach (var a in allArtists.Where(x => x.Name != null && x.Name.StartsWith("Test")))
                SafeDeleteArtist(a.ArtistId);

            testArtist = new Artist()
            {
                ArtistId = GetNextArtistId(),
                Name = "Test Artist",
                Country = "Bulgaria",
                Genre = "Pop"
            };
            business.Add(testArtist);
            testArtist = business.GetAll().LastOrDefault(x => x.Name == "Test Artist");
            Assert.IsNotNull(testArtist, "Setup failed: testArtist is null");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var allArtists = business.GetAll();
                foreach (var a in allArtists.Where(x => x.Name != null && x.Name.StartsWith("Test")))
                    SafeDeleteArtist(a.ArtistId);
            }
            catch { }
        }

        // ===== ADD TESTS =====

        [Test]
        public void Add_ShouldAddArtist()
        {
            Artist artist = new Artist()
            {
                ArtistId = GetNextArtistId(),
                Name = "Test New Artist",
                Country = "Bulgaria",
                Genre = "Rock"
            };
            business.Add(artist);

            var result = business.GetAll().FirstOrDefault(a => a.Name == "Test New Artist");

            Assert.IsNotNull(result, "Added artist not found");
            Assert.AreEqual("Test New Artist", result.Name);
        }

        [Test]
        public void Add_ShouldAssignPositiveId()
        {
            Artist artist = new Artist()
            {
                ArtistId = GetNextArtistId(),
                Name = "Test ID Artist",
                Country = "Bulgaria",
                Genre = "Jazz"
            };
            business.Add(artist);

            var result = business.GetAll().FirstOrDefault(a => a.Name == "Test ID Artist");

            Assert.IsNotNull(result);
            Assert.Greater(result.ArtistId, 0);
        }

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            int countBefore = business.GetAll().Count;

            business.Add(new Artist()
            {
                ArtistId = GetNextArtistId(),
                Name = "Test Count Artist",
                Country = "Bulgaria",
                Genre = "Pop"
            });

            int countAfter = business.GetAll().Count;
            Assert.AreEqual(countBefore + 1, countAfter);
        }

        // ===== GET TESTS =====

        [Test]
        public void Get_ShouldReturnCorrectArtist()
        {
            var result = business.Get(testArtist.ArtistId);

            Assert.IsNotNull(result);
            Assert.AreEqual(testArtist.ArtistId, result.ArtistId);
            Assert.AreEqual("Test Artist", result.Name);
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
        public void GetAll_ShouldContainTestArtist()
        {
            var result = business.GetAll();

            Assert.IsTrue(result.Any(a => a.ArtistId == testArtist.ArtistId));
        }

        [Test]
        public void GetAll_ShouldReturnAtLeastOneArtist()
        {
            var result = business.GetAll();

            Assert.IsTrue(result.Count > 0);
        }

        // ===== UPDATE TESTS =====

        [Test]
        public void Update_ShouldChangeName()
        {
            testArtist.Name = "Test Updated Artist";
            business.Update(testArtist);

            var result = business.Get(testArtist.ArtistId);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Updated Artist", result.Name);
        }

        [Test]
        public void Update_ShouldNotChangeId()
        {
            int originalId = testArtist.ArtistId;
            testArtist.Name = "Test Modified Artist";
            business.Update(testArtist);

            var result = business.Get(originalId);

            Assert.IsNotNull(result);
            Assert.AreEqual(originalId, result.ArtistId);
        }

        [Test]
        public void Update_ShouldNotAffectOtherArtists()
        {
            business.Add(new Artist()
            {
                ArtistId = GetNextArtistId(),
                Name = "Test Other Artist",
                Country = "Serbia",
                Genre = "Rock"
            });
            var other = business.GetAll().FirstOrDefault(a => a.Name == "Test Other Artist");
            Assert.IsNotNull(other);

            testArtist.Name = "Test Changed Name";
            business.Update(testArtist);

            var otherResult = business.Get(other.ArtistId);
            Assert.AreEqual("Test Other Artist", otherResult.Name);
        }

        // ===== DELETE TESTS =====

        [Test]
        public void Delete_ShouldRemoveArtist()
        {
            int id = testArtist.ArtistId;
            SafeDeleteArtist(id);

            var result = business.Get(id);

            Assert.IsNull(result);
        }

        [Test]
        public void Delete_ShouldDecreaseCount()
        {
            int countBefore = business.GetAll().Count;

            SafeDeleteArtist(testArtist.ArtistId);

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
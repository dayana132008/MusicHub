using MusicHub.Data.Models;
using System.Linq;
using MusicHub.Business;
using NUnit.Framework;

namespace NUnitTest_MusicHub
{
    [TestFixture]
    internal class Test_AlbumBusiness
    {
        private AlbumBusiness business;
        private Album testAlbum;
        private int validArtistId;

        private int GetNextAlbumId()
        {
            using (var context = new MusicHubContext())
            {
                var ids = context.Albums.Select(a => a.AlbumId).ToList();
                return ids.Count == 0 ? 1 : ids.Max() + 1;
            }
        }

        [SetUp]
        public void Setup()
        {
            business = new AlbumBusiness();

            // Вземаме съществуващ ArtistId от базата
            using (var context = new MusicHubContext())
            {
                var artist = context.Artists.FirstOrDefault();
                Assert.IsNotNull(artist, "Setup failed: No artists in database");
                validArtistId = artist.ArtistId;
            }

            // Почистваме остатъци от предишни runs
            var allAlbums = business.GetAll();
            foreach (var a in allAlbums.Where(x => x.Title != null && x.Title.StartsWith("Test")))
                business.Delete(a.AlbumId);

            testAlbum = new Album()
            {
                AlbumId = GetNextAlbumId(),
                Title = "Test Album",
                ArtistId = validArtistId
            };
            business.Add(testAlbum);
            testAlbum = business.GetAll().LastOrDefault(x => x.Title == "Test Album");
            Assert.IsNotNull(testAlbum, "Setup failed: testAlbum is null");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var allAlbums = business.GetAll();
                foreach (var a in allAlbums.Where(x => x.Title != null && x.Title.StartsWith("Test")))
                    business.Delete(a.AlbumId);
            }
            catch { }
        }

        // ===== ADD TESTS =====

        [Test]
        public void Add_ShouldAddAlbum()
        {
            Album album = new Album()
            {
                AlbumId = GetNextAlbumId(),
                Title = "Test New Album",
                ArtistId = validArtistId
            };
            business.Add(album);

            var result = business.GetAll().FirstOrDefault(a => a.Title == "Test New Album");

            Assert.IsNotNull(result, "Added album not found");
            Assert.AreEqual("Test New Album", result.Title);
        }

        [Test]
        public void Add_ShouldAssignPositiveId()
        {
            Album album = new Album()
            {
                AlbumId = GetNextAlbumId(),
                Title = "Test ID Album",
                ArtistId = validArtistId
            };
            business.Add(album);

            var result = business.GetAll().FirstOrDefault(a => a.Title == "Test ID Album");

            Assert.IsNotNull(result);
            Assert.Greater(result.AlbumId, 0);
        }

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            int countBefore = business.GetAll().Count;

            business.Add(new Album()
            {
                AlbumId = GetNextAlbumId(),
                Title = "Test Count Album",
                ArtistId = validArtistId
            });

            int countAfter = business.GetAll().Count;
            Assert.AreEqual(countBefore + 1, countAfter);
        }

        // ===== GET TESTS =====

        [Test]
        public void Get_ShouldReturnCorrectAlbum()
        {
            var result = business.Get(testAlbum.AlbumId);

            Assert.IsNotNull(result);
            Assert.AreEqual(testAlbum.AlbumId, result.AlbumId);
            Assert.AreEqual("Test Album", result.Title);
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
        public void GetAll_ShouldContainTestAlbum()
        {
            var result = business.GetAll();

            Assert.IsTrue(result.Any(a => a.AlbumId == testAlbum.AlbumId));
        }

        [Test]
        public void GetAll_ShouldReturnAtLeastOneAlbum()
        {
            var result = business.GetAll();

            Assert.IsTrue(result.Count > 0);
        }

        // ===== UPDATE TESTS =====

        [Test]
        public void Update_ShouldChangeTitle()
        {
            testAlbum.Title = "Test Updated Album";
            business.Update(testAlbum);

            var result = business.Get(testAlbum.AlbumId);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Updated Album", result.Title);
        }

        [Test]
        public void Update_ShouldNotChangeId()
        {
            int originalId = testAlbum.AlbumId;
            testAlbum.Title = "Test Modified Album";
            business.Update(testAlbum);

            var result = business.Get(originalId);

            Assert.IsNotNull(result);
            Assert.AreEqual(originalId, result.AlbumId);
        }

        [Test]
        public void Update_ShouldNotAffectOtherAlbums()
        {
            business.Add(new Album()
            {
                AlbumId = GetNextAlbumId(),
                Title = "Test Other Album",
                ArtistId = validArtistId
            });
            var other = business.GetAll().FirstOrDefault(a => a.Title == "Test Other Album");
            Assert.IsNotNull(other);

            testAlbum.Title = "Test Changed Title";
            business.Update(testAlbum);

            var otherResult = business.Get(other.AlbumId);
            Assert.AreEqual("Test Other Album", otherResult.Title);
        }

        // ===== DELETE TESTS =====

        [Test]
        public void Delete_ShouldRemoveAlbum()
        {
            int id = testAlbum.AlbumId;
            business.Delete(id);

            var result = business.Get(id);

            Assert.IsNull(result);
        }

        [Test]
        public void Delete_ShouldDecreaseCount()
        {
            int countBefore = business.GetAll().Count;

            business.Delete(testAlbum.AlbumId);

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
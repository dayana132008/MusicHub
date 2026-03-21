using MusicHub.Data.Models;
using System.Linq;
using MusicHub.Business;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

namespace NUnitTest_MusicHub
{
    [TestFixture]
    internal class Test_PlaylistBusiness
    {
        private PlaylistBusiness business;
        private Playlist testPlaylist;

        private int GetNextPlaylistId()
        {
            using (var context = new MusicHubContext())
            {
                var ids = context.Playlists.Select(p => p.PlaylistId).ToList();
                return ids.Count == 0 ? 1 : ids.Max() + 1;
            }
        }

        private void SafeDeletePlaylist(int playlistId)
        {
            using (var context = new MusicHubContext())
            {
                // Първо изтриваме свързаните UserPlaylists и PlaylistSongs записи
                context.Database.ExecuteSqlRaw("DELETE FROM UserPlaylists WHERE PlaylistId = {0}", playlistId);
                context.Database.ExecuteSqlRaw("DELETE FROM PlaylistSongs WHERE PlaylistId = {0}", playlistId);

                var playlist = context.Playlists.Find(playlistId);
                if (playlist != null)
                {
                    context.Playlists.Remove(playlist);
                    context.SaveChanges();
                }
            }
        }

        [SetUp]
        public void Setup()
        {
            business = new PlaylistBusiness();

            // Почистваме остатъци от предишни runs
            var allPlaylists = business.GetAll();
            foreach (var p in allPlaylists.Where(x => x.Name != null && x.Name.StartsWith("Test")))
                SafeDeletePlaylist(p.PlaylistId);

            testPlaylist = new Playlist()
            {
                PlaylistId = GetNextPlaylistId(),
                Name = "Test Playlist"
            };
            business.Add(testPlaylist);
            testPlaylist = business.GetAll().LastOrDefault(x => x.Name == "Test Playlist");
            Assert.IsNotNull(testPlaylist, "Setup failed: testPlaylist is null");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var allPlaylists = business.GetAll();
                foreach (var p in allPlaylists.Where(x => x.Name != null && x.Name.StartsWith("Test")))
                    SafeDeletePlaylist(p.PlaylistId);
            }
            catch { }
        }

        // ===== ADD TESTS =====

        [Test]
        public void Add_ShouldAddPlaylist()
        {
            Playlist playlist = new Playlist()
            {
                PlaylistId = GetNextPlaylistId(),
                Name = "Test New Playlist"
            };
            business.Add(playlist);

            var result = business.GetAll().FirstOrDefault(p => p.Name == "Test New Playlist");

            Assert.IsNotNull(result, "Added playlist not found");
            Assert.AreEqual("Test New Playlist", result.Name);
        }

        [Test]
        public void Add_ShouldAssignPositiveId()
        {
            Playlist playlist = new Playlist()
            {
                PlaylistId = GetNextPlaylistId(),
                Name = "Test ID Playlist"
            };
            business.Add(playlist);

            var result = business.GetAll().FirstOrDefault(p => p.Name == "Test ID Playlist");

            Assert.IsNotNull(result);
            Assert.Greater(result.PlaylistId, 0);
        }

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            int countBefore = business.GetAll().Count;

            business.Add(new Playlist()
            {
                PlaylistId = GetNextPlaylistId(),
                Name = "Test Count Playlist"
            });

            int countAfter = business.GetAll().Count;
            Assert.AreEqual(countBefore + 1, countAfter);
        }

        // ===== GET TESTS =====

        [Test]
        public void Get_ShouldReturnCorrectPlaylist()
        {
            var result = business.Get(testPlaylist.PlaylistId);

            Assert.IsNotNull(result);
            Assert.AreEqual(testPlaylist.PlaylistId, result.PlaylistId);
            Assert.AreEqual("Test Playlist", result.Name);
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
        public void GetAll_ShouldContainTestPlaylist()
        {
            var result = business.GetAll();

            Assert.IsTrue(result.Any(p => p.PlaylistId == testPlaylist.PlaylistId));
        }

        [Test]
        public void GetAll_ShouldReturnAtLeastOnePlaylist()
        {
            var result = business.GetAll();

            Assert.IsTrue(result.Count > 0);
        }

        // ===== UPDATE TESTS =====

        [Test]
        public void Update_ShouldChangeName()
        {
            testPlaylist.Name = "Test Updated Playlist";
            business.Update(testPlaylist);

            var result = business.Get(testPlaylist.PlaylistId);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Updated Playlist", result.Name);
        }

        [Test]
        public void Update_ShouldNotChangeId()
        {
            int originalId = testPlaylist.PlaylistId;
            testPlaylist.Name = "Test Modified Playlist";
            business.Update(testPlaylist);

            var result = business.Get(originalId);

            Assert.IsNotNull(result);
            Assert.AreEqual(originalId, result.PlaylistId);
        }

        [Test]
        public void Update_ShouldNotAffectOtherPlaylists()
        {
            business.Add(new Playlist()
            {
                PlaylistId = GetNextPlaylistId(),
                Name = "Test Other Playlist"
            });
            var other = business.GetAll().FirstOrDefault(p => p.Name == "Test Other Playlist");
            Assert.IsNotNull(other);

            testPlaylist.Name = "Test Changed Playlist";
            business.Update(testPlaylist);

            var otherResult = business.Get(other.PlaylistId);
            Assert.AreEqual("Test Other Playlist", otherResult.Name);
        }

        // ===== DELETE TESTS =====

        [Test]
        public void Delete_ShouldRemovePlaylist()
        {
            int id = testPlaylist.PlaylistId;
            SafeDeletePlaylist(id);

            var result = business.Get(id);

            Assert.IsNull(result);
        }

        [Test]
        public void Delete_ShouldDecreaseCount()
        {
            int countBefore = business.GetAll().Count;

            SafeDeletePlaylist(testPlaylist.PlaylistId);

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
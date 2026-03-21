using MusicHub.Data.Models;
using System.Linq;
using MusicHub.Business;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

namespace NUnitTest_MusicHub
{
    [TestFixture]
    internal class Test_UserBusiness
    {
        private UserBusiness business;
        private User testUser;

        private int GetNextUserId()
        {
            using (var context = new MusicHubContext())
            {
                var ids = context.Users.Select(u => u.UserId).ToList();
                return ids.Count == 0 ? 1 : ids.Max() + 1;
            }
        }

        private void SafeDeleteUser(int userId)
        {
            using (var context = new MusicHubContext())
            {
                // Първо изтриваме свързаните UserPlaylists записи
                var userPlaylists = context.Database
                    .ExecuteSqlRaw("DELETE FROM UserPlaylists WHERE UserId = {0}", userId);

                var user = context.Users.Find(userId);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        [SetUp]
        public void Setup()
        {
            business = new UserBusiness();

            // Почистваме остатъци от предишни runs
            var allUsers = business.GetAll();
            foreach (var u in allUsers.Where(x => x.Username != null && x.Username.StartsWith("test")))
                SafeDeleteUser(u.UserId);

            testUser = new User()
            {
                UserId = GetNextUserId(),
                Username = "testuser",
                Email = "testuser@test.com"
            };
            business.Add(testUser);
            testUser = business.GetAll().LastOrDefault(x => x.Username == "testuser");
            Assert.IsNotNull(testUser, "Setup failed: testUser is null");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var allUsers = business.GetAll();
                foreach (var u in allUsers.Where(x => x.Username != null && x.Username.StartsWith("test")))
                    SafeDeleteUser(u.UserId);
            }
            catch { }
        }

        // ===== ADD TESTS =====

        [Test]
        public void Add_ShouldAddUser()
        {
            User user = new User()
            {
                UserId = GetNextUserId(),
                Username = "testnewuser",
                Email = "testnewuser@test.com"
            };
            business.Add(user);

            var result = business.GetAll().FirstOrDefault(u => u.Username == "testnewuser");

            Assert.IsNotNull(result, "Added user not found");
            Assert.AreEqual("testnewuser", result.Username);
        }

        [Test]
        public void Add_ShouldAssignPositiveId()
        {
            User user = new User()
            {
                UserId = GetNextUserId(),
                Username = "testiduser",
                Email = "testiduser@test.com"
            };
            business.Add(user);

            var result = business.GetAll().FirstOrDefault(u => u.Username == "testiduser");

            Assert.IsNotNull(result);
            Assert.Greater(result.UserId, 0);
        }

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            int countBefore = business.GetAll().Count;

            business.Add(new User()
            {
                UserId = GetNextUserId(),
                Username = "testcountuser",
                Email = "testcountuser@test.com"
            });

            int countAfter = business.GetAll().Count;
            Assert.AreEqual(countBefore + 1, countAfter);
        }

        // ===== GET TESTS =====

        [Test]
        public void Get_ShouldReturnCorrectUser()
        {
            var result = business.Get(testUser.UserId);

            Assert.IsNotNull(result);
            Assert.AreEqual(testUser.UserId, result.UserId);
            Assert.AreEqual("testuser", result.Username);
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
        public void GetAll_ShouldContainTestUser()
        {
            var result = business.GetAll();

            Assert.IsTrue(result.Any(u => u.UserId == testUser.UserId));
        }

        [Test]
        public void GetAll_ShouldReturnAtLeastOneUser()
        {
            var result = business.GetAll();

            Assert.IsTrue(result.Count > 0);
        }

        // ===== UPDATE TESTS =====

        [Test]
        public void Update_ShouldChangeUsername()
        {
            testUser.Username = "testupdateduser";
            testUser.Email = "testupdateduser@test.com";
            business.Update(testUser);

            var result = business.Get(testUser.UserId);

            Assert.IsNotNull(result);
            Assert.AreEqual("testupdateduser", result.Username);
        }

        [Test]
        public void Update_ShouldNotChangeId()
        {
            int originalId = testUser.UserId;
            testUser.Username = "testmodifieduser";
            testUser.Email = "testmodifieduser@test.com";
            business.Update(testUser);

            var result = business.Get(originalId);

            Assert.IsNotNull(result);
            Assert.AreEqual(originalId, result.UserId);
        }

        [Test]
        public void Update_ShouldNotAffectOtherUsers()
        {
            business.Add(new User()
            {
                UserId = GetNextUserId(),
                Username = "testotheruser",
                Email = "testotheruser@test.com"
            });
            var other = business.GetAll().FirstOrDefault(u => u.Username == "testotheruser");
            Assert.IsNotNull(other);

            testUser.Username = "testchangeduser";
            testUser.Email = "testchangeduser@test.com";
            business.Update(testUser);

            var otherResult = business.Get(other.UserId);
            Assert.AreEqual("testotheruser", otherResult.Username);
        }

        // ===== DELETE TESTS =====

        [Test]
        public void Delete_ShouldRemoveUser()
        {
            int id = testUser.UserId;
            SafeDeleteUser(id);

            var result = business.Get(id);

            Assert.IsNull(result);
        }

        [Test]
        public void Delete_ShouldDecreaseCount()
        {
            int countBefore = business.GetAll().Count;

            SafeDeleteUser(testUser.UserId);

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
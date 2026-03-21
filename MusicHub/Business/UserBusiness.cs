using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MusicHub.Business
{
    /// <summary>
    /// Provides business logic operations for managing users.
    /// Handles CRUD operations (Create, Read, Update, Delete) for User entities.
    /// </summary>
    public class UserBusiness
    {
        private MusicHubContext userContext;
        public List<User> GetAll()
        {
            using (userContext = new MusicHubContext())
            {
                return userContext.Users.ToList();
            }
        }
        public User Get(int id)
        {
            using (userContext = new MusicHubContext())
            {
                return userContext.Users.Find(id);
            }
        }
        public void Add(User user)
        {
            using (userContext = new MusicHubContext())
            {
                userContext.Users.Add(user);
                userContext.SaveChanges();
            }
        }
        public void Update(User user)
        {
            using (userContext = new MusicHubContext())
            {
                var item = userContext.Users.Find(user.UserId); // ПОПРАВЕНО: беше Find(user)
                if (item != null)
                {
                    userContext.Entry(item).CurrentValues.SetValues(user);
                    userContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using (userContext = new MusicHubContext())
            {
                var league = userContext.Users.Find(id);
                if (league != null)
                {
                    userContext.Users.Remove(league);
                    userContext.SaveChanges();
                }
            }
        }
    }
}
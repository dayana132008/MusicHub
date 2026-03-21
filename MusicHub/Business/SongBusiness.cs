using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MusicHub.Business
{
    /// <summary>
    /// Provides business logic operations for managing songs.
    /// Handles CRUD operations (Create, Read, Update, Delete) for Song entities.
    /// </summary>
    public class SongBusiness
    {
        private MusicHubContext songContext;
        public List<Song> GetAll()
        {
            using (songContext = new MusicHubContext())
            {
                return songContext.Songs.ToList();
            }
        }
        public Song Get(int id)
        {
            using (songContext = new MusicHubContext())
            {
                return songContext.Songs.Find(id);
            }
        }
        public void Add(Song song)
        {
            using (songContext = new MusicHubContext())
            {
                songContext.Songs.Add(song);
                songContext.SaveChanges();
            }
        }
        public void Update(Song song)
        {
            using (songContext = new MusicHubContext())
            {
                var item = songContext.Songs.Find(song.SongId); // ПОПРАВЕНО: беше Find(song)
                if (item != null)
                {
                    songContext.Entry(item).CurrentValues.SetValues(song);
                    songContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using (songContext = new MusicHubContext())
            {
                var league = songContext.Songs.Find(id);
                if (league != null)
                {
                    songContext.Songs.Remove(league);
                    songContext.SaveChanges();
                }
            }
        }
    }
}
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Business
{
    /// <summary>
    /// Provides business logic operations for managing albums.
    /// Handles CRUD operations (Create, Read, Update, Delete) for Album entities.
    /// </summary>
    public class AlbumBusiness
    {
        private MusicHubContext albumContext;

        public List<Album> GetAll()
        {
            using (albumContext = new MusicHubContext())
            {
                return albumContext.Albums.ToList();
            }
        }

        public Album Get(int id)
        {
            using (albumContext = new MusicHubContext())
            {
                return albumContext.Albums.Find(id);
            }

        }

        public void Add(Album album)
        {
            using (albumContext = new MusicHubContext())
            {
                albumContext.Albums.Add(album);
                albumContext.SaveChanges();
            }
        }

        public void Update(Album album)
        {
            using (albumContext = new MusicHubContext())
            {
                var item = albumContext.Albums.Find(album.AlbumId);
                if (item != null)
                {
                    albumContext.Entry(item).CurrentValues.SetValues(album);
                    albumContext.SaveChanges();
                }
            }

        }

        public void Delete(int id)
        {
            using (albumContext = new MusicHubContext())
            {
                var league = albumContext.Albums.Find(id);
                if (league != null)
                {
                    albumContext.Albums.Remove(league);
                    albumContext.SaveChanges();
                }
            }

        }
    }
}

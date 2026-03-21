using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Business
{
    /// <summary>
    /// Provides business logic operations for managing artists.
    /// Handles CRUD operations (Create, Read, Update, Delete) for Artist entities.
    /// </summary>
    public class ArtistBusiness
    {
        private MusicHubContext artistContext;
        public List<Artist> GetAll()
        {
            using (artistContext = new MusicHubContext())
            {
                return artistContext.Artists.ToList();
            }
        }

        public Artist Get(int id)
        {
            using (artistContext = new MusicHubContext())
            {
                return artistContext.Artists.Find(id);
            }

        }

        public void Add(Artist artist)
        {
            using (artistContext = new MusicHubContext())
            {
                artistContext.Artists.Add(artist);
                artistContext.SaveChanges();
            }
        }

        public void Update(Artist artist)
        {
            using (artistContext = new MusicHubContext())
            {
                var item = artistContext.Artists.Find(artist.ArtistId);
                if (item != null)
                {
                    artistContext.Entry(item).CurrentValues.SetValues(artist);
                    artistContext.SaveChanges();
                }
            }

        }

        public void Delete(int id)
        {
            using (artistContext = new MusicHubContext())
            {
                var league = artistContext.Artists.Find(id);
                if (league != null)
                {
                    artistContext.Artists.Remove(league);
                    artistContext.SaveChanges();
                }
            }

        }
    }

}


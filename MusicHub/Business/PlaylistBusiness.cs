using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MusicHub.Business
{
    /// <summary>
    /// Provides business logic operations for managing playlists.
    /// Handles CRUD operations (Create, Read, Update, Delete) for Playlist entities.
    /// </summary>
    public class PlaylistBusiness
    {
        private MusicHubContext playlistContext;
        public List<Playlist> GetAll()
        {
            using (playlistContext = new MusicHubContext())
            {
                return playlistContext.Playlists.ToList();
            }
        }
        public Playlist Get(int id)
        {
            using (playlistContext = new MusicHubContext())
            {
                return playlistContext.Playlists.Find(id);
            }
        }
        public void Add(Playlist playlist)
        {
            using (playlistContext = new MusicHubContext())
            {
                playlistContext.Playlists.Add(playlist);
                playlistContext.SaveChanges();
            }
        }
        public void Update(Playlist playlist)
        {
            using (playlistContext = new MusicHubContext())
            {
                var item = playlistContext.Playlists.Find(playlist.PlaylistId); // ПОПРАВЕНО: беше Artists.Find
                if (item != null)
                {
                    playlistContext.Entry(item).CurrentValues.SetValues(playlist);
                    playlistContext.SaveChanges();
                }
            }
        }
        public void Delete(int id)
        {
            using (playlistContext = new MusicHubContext())
            {
                var league = playlistContext.Playlists.Find(id);
                if (league != null)
                {
                    playlistContext.Playlists.Remove(league);
                    playlistContext.SaveChanges();
                }
            }
        }
    }
}
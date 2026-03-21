using System;
using System.Collections.Generic;

namespace MusicHub.Data.Models;
/// <summary>
/// Represents a song with a title, duration, and associated album.
/// Contains validation for SongId (must be greater than 0)
/// and Duration (cannot be longer than 480 seconds).
/// A song can be part of multiple playlists.
/// </summary>
public partial class Song
{
    private int _songId;
    private int _duration;
    public int SongId
    {
        get { return _songId; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("SongId must be bigger than 0.");
            _songId = value;
        }
    }

    public string Title { get; set; } = null!;

    public int Duration
    {
        get { return _duration; }
        set
        {
            if (value>480)
                throw new ArgumentException("Duration cannot be longer than 480 seconds.");
            _duration = value;
        }
    }

    public int AlbumId { get; set; }

    public virtual Album Album { get; set; } = null!;

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}

using System;
using System.Collections.Generic;

namespace MusicHub.Data.Models;
/// <summary>
/// Represents a music album with a title, release year, and associated artist.
/// Contains validation for AlbumId (must be greater than 0)
/// and ReleaseYear (must be between 1900 and 2026).
/// An album can contain multiple songs.
/// </summary>
public partial class Album
{
    private int _releaseYear;
    private int _albumId;

    public int AlbumId
    {
        get { return _albumId; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("AlbumId must be bigger than 0.");
            _albumId = value;
        }
    }

    public string Title { get; set; } = null!;

    public int ReleaseYear
    {
        get { return _releaseYear; }
        set
        {
            if (value > 2026  || value < 1900)
                throw new ArgumentException("Release year cannot be greater than 2026 and less than 1900.");
            _releaseYear = value;
        }
    }
    public int ArtistId { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}

using System;
using System.Collections.Generic;

namespace MusicHub.Data.Models;
/// <summary>
/// Represents a playlist with a name and creation date.
/// Contains validation for PlaylistId (must be greater than 0)
/// and CreatedDate (cannot be in the future and cannot be before 1900).
/// A playlist can contain multiple songs and be associated with multiple users.
/// </summary>
public partial class Playlist
{
    private DateOnly _createdDate;
    private int _playlistId;
    public int PlaylistId
    {
        get { return _playlistId; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("PlaylistId must be bigger than 0.");
            _playlistId = value;
        }
    }

    public string Name { get; set; } = null!;

    public DateOnly CreatedDate
    {
        get { return _createdDate; }
        set
        {
            if (value > DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentException("Created date cannot be in the future.");

            if (value.Year < 1900)
                throw new ArgumentException("Created date is unrealistically old.");

            _createdDate = value;
        }
    }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

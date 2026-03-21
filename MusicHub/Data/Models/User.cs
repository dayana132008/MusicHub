using System;
using System.Collections.Generic;

namespace MusicHub.Data.Models;
/// <summary>
/// Represents a user with a username and email address.
/// Contains validation for UserId (must be greater than 0).
/// A user can be associated with multiple playlists.
/// </summary>
public partial class User
{
    private int _userId;
    public int UserId
    {
        get { return _userId; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("UserId must be bigger than 0.");
            _userId = value;
        }
    }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}

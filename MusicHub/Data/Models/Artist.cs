using System;
using System.Collections.Generic;

namespace MusicHub.Data.Models;
/// <summary>
/// Represents a music artist with a name, genre, and optional country of origin.
/// Contains validation for ArtistId (must be greater than 0)
/// and Country (cannot be longer than 30 characters).
/// An artist can have multiple albums.
/// </summary>
public partial class Artist
{
    private string _country;
    private int _artistId;
    public int ArtistId
    {
        get { return _artistId; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("ArtistId must be bigger than 0.");
            _artistId = value;
        }
    }

    public string Name { get; set; } = null!;

    public string? Country
    {
        get { return _country; }
        set
        {
            if (value.Length > 30)
                throw new ArgumentException("Country name cannot be longer than 30.");
            _country = value;
        }
    }

    public string Genre { get; set; } = null!;

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}

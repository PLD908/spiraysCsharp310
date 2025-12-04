using System;

namespace MusicPlaylistApp.Models
{
    /// <summary>
    /// Represents a song entry in the playlist.
    /// Inherits from MediaItem (demonstrates inheritance).
    /// </summary>
    public class Song : MediaItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public Artist Artist { get; set; }
        public double Duration { get; set; } // in minutes

        public Song(string title, Artist artist, string genre, double duration)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            Duration = duration;
        }

        public override string DisplayInfo()
        {
            return $"{Title} by {Artist.Name} — {Genre} ({Duration} min)";
        }

        public override string ToString() => DisplayInfo();
    }
}

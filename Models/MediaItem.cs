namespace MusicPlaylistApp.Models
{
    /// <summary>
    /// Abstract base class for media items (songs, podcasts, etc.).
    /// Demonstrates inheritance using abstract and override keywords.
    /// </summary>
    public abstract class MediaItem
    {
        public string Title { get; set; } = "";
        public string Genre { get; set; } = "";

        // Abstract method to display item info
        public abstract string DisplayInfo();
    }
}

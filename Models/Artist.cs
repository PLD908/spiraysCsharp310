namespace MusicPlaylistApp.Models
{
    /// <summary>
    /// Simple structure to represent an artist (demonstrates 'struct' requirement).
    /// </summary>
    public struct Artist
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public Artist(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public override string ToString()
        {
            return $"{Name} ({Country})";
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using MusicPlaylistApp.Models;

namespace MusicPlaylistApp.Services
{
    /// <summary>
    /// Handles loading, saving, and managing songs in the playlist.
    /// </summary>
    public class PlaylistManager
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public List<Song> Songs { get; private set; } = new();

        public PlaylistManager(string filePath)
        {
            _filePath = filePath;
        }

        public void Load()
        {
            if (!File.Exists(_filePath))
            {
                Save();
                return;
            }

            try
            {
                var json = File.ReadAllText(_filePath);
                Songs = JsonSerializer.Deserialize<List<Song>>(json, _jsonOptions) ?? new List<Song>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading songs: {ex.Message}");
                Songs = new List<Song>();
            }
        }

        public void Save()
        {
            try
            {
                var json = JsonSerializer.Serialize(Songs, _jsonOptions);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving songs: {ex.Message}");
            }
        }

        public void AddSong(Song song)
        {
            Songs.Add(song);
            Save();
        }

        public bool RemoveSong(string title)
        {
            var song = Songs.FirstOrDefault(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (song == null) return false;
            Songs.Remove(song);
            Save();
            return true;
        }

        public List<Song> SearchByArtist(string artistName)
        {
            return Songs
                .Where(s => s.Artist.Name.Contains(artistName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void ListAllSongs()
        {
            if (Songs.Count == 0)
            {
                Console.WriteLine("🎵 No songs in playlist.");
                return;
            }

            foreach (var s in Songs)
            {
                Console.WriteLine($"- {s}");
            }
        }

        public double TotalDuration()
        {
            return Songs.Sum(s => s.Duration);
        }
    }
}

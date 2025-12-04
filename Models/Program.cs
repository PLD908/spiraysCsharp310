using System;
using MusicPlaylistApp.Models;
using MusicPlaylistApp.Services;
using System.IO;

namespace MusicPlaylistApp
{
    class Program
    {
        static PlaylistManager manager = null!;


        static void Main(string[] args)
        {
            string dataPath = Path.Combine(Environment.CurrentDirectory, "songs.json");
            manager = new PlaylistManager(dataPath);
            manager.Load();

            Console.Title = "🎧 Music Playlist Manager 🎶";
            bool exit = false;

            while (!exit)
            {
                ShowMenu();
                Console.Write("\nChoose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddSong(); break;
                    case "2": manager.ListAllSongs(); break;
                    case "3": SearchSongs(); break;
                    case "4": DeleteSong(); break;
                    case "5": ShowTotalDuration(); break;
                    case "0": exit = true; break;
                    default:
                        Console.WriteLine("❌ Invalid option. Try again.");
                        break;
                }
            }

            Console.WriteLine("Goodbye! 🎶");
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n=== MUSIC PLAYLIST MANAGER ===");
            Console.WriteLine("1) Add a new song");
            Console.WriteLine("2) List all songs");
            Console.WriteLine("3) Search by artist");
            Console.WriteLine("4) Delete a song");
            Console.WriteLine("5) Show total playlist duration");
            Console.WriteLine("0) Exit");
        }

        static void AddSong()
        {
            Console.Write("\nEnter song title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Artist name: ");
            string artistName = Console.ReadLine() ?? "";

            Console.Write("Artist country: ");
            string country = Console.ReadLine() ?? "";

            Console.Write("Genre: ");
            string genre = Console.ReadLine() ?? "";

            Console.Write("Duration (in minutes): ");
            double duration;
            while (!double.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.Write("Please enter a valid number: ");
            }

            var artist = new Artist(artistName, country);
            var song = new Song(title, artist, genre, duration);
            manager.AddSong(song);

            Console.WriteLine($"✅ Added: {song}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Song added successfully!");
            Console.ResetColor();

        }

        static void SearchSongs()
        {
            Console.Write("\nEnter artist name to search: ");
            string artistName = Console.ReadLine() ?? "";

            var results = manager.SearchByArtist(artistName);
            if (results.Count == 0)
            {
                Console.WriteLine("No songs found for that artist.");
                return;
            }

            Console.WriteLine($"\n🎤 Songs by {artistName}:");
            foreach (var s in results)
                Console.WriteLine($"- {s}");
        }

        static void DeleteSong()
        {
            Console.Write("\nEnter the song title to delete: ");
            string title = Console.ReadLine() ?? "";

            bool deleted = manager.RemoveSong(title);
            Console.WriteLine(deleted ? "🗑️ Song deleted." : "❌ Song not found.");
        }
        


        static void ShowTotalDuration()
        {
            double total = manager.TotalDuration();
            Console.WriteLine($"\nTotal playlist duration: {total:F2} minutes.");
        }
    }
}

# Overview

As a software engineer, I am continuously improving my understanding of object-oriented programming concepts and file handling in C#. For this project, I developed a **Music Playlist Manager** — a console-based application that allows users to create and manage a playlist of songs, view and search songs by genre or artist, and save or load playlists from a file.

The purpose of this project was to deepen my knowledge of **C# syntax**, **classes and inheritance**, and **file I/O operations**. I also implemented a **struct** to represent artists, demonstrating how C# supports both value and reference types in a unified type system.  

This program showcases key language features including:
- Variables, expressions, and conditionals  
- Loops, functions, and exception handling  
- Classes and abstract inheritance  
- Structs for lightweight data types  
- JSON file read/write for data persistence  


# Development Environment

I developed this project using **Visual Studio Code** and the **.NET 8.0 SDK** on Windows.

**Tools and Technologies:**
- **Language:** C#  
- **Framework:** .NET 8.0 Console Application  
- **Libraries:**  
  - `System` (core C# library)  
  - `System.IO` for reading/writing files  
  - `System.Text.Json` for data serialization  

**File Structure:**

SPIRAYSC#/
├── Program.cs
├── Models/
│ ├── Artist.cs
│ ├── MediaItem.cs
│ └── Song.cs
├── Services/
│ └── PlaylistManager.cs
├── songs.json
└── README.md



---

# Useful Websites

- [Microsoft C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [W3Schools C# Tutorial](https://www.w3schools.com/cs/)
- [GeeksforGeeks C# File Handling](https://www.geeksforgeeks.org/file-handling-in-c-sharp/)
- [JSON Serialization in C#](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview)

---

# Future Work

- Add feature to **play music previews** (using an API such as Spotify).  
- Add **user authentication** and multiple playlists.  
- Add **graphical interface (WPF or MAUI)** for better user experience.  


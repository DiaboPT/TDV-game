// Import necessary namespaces
using System;
using System.Collections.Generic;

// Declare the namespace for the SoundLibrary class
namespace JetBoxer2D.Game.Sound
{
    // Define enum for game songs
    public enum GameSongs
    {
        SplashScreen,
        Gameplay1,
        Gameplay2,
        Gameplay3,
        Gameplay4,
        Gameplay5,
        Gameplay6
    }

    // Define enum for game sound effects
    public enum GameSFX
    {
        Fireball
    }

    // Define the SoundLibrary static class
    public static class SoundLibrary
    {
        // Dictionary to map GameSongs to their respective file paths
        private static Dictionary<GameSongs, string> _gameSongs = new()
        {
            {GameSongs.SplashScreen, "Sounds/Splash/Splash Screen"},
            {GameSongs.Gameplay1, "Sounds/Gameplay/Gameplay Theme - 1"},
            {GameSongs.Gameplay2, "Sounds/Gameplay/Gameplay Theme - 2"},
            {GameSongs.Gameplay3, "Sounds/Gameplay/Gameplay Theme - 3"},
            {GameSongs.Gameplay4, "Sounds/Gameplay/Gameplay Theme - 4"},
            {GameSongs.Gameplay5, "Sounds/Gameplay/Gameplay Theme - 5"},
            {GameSongs.Gameplay6, "Sounds/Gameplay/Gameplay Theme - 6"},
        };

        // Dictionary to map GameSFX to their respective file paths
        private static Dictionary<GameSFX, string> _gameSFX = new()
        {
            {GameSFX.Fireball, "Sounds/Effects/Fireball"}
        };

        // Method to get the file path for a specific game song
        public static string GetSong(GameSongs sound)
        {
            try
            {
                foreach (var songDict in _gameSongs)
                {
                    if (songDict.Key == sound)
                    {
                        return songDict.Value;
                    }
                }
                return null; // Return null if the song is not found
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("No such song was found in the SongLibrary");
            }
        }

        // Method to get the file path for a specific game sound effect
        public static string GetSfx(GameSFX sound)
        {
            try
            {
                foreach (var songDict in _gameSFX)
                {
                    if (songDict.Key == sound)
                    {
                        return songDict.Value;
                    }
                }
                return null; // Return null if the sound effect is not found
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("No such sfx was found in the SongLibrary");
            }
        }
    }
}

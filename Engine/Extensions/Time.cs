// Importing the required namespaces
using System;
using Microsoft.Xna.Framework;

// Declaring a namespace for the Time class
namespace JetBoxer2D.Engine.Extensions
{
    // Defining the Time class
    public class Time
    {
        // Private static field to hold the Time instance
        private static Time _instance;

        // Property to access the Time instance
        public static Time Instance
        {
            get
            {
                // If the instance is null, create a new Time instance
                if (_instance == null)
                    _instance = new Time();

                return _instance;
            }
            set => _instance = value;
        }

        // Property to get the DeltaTime (time between frames)
        public static float DeltaTime { get; private set; }

        // Property to get the current GameTime
        public static TimeSpan GameTime { get; private set; }

        // Property to get the total seconds of the GameTime
        public static float TotalSeconds => (float)GameTime.TotalSeconds;

        // Method to update the Time properties based on the provided GameTime
        public static void Update(GameTime gameTime)
        {
            // Updating the DeltaTime with the time between frames
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Updating the GameTime with the total game time
            GameTime = gameTime.TotalGameTime;
        }
    }
}

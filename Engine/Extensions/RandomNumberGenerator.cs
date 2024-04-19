// Importing the System namespace
using System;

// Declaring a namespace for the RandomNumberGenerator class
namespace JetBoxer2D.Engine.Extensions
{
    // Defining the RandomNumberGenerator class
    public class RandomNumberGenerator
    {
        // Creating an instance of the Random class for generating random numbers
        private Random _random = new();

        // Method to generate a random integer
        public int NextRandom() => _random.Next();

        // Method to generate a random integer within a specified range (0 to max-1)
        public int NextRandom(int max) => _random.Next(max);

        // Method to generate a random integer within a specified range (min to max-1)
        public int NextRandom(int min, int max) => _random.Next(min, max);

        // Method to generate a random float within a specified range (0 to max)
        public float NextRandom(float max) => (float)_random.NextDouble() * max;

        // Method to generate a random float within a specified range (min to max)
        public float NextRandom(float min, float max) => (float)_random.NextDouble() * (max - min) + min;
    }
}

// Importing the Microsoft.Xna.Framework namespace
using Microsoft.Xna.Framework;

// Declaring a namespace for the SingletonManager class
namespace JetBoxer2D.Engine.Extensions
{
    // Defining the SingletonManager class as a static class
    public static class SingletonManager
    {
        // Method to initialize singletons (MouseInput and Time instances)
        public static void InitializeSingletons()
        {
            // Creating a new instance of MouseInput and assigning it to MouseInput.Instance
            MouseInput.Instance = new MouseInput();

            // Creating a new instance of Time and assigning it to Time.Instance
            Time.Instance = new Time();
        }

        // Method to update singletons (MouseInput and Time) based on the provided GameTime
        public static void UpdateSingletons(GameTime gameTime)
        {
            // Updating the MouseInput singleton
            MouseInput.Update();

            // Updating the Time singleton with the provided GameTime
            Time.Update(gameTime);
        }
    }
}

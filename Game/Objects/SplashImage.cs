// Import necessary namespaces
using JetBoxer2D.Engine.Objects;
using Microsoft.Xna.Framework.Graphics;

// Declare the namespace for the SplashImage class
namespace JetBoxer2D.Game.Objects
{
    // Define the SplashImage class inheriting from BaseGameObject
    public class SplashImage : BaseGameObject
    {
        // Constructor for the SplashImage class
        public SplashImage(Texture2D texture)
        {
            // Set the texture of the SplashImage
            _texture = texture;
        }
    }
}

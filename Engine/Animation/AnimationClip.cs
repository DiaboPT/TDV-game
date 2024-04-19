// Importing the namespace for JetBoxer2D.Engine.Objects
using JetBoxer2D.Engine.Objects;

// Importing the namespace for Microsoft.Xna.Framework.Graphics
using Microsoft.Xna.Framework.Graphics;

// Declaring a namespace for the Animation class
namespace JetBoxer2D.Engine.Animation
{
    // Defining the AnimationClip class which inherits from BaseGameObject
    public class AnimationClip : BaseGameObject
    {
        // Public property to access the Texture of the animation clip
        public Texture2D Texture => _texture;

        // Public property to get the FrameTime of the animation clip
        public float FrameTime { get; }

        // Public property to get the IsLooping status of the animation clip
        public bool IsLooping { get; }

        // Public property to calculate the AmountOfFrames based on the texture dimensions
        public int AmountOfFrames
        {
            get
            {
                // Check if the aspect ratio of the texture is less than 1
                if (_texture.Width / _texture.Height < 1)
                    return 1; // Return 1 frame if the condition is met

                // Calculate the number of frames based on texture dimensions
                return _texture.Width / _texture.Height;
            }
        }

        // Constructor for creating an AnimationClip with texture, frame time, and looping status
        public AnimationClip(Texture2D texture, float frameTime, bool isLooping)
        {
            _texture = texture; // Assign the provided texture to the private variable
            FrameTime = frameTime; // Set the frame time for the animation
            IsLooping = isLooping; // Set the looping status for the animation

            Width = _texture.Height; // Set the width of the animation clip
            Height = _texture.Height; // Set the height of the animation clip
        }

        // Constructor for creating an AnimationClip with texture, frame dimensions, frame time, and looping status
        public AnimationClip(Texture2D texture, int frameWidth, int frameHeight, float frameTime, bool isLooping)
        {
            _texture = texture; // Assign the provided texture to the private variable
            FrameTime = frameTime; // Set the frame time for the animation
            IsLooping = isLooping; // Set the looping status for the animation

            Width = frameWidth; // Set the width of the animation clip
            Height = frameHeight; // Set the height of the animation clip
        }
    }
}

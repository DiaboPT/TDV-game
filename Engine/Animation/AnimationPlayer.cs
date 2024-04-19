// Importing necessary namespaces
using System;
using JetBoxer2D.Engine.Extensions;
using JetBoxer2D.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Declaring a namespace for the AnimationPlayer class
namespace JetBoxer2D.Engine.Animation
{
    // Defining the AnimationPlayer class which inherits from BaseGameObject
    public class AnimationPlayer : BaseGameObject
    {
        // Private fields for the sprite batch and the animated game object
        private readonly SpriteBatch _spriteBatch;
        private readonly BaseGameObject _animatedGameObject;

        // Private fields for current frame and timer
        private int _currentFrame;
        private float _timer;

        // Public property to get or set the animation speed
        public float AnimationSpeed { get; set; }

        // Public property to get the current AnimationClip being played
        public AnimationClip Animation { get; private set; }

        // Public property to get the normalized time of the animation
        public float NormalizedTime { get; private set; }

        // Public property to get or set the flip status of the animation
        public bool IsFlipped { get; set; }

        // Public property to get or set the stopped status of the animation
        public bool IsStopped { get; set; }

        // Public property to check if the animation has ended
        public bool HasEnded => NormalizedTime >= 1f;

        // Public property to get or set the rotation of the animation
        public float Rotation { get; set; }

        // Constructor for creating an AnimationPlayer with a sprite batch and animated game object
        public AnimationPlayer(SpriteBatch spriteBatch, BaseGameObject animatedGameObj)
        {
            _spriteBatch = spriteBatch;
            _animatedGameObject = animatedGameObj;
            _timer = 0.0f;
            _currentFrame = 0;
            AnimationSpeed = 1f;
        }

        // Method to play the specified animation
        public void Play(AnimationClip animation)
        {
            if (IsStopped)
                return;

            if (animation == null) throw new Exception($"Animation instance wasn't defined");

            if (animation != Animation)
            {
                _currentFrame = 0;
                _timer = 0f;
                _texture = animation.Texture;
                Animation = animation;
            }
            _timer += Time.DeltaTime;
            CalculateNormalizedTime(animation);

            while (_timer > animation.FrameTime)
            {
                _timer -= animation.FrameTime / AnimationSpeed;

                if (animation.IsLooping)
                    _currentFrame = (_currentFrame + 1) % animation.AmountOfFrames;
                else
                    _currentFrame = Math.Min(_currentFrame + 1, animation.AmountOfFrames);
            }

            // Define source and destination rectangles for drawing the animation frame
            var sourceRectangle = new Rectangle(_currentFrame * animation.Width, 0, animation.Width, animation.Height);

            var destinationRectangle = new Rectangle((int)_animatedGameObject.Position.X, (int)_animatedGameObject.Position.Y, animation.Width, animation.Height);

            // Draw the animation frame based on flip status
            if (IsFlipped)
            {
                _spriteBatch.Draw(animation.Texture, destinationRectangle, sourceRectangle, Color.White,
                    Rotation, animation.Centre, SpriteEffects.FlipHorizontally, 1);
            }
            else
            {
                _spriteBatch.Draw(animation.Texture, destinationRectangle, sourceRectangle, Color.White,
                    Rotation, animation.Centre, SpriteEffects.None, 1);
            }
        }

        // Method to calculate the normalized time of the animation
        private void CalculateNormalizedTime(AnimationClip animation)
        {
            NormalizedTime = (_currentFrame + 1) / (float)animation.AmountOfFrames;
        }
    }
}

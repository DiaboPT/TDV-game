using System;
using JetBoxer2D.Engine.Animation;
using JetBoxer2D.Engine.Extensions;
using JetBoxer2D.Engine.Objects;
using JetBoxer2D.Game.Particles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JetBoxer2D.Game.Objects
{
    // Projectile class inherits from BaseGameObject
    public class Projectile : BaseGameObject
    {
        // Constant for acceleration
        private const float Acceleration = 20f;

        // Constants for sprite names
        private const string DefaultSprite = "Placeholder Texture";
        private const string MoveAnimation = "Effects/Energy Blast";
        private const string FlameSpark = "Effects/Spark";

        // Variables for speed, direction, rotation, and lifespan
        private float _currentSpeed;
        private Vector2 _direction;
        private float _rotation;
        public float LifeSpan { get; set; }
        public const float MaxLifeSpan = 3.5f;

        // Override the Position property
        public override Vector2 Position
        {
            set
            {
                _position = value;
                _flameEmitter.Position = new Vector2(_position.X - 6, _position.Y + 18);
            }
        }

        // Animation player and animation clip variables
        private AnimationPlayer _animationPlayer;
        private AnimationClip _moveAnimation;

        // Flame emitter variable
        private FlameSparksEmitter _flameEmitter;

        // Constructor for Projectile class
        public Projectile(Vector2 position, float rotation, SpriteBatch spriteBatch, ContentManager contentManager, int zIndex)
        {
            // Load the texture and set initial values
            _texture = contentManager.Load<Texture2D>(DefaultSprite);
            _position = position;
            _rotation = rotation;
            _direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            this.zIndex = zIndex;
            _currentSpeed = 0;

            // Initialize animation player and animation clip
            _animationPlayer = new AnimationPlayer(spriteBatch, this);
            _moveAnimation = new AnimationClip(contentManager.Load<Texture2D>(MoveAnimation), 0.1f, true);
            _animationPlayer.Rotation = _rotation;

            // Initialize flame emitter
            _flameEmitter = new FlameSparksEmitter(contentManager.Load<Texture2D>(FlameSpark), _position, _rotation);
        }

        // Update method for the Projectile
        public override void Update()
        {
            // Update the flame emitter
            _flameEmitter.Update();

            // Update the position, speed, and lifespan
            Position += _currentSpeed * Time.DeltaTime * _direction;
            _currentSpeed += Acceleration;
            LifeSpan += Time.DeltaTime;
        }

        // Render method for the Projectile
        public override void Render(SpriteBatch spriteBatch)
        {
            // Render the flame emitter
            _flameEmitter.Render(spriteBatch);

            // Play the move animation
            _animationPlayer.Play(_moveAnimation);
        }
    }
}

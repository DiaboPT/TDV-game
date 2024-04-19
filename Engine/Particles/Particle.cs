// Importing the necessary namespace
using Microsoft.Xna.Framework;

// Declaring a namespace for the Particle class
namespace JetBoxer2D.Engine.Particles
{
    // Defining the Particle class
    public class Particle
    {
        // Private fields to store particle properties
        private int _lifespan;
        private int _age;
        private Vector2 _gravity;
        private Vector2 _direction;
        private float _velocity;
        private float _acceleration;
        private float _rotation;
        private float _opacityFadingRate;

        // Public properties for Position, Scale, and Opacity of the particle
        public Vector2 Position { get; set; }
        public float Scale { get; set; }
        public float Opacity { get; set; }

        // Default constructor for the Particle class
        public Particle()
        {
        }

        // Method to activate the particle with specified properties
        public void Activate(int lifespan, Vector2 position, Vector2 direction, Vector2 gravity, float velocity,
            float acceleration, float scale, float rotation, float opacity, float opacityFadingRate)
        {
            // Assigning the specified properties to the particle
            _lifespan = lifespan;
            _gravity = gravity;
            _direction = direction;
            _velocity = velocity;
            _acceleration = acceleration;
            _rotation = rotation;
            _opacityFadingRate = opacityFadingRate;

            // Setting the initial position, scale, and opacity of the particle
            Position = position;
            Scale = scale;
            Opacity = opacity;
        }

        // Method to update the particle's properties over time
        public bool Update()
        {
            // Update velocity based on acceleration
            _velocity *= _acceleration;
            // Update direction with gravity
            _direction += _gravity;

            // Calculate the change in position based on direction and velocity
            var positionDelta = _direction * _velocity;
            Position += positionDelta;
            // Update opacity based on fading rate
            Opacity *= _opacityFadingRate;

            // Increment age of the particle
            _age++;
            // Return whether the particle is still active based on lifespan
            return _age < _lifespan;
        }
    }
}

// Importing necessary namespaces
using System;
using JetBoxer2D.Engine.Extensions;
using Microsoft.Xna.Framework;

// Declaring a namespace for the ConeEmitter class
namespace JetBoxer2D.Engine.Particles.EmitterTypes
{
    // Defining the ConeEmitter class that implements the IEmitterType interface
    public class ConeEmitter : IEmitterType
    {
        // Property to get the direction of the cone emitter
        public Vector2 Direction { get; private set; }

        // Property to get the spread angle of the cone emitter
        public float Spread { get; }

        // Instance of RandomNumberGenerator to generate random numbers
        private RandomNumberGenerator _random = new RandomNumberGenerator();

        // Constructor to initialize the ConeEmitter with a given direction and spread angle
        public ConeEmitter(Vector2 direction, float spread)
        {
            Direction = direction;
            Spread = spread;
        }

        // Method to calculate the direction of a particle based on the emitter's direction and spread angle
        public Vector2 GetParticleDirection()
        {
            // Check if the direction is null, then return zero vector
            if (Direction == null)
                return Vector2.Zero;

            // Calculate the angle based on the direction vector
            var angle = (float)Math.Atan2(Direction.Y, Direction.X);
            var newAngle = _random.NextRandom(angle - Spread / 2.0f, angle + Spread / 2.0f);

            // Calculate the particle direction based on the new angle
            var particleDirection = new Vector2((float)Math.Cos(newAngle), (float)Math.Sin(newAngle));
            particleDirection.Normalize();
            return particleDirection;
        }

        // Method to calculate the position of a particle based on the emitter's position
        public Vector2 GetParticlePosition(Vector2 emitterPosition)
        {
            // Simply return the emitter's position as the particle's position
            var x = emitterPosition.X;
            var y = emitterPosition.Y;

            return new Vector2(x, y);
        }
    }
}

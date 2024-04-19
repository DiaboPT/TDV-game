// Importing necessary namespaces
using System;
using JetBoxer2D.Engine.Extensions;
using Microsoft.Xna.Framework;

// Declaring a namespace for the CircleEmitterType class
namespace JetBoxer2D.Engine.Particles.EmitterTypes
{
    // Defining the CircleEmitterType class that implements the IEmitterType interface
    public class CircleEmitterType : IEmitterType
    {
        // Property to get the radius of the circle emitter
        public float Radius { get; private set; }

        // Instance of RandomNumberGenerator to generate random numbers
        private RandomNumberGenerator _rnd = new RandomNumberGenerator();

        // Constructor to initialize the CircleEmitterType with a given radius
        public CircleEmitterType(float radius)
        {
            Radius = radius;
        }

        // Method to get the direction of a particle (always returning (0, 0) which means no direction)
        public Vector2 GetParticleDirection()
        {
            return new Vector2(0f, 0f);
        }

        // Method to calculate the position of a particle based on the emitter's position
        public Vector2 GetParticlePosition(Vector2 emitterPosition)
        {
            // Generate a random angle within 0 to 2*Pi
            var newAngle = _rnd.NextRandom(0, 2 * MathHelper.Pi);

            // Calculate a position vector based on the random angle
            var positionVector = new Vector2((float)Math.Cos(newAngle), (float)Math.Sin(newAngle));
            positionVector.Normalize();

            // Generate a random distance within the radius
            var distance = _rnd.NextRandom(0, Radius);
            var position = positionVector * distance;

            // Calculate the final position by adding the emitter's position and the calculated position
            var x = emitterPosition.X + position.X;
            var y = emitterPosition.Y + position.Y;

            return new Vector2(x, y);
        }
    }
}

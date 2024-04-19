// Importing the necessary namespaces
using JetBoxer2D.Engine.Extensions;
using Microsoft.Xna.Framework;

// Declaring a namespace for the EmitterParticleState abstract class
namespace JetBoxer2D.Engine.Particles
{
    // Defining the EmitterParticleState abstract class
    public abstract class EmitterParticleState
    {
        // Abstract properties defining the characteristics of a particle
        public abstract int MinLifeSpan { get; }
        public abstract int MaxLifeSpan { get; }

        public abstract float Velocity { get; }
        public abstract float VelocityDeviation { get; }
        public abstract float Acceleration { get; }
        public abstract Vector2 Gravity { get; }

        public abstract float Opacity { get; }
        public abstract float OpacityDeviation { get; }
        public abstract float OpacityFadingRate { get; }

        public abstract float Rotation { get; }
        public abstract float RotationDeviation { get; }

        public abstract float Scale { get; }
        public abstract float ScaleDeviation { get; }

        // Instance of RandomNumberGenerator to generate random numbers
        private RandomNumberGenerator _random = new RandomNumberGenerator();

        // Method to generate a random lifespan between MinLifeSpan and MaxLifeSpan
        public int GenerateLifespan()
        {
            return _random.NextRandom(MinLifeSpan, MaxLifeSpan);
        }

        // Method to generate a random velocity within a specified deviation
        public float GenerateVelocity()
        {
            return GenerateFloat(Velocity, VelocityDeviation);
        }

        // Method to generate a random opacity within a specified deviation
        public float GenerateOpacity()
        {
            return GenerateFloat(Opacity, OpacityDeviation);
        }

        // Method to generate a random rotation within a specified deviation
        public float GenerateRotation()
        {
            return GenerateFloat(Rotation, RotationDeviation);
        }

        // Method to generate a random scale within a specified deviation
        public float GenerateScale()
        {
            return GenerateFloat(Scale, ScaleDeviation);
        }

        // Method to generate a random float within a specified deviation range
        public float GenerateFloat(float startNum, float deviation)
        {
            var halfDeviation = deviation / 2f;
            return _random.NextRandom(startNum - halfDeviation, startNum + halfDeviation);
        }
    }
}

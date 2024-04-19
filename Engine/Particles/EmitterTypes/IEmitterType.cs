// Importing the Microsoft.Xna.Framework namespace
using Microsoft.Xna.Framework;

// Declaring a namespace for the IEmitterType interface
namespace JetBoxer2D.Engine.Particles.EmitterTypes
{
    // Defining the IEmitterType interface
    public interface IEmitterType
    {
        // Method signature to get the direction of a particle
        Vector2 GetParticleDirection();

        // Method signature to get the position of a particle based on the emitter's position
        Vector2 GetParticlePosition(Vector2 emitterPosition);
    }
}

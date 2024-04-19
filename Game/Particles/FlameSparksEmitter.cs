// Import necessary namespaces
using JetBoxer2D.Engine.Particles;
using JetBoxer2D.Engine.Particles.EmitterTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Declare the namespace for the FlameSparksEmitter class
namespace JetBoxer2D.Game.Particles
{
    // Define the FlameSparksEmitter class inheriting from Emitter
    public class FlameSparksEmitter : Emitter
    {
        // Constants and variables for the emitter
        public const string SpriteName = "Effects/Spark";
        private const int NbParticles = 10;
        private const int MaxParticles = 1000;
        private static Vector2 Direction = new Vector2(0.0f, 1.0f);
        private const float Spread = 1.5f;

        // Constructor for FlameSparksEmitter class
        public FlameSparksEmitter(Texture2D texture, Vector2 position, float rotation) : base(texture, position, rotation,
            new FlameSparkParticleState(), new ConeEmitter(Direction, Spread), NbParticles, MaxParticles)
        {
            // Constructor parameters initialization
        }
    }
}

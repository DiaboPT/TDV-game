// Importing necessary libraries
using System;
using System.Collections.Generic;
using JetBoxer2D.Engine.Objects;
using JetBoxer2D.Engine.Particles.EmitterTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Defining the namespace
namespace JetBoxer2D.Engine.Particles;

// Defining the Emitter class which inherits from the BaseGameObject class
public class Emitter : BaseGameObject
{
    // Creating a LinkedList to store active particles
    private LinkedList<Particle> _activeParticles = new();
    // Creating a LinkedList to store inactive particles
    private LinkedList<Particle> _inactiveParticles = new();

    // Declaring an instance of the EmitterParticleState class
    public EmitterParticleState _emitterParticleState;
    // Declaring an instance of the IEmitterType interface
    private IEmitterType _emitterType;
    // Declaring an integer to store the number of particles emitted per update
    private int _nbParticleEmittedPerUpdate = 0;
    // Declaring an integer to store the maximum number of particles
    private int _maxNbParticle = 0;

    // Property to check if the emitter is alive based on the count of active particles
    public bool IsAlive => _activeParticles.Count > 0;
    // Boolean to check if the emitter is active
    private bool _active = true;
    // Property to get and set the age of the emitter
    public int Age { get; set; }
    // Property to get and set the rotation of the emitter
    public float Rotation { get; set; }

    // Constructor for the Emitter class
    public Emitter(Texture2D texture, Vector2 position, float rotation, EmitterParticleState particleState,
        IEmitterType emitterType,
        int nbParticleEmittedPerUpdate, int maxNbParticle)
    {
        // Initializing the texture, position, rotation, emitter particle state, emitter type, number of particles emitted per update, and maximum number of particles
        _texture = texture;
        Position = position;
        Rotation = rotation;
        _emitterParticleState = particleState;
        _emitterType = emitterType;
        _nbParticleEmittedPerUpdate = nbParticleEmittedPerUpdate;
        _maxNbParticle = maxNbParticle;
        // Setting the rotation and age to 0
        Rotation =
            Age = 0;
    }

    // Method to emit a new particle
    private void EmitNewParticle(Particle particle)
    {
        // Generating the lifespan, velocity, scale, rotation, opacity, gravity, acceleration, and opacity fading rate for the particle
        var lifespan = _emitterParticleState.GenerateLifespan();
        var velocity = _emitterParticleState.GenerateVelocity();
        var scale = _emitterParticleState.GenerateScale();
        var rotation = _emitterParticleState.GenerateRotation();
        var opacity = _emitterParticleState.GenerateOpacity();
        var gravity = _emitterParticleState.Gravity;
        var acceleration = _emitterParticleState.Acceleration;
        var opacityFadingRate = _emitterParticleState.OpacityFadingRate;

        // Getting the direction and position of the particle
        var direction = _emitterType.GetParticleDirection();
        var position = _emitterType.GetParticlePosition(_position);

        // Activating the particle with the generated properties
        particle.Activate(lifespan, position, direction, gravity, velocity, acceleration, scale, rotation, opacity,
            opacityFadingRate);
        // Adding the particle to the list of active particles
        _activeParticles.AddLast(particle);
    }

    // Method to emit particles
    private void EmitParticles()
    {
        // If the count of active particles is greater than or equal to the maximum number of particles, return
        if (_activeParticles.Count >= _maxNbParticle)
            return;

        // Calculating the maximum amount of particles to be generated and the needed particles
        var maxAmountToBeGenerated = _maxNbParticle - _activeParticles.Count;
        var neededParticles = Math.Min(maxAmountToBeGenerated, _nbParticleEmittedPerUpdate);

        // Calculating the number of particles to reuse and create
        var nbToReuse = Math.Min(_inactiveParticles.Count, neededParticles);
        var nbToCreate = neededParticles - nbToReuse;

        // Reusing particles
        for (var i = 0; i < nbToReuse; i++)
        {
            var particleNode = _inactiveParticles.First;
            EmitNewParticle(particleNode.Value);
            _inactiveParticles.Remove(particleNode);
        }

        // Creating new particles
        for (var i = 0; i < nbToCreate; i++) EmitNewParticle(new Particle());
    }

    // Overriding the Update method from the BaseGameObject class
    public override void Update()
    {
        // If the emitter is active, emit particles
        if (_active) EmitParticles();

        // Updating each active particle
        var particleNode = _activeParticles.First;
        while (particleNode != null)
        {
            var nextNode = particleNode.Next;
            var stillAlive = particleNode.Value.Update();

            // If the particle is not alive, remove it from the active particles and add it to the inactive particles
            if (!stillAlive)
            {
                _activeParticles.Remove(particleNode);
                _inactiveParticles.AddLast(particleNode.Value);
            }

            particleNode = nextNode;
        }

        // Incrementing the age of the emitter
        Age++;
    }

    // Method to deactivate the emitter
    public void Deactivate()
    {
        _active = false;
    }

    // Overriding the Render method from the BaseGameObject class
    public override void Render(SpriteBatch spriteBatch)
    {
        // Creating a new rectangle for the source of the texture
        var sourceRectangle = new Rectangle(0, 0, _texture.Width, _texture.Height);
        // Calculating the rotation angle
        var rotationAngle = (float)(Math.PI / 2f - Rotation);

        // Drawing each active particle
        foreach (var particle in _activeParticles)
            spriteBatch.Draw(_texture, particle.Position, sourceRectangle, Color.White * particle.Opacity,
                rotationAngle, new Vector2(0, 0), particle.Scale, SpriteEffects.None, zIndex);
    }
}

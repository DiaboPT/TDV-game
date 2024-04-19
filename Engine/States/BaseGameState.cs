using System;
using System.Collections.Generic;
using System.Linq;
using JetBoxer2D.Engine.Events;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using JetBoxer2D.Engine.Input;
using JetBoxer2D.Engine.Objects;
using JetBoxer2D.Engine.Sound;
using Microsoft.Xna.Framework;

namespace JetBoxer2D.Engine.States
{
    public abstract class BaseGameState
    {
        // List to store game objects
        private readonly List<BaseGameObject> _gameObjects = new();

        // Sound manager for this game state
        protected SoundManager SoundManager = new();

        // Input manager property
        public InputManager InputManager { get; set; }

        // Viewport dimensions
        protected int _viewportWidth;
        protected int _viewportHeight;

        // Graphics device manager
        public GraphicsDeviceManager Graphics;

        // Flag to track sound initialization
        protected bool _isSoundInitialized;

        // Abstract methods to be implemented by derived classes
        protected abstract void SetInputManager();
        protected abstract void SetSoundtrack();
        protected abstract void UpdateGameState();

        // Fallback texture name
        private const string FallbackTexture = "Empty";

        // Content manager and game instance
        protected ContentManager _contentManager;
        protected Microsoft.Xna.Framework.Game Game;

        // Initialize method for setting up game state
        public virtual void Initialize(Microsoft.Xna.Framework.Game game, GraphicsDeviceManager graphics,
            ContentManager contentManager)
        {
            Game = game;
            Graphics = graphics;
            _contentManager = contentManager;
            _viewportWidth = Graphics.GraphicsDevice.Viewport.Width;
            _viewportHeight = Graphics.GraphicsDevice.Viewport.Height;

            // Set input manager (to be implemented by derived classes)
            SetInputManager();
        }

        // Abstract method to load content (sprites, sounds, etc.)
        public abstract void LoadContent(SpriteBatch spriteBatch);

        // Unload content method
        public void UnloadContent()
        {
            _contentManager.Unload();
            _isSoundInitialized = false;
        }

        // Load a texture by name (with fallback if not found)
        protected Texture2D LoadTexture(string textureName)
        {
            var texture = _contentManager.Load<Texture2D>(textureName);
            return texture ?? _contentManager.Load<Texture2D>(FallbackTexture);
        }

        // Event handlers for state switching and notifications
        public event EventHandler<BaseGameState> OnStateSwitched;
        public event EventHandler<BaseGameStateEvent> OnEventNotification;

        // Switch to a different game state
        public void SwitchState(BaseGameState state)
        {
            OnStateSwitched?.Invoke(this, state);
        }

        // Notify an event (e.g., player score, game over)
        public void NotifyEvent(BaseGameStateEvent eventType, object argument = null)
        {
            OnEventNotification?.Invoke(this, eventType);

            // Notify game objects and sound manager
            foreach (var gameObject in _gameObjects)
                gameObject.OnNotify(eventType);

            SoundManager.OnNotify(eventType);
        }

        // Add a game object to the list
        protected void AddGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        // Remove a game object from the list
        protected void RemoveGameObject(BaseGameObject gameObject)
        {
            _gameObjects?.Remove(gameObject);
        }

        // Load a sound effect by name
        protected SoundEffect LoadSound(string soundName)
        {
            return _contentManager.Load<SoundEffect>(soundName);
        }

        // Update game state (called every frame)
        public void Update()
        {
            UpdateGameState();
            InputManager.UpdateInput();

            // Update game objects based on their z-index
            foreach (var gameObject in _gameObjects.OrderBy(gameObj => gameObj.zIndex))
                gameObject.Update();
        }

        // Render game objects (called every frame)
        public virtual void Render(SpriteBatch spriteBatch)
        {
            // Render game objects based on their z-index
            foreach (var gameObject in _gameObjects.OrderBy(gameObj => gameObj.zIndex))
                gameObject.Render(spriteBatch);
        }
    }
}

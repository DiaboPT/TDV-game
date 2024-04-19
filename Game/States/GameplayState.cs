using System;
using System.Collections.Generic;
using JetBoxer2D.Engine.Events;
using JetBoxer2D.Engine.Input;
using JetBoxer2D.Engine.States;
using JetBoxer2D.Game.Events;
using JetBoxer2D.Game.InputMaps;
using JetBoxer2D.Game.Objects;
using JetBoxer2D.Game.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JetBoxer2D.Game.States
{
    public class GameplayState : BaseGameState
    {
        private const string BackgroundTexture = "Backgrounds/Barren";

        private TerrainBackground _terrainBackground;
        private Player _player;
        private RedTriangle _redTriangle;

        public override void Initialize(Microsoft.Xna.Framework.Game game, GraphicsDeviceManager graphics,
            ContentManager contentManager)
        {
            base.Initialize(game, graphics, contentManager);
            game.IsMouseVisible = true;
        }

        protected override void SetInputManager()
        {
            // Set up input manager with the GameplayInputMap
            InputManager = new InputManager(new GameplayInputMap());
        }

        protected override void SetSoundtrack()
        {
            // Load and set up the game soundtrack
            // ... (omitted for brevity)
        }

        protected override void UpdateGameState()
        {
            // Update game state logic
            if (InputManager.GetButtonDown(SplashInputMap.ExitGame))
                NotifyEvent(new BaseGameStateEvent.GameQuit());

            _redTriangle?.SetPlayerPosition(_player.Position);

            Game.IsMouseVisible = false;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            // Render game objects
            base.Render(spriteBatch);

            KeepPlayerInBounds();
        }

        public override void LoadContent(SpriteBatch spriteBatch)
        {
            // Load game content (e.g., player, red triangle, background)
            SetSoundtrack();

            _player = new Player(Vector2.Zero, spriteBatch, _contentManager, this)
            { zIndex = 1 };
            _player.Position = new Vector2(_viewportWidth / 2f - _player.Texture.Width,
                _viewportHeight / 2f - _player.Texture.Height);
            AddGameObject(_player);

            _redTriangle = new RedTriangle(_contentManager, spriteBatch, _player)
            { zIndex = 1 };
            _redTriangle.Position = Vector2.Zero;
            AddGameObject(_redTriangle);

            _terrainBackground = new TerrainBackground(LoadTexture(BackgroundTexture))
            { zIndex = 0 };
            AddGameObject(_terrainBackground);
        }

        private void KeepPlayerInBounds()
        {
            // Ensure the player stays within the game bounds
            if (_player.Position.X - _player.Width / 2f < 0)
                _player.Position = new Vector2(_player.Width / 2f, _player.Position.Y);

            if (_player.Position.X > _viewportWidth - _player.Width / 2f)
                _player.Position = new Vector2(_viewportWidth - _player.Width / 2f, _player.Position.Y);

            if (_player.Position.Y - _player.Height / 2f < 0)
                _player.Position = new Vector2(_player.Position.X, _player.Height / 2f);

            if (_player.Position.Y > _viewportHeight - _player.Height / 2f)
                _player.Position = new Vector2(_player.Position.X, _viewportHeight - _player.Height / 2f);
        }
    }
}

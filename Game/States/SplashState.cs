// Import necessary namespaces
using System;
using System.Collections.Generic;
using JetBoxer2D.Engine.Events;
using JetBoxer2D.Engine.Extensions;
using JetBoxer2D.Engine.Input;
using JetBoxer2D.Engine.Sound;
using JetBoxer2D.Engine.States;
using JetBoxer2D.Game.InputMaps;
using JetBoxer2D.Game.Objects;
using JetBoxer2D.Game.Sound;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

// Declare the namespace for the SplashState class
namespace JetBoxer2D.Game.States
{
    // Define the SplashState class inheriting from BaseGameState
    public class SplashState : BaseGameState
    {
        // Define a constant for the splash screen image path
        private const string SplashScreen = "Backgrounds/Splash Screen";

        // Method to set the input manager for the state
        protected override void SetInputManager()
        {
            InputManager = new InputManager(new SplashInputMap());
        }

        // Method to set the soundtrack for the state
        protected override void SetSoundtrack()
        {
            var splashSong = LoadSound(SoundLibrary.GetSong(GameSongs.SplashScreen)).CreateInstance();
            SoundManager.SetSoundtrack(new List<SoundEffectInstance> { splashSong });

            _isSoundInitialized = true;
        }

        // Method to update the game state
        protected override void UpdateGameState()
        {
            if (MouseInput.GetMouseAxis(MouseInputTypes.Horizontal) != 0 ||
                MouseInput.GetMouseAxis(MouseInputTypes.Vertical) != 0)
                Game.IsMouseVisible = true;
            else
                Game.IsMouseVisible = false;

            if (InputManager.GetButtonDown(SplashInputMap.EnterGame)) SwitchState(new GameplayState());

            if (InputManager.GetButtonDown(SplashInputMap.ExitGame)) NotifyEvent(new BaseGameStateEvent.GameQuit());
        }

        // Method to load content for the state
        public override void LoadContent(SpriteBatch spriteBatch)
        {
            SetSoundtrack();

            AddGameObject(new SplashImage(LoadTexture(SplashScreen)));
        }
    }
}

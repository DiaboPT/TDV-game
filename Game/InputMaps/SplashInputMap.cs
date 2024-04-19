using System;
using System.Collections.Generic;
using JetBoxer2D.Engine.Extensions;
using JetBoxer2D.Engine.Input.Enums;
using JetBoxer2D.Engine.Input.InputTypes;
using JetBoxer2D.Engine.Input.Objects;
using Microsoft.Xna.Framework.Input;

namespace JetBoxer2D.Game.InputMaps;

public class EnterGame : BaseInputAction { }
public class ExitGame : BaseInputAction { }

public class SplashInputMap : BaseInputMap
{
    public static EnterGame EnterGame;
    public static ExitGame ExitGame;
    
    public SplashInputMap()
    { 
        InitializeInputActions();
        InitializeInputActionDictionaries();
    }

        private void InitializeInputActions()
        {
            EnterGame = new EnterGame();
            ExitGame = new ExitGame();
        }
        
        private void InitializeInputActionDictionaries()
        {
            EnterGame.AddButtonToInputDictionary(new Dictionary<InputDevices, Enum>(), new ButtonInput());
            InitializeInputActionDictionary(EnterGame.ButtonInputDictionaries[0].Item1, InputDevices.Keyboard, Keys.Space);
            InitializeInputActionDictionary(EnterGame.ButtonInputDictionaries[0].Item1, InputDevices.Mouse, MouseInputTypes.LeftButton);
            InitializeInputActionDictionary(EnterGame.ButtonInputDictionaries[0].Item1, InputDevices.Gamepad, Buttons.Start);

            EnterGame.AddButtonToInputDictionary(new Dictionary<InputDevices, Enum>(), new ButtonInput());
            InitializeInputActionDictionary(EnterGame.ButtonInputDictionaries[1].Item1, InputDevices.Keyboard, Keys.Enter);
            InitializeInputActionDictionary(EnterGame.ButtonInputDictionaries[1].Item1, InputDevices.Mouse, MouseInputTypes.RightButton);
            InitializeInputActionDictionary(EnterGame.ButtonInputDictionaries[1].Item1, InputDevices.Gamepad, Buttons.A);
            
            ExitGame.AddButtonToInputDictionary(new Dictionary<InputDevices, Enum>(), new ButtonInput());
            InitializeInputActionDictionary(ExitGame.ButtonInputDictionaries[0].Item1, InputDevices.Keyboard, Keys.Escape);
            InitializeInputActionDictionary(ExitGame.ButtonInputDictionaries[0].Item1, InputDevices.Gamepad, Buttons.Back);
        }

        #region  Input Retrieval
        private Keys GetInputFromKeyboard(Dictionary<InputDevices, Enum> inputDict)
        {
            
            if (inputDict.TryGetValue(InputDevices.Keyboard, out var value))
                return (Keys)value; 
            else
                throw new KeyNotFoundException($"{InputDevices.Keyboard} not found in {inputDict} dictionary");
        }
        
        private MouseInputTypes GetInputFromMouse(Dictionary<InputDevices, Enum> inputDict)
        {
            
            if (inputDict.TryGetValue(InputDevices.Mouse, out var value))
                return (MouseInputTypes)value; 
            else
                throw new KeyNotFoundException($"{InputDevices.Mouse} not found in {inputDict} dictionary");
        }
        
        private Buttons GetInputFromGamepad(Dictionary<InputDevices, Enum> inputDict)
        {
            
            if (inputDict.TryGetValue(InputDevices.Gamepad, out var value))
                return (Buttons)value; 
            else
                throw new KeyNotFoundException($"{InputDevices.Gamepad} not found in {inputDict} dictionary");
        }
        #endregion
        
        
        protected override void UpdateKeyboardInput()
        {
            var keyboardState = Keyboard.GetState();
            
            foreach (var dictionaryPair in EnterGame.ButtonInputDictionaries)
            {
                var inputDictionary = dictionaryPair.Item1;
                if (keyboardState.IsKeyDown(GetInputFromKeyboard(inputDictionary)))
                {
                    dictionaryPair.Item2.UpdateKeyboardValue(true);
                    break;
                }

                dictionaryPair.Item2.UpdateKeyboardValue(false);
            }

            foreach (var dictionaryPair in ExitGame.ButtonInputDictionaries)
            {
                var inputDictionary = dictionaryPair.Item1;
                if (keyboardState.IsKeyDown(GetInputFromKeyboard(inputDictionary)))
                {
                    dictionaryPair.Item2.UpdateKeyboardValue(true);
                    break;
                }

                dictionaryPair.Item2.UpdateKeyboardValue(false);
            }
        }

        protected override void UpdateMouseInput()
        {
            foreach (var dictionaryPair in EnterGame.ButtonInputDictionaries)
            {
                var inputDictionary = dictionaryPair.Item1;
                if (MouseInput.IsButtonDown(GetInputFromMouse(inputDictionary)))
                {
                    dictionaryPair.Item2.UpdateMouseValue(true);
                    break;
                }

                dictionaryPair.Item2.UpdateMouseValue(false);
            }
        }

        protected override void UpdateGamepadInput()
        {
            var gamepadState = GamePad.GetState(0);

            foreach (var dictionaryPair in EnterGame.ButtonInputDictionaries)
            {
                var inputDictionary = dictionaryPair.Item1;
                if (gamepadState.IsButtonDown(GetInputFromGamepad(inputDictionary)))
                {
                    dictionaryPair.Item2.UpdateGamepadValue(true);
                    break;
                }

                dictionaryPair.Item2.UpdateGamepadValue(false);
            }
            
            foreach (var dictionaryPair in ExitGame.ButtonInputDictionaries)
            {
                var inputDictionary = dictionaryPair.Item1;
                if (gamepadState.IsButtonDown(GetInputFromGamepad(inputDictionary)))
                {
                    dictionaryPair.Item2.UpdateGamepadValue(true);
                    break;
                }

                dictionaryPair.Item2.UpdateGamepadValue(false);
            }
            
        }
    public override void RemapInputAction(Dictionary<InputDevices, List<Enum>> inputActionDict, InputDevices inputType, List<Enum> newInput)
    {
        inputActionDict.Remove(inputType);
        inputActionDict.TryAdd(inputType, newInput);
    }
}
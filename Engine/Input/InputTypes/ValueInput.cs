// Importing the required namespace
using System;
using JetBoxer2D.Engine.Input.Objects;

// Declaring a namespace for the ValueInput class
namespace JetBoxer2D.Engine.Input.InputTypes
{
    // Defining the ValueInput class that inherits from BaseInput
    public class ValueInput : BaseInput
    {
        // Property to get the current value from any input device
        public float Value
        {
            get
            {
                // Check and return the value from the active input device
                if (_keyboardValue != 0)
                    return _keyboardValue;
                if (_mouseValue != 0)
                    return _mouseValue;
                if (_gamepadValue != 0)
                    return _gamepadValue;
                return 0;
            }
        }

        // Private fields to store the values from keyboard, mouse, and gamepad
        private float _keyboardValue;
        private float _mouseValue;
        private float _gamepadValue;

        // Method to update the value received from the keyboard input
        public void UpdateKeyboardValue(float value)
        {
            // Clamping the keyboard input value between -100 and 100
            _keyboardValue = Math.Clamp(value, -100f, 100f);
        }

        // Method to update the value received from the mouse input
        public void UpdateMouseValue(float value)
        {
            // Clamping the mouse input value between -100 and 100
            _mouseValue = Math.Clamp(value, -100f, 100f);
        }

        // Method to update the value received from the gamepad input
        public void UpdateGamepadValue(float value)
        {
            // Clamping the gamepad input value between -100 and 100
            _gamepadValue = Math.Clamp(value, -100f, 100f);
        }
    }
}

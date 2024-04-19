// Importing the required namespace
using JetBoxer2D.Engine.Input.Objects;

// Declaring a namespace for the ButtonInput class
namespace JetBoxer2D.Engine.Input.InputTypes
{
    // Defining the ButtonInput class that inherits from BaseInput
    public class ButtonInput : BaseInput
    {
        // Property to check if the button is currently pressed
        public bool Pressed
        {
            get
            {
                // Check if the button is pressed on any input device
                if (_isKeyboardPressed)
                    return _isKeyboardPressed;
                if (_isMousePressed)
                    return _isMousePressed;
                if (_isGamepadPressed)
                    return _isGamepadPressed;

                return false;
            }
        }

        // Property to check if the button is pressed down
        public bool PressedDown
        {
            get
            {
                // Check if the button is pressed down on any input device
                if (_isKeyboardPressedDown)
                    return true;
                if (_isMousePressedDown)
                    return true;
                if (_isGamepadPressedDown)
                    return true;

                return false;
            }
        }

        // Private fields to track keyboard button states
        private bool _isKeyboardPressed;
        private bool _wasKeyboardPressed;
        private bool _isKeyboardPressedDown;

        // Private fields to track mouse button states
        private bool _isMousePressed;
        private bool _wasMousePressed;
        private bool _isMousePressedDown;

        // Private fields to track gamepad button states
        private bool _isGamepadPressed;
        private bool _wasGamepadPressed;
        private bool _isGamepadPressedDown;

        // Method to update the value of the keyboard button
        public void UpdateKeyboardValue(bool button)
        {
            _isKeyboardPressed = button;

            if (!_wasKeyboardPressed && _isKeyboardPressed)
                _isKeyboardPressedDown = true;
            else
                _isKeyboardPressedDown = false;

            _wasKeyboardPressed = _isKeyboardPressed;
        }

        // Method to update the value of the mouse button
        public void UpdateMouseValue(bool button)
        {
            _isMousePressed = button;

            if (!_wasMousePressed && _isMousePressed)
                _isMousePressedDown = true;
            else
                _isMousePressedDown = false;

            _wasMousePressed = _isMousePressed;
        }

        // Method to update the value of the gamepad button
        public void UpdateGamepadValue(bool button)
        {
            _isGamepadPressed = button;

            if (!_wasGamepadPressed && _isGamepadPressed)
                _isGamepadPressedDown = true;
            else
                _isGamepadPressedDown = false;

            _wasGamepadPressed = _isGamepadPressed;
        }
    }
}

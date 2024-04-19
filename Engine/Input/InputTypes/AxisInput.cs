// Importing necessary namespaces
using JetBoxer2D.Engine.Input.Objects;
using Microsoft.Xna.Framework;

// Defining the namespace for the class
namespace JetBoxer2D.Engine.Input.InputTypes;

// Declaring a public class AxisInput that inherits from BaseInput
public class AxisInput : BaseInput
{
    // Public properties to get the current state of X and Y axis
    public bool CurrentX => _currentX;
    public bool CurrentY => _currentY;

    // Private fields to store the values of keyboard, mouse, and gamepad inputs
    private Vector2 _keyboardValue;
    private Vector2 _mouseValue;
    private Vector2 _gamepadValue;

    // Private fields to store the current state of X and Y axis
    private bool _currentX;
    private bool _currentY;

    // Public property to get the value of the input
    public Vector2 Value
    {
        get
        {
            // Return the value of the input based on the device used
            if (_keyboardValue != Vector2.Zero)
                return _keyboardValue;
            if (_mouseValue != Vector2.Zero)
                return _mouseValue;
            if (_gamepadValue != Vector2.Zero)
                return _gamepadValue;

            // If no input is detected, return zero
            return Vector2.Zero;
        }
    }

    // Region for handling keyboard inputs
    #region Keyboard
    // Method to update the X value of the keyboard input
    public void UpdateKeyboardValueX(bool negativeX, bool positiveX)
    {
        // Update the X value based on the input
        _keyboardValue.X = negativeX ? -1 : _keyboardValue.X;
        _keyboardValue.X = positiveX ? 1 : _keyboardValue.X;

        // Update the current state of the X axis
        if (negativeX || positiveX)
            _currentX = true;
        else
            _currentX = false;

        // Reset the X value if no input is detected
        if (!_currentX)
            _keyboardValue.X = 0;
    }

    // Method to update the Y value of the keyboard input
    public void UpdateKeyboardValueY(bool negativeY, bool positiveY)
    {
        // Update the current state of the Y axis
        if (negativeY || positiveY)
            _currentY = true;
        else
            _currentY = false;

        // Update the Y value based on the input
        _keyboardValue.Y = negativeY ? -1 : _keyboardValue.Y;
        _keyboardValue.Y = positiveY ? 1 : _keyboardValue.Y;

        // Reset the Y value if no input is detected
        if (!_currentY)
            _keyboardValue.Y = 0;
    }
    #endregion

    // Region for handling mouse inputs
    #region Mouse
    // Method to update the X value of the mouse input
    public void UpdateMouseValueX(bool negativeX, bool positiveX)
    {
        // Update the X value based on the input
        _mouseValue.X = negativeX ? -1 : _mouseValue.X;
        _mouseValue.X = positiveX ? 1 : _mouseValue.X;

        // Update the current state of the X axis
        if (negativeX || positiveX)
            _currentX = true;
        else
            _currentX = false;

        // Reset the X value if no input is detected
        if (!_currentX)
            _mouseValue.X = 0;
    }

    // Method to update the Y value of the mouse input
    public void UpdateMouseValueY(bool negativeY, bool positiveY)
    {
        // Update the current state of the Y axis
        if (negativeY || positiveY)
            _currentY = true;
        else
            _currentY = false;

        // Update the Y value based on the input
        _mouseValue.Y = negativeY ? -1 : _mouseValue.Y;
        _mouseValue.Y = positiveY ? 1 : _mouseValue.Y;

        // Reset the Y value if no input is detected
        if (!_currentY)
            _mouseValue.Y = 0;
    }
    #endregion

    // Region for handling gamepad inputs
    #region Gamepad
    // Method to update the X value of the gamepad input
    public void UpdateGamepadValueX(bool negativeX, bool positiveX)
    {
        // Update the current state of the X axis
        if (negativeX || positiveX)
            _currentX = true;
        else
            _currentX = false;

        // Update the X value based on the input
        _gamepadValue.X = negativeX ? -1 : _gamepadValue.X; ;
        _gamepadValue.X = positiveX ? 1 : _gamepadValue.X; ;

        // Reset the X value if no input is detected
        if (!_currentX)
            _gamepadValue.X = 0;
    }

    // Method to update the Y value of the gamepad input
    public void UpdateGamepadValueY(bool negativeY, bool positiveY)
    {
        // Update the current state of the Y axis
        if (negativeY || positiveY)
            _currentY = true;
        else
            _currentY = false;

        // Update the Y value based on the input
        _gamepadValue.Y = negativeY ? -1 : _gamepadValue.Y;
        _gamepadValue.Y = positiveY ? 1 : _gamepadValue.Y;

        // Reset the Y value if no input is detected
        if (!_currentY)
            _gamepadValue.Y = 0;
    }
    #endregion
}

// Importing necessary libraries
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

// Defining the namespace for the code
namespace JetBoxer2D.Engine.Extensions;

// Enum to represent different types of mouse inputs
public enum MouseInputTypes
{
    None,
    RightButton,
    MiddleButton,
    LeftButton,
    Horizontal,
    Vertical
}

// Class to handle mouse inputs
public class MouseInput
{
    // Variables to store the state of the mouse in the current and previous frame
    private MouseState _previousMouseState;
    private MouseState _currentMouseState;

    // Singleton instance of the MouseInput class
    private static MouseInput _instance;

    // Property to get or set the singleton instance
    public static MouseInput Instance
    {
        get
        {
            // If instance is null, create a new instance
            if (_instance == null)
                return _instance = new MouseInput();

            // Return the existing instance
            return _instance;
        }
        // Setter for the instance
        set => _instance = value;
    }

    // Method to update the mouse state
    public static void Update()
    {
        // Store the current mouse state as the previous state
        _instance._previousMouseState = _instance._currentMouseState;
        // Get the current state of the mouse
        _instance._currentMouseState = Mouse.GetState();
    }

    // Method to check if a mouse button is currently pressed
    public static bool IsButtonDown(MouseInputTypes button)
    {
        // Switch case to check which button's state is to be checked
        return button switch
        {
            // Check if the left button is pressed
            MouseInputTypes.LeftButton => _instance._currentMouseState.LeftButton == ButtonState.Pressed,
            // Check if the middle button is pressed
            MouseInputTypes.MiddleButton => _instance._currentMouseState.MiddleButton == ButtonState.Pressed,
            // Check if the right button is pressed
            MouseInputTypes.RightButton => _instance._currentMouseState.RightButton == ButtonState.Pressed,
            // Default case if no valid button is provided
            _ => false
        };
    }

    // Method to check if a mouse button was just released
    public static bool IsButtonUp(MouseInputTypes button)
    {
        // Switch case to check which button's state is to be checked
        return button switch
        {
            // Check if the left button was just released
            MouseInputTypes.LeftButton => _instance._currentMouseState.LeftButton == ButtonState.Released &&
                                          _instance._previousMouseState.LeftButton == ButtonState.Pressed,
            // Check if the middle button was just released
            MouseInputTypes.MiddleButton => _instance._currentMouseState.MiddleButton == ButtonState.Released &&
                                            _instance._previousMouseState.MiddleButton == ButtonState.Pressed,
            // Check if the right button was just released
            MouseInputTypes.RightButton => _instance._currentMouseState.RightButton == ButtonState.Released &&
                                           _instance._previousMouseState.RightButton == ButtonState.Pressed,
            // Default case if no valid button is provided
            _ => false
        };
    }

    // Method to check if a mouse button was just pressed
    public static bool GetButtonDown(MouseInputTypes button)
    {
        // Switch case to check which button's state is to be checked
        return button switch
        {
            // Check if the left button was just pressed
            MouseInputTypes.LeftButton => _instance._currentMouseState.LeftButton == ButtonState.Pressed &&
                                          _instance._previousMouseState.LeftButton == ButtonState.Released,
            // Check if the middle button was just pressed
            MouseInputTypes.MiddleButton => _instance._currentMouseState.MiddleButton == ButtonState.Pressed &&
                                            _instance._previousMouseState.MiddleButton == ButtonState.Released,
            // Check if the right button was just pressed
            MouseInputTypes.RightButton => _instance._currentMouseState.RightButton == ButtonState.Pressed &&
                                           _instance._previousMouseState.RightButton == ButtonState.Released,
            // Default case if no valid button is provided
            _ => false
        };
    }

    // Method to get the change in mouse position
    public static float GetMouseAxis(MouseInputTypes mouseDelta)
    {
        // Switch case to check which axis's change is to be checked
        switch (mouseDelta)
        {
            // Check the change in horizontal position
            case MouseInputTypes.Horizontal:
                return _instance._currentMouseState.X -
                       _instance._previousMouseState.X;
            // Check the change in vertical position
            case MouseInputTypes.Vertical:
                return -(_instance._currentMouseState.Y -
                         _instance._previousMouseState.Y);
            // Default case if no valid axis is provided
            case MouseInputTypes.None:
                break;
        }

        // Return 0 if no valid axis is provided
        return 0;
    }

    // Method to get the current mouse position
    public static Vector2 GetMouseScreenPosition()
    {
        // Convert the current mouse position to a Vector2 and return it
        return _instance._currentMouseState.Position.ToVector2();
    }

    // Method to get the current mouse position in a specific axis
    public static int GetMouseScreenPosition(MouseInputTypes mouseDelta)
    {
        // Switch case to check which axis's position is to be checked
        return mouseDelta switch
        {
            // Check the horizontal position
            MouseInputTypes.Horizontal => _instance._currentMouseState.Position.X,
            // Check the vertical position
            MouseInputTypes.Vertical => _instance._currentMouseState.Position.Y,
            // Default case if no valid axis is provided
            _ => 0
        };
    }
}

// Importing necessary namespaces
using System;
using System.Collections.Generic;
using JetBoxer2D.Engine.Input.Enums;
using JetBoxer2D.Engine.Input.Objects;
using JetBoxer2D.Game.InputMaps;
using JetBoxer2D.Game.States;
using Microsoft.Xna.Framework;

// Defining the namespace for the InputManager class
namespace JetBoxer2D.Engine.Input;

// Defining the InputManager class
public class InputManager
{
    // Declaring a private variable of type BaseInputMap
    private BaseInputMap _currentInputMap;

    // Declaring a public variable of type SplashInputMap
    public SplashInputMap _splashInputMap;
    // Declaring a private variable of type GameplayInputMap
    private GameplayInputMap _gameplayInputMap;

    // Constructor for the InputManager class, takes an object of type BaseInputMap as a parameter
    public InputManager(BaseInputMap inputMap)
    {
        // Initializing _splashInputMap with a new instance of SplashInputMap
        _splashInputMap = new SplashInputMap();
        // Initializing _gameplayInputMap with a new instance of GameplayInputMap
        _gameplayInputMap = new GameplayInputMap();

        // Setting the _currentInputMap to the inputMap passed to the constructor
        _currentInputMap = inputMap;
    }

    // Method to set the _currentInputMap to a new input map
    public void SetInputMap(BaseInputMap inputMap)
    {
        _currentInputMap = inputMap;
    }

    // Method to update the current input map
    public void UpdateInput()
    {
        _currentInputMap.UpdateInput();
    }

    // Method to get the state of a button from the current input map
    public bool GetButton(BaseInputAction inputAction)
    {
        // Checking if the inputAction is null, if so, throw an exception
        if (inputAction == null)
            throw new ArgumentException($"A BaseInputAction in this InputMap hasn't been initialized");

        // Checking if the ButtonInputDictionaries of the inputAction is null, if so, throw an exception
        if (inputAction.ButtonInputDictionaries == null)
            throw new ArgumentException($"The Button Dictionary of {inputAction} is empty");

        // Looping through each item in the ButtonInputDictionaries of the inputAction
        foreach (var list in inputAction.ButtonInputDictionaries)
            // If the button is pressed, return true
            if (list.Item2.Pressed)
                return list.Item2.Pressed;

        // If no button is pressed, return false
        return false;
    }

    // Method to check if a button was pressed down in the current input map
    public bool GetButtonDown(BaseInputAction inputAction)
    {
        // Checking if the inputAction is null, if so, throw an exception
        if (inputAction == null)
            throw new ArgumentException($"A BaseInputAction in this InputMap hasn't been initialized");

        // Checking if the ButtonInputDictionaries of the inputAction is null, if so, throw an exception
        if (inputAction.ButtonInputDictionaries == null)
            throw new ArgumentException($"The Button Dictionary of {nameof(inputAction)} is empty");

        // Looping through each item in the ButtonInputDictionaries of the inputAction
        foreach (var list in inputAction.ButtonInputDictionaries)
            // If the button was pressed down, return true
            if (list.Item2.PressedDown)
                return true;

        // If no button was pressed down, return false
        return false;
    }

    // Method to get the value of an axis from the current input map
    public Vector2 GetAxisValue(BaseInputAction inputAction)
    {
        // Checking if the inputAction is null, if so, throw an exception
        if (inputAction == null)
            throw new ArgumentException($"A BaseInputAction in this InputMap hasn't been initialized");

        // Checking if the AxisInputDictionaries of the inputAction is null, if so, throw an exception
        if (inputAction.AxisInputDictionaries == null)
            throw new ArgumentException($"The Axis Dictionary of {inputAction} is empty");

        // Looping through each item in the AxisInputDictionaries of the inputAction
        foreach (var list in inputAction.AxisInputDictionaries)
            // If the value of the axis is not zero, return the value
            if (list.Item2.Value != Vector2.Zero)
                return list.Item2.Value;

        // If no axis has a non-zero value, return a zero vector
        return Vector2.Zero;
    }

    // Method to get the value of an input action from the current input map
    public float GetValue(BaseInputAction inputAction)
    {
        // Checking if the inputAction is null, if so, throw an exception
        if (inputAction == null)
            throw new ArgumentException($"A BaseInputAction in this InputMap hasn't been initialized");

        // Checking if the ValueInputDictionaries of the inputAction is null, if so, throw an exception
        if (inputAction.ValueInputDictionaries == null)
            throw new ArgumentException($"The Value Dictionary of {inputAction} is empty");

        // Looping through each item in the ValueInputDictionaries of the inputAction
        foreach (var list in inputAction.ValueInputDictionaries)
            // If the value is not zero, return the value
            if (list.Item2.Value != 0)
                return list.Item2.Value;

        // If no value is non-zero, return zero
        return 0;
    }

    // Method to remap the input actions in the current input map
    public void RemapInput(Dictionary<InputDevices, List<Enum>> inputActionDict, InputDevices inputDevice,
        List<Enum> newButtons)
    {
        _currentInputMap.RemapInputAction(inputActionDict, inputDevice, newButtons);
    }
}

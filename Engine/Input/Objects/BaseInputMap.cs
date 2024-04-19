// Importing the required namespaces
using System;
using System.Collections.Generic;
using JetBoxer2D.Engine.Input.Enums;

// Declaring a namespace for the BaseInputMap class
namespace JetBoxer2D.Engine.Input.Objects
{
    // Defining the abstract BaseInputMap class
    public abstract class BaseInputMap
    {
        // Method to initialize the input action dictionary with device and buttons
        protected void InitializeInputActionDictionary(Dictionary<InputDevices, Enum> inputActionDict, InputDevices inputDevice, Enum inputButtons)
        {
            // Try adding the input device and buttons to the dictionary
            inputActionDict.TryAdd(inputDevice, inputButtons);
        }

        // Virtual method to update input from keyboard, gamepad, and mouse
        public virtual void UpdateInput()
        {
            // Calling specific methods to update keyboard, gamepad, and mouse input
            UpdateKeyboardInput();
            UpdateGamepadInput();
            UpdateMouseInput();
        }

        // Protected virtual methods to update keyboard, mouse, and gamepad input
        protected virtual void UpdateKeyboardInput() { }
        protected virtual void UpdateMouseInput() { }
        protected virtual void UpdateGamepadInput() { }

        // Abstract method to remap input actions based on the dictionary of input actions
        public abstract void RemapInputAction(Dictionary<InputDevices, List<Enum>> inputActionDict, InputDevices inputType, List<Enum> newInput);
    }
}

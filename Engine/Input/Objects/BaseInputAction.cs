// Importing the required namespaces
using System;
using System.Collections.Generic;
using JetBoxer2D.Engine.Input.Enums;
using JetBoxer2D.Engine.Input.InputTypes;

// Declaring a namespace for the BaseInputAction class
namespace JetBoxer2D.Engine.Input.Objects
{
    // Defining the BaseInputAction class
    public class BaseInputAction
    {
        // Properties to store dictionaries of different input types for various devices
        public List<(Dictionary<InputDevices, Enum>, BaseInput)> BaseInputDictionaries { get; }
        public List<(Dictionary<InputDevices, Enum>, ButtonInput)> ButtonInputDictionaries { get; }
        public List<(Dictionary<InputDevices, Enum>, AxisInput)> AxisInputDictionaries { get; }
        public List<(Dictionary<InputDevices, Enum>, ValueInput)> ValueInputDictionaries { get; }

        // Constructor to initialize the input dictionaries
        protected BaseInputAction()
        {
            BaseInputDictionaries = new List<(Dictionary<InputDevices, Enum>, BaseInput)>();
            ButtonInputDictionaries = new List<(Dictionary<InputDevices, Enum>, ButtonInput)>();
            AxisInputDictionaries = new List<(Dictionary<InputDevices, Enum>, AxisInput)>();
            ValueInputDictionaries = new List<(Dictionary<InputDevices, Enum>, ValueInput)>();
        }

        // Method to add a BaseInput to the input dictionary
        public virtual void AddBaseInputToInputDictionary(Dictionary<InputDevices, Enum> inputDict, BaseInput input)
        {
            BaseInputDictionaries.Add((inputDict, input));
        }

        // Method to add a ButtonInput to the input dictionary
        public virtual void AddButtonToInputDictionary(Dictionary<InputDevices, Enum> inputDict, ButtonInput input)
        {
            ButtonInputDictionaries.Add((inputDict, input));
        }

        // Method to add an AxisInput to the input dictionary
        public virtual void AddAxisToInputDictionary(Dictionary<InputDevices, Enum> inputDict, AxisInput input)
        {
            AxisInputDictionaries.Add((inputDict, input));
        }

        // Method to add a ValueInput to the input dictionary
        public virtual void AddValueToInputDictionary(Dictionary<InputDevices, Enum> inputDict, ValueInput input)
        {
            ValueInputDictionaries.Add((inputDict, input));
        }
    }
}

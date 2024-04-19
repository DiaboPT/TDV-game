using System;
using System.Collections.Generic;
using JetBoxer2D.Engine.Extensions;
using JetBoxer2D.Engine.Input.Enums;
using JetBoxer2D.Engine.Input.InputTypes;
using JetBoxer2D.Engine.Input.Objects;
using Microsoft.Xna.Framework.Input;

namespace JetBoxer2D.Game.InputMaps;

#region Input Actions

// Define input action classes for various actions (e.g., Move, Look, Shoot)
public class MoveLeft : BaseInputAction
{
}

public class MoveRight : BaseInputAction
{
}

public class MoveUp : BaseInputAction
{
}

public class MoveDown : BaseInputAction
{
}

public class LookLeft : BaseInputAction
{
}

public class LookRight : BaseInputAction
{
}

public class LookUp : BaseInputAction
{
}

public class LookDown : BaseInputAction
{
}

public class ShootLeft : BaseInputAction
{
}

public class ShootRight : BaseInputAction
{
}

#endregion

public class GameplayInputMap : BaseInputMap
{
    // Define static instances for each input action
    public static MoveLeft MoveLeft;
    public static MoveRight MoveRight;
    public static MoveUp MoveUp;
    public static MoveDown MoveDown;

    public static LookLeft LookLeft;
    public static LookRight LookRight;
    public static LookUp LookUp;
    public static LookDown LookDown;

    public static ShootLeft ShootLeft;
    public static ShootRight ShootRight;

    public GameplayInputMap()
    {
        InitializeInputActions();
        InitializeInputActionDictionaries();
    }

    private void InitializeInputActions()
    {
        // Initialize input actions (create instances)
        MoveLeft = new MoveLeft();
        MoveRight = new MoveRight();
        MoveDown = new MoveDown();
        MoveUp = new MoveUp();

        LookLeft = new LookLeft();
        LookRight = new LookRight();
        LookDown = new LookDown();
        LookUp = new LookUp();

        ShootLeft = new ShootLeft();
        ShootRight = new ShootRight();
    }

    private void InitializeInputActionDictionaries()
    {
        // Initialize input dictionaries for various actions
        #region MoveHorizontal

        MoveRight.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(), new ValueInput());
        InitializeInputActionDictionary(MoveRight.ValueInputDictionaries[0].Item1, InputDevices.Keyboard, Keys.D);
        InitializeInputActionDictionary(MoveRight.ValueInputDictionaries[0].Item1, InputDevices.Gamepad,
            Buttons.LeftThumbstickRight);

        MoveRight.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(), new ValueInput());
        InitializeInputActionDictionary(MoveRight.ValueInputDictionaries[1].Item1, InputDevices.Keyboard, Keys.Right);
        InitializeInputActionDictionary(MoveRight.ValueInputDictionaries[1].Item1, InputDevices.Gamepad,
            Buttons.DPadRight);

        MoveLeft.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(), new ValueInput());
        InitializeInputActionDictionary(MoveLeft.ValueInputDictionaries[0].Item1, InputDevices.Keyboard, Keys.A);
        InitializeInputActionDictionary(MoveLeft.ValueInputDictionaries[0].Item1, InputDevices.Gamepad,
            Buttons.LeftThumbstickLeft);

        MoveLeft.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(), new ValueInput());
        InitializeInputActionDictionary(MoveLeft.ValueInputDictionaries[1].Item1, InputDevices.Keyboard, Keys.Left);
        InitializeInputActionDictionary(MoveLeft.ValueInputDictionaries[1].Item1, InputDevices.Gamepad,
            Buttons.DPadLeft);

        #endregion

        #region MoveVertical

        MoveDown.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(), new ValueInput());
        InitializeInputActionDictionary(MoveDown.ValueInputDictionaries[0].Item1, InputDevices.Keyboard, Keys.S);
        InitializeInputActionDictionary(MoveDown.ValueInputDictionaries[0].Item1, InputDevices.Gamepad,
            Buttons.LeftThumbstickDown);

        MoveDown.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(), new ValueInput());
        InitializeInputActionDictionary(MoveDown.ValueInputDictionaries[1].Item1, InputDevices.Keyboard, Keys.Down);
        InitializeInputActionDictionary(MoveDown.ValueInputDictionaries[1].Item1, InputDevices.Gamepad,
            Buttons.DPadDown);

        MoveUp.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(), new ValueInput());
        InitializeInputActionDictionary(MoveUp.ValueInputDictionaries[0].Item1, InputDevices.Keyboard, Keys.W);
        InitializeInputActionDictionary(MoveUp.ValueInputDictionaries[0].Item1, InputDevices.Gamepad,
            Buttons.LeftThumbstickUp);

        MoveUp.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(), new ValueInput());
        InitializeInputActionDictionary(MoveUp.ValueInputDictionaries[1].Item1, InputDevices.Keyboard, Keys.Up);
        InitializeInputActionDictionary(MoveUp.ValueInputDictionaries[1].Item1, InputDevices.Gamepad, Buttons.DPadUp);

        #endregion

        #region LookHorizontal


        LookRight.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(), new ValueInput());
        InitializeInputActionDictionary(LookRight.ValueInputDictionaries[0].Item1, InputDevices.Mouse,
            MouseInputTypes.Horizontal);


        LookLeft.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(), new ValueInput());
        InitializeInputActionDictionary(LookLeft.ValueInputDictionaries[0].Item1, InputDevices.Mouse,
            MouseInputTypes.Horizontal);

        #endregion

        #region LookVertical


        LookDown.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(),
            new ValueInput());
        InitializeInputActionDictionary(LookDown.ValueInputDictionaries[0].Item1, InputDevices.Mouse,
            MouseInputTypes.Vertical);


        LookUp.AddValueToInputDictionary(new Dictionary<InputDevices, Enum>(), new ValueInput());
        InitializeInputActionDictionary(LookUp.ValueInputDictionaries[0].Item1, InputDevices.Mouse,
            MouseInputTypes.Vertical);

        #endregion

        #region Shoot Left

        ShootLeft.AddButtonToInputDictionary(new Dictionary<InputDevices, Enum>(),
            new ButtonInput());
        InitializeInputActionDictionary(ShootLeft.ButtonInputDictionaries[0].Item1, InputDevices.Keyboard, Keys.J);
        InitializeInputActionDictionary(ShootLeft.ButtonInputDictionaries[0].Item1, InputDevices.Mouse,
            MouseInputTypes.LeftButton);
        InitializeInputActionDictionary(ShootLeft.ButtonInputDictionaries[0].Item1, InputDevices.Gamepad,
            Buttons.LeftTrigger);

        #endregion

        #region Shoot Right

        ShootRight.AddButtonToInputDictionary(new Dictionary<InputDevices, Enum>(),
            new ButtonInput());
        InitializeInputActionDictionary(ShootRight.ButtonInputDictionaries[0].Item1, InputDevices.Keyboard, Keys.K);
        InitializeInputActionDictionary(ShootRight.ButtonInputDictionaries[0].Item1, InputDevices.Mouse,
            MouseInputTypes.RightButton);
        InitializeInputActionDictionary(ShootRight.ButtonInputDictionaries[0].Item1, InputDevices.Gamepad,
            Buttons.RightTrigger);

        #endregion
    }

    #region Input Dictionary Finders

    private Keys GetInputFromKeyboard(Dictionary<InputDevices, Enum> inputDict)
    {
        if (inputDict.TryGetValue(InputDevices.Keyboard, out var value))
            return (Keys)value;

        return Keys.None;
    }

    private MouseInputTypes GetInputFromMouse(Dictionary<InputDevices, Enum> inputDict)
    {
        if (inputDict.TryGetValue(InputDevices.Mouse, out var value))
            return (MouseInputTypes)value;

        return MouseInputTypes.None;
    }

    private Buttons GetInputFromGamepad(Dictionary<InputDevices, Enum> inputDict)
    {
        if (inputDict.TryGetValue(InputDevices.Gamepad, out var value))
            return (Buttons)value;

        return Buttons.None;
    }

    #endregion

    #region Input Updates

    protected override void UpdateKeyboardInput()
    {
        var keyboardState = Keyboard.GetState();

        foreach (var dictionaryPair in MoveLeft.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (keyboardState.IsKeyDown(GetInputFromKeyboard(inputDictionary)))
            {
                dictionaryPair.Item2.UpdateKeyboardValue(-1);
                break;
            }

            dictionaryPair.Item2.UpdateKeyboardValue(0);
        }

        foreach (var dictionaryPair in MoveRight.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (keyboardState.IsKeyDown(GetInputFromKeyboard(inputDictionary)))
            {
                dictionaryPair.Item2.UpdateKeyboardValue(1);
                break;
            }

            dictionaryPair.Item2.UpdateKeyboardValue(0);
        }

        foreach (var dictionaryPair in MoveDown.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (keyboardState.IsKeyDown(GetInputFromKeyboard(inputDictionary)))
            {
                dictionaryPair.Item2.UpdateKeyboardValue(-1);
                break;
            }

            dictionaryPair.Item2.UpdateKeyboardValue(0);
        }

        foreach (var dictionaryPair in MoveUp.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (keyboardState.IsKeyDown(GetInputFromKeyboard(inputDictionary)))
            {
                dictionaryPair.Item2.UpdateKeyboardValue(1);
                break;
            }

            dictionaryPair.Item2.UpdateKeyboardValue(0);
        }

        foreach (var dictionaryPair in ShootLeft.ButtonInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (keyboardState.IsKeyDown(GetInputFromKeyboard(inputDictionary)))
            {
                dictionaryPair.Item2.UpdateKeyboardValue(true);
                break;
            }

            dictionaryPair.Item2.UpdateKeyboardValue(false);
        }

        foreach (var dictionaryPair in ShootRight.ButtonInputDictionaries)
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

        foreach (var dictionaryPair in LookLeft.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (MouseInput.GetMouseAxis(GetInputFromMouse(inputDictionary)) < 0)
            {
                dictionaryPair.Item2.UpdateMouseValue(MouseInput.GetMouseAxis(GetInputFromMouse(inputDictionary)));
                break;
            }

            dictionaryPair.Item2.UpdateMouseValue(0);
        }


        foreach (var dictionaryPair in LookRight.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (MouseInput.GetMouseAxis(GetInputFromMouse(inputDictionary)) > 0)
            {
                dictionaryPair.Item2.UpdateMouseValue(MouseInput.GetMouseAxis(GetInputFromMouse(inputDictionary)));
                break;
            }

            dictionaryPair.Item2.UpdateMouseValue(0);
        }


        foreach (var dictionaryPair in LookDown.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (MouseInput.GetMouseAxis(GetInputFromMouse(inputDictionary)) < 0)
            {
                dictionaryPair.Item2.UpdateMouseValue(MouseInput.GetMouseAxis(GetInputFromMouse(inputDictionary)));
                break;
            }

            dictionaryPair.Item2.UpdateMouseValue(0);
        }


        foreach (var dictionaryPair in LookUp.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (MouseInput.GetMouseAxis(GetInputFromMouse(inputDictionary)) > 0)
            {
                dictionaryPair.Item2.UpdateMouseValue(MouseInput.GetMouseAxis(GetInputFromMouse(inputDictionary)));
                break;
            }

            dictionaryPair.Item2.UpdateMouseValue(0);
        }

        foreach (var dictionaryPair in ShootLeft.ButtonInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (MouseInput.IsButtonDown(GetInputFromMouse(inputDictionary)))
            {
                dictionaryPair.Item2.UpdateMouseValue(true);
                break;
            }

            dictionaryPair.Item2.UpdateMouseValue(false);
        }

        foreach (var dictionaryPair in ShootRight.ButtonInputDictionaries)
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

        foreach (var dictionaryPair in MoveLeft.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (gamepadState.IsButtonDown(GetInputFromGamepad(inputDictionary)))
            {
                dictionaryPair.Item2.UpdateGamepadValue(-1);
                break;
            }

            dictionaryPair.Item2.UpdateGamepadValue(0);
        }

        foreach (var dictionaryPair in MoveRight.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (gamepadState.IsButtonDown(GetInputFromGamepad(inputDictionary)))
            {
                dictionaryPair.Item2.UpdateGamepadValue(1);
                break;
            }

            dictionaryPair.Item2.UpdateGamepadValue(0);
        }

        foreach (var dictionaryPair in MoveDown.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (gamepadState.IsButtonDown(GetInputFromGamepad(inputDictionary)))
            {
                dictionaryPair.Item2.UpdateGamepadValue(-1);
                break;
            }

            dictionaryPair.Item2.UpdateGamepadValue(0);
        }

        foreach (var dictionaryPair in MoveUp.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (gamepadState.IsButtonDown(GetInputFromGamepad(inputDictionary)))
            {
                dictionaryPair.Item2.UpdateGamepadValue(1);
                break;
            }

            dictionaryPair.Item2.UpdateGamepadValue(0);
        }


        foreach (var dictionaryPair in LookLeft.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (gamepadState.ThumbSticks.Right.X < 0)
            {
                dictionaryPair.Item2.UpdateGamepadValue(gamepadState.ThumbSticks.Right.X);
                break;
            }

            dictionaryPair.Item2.UpdateGamepadValue(0);
        }


        foreach (var dictionaryPair in LookRight.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (gamepadState.ThumbSticks.Right.X > 0)
            {
                dictionaryPair.Item2.UpdateGamepadValue(gamepadState.ThumbSticks.Right.X);
                break;
            }

            dictionaryPair.Item2.UpdateGamepadValue(0);
        }


        foreach (var dictionaryPair in LookDown.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (gamepadState.ThumbSticks.Right.Y < 0)
            {
                dictionaryPair.Item2.UpdateGamepadValue(gamepadState.ThumbSticks.Right.Y);
                break;
            }

            dictionaryPair.Item2.UpdateGamepadValue(0);
        }


        foreach (var dictionaryPair in LookUp.ValueInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (gamepadState.ThumbSticks.Right.Y > 0)
            {
                dictionaryPair.Item2.UpdateGamepadValue(gamepadState.ThumbSticks.Right.Y);
                break;
            }

            dictionaryPair.Item2.UpdateGamepadValue(0);
        }


        foreach (var dictionaryPair in
                 ShootLeft.ButtonInputDictionaries)
        {
            var inputDictionary = dictionaryPair.Item1;
            if (gamepadState.IsButtonDown(GetInputFromGamepad(inputDictionary)))
            {
                dictionaryPair.Item2.UpdateGamepadValue(true);
                break;
            }

            dictionaryPair.Item2.UpdateGamepadValue(false);
        }


        foreach (var dictionaryPair in
                 ShootRight.ButtonInputDictionaries)
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

    #endregion

    public override void RemapInputAction(Dictionary<InputDevices, List<Enum>> inputActionDict, InputDevices inputType,
        List<Enum> newInput)
    {
        inputActionDict.Remove(inputType);
        inputActionDict.TryAdd(inputType, newInput);
    }
}

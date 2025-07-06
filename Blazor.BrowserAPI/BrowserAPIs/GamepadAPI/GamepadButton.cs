namespace BrowserAPI;

/// <summary>
/// <para>The <i>GamepadButton</i> interface defines an individual button of a gamepad or other controller, allowing access to the current state of different types of buttons available on the control device.</para>
/// <para>A <i>GamepadButton</i> object is returned by querying any value of the array returned by the buttons property of the Gamepad interface.</para>
/// </summary>
public readonly record struct GamepadButton {
    /// <summary>
    /// A boolean value indicating whether the button is currently pressed (true) or unpressed (false).
    /// </summary>
    public bool Pressed { get; init; }

    /// <summary>
    /// <para>A boolean value indicating whether the button is currently touched (true) or not touched (false).</para>
    /// <para>
    /// If the button is not capable of detecting touch but can return an analog value, the property will be true if the value is greater than 0, and false otherwise.
    /// If the button is not capable of detecting touch and can only report a digital value, then it should mirror the GamepadButton.pressed property.
    /// </para>
    /// </summary>
    public bool Touched { get; init; }

    /// <summary>
    /// <para>A double value used to represent the current state of analog buttons, such as the triggers on many modern gamepads.</para>
    /// <para>The values are normalized to the range 0.0 —1.0, with 0.0 representing a button that is not pressed, and 1.0 representing a button that is fully pressed.</para>
    /// </summary>
    public double Value { get; init; }
}

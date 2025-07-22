using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>Gamepad</i> interface of the Gamepad API defines an individual gamepad or other controller, allowing access to information such as button presses, axis positions, and id.</para>
/// <para>
/// A Gamepad object can be returned in one of two ways:
/// via the gamepad property of the <see cref="IGamepadAPI.OnGamepadConnected">gamepadconnected</see> and <see cref="IGamepadAPI.OnGamepadDisconnected">gamepaddisconnected</see> events,
/// or by grabbing any position in the array returned by the <see cref="IGamepadAPI.GetGamepads">Navigator.getGamepads()</see> method.
/// </para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class Gamepad(IJSObjectReference gamepadJS) : GamepadBase(gamepadJS), IGamepad {
    /// <summary>
    /// Releases the JS instance for this gamepad.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() => gamepadJS.DisposeTrySync();


    /// <summary>
    /// <para>An array representing the controls with axes present on the device (e.g., analog thumb sticks).</para>
    /// <para>Each entry in the array is a floating point value in the range -1.0 – 1.0, representing the axis position from the lowest value (-1.0) to the highest value (1.0).</para>
    /// </summary>
    public ValueTask<double[]> Axes => GetAxes(default);

    /// <inheritdoc cref="Axes" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double[]> GetAxes(CancellationToken cancellationToken) => gamepadJS.InvokeTrySync<double[]>("getAxes", cancellationToken);


    /// <summary>
    /// <para>An array of <see cref="GamepadButton"/> objects representing the buttons present on the device.</para>
    /// <para>Each entry in the array is 0 if the button is not pressed, and non-zero (typically 1.0) if the button is pressed.</para>
    /// </summary>
    public ValueTask<GamepadButton[]> Buttons => GetButtons(default);

    /// <inheritdoc cref="Buttons" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<GamepadButton[]> GetButtons(CancellationToken cancellationToken) => gamepadJS.InvokeTrySync<GamepadButton[]>("getButtons", cancellationToken);



    /// <summary>
    /// <para>A boolean indicating whether the gamepad is still connected to the system.</para>
    /// <para>If the gamepad is connected, the value is true; if not, it is false.</para>
    /// </summary>
    public ValueTask<bool> Connected => GetConnected(default);

    /// <inheritdoc cref="Connected" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetConnected(CancellationToken cancellationToken) => gamepadJS.InvokeTrySync<bool>("getConnected", cancellationToken);


    /// <summary>
    /// <para>A string containing identifying information about the controller.</para>
    /// <para>
    /// The exact syntax is not strictly specified, but in Firefox it will contain three pieces of information separated by dashes (-):<br />
    /// - Two 4-digit hexadecimal strings containing the USB vendor and product id of the controller<br />
    /// - The name of the controller as provided by the driver.<br />
    /// For example, a PS2 controller returned <i>810-3-USB Gamepad</i>.
    /// </para>
    /// <para>This information is intended to allow you to find a mapping for the controls on the device as well as display useful feedback to the user.</para>
    /// </summary>
    public ValueTask<string> Id => GetId(default);

    /// <inheritdoc cref="Id" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetId(CancellationToken cancellationToken) => gamepadJS.InvokeTrySync<string>("getId", cancellationToken);


    /// <summary>
    /// <para>An integer that is auto-incremented to be unique for each device currently connected to the system.</para>
    /// <para>This can be used to distinguish multiple controllers; a gamepad that is disconnected and reconnected will retain the same index.</para>
    /// </summary>
    public ValueTask<int> Index => GetIndex(default);

    /// <inheritdoc cref="Index" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetIndex(CancellationToken cancellationToken) => gamepadJS.InvokeTrySync<int>("getIndex", cancellationToken);


    /// <summary>
    /// <para>A string indicating whether the browser has remapped the controls on the device to a known layout.</para>
    /// <para>
    /// The currently supported known layouts are:<br />
    /// - "standard" for the <see href="https://w3c.github.io/gamepad/#remapping">standard gamepad</see>.<br />
    /// - "xr-standard for the <see href="https://immersive-web.github.io/webxr-gamepads-module/#xr-standard-heading">standard XR gamepad</see>. See also <see href="https://developer.mozilla.org/en-US/docs/Web/API/XRInputSource/gamepad">XRInputSource.gamepad</see>.
    /// </para>
    /// </summary>
    public ValueTask<string> Mapping => GetMapping(default);

    /// <inheritdoc cref="Mapping" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetMapping(CancellationToken cancellationToken) => gamepadJS.InvokeTrySync<string>("getMapping", cancellationToken);


    /// <summary>
    /// <para>A <see href="https://developer.mozilla.org/en-US/docs/Web/API/DOMHighResTimeStamp">DOMHighResTimeStamp</see> representing the last time the data for this gamepad was updated.</para>
    /// <para>
    /// The idea behind this is to allow developers to determine if the axes and button data have been updated from the hardware.
    /// The value must be relative to the navigationStart attribute of the PerformanceTiming interface.Values are monotonically increasing,
    /// meaning that they can be compared to determine the ordering of updates, as newer values will always be greater than or equal to older values.</para>
    /// <para>Note: This property is not currently supported anywhere.</para>
    /// </summary>
    public ValueTask<double> Timestamp => GetTimestamp(default);

    /// <inheritdoc cref="Timestamp" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetTimestamp(CancellationToken cancellationToken) => gamepadJS.InvokeTrySync<double>("getTimestamp", cancellationToken);



    /// <summary>
    /// <para>Returns an array of enumerated values representing the different haptic effects that the actuator supports.</para>
    /// <para>
    /// Possible included values are:<br />
    /// - "dual-rumble": A positional rumbling effect created by dual vibration motors in each handle of a controller, which can be vibrated independently.<br />
    /// - "trigger-rumble": Localized rumbling effects on the surface of a controller's trigger buttons created by vibrational motors located in each button. These buttons most commonly take the form of spring-loaded triggers.<br />
    /// - "vibration": Simple vibration hardware, which creates a rumbling effect.
    /// </para>
    /// <para>If no vibration is supported, an empty array is returned.</para>
    /// <remarks>Browser support: If the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Gamepad/vibrationActuator">vibrationActuator</see> property is not supported, an empty array is returned.
    /// If <see href="https://developer.mozilla.org/en-US/docs/Web/API/GamepadHapticActuator/effects">effects</see> property is not supported, the <see href="https://developer.mozilla.org/en-US/docs/Web/API/GamepadHapticActuator/type">type</see> property is used instead.</remarks>
    /// </summary>
    public ValueTask<string[]> VibrationActuatorEffects => GetVibrationActuatorEffects(default);

    /// <inheritdoc cref="VibrationActuatorEffects" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string[]> GetVibrationActuatorEffects(CancellationToken cancellationToken) => gamepadJS.InvokeTrySync<string[]>("getVibrationActuatorEffects", cancellationToken);
}

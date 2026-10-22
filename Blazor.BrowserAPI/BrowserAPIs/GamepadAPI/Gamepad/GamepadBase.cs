using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IGamepad"/> and <see cref="IGamepadInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <param name="gamepadJS"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class GamepadBase<TJSObjectReference>(TJSObjectReference gamepadJS) where TJSObjectReference : IJSObjectReference {
    private protected TJSObjectReference gamepadJS = gamepadJS;


    /// <summary>
    /// Causes the hardware to play a specific vibration effect.
    /// </summary>
    /// <param name="type">
    /// A string representing the desired effect.
    /// Possible values are "dual-rumble" and "trigger-rumble", and their effects can vary depending on the hardware type.
    /// Use <i>VibrationActuatorEffects</i> to get the effect types.
    /// </param>
    /// <param name="duration">The duration of the effect in milliseconds. Defaults to 0.</param>
    /// <param name="startDelay">The delay in milliseconds before the effect is started. Defaults to 0.</param>
    /// <param name="strongMagnitude">The rumble intensity of the low-frequency (strong) rumble motors, normalized to the range between 0.0 and 1.0. Defaults to 0.0.</param>
    /// <param name="weakMagnitude">The rumble intensity of the high-frequency (weak) rumble motors, normalized to the range between 0.0 and 1.0. Defaults to 0.0.</param>
    /// <param name="leftTrigger">The rumble intensity of the bottom-left front trigger, normalized to the range between 0.0 and 1.0. Defaults to 0.0.</param>
    /// <param name="rightTrigger">The rumble intensity of the bottom-right front trigger, normalized to the range between 0.0 and 1.0. Defaults to 0.0.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// A promise that resolves with<br />
    /// - "complete": When the effect successfully completes.<br />
    /// - "preempted": If the current effect is stopped or replaced by another effect.<br />
    /// - "none": If vibration is not supported.
    /// </returns>
    public ValueTask<string> PlayVibrationActuatorEffect(string type, double duration = 0.0, double startDelay = 0.0, double strongMagnitude = 0.0, double weakMagnitude = 0.0, double leftTrigger = 0.0, double rightTrigger = 0.0, CancellationToken cancellationToken = default)
        => gamepadJS.InvokeAsync<string>("playVibrationActuatorEffect", cancellationToken, [type, duration, startDelay, strongMagnitude, weakMagnitude, leftTrigger, rightTrigger]);

    /// <summary>
    /// Stops the hardware from playing an active vibration effect.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// A promise that resolves with<br />
    /// - "complete": If the effect is successfully reset.<br />
    /// - "preempted": If the effect was stopped or replaced by another effect.<br />
    /// - "none": If vibration is not supported.
    /// </returns>
    public ValueTask<string> ResetVibrationActuator(CancellationToken cancellationToken = default)
        => gamepadJS.InvokeAsync<string>("resetVibrationActuator", cancellationToken);
}

using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>Gamepad API</i> is a way for developers to access and respond to signals from gamepads and other game controllers in a simple, consistent way.
/// It contains three interfaces, two events and one specialist function, to respond to gamepads being connected and disconnected,
/// and to access other information about the gamepads themselves, and what buttons and other controls are currently being pressed.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IGamepadAPIBase<IJSInProcessObjectReference, IGamepadInProcess>)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class GamepadAPIInProcess(IModuleManager moduleManager) : GamepadAPIBase<IJSInProcessObjectReference, IGamepadInProcess>(moduleManager), IGamepadAPIInProcess {
    /// <summary>
    /// <para>Returns an array of <see cref="IGamepadInProcess"/> objects, one for each connected gamepad.</para>
    /// <para>Elements in the array may be <i>null</i> if a gamepad disconnects during a session, so that the remaining gamepads retain the same index.</para>
    /// </summary>
    /// <returns></returns>
    public IGamepadInProcess?[] GetGamepads() {
        IJSInProcessObjectReference?[] gamepads = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("GamepadInterfaceAPI.getGamepads");

        GamepadInProcess?[] result = new GamepadInProcess?[gamepads.Length];
        for (int i = 0; i < result.Length; i++)
            if (gamepads[i] != null)
                result[i] = new GamepadInProcess(gamepads[i]!);
            else
                result[i] = null;
        return result;
    }
}

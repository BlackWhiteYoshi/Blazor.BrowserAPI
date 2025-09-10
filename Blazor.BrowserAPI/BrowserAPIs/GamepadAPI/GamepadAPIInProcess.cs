using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>Gamepad API</i> is a way for developers to access and respond to signals from gamepads and other game controllers in a simple, consistent way.
/// It contains three interfaces, two events and one specialist function, to respond to gamepads being connected and disconnected,
/// and to access other information about the gamepads themselves, and what buttons and other controls are currently being pressed.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class GamepadAPIInProcess(IModuleManager moduleManager) : IGamepadAPIInProcess, IDisposable {
    /// <summary>
    /// Releases the <see cref="EventTrigger"/> object used to trigger the events.
    /// </summary>
    public void Dispose() => _objectReferenceEventTrigger?.Dispose();


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


    #region Events

    [method: DynamicDependency(nameof(InvokeGamepadConnected))]
    [method: DynamicDependency(nameof(InvokeGamepadDisconnected))]
    [RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
    private sealed class EventTrigger(GamepadAPIInProcess gamepadAPI) {
        [JSInvokable] public void InvokeGamepadConnected(IJSInProcessObjectReference gamepad) => gamepadAPI._onGamepadConnected?.Invoke(new GamepadInProcess(gamepad));
        [JSInvokable] public void InvokeGamepadDisconnected(IJSInProcessObjectReference gamepad) => gamepadAPI._onGamepadDisconnected?.Invoke(new GamepadInProcess(gamepad));
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private void InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        moduleManager.InvokeSync("GamepadInterfaceAPI.initEvents", [_objectReferenceEventTrigger]);
    }


    private void ActivateJSEvent(string jsMethodName) {
        InitEventTrigger();
        moduleManager.InvokeSync(jsMethodName);
    }

    private void DeactivateJSEvent(string jsMethodName) => moduleManager.InvokeSync(jsMethodName);


    private Action<IGamepadInProcess>? _onGamepadConnected;
    /// <summary>
    /// <para>
    /// Is fired when the browser detects that a gamepad has been connected or the first time a button/axis of the gamepad is used.<br />
    /// The event will not fire if disallowed by the document's gamepad Permissions Policy.<br />
    /// This event is not cancelable and does not bubble.
    /// </para>
    /// <para>
    /// Parameter is the connected Gamepad.<br />
    /// Note: Dispose the given Gamepad object when you are done with it.
    /// </para>
    /// </summary>
    public event Action<IGamepadInProcess> OnGamepadConnected {
        add {
            if (_onGamepadConnected == null)
                ActivateJSEvent("GamepadInterfaceAPI.activateOngamepadconnected");
            _onGamepadConnected += value;
        }
        remove {
            _onGamepadConnected -= value;
            if (_onGamepadConnected == null)
                DeactivateJSEvent("GamepadInterfaceAPI.deactivateOngamepadconnected");
        }
    }

    private Action<IGamepadInProcess>? _onGamepadDisconnected;
    /// <summary>
    /// <para>
    /// Is fired when the browser detects that a gamepad has been disconnected.<br />
    /// The event will not fire if disallowed by the document's gamepad Permissions Policy.<br />
    /// This event is not cancelable and does not bubble.
    /// </para>
    /// <para>
    /// Parameter is the disconnected Gamepad.<br />
    /// Note: Dispose the given Gamepad object when you are done with it.
    /// </para>
    /// </summary>
    public event Action<IGamepadInProcess> OnGamepadDisconnected {
        add {
            if (_onGamepadDisconnected == null)
                ActivateJSEvent("GamepadInterfaceAPI.activateOngamepaddisconnected");
            _onGamepadDisconnected += value;
        }
        remove {
            _onGamepadDisconnected -= value;
            if (_onGamepadDisconnected == null)
                DeactivateJSEvent("GamepadInterfaceAPI.deactivateOngamepaddisconnected");
        }
    }

    #endregion
}

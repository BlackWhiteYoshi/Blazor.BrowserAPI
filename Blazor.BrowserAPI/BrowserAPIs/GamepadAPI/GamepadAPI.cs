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
public sealed class GamepadAPI(IModuleManager moduleManager) : IGamepadAPI, IDisposable {
    /// <summary>
    /// Releases the <see cref="EventTrigger"/> object used to trigger the events.
    /// </summary>
    public void Dispose() => _objectReferenceEventTrigger?.Dispose();


    /// <summary>
    /// <para>Returns an array of <see cref="IGamepad"/> objects, one for each connected gamepad.</para>
    /// <para>Elements in the array may be <i>null</i> if a gamepad disconnects during a session, so that the remaining gamepads retain the same index.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IGamepad?[]> GetGamepads(CancellationToken cancellationToken = default) {
        IJSObjectReference?[] gamepads = await moduleManager.InvokeTrySync<IJSObjectReference?[]>("GamepadInterfaceAPI.getGamepads", cancellationToken);

        Gamepad?[] result = new Gamepad?[gamepads.Length];
        for (int i = 0; i < result.Length; i++)
            if (gamepads[i] != null)
                result[i] = new Gamepad(gamepads[i]!);
            else
                result[i] = null;
        return result;
    }


    #region Events

    [method: DynamicDependency(nameof(InvokeGamepadConnected))]
    [method: DynamicDependency(nameof(InvokeGamepadDisconnected))]
    [RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
    private sealed class EventTrigger(GamepadAPI gamepadAPI) {
        [JSInvokable] public void InvokeGamepadConnected(IJSObjectReference gamepad) => gamepadAPI._onGamepadConnected?.Invoke(new Gamepad(gamepad));
        [JSInvokable] public void InvokeGamepadDisconnected(IJSObjectReference gamepad) => gamepadAPI._onGamepadDisconnected?.Invoke(new Gamepad(gamepad));
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return moduleManager.InvokeTrySync("GamepadInterfaceAPI.initEvents", CancellationToken.None, [_objectReferenceEventTrigger]);
    }


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await moduleManager.InvokeTrySync(jsMethodName, CancellationToken.None);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => moduleManager.InvokeTrySync(jsMethodName, CancellationToken.None);


    private Action<IGamepad>? _onGamepadConnected;
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
    public event Action<IGamepad> OnGamepadConnected {
        add {
            if (_onGamepadConnected == null)
                _ = ActivateJSEvent("GamepadInterfaceAPI.activateOngamepadconnected").Preserve();
            _onGamepadConnected += value;
        }
        remove {
            _onGamepadConnected -= value;
            if (_onGamepadConnected == null)
                _ = DeactivateJSEvent("GamepadInterfaceAPI.deactivateOngamepadconnected").Preserve();
        }
    }

    private Action<IGamepad>? _onGamepadDisconnected;
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
    public event Action<IGamepad> OnGamepadDisconnected {
        add {
            if (_onGamepadDisconnected == null)
                _ = ActivateJSEvent("GamepadInterfaceAPI.activateOngamepaddisconnected").Preserve();
            _onGamepadDisconnected += value;
        }
        remove {
            _onGamepadDisconnected -= value;
            if (_onGamepadDisconnected == null)
                _ = DeactivateJSEvent("GamepadInterfaceAPI.deactivateOngamepaddisconnected").Preserve();
        }
    }

    #endregion
}

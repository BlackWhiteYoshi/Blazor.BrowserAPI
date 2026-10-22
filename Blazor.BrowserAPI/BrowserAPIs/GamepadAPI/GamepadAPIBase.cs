using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IGamepadAPI"/> and <see cref="IGamepadAPIInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <typeparam name="TGamepad"></typeparam>
/// <param name="moduleManager"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class GamepadAPIBase<TJSObjectReference, TGamepad>(IModuleManager moduleManager) : IDisposable
    where TJSObjectReference : IJSObjectReference
    where TGamepad : IGamepadBase<TJSObjectReference> {
    private protected IModuleManager moduleManager = moduleManager;

    /// <summary>
    /// Releases the EventTrigger object used to trigger the events.
    /// </summary>
    public void Dispose() => _objectReferenceEventTrigger?.Dispose();


    #region Events

    [method: DynamicDependency(nameof(InvokeGamepadConnected))]
    [method: DynamicDependency(nameof(InvokeGamepadDisconnected))]
    [RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
    private sealed class EventTrigger(GamepadAPIBase<TJSObjectReference, TGamepad> gamepadAPI) {
        [JSInvokable]
        public void InvokeGamepadConnected(TJSObjectReference gamepadJs) {
            TGamepad gamepad = typeof(TJSObjectReference) == typeof(IJSObjectReference)
                ? (TGamepad)(IGamepad)new Gamepad(gamepadJs)
                : (TGamepad)(IGamepadInProcess)new GamepadInProcess((IJSInProcessObjectReference)gamepadJs);
            gamepadAPI._onGamepadConnected?.Invoke(gamepad);
        }

        [JSInvokable]
        public void InvokeGamepadDisconnected(TJSObjectReference gamepadJs) {
            TGamepad gamepad = typeof(TJSObjectReference) == typeof(IJSObjectReference)
                ? (TGamepad)(IGamepad)new Gamepad(gamepadJs)
                : (TGamepad)(IGamepadInProcess)new GamepadInProcess((IJSInProcessObjectReference)gamepadJs);
            gamepadAPI._onGamepadDisconnected?.Invoke(gamepad);
        }
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


    // Events

    private Action<TGamepad>? _onGamepadConnected;
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
    public event Action<TGamepad> OnGamepadConnected {
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

    private Action<TGamepad>? _onGamepadDisconnected;
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
    public event Action<TGamepad> OnGamepadDisconnected {
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

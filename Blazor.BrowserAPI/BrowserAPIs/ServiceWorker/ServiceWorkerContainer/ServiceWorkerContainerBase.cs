using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerContainer")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerContainerInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class ServiceWorkerContainerBase(IModuleManager moduleManager) : IDisposable {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;

    /// <summary>
    /// Releases the <see cref="EventTrigger"/> object used to trigger the events.
    /// </summary>
    public void Dispose() => _objectReferenceEventTrigger?.Dispose();


    /// <summary>
    /// Registers a service worker.
    /// </summary>
    /// <param name="scriptURL">relative file path to the service worker script (e.g. "/sw.js")</param>
    /// <param name="cancellationToken"></param>
    /// <returns>true, if service worker is supported, otherwise false</returns>
    public ValueTask Register(string scriptURL, CancellationToken cancellationToken = default) => moduleManager.InvokeAsync("ServiceWorkerContainerAPI.register", cancellationToken, [scriptURL]);


    #region Events

    [method: DynamicDependency(nameof(InvokeControllerChange))]
    [method: DynamicDependency(nameof(InvokeMessage))]
    private sealed class EventTrigger(ServiceWorkerContainerBase serviceWorkerContainer) {
        [JSInvokable] public void InvokeControllerChange() => serviceWorkerContainer._onControllerChange?.Invoke();
        [JSInvokable] public void InvokeMessage(JsonElement message) => serviceWorkerContainer._onMessage?.Invoke(message);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return moduleManager.InvokeTrySync("ServiceWorkerContainerAPI.initEvents", default, [_objectReferenceEventTrigger, moduleManager.IsInProcess]);
    }


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await moduleManager.InvokeTrySync(jsMethodName, default);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => moduleManager.InvokeTrySync(jsMethodName, default);


    private Action? _onControllerChange;
    /// <summary>
    /// Occurs when the document's associated <i>ServiceWorkerRegistration</i> acquires a new active worker.
    /// </summary>
    public event Action OnControllerChange {
        add {
            if (_onControllerChange == null)
                _ = ActivateJSEvent("ServiceWorkerContainerAPI.activateOncontrollerchange").Preserve();
            _onControllerChange += value;
        }
        remove {
            _onControllerChange -= value;
            if (_onControllerChange == null)
                _ = DeactivateJSEvent("ServiceWorkerContainerAPI.deactivateOncontrollerchange").Preserve();
        }
    }

    private Action<JsonElement>? _onMessage;
    /// <summary>
    /// <para>The message event is used in a page controlled by a service worker to receive messages from the service worker.</para>
    /// <para>Parameter is <see href="https://developer.mozilla.org/en-US/docs/Web/API/MessageEvent/data">MessageEvent.data</see> as json.</para>
    /// </summary>
    public event Action<JsonElement> OnMessage {
        add {
            if (_onMessage == null)
                _ = ActivateJSEvent("ServiceWorkerContainerAPI.activateOnMessage").Preserve();
            _onMessage += value;
        }
        remove {
            _onMessage -= value;
            if (_onMessage == null)
                _ = DeactivateJSEvent("ServiceWorkerContainerAPI.deactivateOnMessage").Preserve();
        }
    }

    #endregion
}

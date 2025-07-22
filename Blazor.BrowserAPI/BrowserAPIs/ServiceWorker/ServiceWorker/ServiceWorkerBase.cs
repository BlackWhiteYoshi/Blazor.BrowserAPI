using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorker")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class ServiceWorkerBase(IJSObjectReference serviceWorkerJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference serviceWorkerJS = serviceWorkerJS;


    #region Events

    [method: DynamicDependency(nameof(InvokeStateChange))]
    [method: DynamicDependency(nameof(InvokeError))]
    private sealed class EventTrigger(ServiceWorkerBase serviceWorker) {
        [JSInvokable] public void InvokeStateChange(string state) => serviceWorker._onStateChange?.Invoke(state);
        [JSInvokable] public void InvokeError(JsonElement errorEvent) => serviceWorker._onError?.Invoke(errorEvent);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return serviceWorkerJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger, serviceWorkerJS is IJSInProcessObjectReference]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await serviceWorkerJS.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => serviceWorkerJS.InvokeVoidTrySync(jsMethodName);


    private Action<string>? _onStateChange;
    /// <summary>
    /// <para>Fires anytime the ServiceWorker.state changes.</para>
    /// <para>Parameter is the new state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant.</para>
    /// </summary>
    public event Action<string> OnStateChange {
        add {
            if (_onStateChange == null)
                _ = ActivateJSEvent("activateOnstatechange").Preserve();
            _onStateChange += value;
        }
        remove {
            _onStateChange -= value;
            if (_onStateChange == null)
                _ = DeactivateJSEvent("deactivateOnstatechange").Preserve();
        }
    }

    private Action<JsonElement>? _onError;
    /// <summary>
    /// <para>Fires whenever an error occurs in the service worker.</para>
    /// <para>Parameter is of type <see href="https://developer.mozilla.org/en-US/docs/Web/API/Event">Event</see> as JSON.</para>
    /// </summary>
    public event Action<JsonElement> OnError {
        add {
            if (_onError == null)
                _ = ActivateJSEvent("activateOnerror").Preserve();
            _onError += value;
        }
        remove {
            _onError -= value;
            if (_onError == null)
                _ = DeactivateJSEvent("deactivateOnerror").Preserve();
        }
    }

    #endregion
}

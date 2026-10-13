using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// Base interface of <see cref="IServiceWorkerRegistration"/> and <see cref="IServiceWorkerRegistrationInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class ServiceWorkerRegistrationBase<TJSObjectReference, TServiceWorkerRegistration>(TJSObjectReference serviceWorkerRegistrationJS)
    where TJSObjectReference : IJSObjectReference
    where TServiceWorkerRegistration : IServiceWorkerRegistrationBase<TJSObjectReference, TServiceWorkerRegistration> {
    private protected TJSObjectReference serviceWorkerRegistrationJS = serviceWorkerRegistrationJS;


    /// <summary>
    /// Unregisters the service worker registration and returns a Promise.
    /// The promise will resolve to false if no registration was found, otherwise it resolves to true irrespective of whether unregistration happened or not (it may not unregister if someone else just called ServiceWorkerContainer.register() with the same scope.)
    /// The service worker will finish any ongoing operations before it is unregistered.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>false if no registration was found, otherwise true (irrespective of whether unregistration happened or not)</returns>
    public ValueTask<bool> Unregister(CancellationToken cancellationToken = default) => serviceWorkerRegistrationJS.InvokeAsync<bool>("unregister", cancellationToken);

    /// <summary>
    /// Attempts to update the service worker.
    /// It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker.
    /// The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TServiceWorkerRegistration> Update(CancellationToken cancellationToken = default) {
        TJSObjectReference serviceWorkerRegistration = await serviceWorkerRegistrationJS.InvokeAsync<TJSObjectReference>("update", cancellationToken);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TServiceWorkerRegistration)(IServiceWorkerRegistration)new ServiceWorkerRegistration(serviceWorkerRegistration);
        else
            return (TServiceWorkerRegistration)(IServiceWorkerRegistrationInProcess)new ServiceWorkerRegistrationInProcess((IJSInProcessObjectReference)serviceWorkerRegistration);
    }


    #region Events

    [method: DynamicDependency(nameof(InvokeUpdateFound))]
    private sealed class EventTrigger(ServiceWorkerRegistrationBase<TJSObjectReference, TServiceWorkerRegistration> serviceWorkerRegistration) {
        [JSInvokable]
        public void InvokeUpdateFound() => serviceWorkerRegistration._onUpdateFound?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return serviceWorkerRegistrationJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await serviceWorkerRegistrationJS.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => serviceWorkerRegistrationJS.InvokeVoidTrySync(jsMethodName);


    // Events

    private Action? _onUpdateFound;
    /// <summary>
    /// Is fired any time the <i>ServiceWorkerRegistration.installing</i> property acquires a new service worker.
    /// </summary>
    public event Action OnUpdateFound {
        add {
            if (_onUpdateFound == null)
                _ = ActivateJSEvent("activateOnupdatefound").Preserve();
            _onUpdateFound += value;
        }
        remove {
            _onUpdateFound -= value;
            if (_onUpdateFound == null)
                _ = DeactivateJSEvent("deactivateOnupdatefound").Preserve();
            ;
        }
    }

    #endregion
}

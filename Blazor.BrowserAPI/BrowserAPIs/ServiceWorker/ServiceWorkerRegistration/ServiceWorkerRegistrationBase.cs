﻿using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerRegistration")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerRegistrationInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class ServiceWorkerRegistrationBase {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected abstract IJSObjectReference ServiceWorkerRegistrationJS { get; }


    /// <summary>
    /// The <i>unregister()</i> method of the ServiceWorkerRegistration interface unregisters the service worker registration and returns a Promise.
    /// The promise will resolve to false if no registration was found, otherwise it resolves to true irrespective of whether unregistration happened or not (it may not unregister if someone else just called ServiceWorkerContainer.register() with the same scope.)
    /// The service worker will finish any ongoing operations before it is unregistered.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>false if no registration was found, otherwise true (irrespective of whether unregistration happened or not)</returns>
    public ValueTask<bool> Unregister(CancellationToken cancellationToken = default) => ServiceWorkerRegistrationJS.InvokeAsync<bool>("unregister", cancellationToken);

    private protected ValueTask<IJSObjectReference> UpdateBase(CancellationToken cancellationToken = default) => ServiceWorkerRegistrationJS.InvokeAsync<IJSObjectReference>("update", cancellationToken);


    #region Events

    [method: DynamicDependency(nameof(InvokeUpdateFound))]
    private sealed class EventTrigger(ServiceWorkerRegistrationBase serviceWorkerRegistration) {
        [JSInvokable]
        public void InvokeUpdateFound() => serviceWorkerRegistration._onUpdateFound?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return ServiceWorkerRegistrationJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger, ServiceWorkerRegistrationJS is IJSInProcessObjectReference]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await ServiceWorkerRegistrationJS.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => ServiceWorkerRegistrationJS.InvokeVoidTrySync(jsMethodName);


    private Action? _onUpdateFound;
    /// <summary>
    /// The <i>updatefound</i> event of the ServiceWorkerRegistration interface is fired any time the <i>ServiceWorkerRegistration.installing</i> property acquires a new service worker.
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

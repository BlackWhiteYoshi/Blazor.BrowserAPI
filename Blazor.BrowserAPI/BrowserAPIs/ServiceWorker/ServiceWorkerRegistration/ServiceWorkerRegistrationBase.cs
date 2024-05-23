using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>Base class for <see cref="ServiceWorkerRegistration"/> and <see cref="ServiceWorkerRegistrationInProcess"/>.</para>
/// <para>Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call <see cref="DisposeEventTrigger"/> there.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerRegistration")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerRegistrationInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class ServiceWorkerRegistrationBase {
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
    private DotNetObjectReference<EventTrigger> ObjectReferenceEventTrigger => _objectReferenceEventTrigger ??= DotNetObjectReference.Create(new EventTrigger(this));

    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private Action? _onUpdateFound;
    /// <summary>
    /// The <i>updatefound</i> event of the ServiceWorkerRegistration interface is fired any time the <i>ServiceWorkerRegistration.installing</i> property acquires a new service worker.
    /// </summary>
    public event Action OnUpdateFound {
        add {
            if (_onUpdateFound == null)
                Task.Factory.StartNew(async () => await ServiceWorkerRegistrationJS.InvokeVoidTrySync("activateOnupdatefound", default, [ObjectReferenceEventTrigger]));
            _onUpdateFound += value;
        }
        remove {
            _onUpdateFound -= value;
            if (_onUpdateFound == null)
                Task.Factory.StartNew(async () => await ServiceWorkerRegistrationJS.InvokeVoidTrySync("deactivateOnupdatefound", default));
        }
    }

    #endregion
}

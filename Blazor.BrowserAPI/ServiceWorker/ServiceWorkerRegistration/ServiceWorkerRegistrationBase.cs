using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

/// <summary>
/// The <i>ServiceWorkerRegistration</i> interface of the Service Worker API represents the service worker registration. You register a service worker to control one or more pages that share the same origin.
/// </summary>
[AutoInterface(Name = "IServiceWorkerRegistration", Modifier = "public partial")]
[AutoInterface(Name = "IServiceWorkerRegistrationInProcess", Modifier = "public partial")]
internal abstract class ServiceWorkerRegistrationBase {
    protected abstract IJSObjectReference ServiceWorkerRegistrationJS { get; }


    /// <summary>
    /// The <i>unregister()</i> method of the ServiceWorkerRegistration interface unregisters the service worker registration and returns a Promise. The promise will resolve to false if no registration was found, otherwise it resolves to true irrespective of whether unregistration happened or not (it may not unregister if someone else just called ServiceWorkerContainer.register() with the same scope.) The service worker will finish any ongoing operations before it is unregistered.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> Unregister(CancellationToken cancellationToken = default) => ServiceWorkerRegistrationJS.InvokeAsync<bool>("unregister", cancellationToken);

    /// <summary>
    /// The <i>update()</i> method of the ServiceWorkerRegistration interface attempts to update the service worker. It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker. The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected ValueTask<IJSObjectReference> UpdateBase(CancellationToken cancellationToken = default) => ServiceWorkerRegistrationJS.InvokeAsync<IJSObjectReference>("update", cancellationToken);


    #region UpdateFound event

    private Action? _onUpdateFound;
    /// <summary>
    /// The <i>updatefound</i> event of the ServiceWorkerRegistration interface is fired any time the <i>ServiceWorkerRegistration.installing</i> property acquires a new service worker.
    /// </summary>
    public event Action OnUpdateFound {
        add {
            if (_onUpdateFound == null)
                _ = ServiceWorkerRegistrationJS.InvokeVoidTrySync("activateOnupdatefound", default, DotNetObjectReference.Create(new UpdateFoundTrigger(this))).Preserve();

            _onUpdateFound += value;
        }
        remove {
            _onUpdateFound -= value;

            if (_onUpdateFound == null)
                _ = ServiceWorkerRegistrationJS.InvokeVoidTrySync("deactivateOnupdatefound", default).Preserve();
        }
    }

    private sealed class UpdateFoundTrigger {
        private readonly ServiceWorkerRegistrationBase _serviceWorkerRegistration;

        [DynamicDependency(nameof(Trigger))]
        public UpdateFoundTrigger(ServiceWorkerRegistrationBase serviceWorkerRegistration) {
            _serviceWorkerRegistration = serviceWorkerRegistration;
        }

        [JSInvokable]
        public void Trigger() => _serviceWorkerRegistration._onUpdateFound?.Invoke();
    }

    #endregion
}

using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

/// <summary>
/// The <i>ServiceWorkerRegistration</i> interface of the Service Worker API represents the service worker registration.
/// You register a service worker to control one or more pages that share the same origin.
/// </summary>
[AutoInterface(Name = "IServiceWorkerRegistration", Modifier = "public partial")]
[AutoInterface(Name = "IServiceWorkerRegistrationInProcess", Modifier = "public partial")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
internal abstract class ServiceWorkerRegistrationBase {
    protected abstract IJSObjectReference ServiceWorkerRegistrationJS { get; }


    /// <summary>
    /// The <i>unregister()</i> method of the ServiceWorkerRegistration interface unregisters the service worker registration and returns a Promise.
    /// The promise will resolve to false if no registration was found, otherwise it resolves to true irrespective of whether unregistration happened or not (it may not unregister if someone else just called ServiceWorkerContainer.register() with the same scope.)
    /// The service worker will finish any ongoing operations before it is unregistered.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>false if no registration was found, otherwise true (irrespective of whether unregistration happened or not)</returns>
    public ValueTask<bool> Unregister(CancellationToken cancellationToken = default) => ServiceWorkerRegistrationJS.InvokeAsync<bool>("unregister", cancellationToken);

    protected ValueTask<IJSObjectReference> UpdateBase(CancellationToken cancellationToken = default) => ServiceWorkerRegistrationJS.InvokeAsync<IJSObjectReference>("update", cancellationToken);


    #region UpdateFound event

    private DotNetObjectReference<UpdateFoundTrigger>? objectReferenceUpdateFoundTrigger;

    private Action? _onUpdateFound;
    /// <summary>
    /// The <i>updatefound</i> event of the ServiceWorkerRegistration interface is fired any time the <i>ServiceWorkerRegistration.installing</i> property acquires a new service worker.
    /// </summary>
    public event Action OnUpdateFound {
        add {
            if (objectReferenceUpdateFoundTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceUpdateFoundTrigger = DotNetObjectReference.Create(new UpdateFoundTrigger(this));
                    await ServiceWorkerRegistrationJS.InvokeVoidTrySync("activateOnupdatefound", default, [objectReferenceUpdateFoundTrigger]);
                });

            _onUpdateFound += value;
        }
        remove {
            _onUpdateFound -= value;

            if (_onUpdateFound == null && objectReferenceUpdateFoundTrigger != null)
                Task.Factory.StartNew(async () => {
                    await ServiceWorkerRegistrationJS.InvokeVoidTrySync("deactivateOnupdatefound", default);
                    objectReferenceUpdateFoundTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class UpdateFoundTrigger(ServiceWorkerRegistrationBase serviceWorkerRegistration) {
        [JSInvokable]
        public void Trigger() => serviceWorkerRegistration._onUpdateFound?.Invoke();
    }

    #endregion
}

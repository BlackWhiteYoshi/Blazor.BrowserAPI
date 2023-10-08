using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

internal abstract class ServiceWorkerRegistrationBase {
    protected readonly IModuleManager _moduleManager;
    protected readonly IJSObjectReference _serviceWorkerRegistration;

    public ServiceWorkerRegistrationBase(IModuleManager moduleManager, IJSObjectReference serviceWorkerRegistration) {
        _moduleManager = moduleManager;
        _serviceWorkerRegistration = serviceWorkerRegistration;
    }


    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> Unregister(CancellationToken cancellationToken = default) => _moduleManager.InvokeAsync<bool>("serviceWorkerRegistrationUnregister", cancellationToken, _serviceWorkerRegistration);

    /// <summary>
    /// The <i>update()</i> method of the ServiceWorkerRegistration interface attempts to update the service worker. It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker. The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago. 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected ValueTask<IJSObjectReference> UpdateBase(CancellationToken cancellationToken = default) => _moduleManager.InvokeAsync<IJSObjectReference>("serviceWorkerRegistrationUpdate", cancellationToken, _serviceWorkerRegistration);


    #region UpdateFound

    private event Action? _updateFound;
    /// <summary>
    /// The <i>updatefound</i> event of the ServiceWorkerRegistration interface is fired any time the <i>ServiceWorkerRegistration.installing</i> property acquires a new service worker. 
    /// </summary>
    public event Action UpdateFound {
        add {
            if (_updateFound == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerRegistrationActivateOnupdatefound", default, _serviceWorkerRegistration, DotNetObjectReference.Create(new UpdateFoundTrigger(this))).Preserve();

            _updateFound += value;
        }
        remove {
            _updateFound -= value;

            if (_updateFound == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerRegistrationDeactivateOnupdatefound", default, _serviceWorkerRegistration).Preserve();
        }
    }

    private sealed class UpdateFoundTrigger {
        private readonly ServiceWorkerRegistrationBase _serviceWorkerRegistration;

        [DynamicDependency(nameof(Trigger))]
        public UpdateFoundTrigger(ServiceWorkerRegistrationBase serviceWorkerRegistration) {
            _serviceWorkerRegistration = serviceWorkerRegistration;
        }

        [JSInvokable]
        public void Trigger() => _serviceWorkerRegistration._updateFound?.Invoke();
    }

    #endregion
}

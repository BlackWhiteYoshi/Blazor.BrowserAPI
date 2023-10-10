using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

/// <summary>
/// The <i>ServiceWorker</i> interface of the Service Worker API provides a reference to a service worker. Multiple browsing contexts (e.g. pages, workers, etc.) can be associated with the same service worker, each through a unique ServiceWorker object.
/// </summary>
[AutoInterface(Name = "IServiceWorker", Modifier = "public partial")]
[AutoInterface(Name = "IServiceWorkerInProcess", Modifier = "public partial")]
internal abstract class ServiceWorkerBase {
    protected abstract IJSObjectReference ServiceWorkerJS { get; }

    protected readonly IModuleManager _moduleManager;

    public ServiceWorkerBase(IModuleManager moduleManager) {
        _moduleManager = moduleManager;
    }


    #region StateChange event

    private Action<string>? _onStateChange;
    /// <summary>
    /// The <i>statechange</i> event fires anytime the ServiceWorker.state changes.
    /// </summary>
    public event Action<string>? OnStateChange {
        add {
            if (_onStateChange == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerActivateOnstatechange", default, ServiceWorkerJS, DotNetObjectReference.Create(new StateChangeTrigger(this))).Preserve();

            _onStateChange += value;
        }
        remove {
            _onStateChange -= value;

            if (_onStateChange == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerDeactivateOnstatechange", default, ServiceWorkerJS).Preserve();
        }
    }

    private sealed class StateChangeTrigger {
        private readonly ServiceWorkerBase _serviceWorker;

        [DynamicDependency(nameof(Trigger))]
        public StateChangeTrigger(ServiceWorkerBase serviceWorker) {
            _serviceWorker = serviceWorker;
        }

        [JSInvokable]
        public void Trigger(string state) => _serviceWorker._onStateChange?.Invoke(state);
    }

    #endregion


    #region Error event

    private Action<string>? _onError;
    /// <summary>
    /// The <i>error</i> event fires whenever an error occurs in the service worker.
    /// </summary>
    public event Action<string> OnError {
        add {
            if (_onError == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerActivateOnerror", default, ServiceWorkerJS, DotNetObjectReference.Create(new ErrorTrigger(this))).Preserve();

            _onError += value;
        }
        remove {
            _onError -= value;

            if (_onError == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerDeactivateOnerror", default, ServiceWorkerJS).Preserve();
        }
    }

    private sealed class ErrorTrigger {
        private readonly ServiceWorkerBase _serviceWorker;

        [DynamicDependency(nameof(Trigger))]
        public ErrorTrigger(ServiceWorkerBase serviceWorker) {
            _serviceWorker = serviceWorker;
        }

        [JSInvokable]
        public void Trigger(object message) => _serviceWorker._onError?.Invoke(message.ToString()!);
    }

    #endregion
}

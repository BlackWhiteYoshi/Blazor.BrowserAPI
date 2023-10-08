using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

internal abstract class ServiceWorkerInstanceBase {
    protected readonly IModuleManager _moduleManager;
    protected readonly IJSObjectReference _serviceWorker;

    public ServiceWorkerInstanceBase(IModuleManager moduleManager, IJSObjectReference serviceWorker) {
        _moduleManager = moduleManager;
        _serviceWorker = serviceWorker;
    }


    #region StateChange

    private event Action<string>? _stateChange;
    /// <summary>
    /// The <i>statechange</i> event fires anytime the ServiceWorker.state changes.
    /// </summary>
    public event Action<string>? StateChange {
        add {
            if (_stateChange == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerInstanceActivateOnstatechange", default, _serviceWorker, DotNetObjectReference.Create(new StateChangeTrigger(this))).Preserve();

            _stateChange += value;
        }
        remove {
            _stateChange -= value;

            if (_stateChange == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerInstanceDeactivateOnstatechange", default, _serviceWorker).Preserve();
        }
    }

    private sealed class StateChangeTrigger {
        private readonly ServiceWorkerInstanceBase _serviceWorkerInstance;

        [DynamicDependency(nameof(Trigger))]
        public StateChangeTrigger(ServiceWorkerInstanceBase serviceWorkerInstance) {
            _serviceWorkerInstance = serviceWorkerInstance;
        }

        [JSInvokable]
        public void Trigger(string state) => _serviceWorkerInstance._stateChange?.Invoke(state);
    }

    #endregion


    #region Error

    private event Action<string>? _error;
    /// <summary>
    /// The <i>error</i> event fires whenever an error occurs in the service worker.
    /// </summary>
    public event Action<string> Error {
        add {
            if (_error == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerInstanceActivateOnerror", default, _serviceWorker, DotNetObjectReference.Create(new ErrorTrigger(this))).Preserve();

            _error += value;
        }
        remove {
            _error -= value;

            if (_error == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerInstanceDeactivateOnerror", default, _serviceWorker).Preserve();
        }
    }

    private sealed class ErrorTrigger {
        private readonly ServiceWorkerInstanceBase _serviceWorkerInstance;

        [DynamicDependency(nameof(Trigger))]
        public ErrorTrigger(ServiceWorkerInstanceBase serviceWorkerInstance) {
            _serviceWorkerInstance = serviceWorkerInstance;
        }

        [JSInvokable]
        public void Trigger(object message) => _serviceWorkerInstance._error?.Invoke(message.ToString()!);
    }

    #endregion
}

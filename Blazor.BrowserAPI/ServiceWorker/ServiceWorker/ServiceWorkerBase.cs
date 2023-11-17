using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

/// <summary>
/// The <i>ServiceWorker</i> interface of the Service Worker API provides a reference to a service worker.
/// Multiple browsing contexts (e.g. pages, workers, etc.) can be associated with the same service worker, each through a unique ServiceWorker object.
/// </summary>
[AutoInterface(Name = "IServiceWorker", Modifier = "public partial")]
[AutoInterface(Name = "IServiceWorkerInProcess", Modifier = "public partial")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
internal abstract class ServiceWorkerBase {
    protected abstract IJSObjectReference ServiceWorkerJS { get; }


    #region StateChange event

    private Action<string>? _onStateChange;
    /// <summary>
    /// <para>The <i>statechange</i> event fires anytime the ServiceWorker.state changes.</para>
    /// <para>Parameter is the new state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant.</para>
    /// </summary>
    public event Action<string> OnStateChange {
        add {
            if (_onStateChange == null)
                _ = ServiceWorkerJS.InvokeVoidTrySync("activateOnstatechange", default, [DotNetObjectReference.Create(new StateChangeTrigger(this))]).Preserve();

            _onStateChange += value;
        }
        remove {
            _onStateChange -= value;

            if (_onStateChange == null)
                _ = ServiceWorkerJS.InvokeVoidTrySync("deactivateOnstatechange", default).Preserve();
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class StateChangeTrigger(ServiceWorkerBase serviceWorker) {
        [JSInvokable]
        public void Trigger(string state) => serviceWorker._onStateChange?.Invoke(state);
    }

    #endregion


    #region Error event

    private Action<string>? _onError;
    /// <summary>
    /// <para>The <i>error</i> event fires whenever an error occurs in the service worker.</para>
    /// <para>Parameter is of type <see href="https://developer.mozilla.org/en-US/docs/Web/API/Event">Event</see> as JSON.</para>
    /// </summary>
    public event Action<string> OnError {
        add {
            if (_onError == null)
                _ = ServiceWorkerJS.InvokeVoidTrySync("activateOnerror", default, [DotNetObjectReference.Create(new ErrorTrigger(this))]).Preserve();

            _onError += value;
        }
        remove {
            _onError -= value;

            if (_onError == null)
                _ = ServiceWorkerJS.InvokeVoidTrySync("deactivateOnerror", default).Preserve();
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class ErrorTrigger(ServiceWorkerBase serviceWorker) {
        [JSInvokable]
        public void Trigger(object message) => serviceWorker._onError?.Invoke(message.ToString()!);
    }

    #endregion
}

using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

[AutoInterface(Name = "IServiceWorker", Modifier = "public partial")]
[AutoInterface(Name = "IServiceWorkerInProcess", Modifier = "public partial")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
internal abstract class ServiceWorkerBase {
    protected abstract IJSObjectReference ServiceWorkerJS { get; }


    #region StateChange event

    private DotNetObjectReference<StateChangeTrigger>? objectReferenceStateChangeTrigger;

    private Action<string>? _onStateChange;
    /// <summary>
    /// <para>The <i>statechange</i> event fires anytime the ServiceWorker.state changes.</para>
    /// <para>Parameter is the new state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant.</para>
    /// </summary>
    public event Action<string> OnStateChange {
        add {
            if (objectReferenceStateChangeTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceStateChangeTrigger = DotNetObjectReference.Create(new StateChangeTrigger(this));
                    await ServiceWorkerJS.InvokeVoidTrySync("activateOnstatechange", default, [objectReferenceStateChangeTrigger]);
                });

            _onStateChange += value;
        }
        remove {
            _onStateChange -= value;

            if (_onStateChange == null && objectReferenceStateChangeTrigger != null)
                Task.Factory.StartNew(async () => {
                    await ServiceWorkerJS.InvokeVoidTrySync("deactivateOnstatechange", default);
                    objectReferenceStateChangeTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class StateChangeTrigger(ServiceWorkerBase serviceWorker) {
        [JSInvokable]
        public void Trigger(string state) => serviceWorker._onStateChange?.Invoke(state);
    }

    #endregion


    #region Error event

    private DotNetObjectReference<ErrorTrigger>? objectReferenceErrorTrigger;

    private Action<string>? _onError;
    /// <summary>
    /// <para>The <i>error</i> event fires whenever an error occurs in the service worker.</para>
    /// <para>Parameter is of type <see href="https://developer.mozilla.org/en-US/docs/Web/API/Event">Event</see> as JSON.</para>
    /// </summary>
    public event Action<string> OnError {
        add {
            if (objectReferenceErrorTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceErrorTrigger = DotNetObjectReference.Create(new ErrorTrigger(this));
                    await ServiceWorkerJS.InvokeVoidTrySync("activateOnerror", default, [objectReferenceErrorTrigger]);
                });

            _onError += value;
        }
        remove {
            _onError -= value;

            if (_onError == null && objectReferenceErrorTrigger != null)
                Task.Factory.StartNew(async () => {
                    await ServiceWorkerJS.InvokeVoidTrySync("deactivateOnerror", default);
                    objectReferenceErrorTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class ErrorTrigger(ServiceWorkerBase serviceWorker) {
        [JSInvokable]
        public void Trigger(object message) => serviceWorker._onError?.Invoke(message.ToString()!);
    }

    #endregion
}

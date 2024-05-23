﻿using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>Base class for <see cref="ServiceWorker"/> and <see cref="ServiceWorkerInProcess"/>.</para>
/// <para>Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call <see cref="DisposeEventTrigger"/> there.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorker")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class ServiceWorkerBase {
    private protected abstract IJSObjectReference ServiceWorkerJS { get; }


    #region Events

    [method: DynamicDependency(nameof(InvokeStateChange))]
    [method: DynamicDependency(nameof(InvokeError))]
    private sealed class EventTrigger(ServiceWorkerBase serviceWorker) {
        [JSInvokable] public void InvokeStateChange(string state) => serviceWorker._onStateChange?.Invoke(state);
        [JSInvokable] public void InvokeError(object message) => serviceWorker._onError?.Invoke(message.ToString()!);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;
    private DotNetObjectReference<EventTrigger> ObjectReferenceEventTrigger => _objectReferenceEventTrigger ??= DotNetObjectReference.Create(new EventTrigger(this));

    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private Action<string>? _onStateChange;
    /// <summary>
    /// <para>The <i>statechange</i> event fires anytime the ServiceWorker.state changes.</para>
    /// <para>Parameter is the new state of the service worker. It can be one of the following values: parsed, installing, installed, activating, activated, or redundant.</para>
    /// </summary>
    public event Action<string> OnStateChange {
        add {
            if (_onStateChange == null)
                Task.Factory.StartNew(async () => await ServiceWorkerJS.InvokeVoidTrySync("activateOnstatechange", default, [ObjectReferenceEventTrigger]));
            _onStateChange += value;
        }
        remove {
            _onStateChange -= value;
            if (_onStateChange == null)
                Task.Factory.StartNew(async () => await ServiceWorkerJS.InvokeVoidTrySync("deactivateOnstatechange", default));
        }
    }

    private Action<string>? _onError;
    /// <summary>
    /// <para>The <i>error</i> event fires whenever an error occurs in the service worker.</para>
    /// <para>Parameter is of type <see href="https://developer.mozilla.org/en-US/docs/Web/API/Event">Event</see> as JSON.</para>
    /// </summary>
    public event Action<string> OnError {
        add {
            if (_onError == null)
                Task.Factory.StartNew(async () => await ServiceWorkerJS.InvokeVoidTrySync("activateOnerror", default, [ObjectReferenceEventTrigger]));
            _onError += value;
        }
        remove {
            _onError -= value;
            if (_onError == null)
                Task.Factory.StartNew(async () => await ServiceWorkerJS.InvokeVoidTrySync("deactivateOnerror", default));
        }
    }

    #endregion
}

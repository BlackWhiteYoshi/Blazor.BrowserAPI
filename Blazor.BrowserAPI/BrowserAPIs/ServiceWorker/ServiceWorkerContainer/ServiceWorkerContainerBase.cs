﻿using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerContainer")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerContainerInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class ServiceWorkerContainerBase : IDisposable {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected abstract IModuleManager ModuleManager { get; }

    /// <summary>
    /// Releases the <see cref="EventTrigger"/> object used to trigger the events.
    /// </summary>
    public void Dispose() => DisposeEventTrigger();


    /// <summary>
    /// Registers a service worker.
    /// </summary>
    /// <param name="scriptURL">relative file path to the service worker script (e.g. "/sw.js")</param>
    /// <param name="cancellationToken"></param>
    /// <returns>true, if service worker is supported, otherwise false</returns>
    public ValueTask<bool> Register(string scriptURL, CancellationToken cancellationToken = default) => ModuleManager.InvokeAsync<bool>("ServiceWorkerContainerAPI.register", cancellationToken, [scriptURL]);

    private protected async ValueTask<IJSObjectReference?> RegisterWithWorkerRegistrationBase(string scriptURL, CancellationToken cancellationToken) {
        try {
            return await ModuleManager.InvokeAsync<IJSObjectReference>("ServiceWorkerContainerAPI.registerWithWorkerRegistration", cancellationToken, [scriptURL]);
        }
        catch (JSException) {
            return null;
        }
    }


    private protected ValueTask<IJSObjectReference> DelayUntilReadyBase(CancellationToken cancellationToken) => ModuleManager.InvokeAsync<IJSObjectReference>("ServiceWorkerContainerAPI.ready", cancellationToken);


    private protected async ValueTask<IJSObjectReference?> GetRegistrationBase(string clientUrl, CancellationToken cancellationToken) {
        try {
            return await ModuleManager.InvokeAsync<IJSObjectReference>("ServiceWorkerContainerAPI.getRegistration", cancellationToken, [clientUrl]);
        }
        catch (JSException) {
            return null;
        }
    }

    private protected ValueTask<IJSObjectReference[]> GetRegistrationsBase(CancellationToken cancellationToken) => ModuleManager.InvokeAsync<IJSObjectReference[]>("ServiceWorkerContainerAPI.getRegistrations", cancellationToken);


    #region Events

    [method: DynamicDependency(nameof(InvokeControllerChange))]
    [method: DynamicDependency(nameof(InvokeMessage))]
    private sealed class EventTrigger(ServiceWorkerContainerBase serviceWorkerContainer) {
        [JSInvokable] public void InvokeControllerChange() => serviceWorkerContainer._onControllerChange?.Invoke();
        [JSInvokable] public void InvokeMessage(object message) => serviceWorkerContainer._onMessage?.Invoke(message.ToString()!);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return ModuleManager.InvokeTrySync("ServiceWorkerContainerAPI.initEvents", default, [_objectReferenceEventTrigger, ModuleManager.IsInProcess]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await ModuleManager.InvokeTrySync(jsMethodName, default);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => ModuleManager.InvokeTrySync(jsMethodName, default);


    private Action? _onControllerChange;
    /// <summary>
    /// Occurs when the document's associated <i>ServiceWorkerRegistration</i> acquires a new active worker.
    /// </summary>
    public event Action OnControllerChange {
        add {
            if (_onControllerChange == null)
                _ = ActivateJSEvent("ServiceWorkerContainerAPI.activateOncontrollerchange").Preserve();
            _onControllerChange += value;
        }
        remove {
            _onControllerChange -= value;
            if (_onControllerChange == null)
                _ = DeactivateJSEvent("ServiceWorkerContainerAPI.deactivateOncontrollerchange").Preserve();
        }
    }

    private Action<string>? _onMessage;
    /// <summary>
    /// <para>The message event is used in a page controlled by a service worker to receive messages from the service worker.</para>
    /// <para>Parameter is of type <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer/message_event">MessageEvent</see> as json.</para>
    /// </summary>
    public event Action<string> OnMessage {
        add {
            if (_onMessage == null)
                _ = ActivateJSEvent("ServiceWorkerContainerAPI.activateOnMessage").Preserve();
            _onMessage += value;
        }
        remove {
            _onMessage -= value;
            if (_onMessage == null)
                _ = DeactivateJSEvent("ServiceWorkerContainerAPI.deactivateOnMessage").Preserve();
        }
    }

    #endregion
}

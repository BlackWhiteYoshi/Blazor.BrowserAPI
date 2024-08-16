using AutoInterfaceAttributes;
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
    public ValueTask<bool> Register(string scriptURL, CancellationToken cancellationToken = default) => ModuleManager.InvokeAsync<bool>("serviceWorkerContainerRegister", cancellationToken, [scriptURL]);

    private protected async ValueTask<IJSObjectReference?> RegisterWithWorkerRegistrationBase(string scriptURL, CancellationToken cancellationToken) {
        try {
            return await ModuleManager.InvokeAsync<IJSObjectReference>("serviceWorkerContainerRegisterWithWorkerRegistration", cancellationToken, [scriptURL]);
        }
        catch (JSException) {
            return null;
        }
    }


    private protected ValueTask<IJSObjectReference> DelayUntilReadyBase(CancellationToken cancellationToken) => ModuleManager.InvokeAsync<IJSObjectReference>("serviceWorkerContainerReady", cancellationToken);


    private protected async ValueTask<IJSObjectReference?> GetRegistrationBase(string clientUrl, CancellationToken cancellationToken) {
        try {
            return await ModuleManager.InvokeAsync<IJSObjectReference>("serviceWorkerContainerGetRegistration", cancellationToken, [clientUrl]);
        }
        catch (JSException) {
            return null;
        }
    }

    private protected ValueTask<IJSObjectReference[]> GetRegistrationsBase(CancellationToken cancellationToken) => ModuleManager.InvokeAsync<IJSObjectReference[]>("serviceWorkerContainerGetRegistrations", cancellationToken);


    #region Events

    [method: DynamicDependency(nameof(InvokeControllerChange))]
    [method: DynamicDependency(nameof(InvokeMessage))]
    private sealed class EventTrigger(ServiceWorkerContainerBase serviceWorkerContainer) {
        [JSInvokable] public void InvokeControllerChange() => serviceWorkerContainer._onControllerChange?.Invoke();
        [JSInvokable] public void InvokeMessage(object message) => serviceWorkerContainer._onMessage?.Invoke(message.ToString()!);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;
    private DotNetObjectReference<EventTrigger> ObjectReferenceEventTrigger => _objectReferenceEventTrigger ??= DotNetObjectReference.Create(new EventTrigger(this));

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private Action? _onControllerChange;
    /// <summary>
    /// Occurs when the document's associated <i>ServiceWorkerRegistration</i> acquires a new active worker.
    /// </summary>
    public event Action OnControllerChange {
        add {
            if (_onControllerChange == null)
                Task.Factory.StartNew(async () => await ModuleManager.InvokeTrySync("serviceWorkerContainerActivateOncontrollerchange", default, [ObjectReferenceEventTrigger]));
            _onControllerChange += value;
        }
        remove {
            _onControllerChange -= value;
            if (_onControllerChange == null)
                Task.Factory.StartNew(async () => await ModuleManager.InvokeTrySync("serviceWorkerContainerDeactivateOncontrollerchange", default));
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
                Task.Factory.StartNew(async () => await ModuleManager.InvokeTrySync("serviceWorkerContainerActivateOnMessage", default, [ObjectReferenceEventTrigger]));
            _onMessage += value;
        }
        remove {
            _onMessage -= value;
            if (_onMessage == null)
                Task.Factory.StartNew(async () => await ModuleManager.InvokeTrySync("serviceWorkerContainerDeactivateOnMessage", default));
        }
    }

    #endregion
}

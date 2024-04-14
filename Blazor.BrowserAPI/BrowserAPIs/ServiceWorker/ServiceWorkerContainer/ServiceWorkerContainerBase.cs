using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base class for <see cref="ServiceWorkerContainer"/> and <see cref="ServiceWorkerContainerInProcess"/>.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerContainer")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IServiceWorkerContainerInProcess")]
public abstract class ServiceWorkerContainerBase {
    private protected abstract IModuleManager ModuleManager { get; }


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


    #region ControllerChange event

    private DotNetObjectReference<ControllerChangeTrigger>? objectReferenceControllerChangeTrigger;

    private Action? _onControllerChange;
    /// <summary>
    /// Occurs when the document's associated <i>ServiceWorkerRegistration</i> acquires a new active worker.
    /// </summary>
    public event Action OnControllerChange {
        add {
            if (objectReferenceControllerChangeTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceControllerChangeTrigger = DotNetObjectReference.Create(new ControllerChangeTrigger(this));
                    await ModuleManager.InvokeTrySync("serviceWorkerContainerActivateOncontrollerchange", default, [objectReferenceControllerChangeTrigger]);
                });

            _onControllerChange += value;
        }
        remove {
            _onControllerChange -= value;

            if (_onControllerChange == null && objectReferenceControllerChangeTrigger != null)
                Task.Factory.StartNew(async () => {
                    await ModuleManager.InvokeTrySync("serviceWorkerContainerDeactivateOncontrollerchange", default);
                    objectReferenceControllerChangeTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class ControllerChangeTrigger(ServiceWorkerContainerBase serviceWorkerContainer) {
        [JSInvokable]
        public void Trigger() => serviceWorkerContainer._onControllerChange?.Invoke();
    }

    #endregion


    #region Message event

    private DotNetObjectReference<MessageTrigger>? objectReferenceMessageTrigger;

    private Action<string>? _onMessage;
    /// <summary>
    /// <para>The message event is used in a page controlled by a service worker to receive messages from the service worker.</para>
    /// <para>Parameter is of type <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer/message_event">MessageEvent</see> as json.</para>
    /// </summary>
    public event Action<string> OnMessage {
        add {
            if (objectReferenceMessageTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceMessageTrigger = DotNetObjectReference.Create(new MessageTrigger(this));
                    await ModuleManager.InvokeTrySync("serviceWorkerContainerActivateOnMessage", default, [objectReferenceMessageTrigger]);
                });

            _onMessage += value;
        }
        remove {
            _onMessage -= value;

            if (_onMessage == null && objectReferenceMessageTrigger != null)
                Task.Factory.StartNew(async () => {
                    await ModuleManager.InvokeTrySync("serviceWorkerContainerDeactivateOnMessage", default);
                    objectReferenceMessageTrigger.Dispose();
                });

        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class MessageTrigger(ServiceWorkerContainerBase serviceWorkerContainer) {
        [JSInvokable]
        public void Trigger(object message) => serviceWorkerContainer._onMessage?.Invoke(message.ToString()!);
    }

    #endregion
}

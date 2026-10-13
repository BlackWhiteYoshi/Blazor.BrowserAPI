using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace BrowserAPI.Implementation;

/// Base interface of <see cref="IServiceWorkerContainer"/> and <see cref="IServiceWorkerContainerInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class ServiceWorkerContainerBase<TJSObjectReference, TServiceWorkerRegistration, TServiceWorker>(IModuleManager moduleManager) : IDisposable
    where TJSObjectReference : IJSObjectReference
    where TServiceWorkerRegistration : class, IServiceWorkerRegistrationBase<TJSObjectReference, TServiceWorkerRegistration>
    where TServiceWorker : IServiceWorkerBase<TJSObjectReference> {
    private protected IModuleManager moduleManager = moduleManager;

    /// <summary>
    /// Releases the EventTrigger object used to trigger the events.
    /// </summary>
    public void Dispose() => _objectReferenceEventTrigger?.Dispose();


    /// <summary>
    /// Registers a service worker.
    /// </summary>
    /// <param name="scriptURL">relative file path to the service worker script (e.g. "/sw.js")</param>
    /// <param name="cancellationToken"></param>
    /// <returns>true, if service worker is supported, otherwise false</returns>
    public ValueTask Register(string scriptURL, CancellationToken cancellationToken = default) => moduleManager.InvokeAsync("ServiceWorkerContainerAPI.register", cancellationToken, [scriptURL]);

    /// <summary>
    /// Registers a service worker and returns a <i>ServiceWorkerRegistration</i> object, which can be used to track the registration.
    /// </summary>
    /// <param name="scriptURL">relative file path to the service worker script (e.g. "/sw.js")</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TServiceWorkerRegistration> RegisterWithWorkerRegistration(string scriptURL, CancellationToken cancellationToken = default) {
        TJSObjectReference serviceWorkerRegistration = await moduleManager.InvokeAsync<TJSObjectReference>("ServiceWorkerContainerAPI.registerWithWorkerRegistration", cancellationToken, [scriptURL]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TServiceWorkerRegistration)(IServiceWorkerRegistration)new ServiceWorkerRegistration(serviceWorkerRegistration);
        else
            return (TServiceWorkerRegistration)(IServiceWorkerRegistrationInProcess)new ServiceWorkerRegistrationInProcess((IJSInProcessObjectReference)serviceWorkerRegistration);
    }


    /// <summary>
    /// Provides a way of delaying code execution until a service worker is active.
    /// It returns a Promise that will never reject, and which waits indefinitely until the ServiceWorkerRegistration associated with the current page has an ServiceWorkerRegistration.active worker.
    /// Once that condition is met, it resolves with the ServiceWorkerRegistration.
    /// </summary>
    public ValueTask<TServiceWorkerRegistration> Ready => GetReady(CancellationToken.None);

    /// <inheritdoc cref="Ready" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TServiceWorkerRegistration> GetReady(CancellationToken cancellationToken) {
        TJSObjectReference serviceWorkerRegistration = await moduleManager.InvokeAsync<TJSObjectReference>("ServiceWorkerContainerAPI.getReady", cancellationToken);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TServiceWorkerRegistration)(IServiceWorkerRegistration)new ServiceWorkerRegistration(serviceWorkerRegistration);
        else
            return (TServiceWorkerRegistration)(IServiceWorkerRegistrationInProcess)new ServiceWorkerRegistrationInProcess((IJSInProcessObjectReference)serviceWorkerRegistration);
    }


    /// <summary>
    /// Gets a ServiceWorkerRegistration object whose scope URL matches the provided client URL.
    /// The method returns a Promise that resolves to a ServiceWorkerRegistration or undefined.
    /// </summary>
    /// <param name="clientUrl">The registration whose scope matches this URL will be returned. Relative URLs are resolved with the current client as the base.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TServiceWorkerRegistration?> GetRegistration(string clientUrl, CancellationToken cancellationToken = default) {
        TJSObjectReference?[] singleReference = await moduleManager.InvokeAsync<TJSObjectReference?[]>("ServiceWorkerContainerAPI.getRegistration", cancellationToken, [clientUrl]);
        if (singleReference[0] is TJSObjectReference serviceWorkerRegistration)
            if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
                return (TServiceWorkerRegistration)(IServiceWorkerRegistration)new ServiceWorkerRegistration(serviceWorkerRegistration);
            else
                return (TServiceWorkerRegistration)(IServiceWorkerRegistrationInProcess)new ServiceWorkerRegistrationInProcess((IJSInProcessObjectReference)serviceWorkerRegistration);
        else
            return null;
    }

    /// <summary>
    /// Gets all ServiceWorkerRegistrations associated with a ServiceWorkerContainer, in an array.
    /// The method returns a Promise that resolves to an array of ServiceWorkerRegistration.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TServiceWorkerRegistration[]> GetRegistrations(CancellationToken cancellationToken = default) {
        TJSObjectReference[] serviceWorkerRegistrations = await moduleManager.InvokeAsync<TJSObjectReference[]>("ServiceWorkerContainerAPI.getRegistrations", cancellationToken);

        TServiceWorkerRegistration[] result = new TServiceWorkerRegistration[serviceWorkerRegistrations.Length];
        for (int i = 0; i < serviceWorkerRegistrations.Length; i++)
            result[i] = typeof(TJSObjectReference) == typeof(IJSObjectReference)
                ? (TServiceWorkerRegistration)(IServiceWorkerRegistration)new ServiceWorkerRegistration(serviceWorkerRegistrations[i])
                : (TServiceWorkerRegistration)(IServiceWorkerRegistrationInProcess)new ServiceWorkerRegistrationInProcess((IJSInProcessObjectReference)serviceWorkerRegistrations[i]);
        return result;
    }


    #region Events

    [method: DynamicDependency(nameof(InvokeControllerChange))]
    [method: DynamicDependency(nameof(InvokeMessage))]
    private sealed class EventTrigger(ServiceWorkerContainerBase<TJSObjectReference, TServiceWorkerRegistration, TServiceWorker> serviceWorkerContainer) {
        [JSInvokable] public void InvokeControllerChange() => serviceWorkerContainer._onControllerChange?.Invoke();
        [JSInvokable] public void InvokeMessage(JsonElement message) => serviceWorkerContainer._onMessage?.Invoke(message);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return moduleManager.InvokeTrySync("ServiceWorkerContainerAPI.initEvents", CancellationToken.None, [_objectReferenceEventTrigger]);
    }


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await moduleManager.InvokeTrySync(jsMethodName, CancellationToken.None);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => moduleManager.InvokeTrySync(jsMethodName, CancellationToken.None);


    // Events

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

    private Action<JsonElement>? _onMessage;
    /// <summary>
    /// <para>Is used in a page controlled by a service worker to receive messages from the service worker.</para>
    /// <para>Parameter is <see href="https://developer.mozilla.org/en-US/docs/Web/API/MessageEvent/data">MessageEvent.data</see> as json.</para>
    /// </summary>
    public event Action<JsonElement> OnMessage {
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

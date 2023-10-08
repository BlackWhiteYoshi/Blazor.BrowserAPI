using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

internal abstract class ServiceWorkerBase {
    protected readonly IModuleManager _moduleManager;

    public ServiceWorkerBase(IModuleManager moduleManager) {
        _moduleManager = moduleManager;
    }


    /// <summary>
    /// Registers a service worker.
    /// </summary>
    /// <param name="scriptURL">relative file path to the service worker script (e.g. "/sw.js")</param>
    /// <param name="cancellationToken"></param>
    /// <returns>true, if service worker is supported, otherwise false</returns>
    public ValueTask<bool> Register(string scriptURL, CancellationToken cancellationToken = default)
        => _moduleManager.InvokeAsync<bool>("serviceWorkerRegister", cancellationToken, scriptURL);

    protected async ValueTask<IJSObjectReference?> RegisterWithWorkerRegistrationBase(string scriptURL, CancellationToken cancellationToken) {
        try {
            return await _moduleManager.InvokeAsync<IJSObjectReference>("serviceWorkerRegisterWithWorkerRegistration", cancellationToken, scriptURL);
        }
        catch (JSException) {
            return null;
        }
    }


    protected ValueTask<IJSObjectReference> DelayUntilReadyBase(CancellationToken cancellationToken)
        => _moduleManager.InvokeAsync<IJSObjectReference>("serviceWorkerReady", cancellationToken);


    protected async ValueTask<IJSObjectReference?> GetRegistrationBase(string clientUrl, CancellationToken cancellationToken) {
        try {
            return await _moduleManager.InvokeAsync<IJSObjectReference>("serviceWorkerGetRegistration", cancellationToken, clientUrl);
        }
        catch (JSException) {
            return null;
        }
    }

    protected ValueTask<IJSObjectReference[]> GetRegistrationsBase(CancellationToken cancellationToken)
        => _moduleManager.InvokeAsync<IJSObjectReference[]>("serviceWorkerGetRegistrations", cancellationToken);


    #region ControllerChange

    private event Action? _controllerChange;
    /// <summary>
    /// Occurs when the document's associated <i>ServiceWorkerRegistration</i> acquires a new active worker.
    /// </summary>
    public event Action ControllerChange {
        add {
            if (_controllerChange == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerActivateOncontrollerchange", default, DotNetObjectReference.Create(new ControllerChangeTrigger(this))).Preserve();

            _controllerChange += value;
        }
        remove {
            _controllerChange -= value;

            if (_controllerChange == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerDeactivateOncontrollerchange", default).Preserve();
        }
    }

    private sealed class ControllerChangeTrigger {
        private readonly ServiceWorkerBase _serviceWorker;

        [DynamicDependency(nameof(Trigger))]
        public ControllerChangeTrigger(ServiceWorkerBase serviceWorker) {
            _serviceWorker = serviceWorker;
        }

        [JSInvokable]
        public void Trigger() => _serviceWorker._controllerChange?.Invoke();
    }

    #endregion


    #region Message

    private event Action<string>? _message;
    /// <summary>
    /// <para>The message event is used in a page controlled by a service worker to receive messages from the service worker.</para>
    /// <para>Parameter is of type <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer/message_event">MessageEvent.</see> as json.</para>
    /// </summary>
    public event Action<string> Message {
        add {
            if (_message == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerActivateOnMessage", default, DotNetObjectReference.Create(new ControllerChangeTrigger(this))).Preserve();

            _message += value;
        }
        remove {
            _message -= value;

            if (_message == null)
                _ = _moduleManager.InvokeTrySync("serviceWorkerDeactivateOnMessage", default).Preserve();
        }
    }

    private sealed class MessageTrigger {
        private readonly ServiceWorkerBase _serviceWorker;

        [DynamicDependency(nameof(Trigger))]
        public MessageTrigger(ServiceWorkerBase serviceWorker) {
            _serviceWorker = serviceWorker;
        }

        [JSInvokable]
        public void Trigger(object message) => _serviceWorker._message?.Invoke(message.ToString()!);
    }

    #endregion
}

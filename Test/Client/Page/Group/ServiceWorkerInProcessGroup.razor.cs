using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class ServiceWorkerInProcessGroup : ComponentBase, IAsyncDisposable {
    public const string SERVICE_WORKER_URL = "service-worker.js";
    public const string TEST_EVENT_CONTROLLER_CHANGED = "service-worker-container-inprocess controller changed";
    public const string TEST_EVENT_UPDATE_FOUND = "service-worker-registration-inprocess update found";
    public const string TEST_POST_MESSAGE = "service-worker-inprocess post message";


    [Inject]
    public required IServiceWorkerContainerInProcess ServiceWorkerContainer { private get; init; }

    private Task<IServiceWorkerRegistrationInProcess>? _serviceWorkerRegistration;
    private Task<IServiceWorkerRegistrationInProcess> ServiceWorkerRegistration {
        get {
            return _serviceWorkerRegistration ??= DoAsync();
            async Task<IServiceWorkerRegistrationInProcess> DoAsync() => (await ServiceWorkerContainer.RegisterWithWorkerRegistration(SERVICE_WORKER_URL)) ?? throw new ArgumentNullException(null, "service worker could not be registered.");
        }
    }

    private Task<IServiceWorkerInProcess>? _serviceWorker;
    private Task<IServiceWorkerInProcess> ServiceWorker {
        get {
            return _serviceWorker ??= DoAsync();
            async Task<IServiceWorkerInProcess> DoAsync() {
                await ServiceWorkerContainer.Register(SERVICE_WORKER_URL);
                using IServiceWorkerRegistrationInProcess serviceWorkerRegistration = await ServiceWorkerContainer.DelayUntilReady();
                return serviceWorkerRegistration.Active ?? throw new ArgumentNullException(null, "service worker could not be retrieved.");
            }
        }
    }

    public async ValueTask DisposeAsync() {
        if (_serviceWorkerRegistration is not null)
            (await _serviceWorkerRegistration).Dispose();
        if (_serviceWorker is not null)
            (await _serviceWorker).Dispose();
    }


    public const string LABEL_OUTPUT = "service-worker-inprocess-output";
    private string labelOutput = string.Empty;


    // Service Worker Container

    public const string BUTTON_REGISTER = "service-worker-container-inprocess-register";
    private async Task Register() {
        bool result = await ServiceWorkerContainer.Register(SERVICE_WORKER_URL);
        labelOutput = result.ToString();
    }

    public const string BUTTON_REGISTER_WITH_WORKER_REGISTRATION = "service-worker-container-inprocess-register-with-worker-registration";
    private async Task RegisterWithWorkerRegistration() {
        using IServiceWorkerRegistrationInProcess? serviceWorkerRegistration = await ServiceWorkerContainer.RegisterWithWorkerRegistration(SERVICE_WORKER_URL);
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_DELAY_UNTIL_READY = "service-worker-container-inprocess-delay-until-ready";
    private async Task DelayUntilReady() {
        using IServiceWorkerRegistrationInProcess? serviceWorkerRegistration = await ServiceWorkerContainer.DelayUntilReady();
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_GET_REGISTRATION = "service-worker-container-inprocess-get-registration";
    private async Task GetRegistration() {
        using IServiceWorkerRegistrationInProcess? serviceWorkerRegistration = await ServiceWorkerContainer.GetRegistration(SERVICE_WORKER_URL);
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_GET_REGISTRATIONS = "service-worker-container-inprocess-get-registrations";
    private async Task GetRegistrations() {
        IServiceWorkerRegistrationInProcess[] serviceWorkerRegistrations = await ServiceWorkerContainer.GetRegistrations();
        labelOutput = serviceWorkerRegistrations.Length.ToString();

        foreach (IServiceWorkerRegistrationInProcess serviceWorkerRegistration in serviceWorkerRegistrations)
            serviceWorkerRegistration.Dispose();
    }

    public const string BUTTON_GET_CONTROLLER = "service-worker-container-inprocess-get-controller";
    private void GetController() {
        using IServiceWorkerInProcess? serviceWorker = ServiceWorkerContainer.Controller;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_START_MESSAGES = "service-worker-container-inprocess-start-messages";
    private void StartMessages() {
        ServiceWorkerContainer.StartMessages();
    }

    public const string BUTTON_REGISTER_ON_CONTROLLER_CHANGE = "service-worker-container-inprocess-event-controller-change";
    private void RegisterOnControllerChange() {
        ServiceWorkerContainer.OnControllerChange += () => {
            labelOutput = TEST_EVENT_CONTROLLER_CHANGED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MESSAGE = "service-worker-container-inprocess-event-message";
    private void RegisterOnMessage() {
        ServiceWorkerContainer.OnMessage += (string messageEvent) => {
            labelOutput = messageEvent;
            StateHasChanged();
        };
    }


    // Service Worker Registration

    public const string BUTTON_UNREGISTER = "service-worker-registration-inprocess-unregister";
    private async Task Unregister() {
        bool result = await (await ServiceWorkerRegistration).Unregister();
        labelOutput = result.ToString();
    }

    public const string BUTTON_ACTIVE = "service-worker-registration-inprocess-active";
    private async Task Active() {
        IServiceWorkerInProcess? serviceWorker = (await ServiceWorkerRegistration).Active;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_INSTALLING = "service-worker-registration-inprocess-installing";
    private async Task Installing() {
        IServiceWorkerInProcess? serviceWorker = (await ServiceWorkerRegistration).Installing;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_WAITING = "service-worker-registration-inprocess-waiting";
    private async Task Waiting() {
        IServiceWorkerInProcess? serviceWorker = (await ServiceWorkerRegistration).Waiting;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_SCOPE = "service-worker-registration-inprocess-scope";
    private async Task Scope() {
        string scope = (await ServiceWorkerRegistration).Scope;
        labelOutput = scope;
    }

    public const string BUTTON_UPDATE_VIA_CACHE = "service-worker-registration-inprocess-update-via-cache";
    private async Task UpdateViaCache() {
        string cacheMode = (await ServiceWorkerRegistration).UpdateViaCache;
        labelOutput = cacheMode;
    }

    public const string BUTTON_UPDATE = "service-worker-registration-inprocess-update";
    private async void Update() {
        IServiceWorkerRegistrationInProcess serviceWorkerRegistration = await (await ServiceWorkerRegistration).Update();
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_REGISTER_ON_UPDATE_FOUND = "service-worker-registration-inprocess-event-update-found";
    private async void RegisterOnUpdateFound() {
        (await ServiceWorkerRegistration).OnUpdateFound += () => {
            labelOutput = TEST_EVENT_UPDATE_FOUND;
            StateHasChanged();
        };
    }


    // Service Worker

    public const string BUTTON_SCRIPT_URL = "service-worker-inprocess-script-url";
    private async Task ScriptUrl() {
        string scriptUrl = (await ServiceWorker).ScriptUrl;
        labelOutput = scriptUrl;
    }

    public const string BUTTON_STATE = "service-worker-inprocess-state";
    private async Task State() {
        string state = (await ServiceWorker).State;
        labelOutput = state;
    }

    public const string BUTTON_POST_MESSAGE = "service-worker-inprocess-post-message";
    private async Task PostMessage() {
        (await ServiceWorker).PostMessage(TEST_POST_MESSAGE);
        labelOutput = TEST_POST_MESSAGE;
    }

    public const string BUTTON_REGISTER_ON_STATE_CHANGE = "service-worker-inprocess-event-state-change";
    private async void RegisterOnStateChange() {
        (await ServiceWorker).OnStateChange += (string state) => {
            labelOutput = state;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ERROR = "service-worker-inprocess-event-error";
    private async void RegisterOnError() {
        (await ServiceWorker).OnError += (string error) => {
            labelOutput = error;
            StateHasChanged();
        };
    }
}

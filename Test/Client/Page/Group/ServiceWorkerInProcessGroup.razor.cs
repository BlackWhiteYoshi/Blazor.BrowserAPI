using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class ServiceWorkerInProcessGroup : ComponentBase, IAsyncDisposable {
    public const string SERVICE_WORKER_URL = "service-worker.js";
    public const string TEST_REGISTER = "service worker registered";
    public const string TEST_START_MESSAGES = "started messages";
    public const string TEST_EVENT_CONTROLLER_CHANGED = "service-worker-container-inprocess controller changed";
    public const string TEST_EVENT_UPDATE_FOUND = "service-worker-registration-inprocess update found";
    public const string TEST_POST_MESSAGE = "service-worker-inprocess post message";


    [Inject]
    public required IServiceWorkerContainerInProcess ServiceWorkerContainer { private get; init; }

    private Task<IServiceWorkerRegistrationInProcess>? _serviceWorkerRegistration;
    private Task<IServiceWorkerRegistrationInProcess> ServiceWorkerRegistration => _serviceWorkerRegistration ??= ServiceWorkerContainer.RegisterWithWorkerRegistration(SERVICE_WORKER_URL).AsTask();

    private Task<IServiceWorkerInProcess>? _serviceWorker;
    private Task<IServiceWorkerInProcess> ServiceWorker {
        get {
            return _serviceWorker ??= DoAsync();
            async Task<IServiceWorkerInProcess> DoAsync() {
                await ServiceWorkerRegistration;
                using IServiceWorkerRegistrationInProcess serviceWorkerRegistration = await ServiceWorkerContainer.Ready;
                return serviceWorkerRegistration.Active ?? throw new UnreachableException("DelayUntilReady() ensures there is a active service worker.");
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
        await ServiceWorkerContainer.Register(SERVICE_WORKER_URL);
        labelOutput = TEST_REGISTER;
    }

    public const string BUTTON_REGISTER_WITH_WORKER_REGISTRATION = "service-worker-container-inprocess-register-with-worker-registration";
    private async Task RegisterWithWorkerRegistration() {
        using IServiceWorkerRegistrationInProcess? serviceWorkerRegistration = await ServiceWorkerContainer.RegisterWithWorkerRegistration(SERVICE_WORKER_URL);
        labelOutput = (serviceWorkerRegistration is not null).ToString();
    }


    public const string BUTTON_GET_CONTROLLER = "service-worker-container-inprocess-get-controller";
    private void GetController() {
        using IServiceWorkerInProcess? serviceWorker = ServiceWorkerContainer.Controller;
        labelOutput = (serviceWorker is not null).ToString();
    }

    public const string BUTTON_GET_READY_PROPERTY = "service-worker-container-inprocess-get-ready-property";
    private async Task GetReady_Property() {
        using IServiceWorkerRegistrationInProcess? serviceWorkerRegistration = await ServiceWorkerContainer.Ready;
        labelOutput = (serviceWorkerRegistration is not null).ToString();
    }

    public const string BUTTON_GET_READY_METHOD = "service-worker-container-inprocess-get-ready-method";
    private async Task GetReady_Method() {
        using IServiceWorkerRegistrationInProcess? serviceWorkerRegistration = await ServiceWorkerContainer.GetReady(default);
        labelOutput = (serviceWorkerRegistration is not null).ToString();
    }


    public const string BUTTON_GET_REGISTRATION = "service-worker-container-inprocess-get-registration";
    private async Task GetRegistration() {
        using IServiceWorkerRegistrationInProcess? serviceWorkerRegistration = await ServiceWorkerContainer.GetRegistration(SERVICE_WORKER_URL);
        labelOutput = (serviceWorkerRegistration is not null).ToString();
    }

    public const string BUTTON_GET_REGISTRATIONS = "service-worker-container-inprocess-get-registrations";
    private async Task GetRegistrations() {
        IServiceWorkerRegistrationInProcess[] serviceWorkerRegistrations = await ServiceWorkerContainer.GetRegistrations();
        labelOutput = serviceWorkerRegistrations.Length.ToString();

        serviceWorkerRegistrations.Dispose();
    }

    public const string BUTTON_START_MESSAGES = "service-worker-container-inprocess-start-messages";
    private void StartMessages() {
        ServiceWorkerContainer.StartMessages();
        labelOutput = TEST_START_MESSAGES;
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
        ServiceWorkerContainer.OnMessage += (JsonElement message) => {
            labelOutput = message.ToString();
            StateHasChanged();
        };
    }


    // Service Worker Registration

    public const string BUTTON_UNREGISTER = "service-worker-registration-inprocess-unregister";
    private async Task Unregister() {
        using IServiceWorkerRegistrationInProcess serviceWorkerRegistration = await ServiceWorkerRegistration;
        bool result = await serviceWorkerRegistration.Unregister();

        if (result) {
            serviceWorkerRegistration.Dispose();
            _serviceWorkerRegistration = null;
        }

        labelOutput = result.ToString();
    }


    public const string BUTTON_ACTIVE = "service-worker-registration-inprocess-active";
    private async Task Active() {
        using IServiceWorkerInProcess? serviceWorker = (await ServiceWorkerRegistration).Active;
        labelOutput = (serviceWorker is not null).ToString();
    }

    public const string BUTTON_INSTALLING = "service-worker-registration-inprocess-installing";
    private async Task Installing() {
        using IServiceWorkerInProcess? serviceWorker = (await ServiceWorkerRegistration).Installing;
        labelOutput = (serviceWorker is not null).ToString();
    }

    public const string BUTTON_WAITING = "service-worker-registration-inprocess-waiting";
    private async Task Waiting() {
        using IServiceWorkerInProcess? serviceWorker = (await ServiceWorkerRegistration).Waiting;
        labelOutput = (serviceWorker is not null).ToString();
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
    private async Task Update() {
        using IServiceWorkerRegistrationInProcess serviceWorkerRegistration = await (await ServiceWorkerRegistration).Update();
        labelOutput = (serviceWorkerRegistration is not null).ToString();
    }


    public const string BUTTON_REGISTER_ON_UPDATE_FOUND = "service-worker-registration-inprocess-event-update-found";
    private async Task RegisterOnUpdateFound() {
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
    private async Task RegisterOnStateChange() {
        (await ServiceWorker).OnStateChange += (string state) => {
            labelOutput = state;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ERROR = "service-worker-inprocess-event-error";
    private async Task RegisterOnError() {
        (await ServiceWorker).OnError += (JsonElement error) => {
            labelOutput = error.ToString();
            StateHasChanged();
        };
    }
}

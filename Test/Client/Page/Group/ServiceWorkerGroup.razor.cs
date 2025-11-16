using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class ServiceWorkerGroup : ComponentBase, IAsyncDisposable {
    public const string SERVICE_WORKER_URL = "service-worker.js";
    public const string TEST_REGISTER = "service worker registered";
    public const string TEST_START_MESSAGES = "started messages";
    public const string TEST_EVENT_CONTROLLER_CHANGED = "service-worker-container controller changed";
    public const string TEST_EVENT_UPDATE_FOUND = "service-worker-registration update found";
    public const string TEST_POST_MESSAGE = "service-worker post message";


    [Inject]
    public required IServiceWorkerContainer ServiceWorkerContainer { private get; init; }

    private Task<IServiceWorkerRegistration>? _serviceWorkerRegistration;
    private Task<IServiceWorkerRegistration> ServiceWorkerRegistration => _serviceWorkerRegistration ??= ServiceWorkerContainer.RegisterWithWorkerRegistration(SERVICE_WORKER_URL).AsTask();

    private Task<IServiceWorker>? _serviceWorker;
    private Task<IServiceWorker> ServiceWorker {
        get {
            return _serviceWorker ??= DoAsync();
            async Task<IServiceWorker> DoAsync() {
                await ServiceWorkerRegistration;
                await using IServiceWorkerRegistration serviceWorkerRegistration = await ServiceWorkerContainer.Ready;
                return await serviceWorkerRegistration.Active ?? throw new UnreachableException("DelayUntilReady() ensures there is a active service worker.");
            }
        }
    }

    public async ValueTask DisposeAsync() {
        if (_serviceWorkerRegistration is not null)
            await (await _serviceWorkerRegistration).DisposeAsync();
        if (_serviceWorker is not null)
            await (await _serviceWorker).DisposeAsync();
    }


    public const string LABEL_OUTPUT = "service-worker-output";
    private string labelOutput = string.Empty;


    // Service Worker Container

    public const string BUTTON_REGISTER = "service-worker-container-register";
    private async Task Register() {
        await ServiceWorkerContainer.Register(SERVICE_WORKER_URL);
        labelOutput = TEST_REGISTER;
    }

    public const string BUTTON_REGISTER_WITH_WORKER_REGISTRATION = "service-worker-container-register-with-worker-registration";
    private async Task RegisterWithWorkerRegistration() {
        await using IServiceWorkerRegistration? serviceWorkerRegistration = await ServiceWorkerContainer.RegisterWithWorkerRegistration(SERVICE_WORKER_URL);
        labelOutput = (serviceWorkerRegistration is not null).ToString();
    }


    public const string BUTTON_GET_CONTROLLER_PROPERTY = "service-worker-container-get-controller-property";
    private async Task GetController_Property() {
        await using IServiceWorker? serviceWorker = await ServiceWorkerContainer.Controller;
        labelOutput = (serviceWorker is not null).ToString();
    }

    public const string BUTTON_GET_CONTROLLER_METHOD = "service-worker-container-get-controller-method";
    private async Task GetController_Method() {
        await using IServiceWorker? serviceWorker = await ServiceWorkerContainer.GetController(CancellationToken.None);
        labelOutput = (serviceWorker is not null).ToString();
    }

    public const string BUTTON_GET_READY_PROPERTY = "service-worker-container-get-ready-property";
    private async Task GetReady_Property() {
        await using IServiceWorkerRegistration? serviceWorkerRegistration = await ServiceWorkerContainer.Ready;
        labelOutput = (serviceWorkerRegistration is not null).ToString();
    }

    public const string BUTTON_GET_READY_METHOD = "service-worker-container-get-ready-method";
    private async Task GetReady_Method() {
        await using IServiceWorkerRegistration? serviceWorkerRegistration = await ServiceWorkerContainer.GetReady(CancellationToken.None);
        labelOutput = (serviceWorkerRegistration is not null).ToString();
    }


    public const string BUTTON_GET_REGISTRATION = "service-worker-container-get-registration";
    private async Task GetRegistration() {
        await using IServiceWorkerRegistration? serviceWorkerRegistration = await ServiceWorkerContainer.GetRegistration(SERVICE_WORKER_URL);
        labelOutput = (serviceWorkerRegistration is not null).ToString();
    }

    public const string BUTTON_GET_REGISTRATIONS = "service-worker-container-get-registrations";
    private async Task GetRegistrations() {
        IServiceWorkerRegistration[] serviceWorkerRegistrations = await ServiceWorkerContainer.GetRegistrations();
        labelOutput = serviceWorkerRegistrations.Length.ToString();

        await serviceWorkerRegistrations.DisposeAsync();
    }

    public const string BUTTON_START_MESSAGES = "service-worker-container-start-messages";
    private async Task StartMessages() {
        await ServiceWorkerContainer.StartMessages();
        labelOutput = TEST_START_MESSAGES;
    }


    public const string BUTTON_REGISTER_ON_CONTROLLER_CHANGE = "service-worker-container-event-controller-change";
    private void RegisterOnControllerChange() {
        ServiceWorkerContainer.OnControllerChange += () => {
            labelOutput = TEST_EVENT_CONTROLLER_CHANGED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MESSAGE = "service-worker-container-event-message";
    private void RegisterOnMessage() {
        ServiceWorkerContainer.OnMessage += (JsonElement message) => {
            labelOutput = message.ToString();
            StateHasChanged();
        };
    }


    // Service Worker Registration

    public const string BUTTON_UNREGISTER = "service-worker-registration-unregister";
    private async Task Unregister() {
        await using IServiceWorkerRegistration serviceWorkerRegistration = await ServiceWorkerRegistration;
        bool result = await serviceWorkerRegistration.Unregister();

        if (result) {
            await serviceWorkerRegistration.DisposeAsync();
            _serviceWorkerRegistration = null;
        }

        labelOutput = result.ToString();
    }


    public const string BUTTON_ACTIVE_PROPERTY = "service-worker-registration-active-property";
    private async Task Active_Property() {
        await using IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).Active;
        labelOutput = (serviceWorker is not null).ToString();
    }

    public const string BUTTON_ACTIVE_METHOD = "service-worker-registration-active-method";
    private async Task Active_Method() {
        await using IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).GetActive(CancellationToken.None);
        labelOutput = (serviceWorker is not null).ToString();
    }

    public const string BUTTON_INSTALLING_PROPERTY = "service-worker-registration-installing-property";
    private async Task Installing_Property() {
        await using IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).Installing;
        labelOutput = (serviceWorker is not null).ToString();
    }

    public const string BUTTON_INSTALLING_METHOD = "service-worker-registration-installing-method";
    private async Task Installing_Method() {
        await using IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).GetInstalling(CancellationToken.None);
        labelOutput = (serviceWorker is not null).ToString();
    }

    public const string BUTTON_WAITING_PROPERTY = "service-worker-registration-waiting-property";
    private async Task Waiting_Property() {
        await using IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).Waiting;
        labelOutput = (serviceWorker is not null).ToString();
    }

    public const string BUTTON_WAITING_METHOD = "service-worker-registration-waiting-method";
    private async Task Waiting_Method() {
        await using IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).GetWaiting(CancellationToken.None);
        labelOutput = (serviceWorker is not null).ToString();
    }

    public const string BUTTON_SCOPE_PROPERTY = "service-worker-registration-scope-property";
    private async Task Scope_Property() {
        string scope = await (await ServiceWorkerRegistration).Scope;
        labelOutput = scope;
    }

    public const string BUTTON_SCOPE_METHOD = "service-worker-registration-scope-method";
    private async Task Scope_Method() {
        string scope = await (await ServiceWorkerRegistration).GetScope(CancellationToken.None);
        labelOutput = scope;
    }

    public const string BUTTON_UPDATE_VIA_CACHE_PROPERTY = "service-worker-registration-update-via-cache-property";
    private async Task UpdateViaCache_Property() {
        string cacheMode = await (await ServiceWorkerRegistration).UpdateViaCache;
        labelOutput = cacheMode;
    }

    public const string BUTTON_UPDATE_VIA_CACHE_METHOD = "service-worker-registration-update-via-cache-method";
    private async Task UpdateViaCache_Method() {
        string cacheMode = await (await ServiceWorkerRegistration).GetUpdateViaCache(CancellationToken.None);
        labelOutput = cacheMode;
    }


    public const string BUTTON_UPDATE = "service-worker-registration-update";
    private async Task Update() {
        await using IServiceWorkerRegistration serviceWorkerRegistration = await (await ServiceWorkerRegistration).Update();
        labelOutput = (serviceWorkerRegistration is not null).ToString();
    }


    public const string BUTTON_REGISTER_ON_UPDATE_FOUND = "service-worker-registration-event-update-found";
    private async Task RegisterOnUpdateFound() {
        (await ServiceWorkerRegistration).OnUpdateFound += () => {
            labelOutput = TEST_EVENT_UPDATE_FOUND;
            StateHasChanged();
        };
    }


    // Service Worker

    public const string BUTTON_SCRIPT_URL_PROPERTY = "service-worker-script-url-property";
    private async Task ScriptUrl_Property() {
        string scriptUrl = await (await ServiceWorker).ScriptUrl;
        labelOutput = scriptUrl;
    }

    public const string BUTTON_SCRIPT_URL_METHOD = "service-worker-script-url-method";
    private async Task ScriptUrl_Method() {
        string scriptUrl = await (await ServiceWorker).GetScriptUrl(CancellationToken.None);
        labelOutput = scriptUrl;
    }

    public const string BUTTON_STATE_PROPERTY = "service-worker-state-property";
    private async Task State_Property() {
        string state = await (await ServiceWorker).State;
        labelOutput = state;
    }

    public const string BUTTON_STATE_METHOD = "service-worker-state-method";
    private async Task State_Method() {
        string state = await (await ServiceWorker).GetState(CancellationToken.None);
        labelOutput = state;
    }


    public const string BUTTON_POST_MESSAGE = "service-worker-post-message";
    private async Task PostMessage() {
        await (await ServiceWorker).PostMessage(TEST_POST_MESSAGE);
        labelOutput = TEST_POST_MESSAGE;
    }


    public const string BUTTON_REGISTER_ON_STATE_CHANGE = "service-worker-event-state-change";
    private async Task RegisterOnStateChange() {
        (await ServiceWorker).OnStateChange += (string state) => {
            labelOutput = state;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ERROR = "service-worker-event-error";
    private async Task RegisterOnError() {
        (await ServiceWorker).OnError += (JsonElement error) => {
            labelOutput = error.ToString();
            StateHasChanged();
        };
    }
}

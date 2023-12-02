using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class ServiceWorkerRegistrationGroup : ComponentBase {
    public const string TEST_EVENT_UPDATE_FOUND = "service-worker-registration update found";


    [Inject]
    public required IServiceWorkerContainer ServiceWorkerContainer { private get; init; }

    [Inject]
    public required IServiceWorkerContainerInProcess ServiceWorkerContainerInProcess { private get; init; }


    private Task<IServiceWorkerRegistration>? _serviceWorkerRegistration;
    private Task<IServiceWorkerRegistration> ServiceWorkerRegistration {
        get {
            return _serviceWorkerRegistration ??= DoAsync();
            async Task<IServiceWorkerRegistration> DoAsync() => (await ServiceWorkerContainer.RegisterWithWorkerRegistration(ServiceWorkerContainerGroup.SERVICE_WORKER_URL)) ?? throw new ArgumentNullException(null, "service worker could not be registered.");
        }
    }

    private Task<IServiceWorkerRegistrationInProcess>? _serviceWorkerRegistrationInProcess;
    private Task<IServiceWorkerRegistrationInProcess> ServiceWorkerRegistrationInProcess {
        get {
            return _serviceWorkerRegistrationInProcess ??= DoAsync();
            async Task<IServiceWorkerRegistrationInProcess> DoAsync() => (await ServiceWorkerContainerInProcess.RegisterWithWorkerRegistration(ServiceWorkerContainerGroup.SERVICE_WORKER_URL)) ?? throw new ArgumentNullException(null, "service worker could not be registered.");
        }
    }


    public const string LABEL_OUTPUT = "service-worker-registration-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_UNREGISTER = "service-worker-registration-unregister";
    private async Task Unregister() {
        bool result = await (await ServiceWorkerRegistration).Unregister();
        labelOutput = result.ToString();
    }

    public const string BUTTON_ACTIVE_PROPERTY = "service-worker-registration-active-property";
    private async Task Active_Property() {
        IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).Active;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_ACTIVE_METHOD = "service-worker-registration-active-method";
    private async Task Active_Method() {
        IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).GetActive(default);
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_INSTALLING_PROPERTY = "service-worker-registration-installing-property";
    private async Task Installing_Property() {
        IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).Installing;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_INSTALLING_METHOD = "service-worker-registration-installing-method";
    private async Task Installing_Method() {
        IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).GetInstalling(default);
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_WAITING_PROPERTY = "service-worker-registration-waiting-property";
    private async Task Waiting_Property() {
        IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).Waiting;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_WAITING_METHOD = "service-worker-registration-waiting-method";
    private async Task Waiting_Method() {
        IServiceWorker? serviceWorker = await (await ServiceWorkerRegistration).GetWaiting(default);
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_SCOPE_PROPERTY = "service-worker-registration-scope-property";
    private async Task Scope_Property() {
        string scope = await (await ServiceWorkerRegistration).Scope;
        labelOutput = scope;
    }

    public const string BUTTON_SCOPE_METHOD = "service-worker-registration-scope-method";
    private async Task Scope_Method() {
        string scope = await (await ServiceWorkerRegistration).GetScope(default);
        labelOutput = scope;
    }

    public const string BUTTON_UPDATE_VIA_CACHE_PROPERTY = "service-worker-registration-update-via-cache-property";
    private async Task UpdateViaCache_Property() {
        string cacheMode = await (await ServiceWorkerRegistration).UpdateViaCache;
        labelOutput = cacheMode;
    }

    public const string BUTTON_UPDATE_VIA_CACHE_METHOD = "service-worker-registration-update-via-cache-method";
    private async Task UpdateViaCache_Method() {
        string cacheMode = await (await ServiceWorkerRegistration).GetUpdateViaCache(default);
        labelOutput = cacheMode;
    }

    public const string BUTTON_UPDATE = "service-worker-container-update";
    private async void Update() {
        IServiceWorkerRegistration serviceWorkerRegistration = await (await ServiceWorkerRegistration).Update();
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_REGISTER_ON_UPDATE_FOUND = "service-worker-container-event-update-found";
    private async void RegisterOnUpdateFound() {
        (await ServiceWorkerRegistration).OnUpdateFound += () => {
            labelOutput = TEST_EVENT_UPDATE_FOUND;
            StateHasChanged();
        };
    }


    public const string BUTTON_UNREGISTER_INPROCESS = "service-worker-registration-unregister-inprocess";
    private async Task Unregister_InProcess() {
        bool result = await (await ServiceWorkerRegistrationInProcess).Unregister();
        labelOutput = result.ToString();
    }

    public const string BUTTON_ACTIVE_INPROCESS = "service-worker-registration-active-inprocess";
    private async Task Active_InProcess() {
        IServiceWorkerInProcess? serviceWorker = (await ServiceWorkerRegistrationInProcess).Active;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_INSTALLING_INPROCESS = "service-worker-registration-installing-inprocess";
    private async Task Installing_InProcess() {
        IServiceWorkerInProcess? serviceWorker = (await ServiceWorkerRegistrationInProcess).Installing;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_WAITING_INPROCESS = "service-worker-registration-waiting-inprocess";
    private async Task Waiting_InProcess() {
        IServiceWorkerInProcess? serviceWorker = (await ServiceWorkerRegistrationInProcess).Waiting;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_SCOPE_INPROCESS = "service-worker-registration-scope-inprocess";
    private async Task Scope_InProcess() {
        string scope = (await ServiceWorkerRegistrationInProcess).Scope;
        labelOutput = scope;
    }

    public const string BUTTON_UPDATE_VIA_CACHE_INPROCESS = "service-worker-registration-update-via-cache-inprocess";
    private async Task UpdateViaCache_InProcess() {
        string cacheMode = (await ServiceWorkerRegistrationInProcess).UpdateViaCache;
        labelOutput = cacheMode;
    }

    public const string BUTTON_UPDATE_INPROCESS = "service-worker-container-update-inprocess";
    private async void Update_InProcess() {
        IServiceWorkerRegistrationInProcess serviceWorkerRegistration = await (await ServiceWorkerRegistrationInProcess).Update();
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_REGISTER_ON_UPDATE_FOUND_INPROCESS = "service-worker-container-event-update-found-inprocess";
    private async void RegisterOnUpdateFound_InProcess() {
        (await ServiceWorkerRegistrationInProcess).OnUpdateFound += () => {
            labelOutput = TEST_EVENT_UPDATE_FOUND;
            StateHasChanged();
        };
    }
}

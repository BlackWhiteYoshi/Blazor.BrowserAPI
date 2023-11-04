using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class ServiceWorkerGroup : ComponentBase {
    public const string TEST_POST_MESSAGE = "service-worker post message";


    [Inject]
    public required IServiceWorkerContainer ServiceWorkerContainer { private get; init; }

    [Inject]
    public required IServiceWorkerContainerInProcess ServiceWorkerContainerInProcess { private get; init; }


    private Task<IServiceWorker>? _serviceWorker;
    private Task<IServiceWorker> ServiceWorker {
        get {
            return _serviceWorker ??= DoAsync();
            async Task<IServiceWorker> DoAsync() {
                await ServiceWorkerContainer.Register(ServiceWorkerContainerGroup.SERVICE_WORKER_URL);
                await using IServiceWorkerRegistration serviceWorkerRegistration = await ServiceWorkerContainer.DelayUntilReady();
                return await serviceWorkerRegistration.Active ?? throw new ArgumentNullException(null, "service worker could not be retrieved.");
            }
        }
    }

    private Task<IServiceWorkerInProcess>? _serviceWorkerInProcess;
    private Task<IServiceWorkerInProcess> ServiceWorkerInProcess {
        get {
            return _serviceWorkerInProcess ??= DoAsync();
            async Task<IServiceWorkerInProcess> DoAsync() {
                await ServiceWorkerContainerInProcess.Register(ServiceWorkerContainerGroup.SERVICE_WORKER_URL);
                using IServiceWorkerRegistrationInProcess serviceWorkerRegistration = await ServiceWorkerContainerInProcess.DelayUntilReady();
                return serviceWorkerRegistration.Active ?? throw new ArgumentNullException(null, "service worker could not be retrieved.");
            }
        }
    }


    public const string LABEL_OUTPUT = "service-worker-registration-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_SCRIPT_URL_PROPERTY = "service-worker-script-url-property";
    private async Task ScriptUrl_Property() {
        string scriptUrl = await (await ServiceWorker).ScriptUrl;
        labelOutput = scriptUrl;
    }

    public const string BUTTON_SCRIPT_URL_METHOD = "service-worker-script-url-method";
    private async Task ScriptUrl_Method() {
        string scriptUrl = await (await ServiceWorker).GetScriptUrl(default);
        labelOutput = scriptUrl;
    }

    public const string BUTTON_STATE_PROPERTY = "service-worker-state-property";
    private async Task State_Property() {
        string state = await (await ServiceWorker).State;
        labelOutput = state;
    }

    public const string BUTTON_STATE_METHOD = "service-worker-state-method";
    private async Task State_Method() {
        string state = await (await ServiceWorker).GetState(default);
        labelOutput = state;
    }

    public const string BUTTON_POST_MESSAGE = "service-worker-post-message";
    private async Task PostMessage() {
        await (await ServiceWorker).PostMessage(TEST_POST_MESSAGE);
        labelOutput = TEST_POST_MESSAGE;
    }

    public const string BUTTON_REGISTER_ON_STATE_CHANGE = "service-worker-event-state-change";
    private async void RegisterOnStateChange() {
        (await ServiceWorker).OnStateChange += (string state) => {
            labelOutput = state;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ERROR = "service-worker-event-error";
    private async void RegisterOnError() {
        (await ServiceWorker).OnError += (string error) => {
            labelOutput = error;
            StateHasChanged();
        };
    }


    public const string BUTTON_SCRIPT_URL_INPROCESS = "service-worker-script-url-inprocess";
    private async Task ScriptUrl_InProcess() {
        string scriptUrl = (await ServiceWorkerInProcess).ScriptUrl;
        labelOutput = scriptUrl;
    }

    public const string BUTTON_STATE_INPROCESS = "service-worker-state-inprocess";
    private async Task State_InProcess() {
        string state = (await ServiceWorkerInProcess).State;
        labelOutput = state;
    }

    public const string BUTTON_POST_MESSAGE_INPROCESS = "service-worker-post-message-inprocess";
    private async Task PostMessage_InProcess() {
        (await ServiceWorkerInProcess).PostMessage(TEST_POST_MESSAGE);
        labelOutput = TEST_POST_MESSAGE;
    }

    public const string BUTTON_REGISTER_ON_STATE_CHANGE_INPROCESS = "service-worker-event-state-change-inprocess";
    private async void RegisterOnStateChange_InProcess() {
        (await ServiceWorkerInProcess).OnStateChange += (string state) => {
            labelOutput = state;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ERROR_INPROCESS = "service-worker-event-error-inprocess";
    private async void RegisterOnError_InProcess() {
        (await ServiceWorkerInProcess).OnError += (string error) => {
            labelOutput = error;
            StateHasChanged();
        };
    }
}

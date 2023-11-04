using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class ServiceWorkerContainerGroup : ComponentBase {
    public const string SERVICE_WORKER_URL = "service-worker.js";
    public const string TEST_EVENT_CONTROLLER_CHANGED = "service-worker-container controller changed";


    [Inject]
    public required IServiceWorkerContainer ServiceWorkerContainer { private get; init; }

    [Inject]
    public required IServiceWorkerContainerInProcess ServiceWorkerContainerInProcess { private get; init; }


    public const string LABEL_OUTPUT = "service-worker-container-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_REGISTER = "service-worker-container-register";
    private async Task Register() {
        bool result = await ServiceWorkerContainer.Register(SERVICE_WORKER_URL);
        labelOutput = result.ToString();
    }

    public const string BUTTON_REGISTER_WITH_WORKER_REGISTRATION = "service-worker-container-register-with-worker-registration";
    private async Task RegisterWithWorkerRegistration() {
        await using IServiceWorkerRegistration? serviceWorkerRegistration = await ServiceWorkerContainer.RegisterWithWorkerRegistration(SERVICE_WORKER_URL);
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_DELAY_UNTIL_READY = "service-worker-container-delay-until-ready";
    private async Task DelayUntilReady() {
        await using IServiceWorkerRegistration? serviceWorkerRegistration = await ServiceWorkerContainer.DelayUntilReady();
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_GET_REGISTRATION = "service-worker-container-get-registration";
    private async Task GetRegistration() {
        await using IServiceWorkerRegistration? serviceWorkerRegistration = await ServiceWorkerContainer.GetRegistration(SERVICE_WORKER_URL);
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_GET_REGISTRATIONS = "service-worker-container-get-registrations";
    private async Task GetRegistrations() {
        IServiceWorkerRegistration[] serviceWorkerRegistrations = await ServiceWorkerContainer.GetRegistrations();
        labelOutput = serviceWorkerRegistrations.Length.ToString();

        foreach (IServiceWorkerRegistration serviceWorkerRegistration in serviceWorkerRegistrations)
            await serviceWorkerRegistration.DisposeAsync();
    }

    public const string BUTTON_GET_CONTROLLER_PROPERTY = "service-worker-container-get-controller-property";
    private async Task GetController_Property() {
        await using IServiceWorker? serviceWorker = await ServiceWorkerContainer.Controller;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_GET_CONTROLLER_METHOD = "service-worker-container-get-controller-method";
    private async Task GetController_Method() {
        await using IServiceWorker? serviceWorker = await ServiceWorkerContainer.GetController(default);
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_START_MESSAGES = "service-worker-container-start-messages";
    private async Task StartMessages() {
        await ServiceWorkerContainer.StartMessages();
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
        ServiceWorkerContainer.OnMessage += (string messageEvent) => {
            labelOutput = messageEvent;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_INPROCESS = "service-worker-container-register-inprocess";
    private async Task Register_InProcess() {
        bool result = await ServiceWorkerContainerInProcess.Register(SERVICE_WORKER_URL);
        labelOutput = result.ToString();
    }

    public const string BUTTON_REGISTER_WITH_WORKER_REGISTRATION_INPROCESS = "service-worker-container-register-with-worker-registration-inprocess";
    private async Task RegisterWithWorkerRegistration_InProcess() {
        using IServiceWorkerRegistrationInProcess? serviceWorkerRegistration = await ServiceWorkerContainerInProcess.RegisterWithWorkerRegistration(SERVICE_WORKER_URL);
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_DELAY_UNTIL_READY_INPROCESS = "service-worker-container-delay-until-ready-inprocess";
    private async Task DelayUntilReady_InProcess() {
        using IServiceWorkerRegistrationInProcess? serviceWorkerRegistration = await ServiceWorkerContainerInProcess.DelayUntilReady();
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_GET_REGISTRATION_INPROCESS = "service-worker-container-get-registration-inprocess";
    private async Task GetRegistration_InProcess() {
        using IServiceWorkerRegistrationInProcess? serviceWorkerRegistration = await ServiceWorkerContainerInProcess.GetRegistration(SERVICE_WORKER_URL);
        labelOutput = (serviceWorkerRegistration != null).ToString();
    }

    public const string BUTTON_GET_REGISTRATIONS_INPROCESS = "service-worker-container-get-registrations-inprocess";
    private async Task GetRegistrations_InProcess() {
        IServiceWorkerRegistrationInProcess[] serviceWorkerRegistrations = await ServiceWorkerContainerInProcess.GetRegistrations();
        labelOutput = serviceWorkerRegistrations.Length.ToString();

        foreach (IServiceWorkerRegistrationInProcess serviceWorkerRegistration in serviceWorkerRegistrations)
            serviceWorkerRegistration.Dispose();
    }

    public const string BUTTON_GET_CONTROLLER_INPROCESS = "service-worker-container-get-controller-inprocess";
    private void GetController_InProcess() {
        using IServiceWorkerInProcess? serviceWorker = ServiceWorkerContainerInProcess.Controller;
        labelOutput = (serviceWorker != null).ToString();
    }

    public const string BUTTON_START_MESSAGES_INPROCESS = "service-worker-container-start-messages-inprocess";
    private void StartMessages_InProcess() {
        ServiceWorkerContainerInProcess.StartMessages();
    }

    public const string BUTTON_REGISTER_ON_CONTROLLER_CHANGE_INPROCESS = "service-worker-container-event-controller-change-inprocess";
    private void RegisterOnControllerChange_InProcess() {
        ServiceWorkerContainerInProcess.OnControllerChange += () => {
            labelOutput = TEST_EVENT_CONTROLLER_CHANGED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MESSAGE_INPROCESS = "service-worker-container-event-message-inprocess";
    private void RegisterOnMessage_InProcess() {
        ServiceWorkerContainerInProcess.OnMessage += (string messageEvent) => {
            labelOutput = messageEvent;
            StateHasChanged();
        };
    }
}

using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class ServiceWorkerInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    private const string SERVICE_WORKER_REGISTRATION_SCOPE = "fake-ID";
    private const string SERVICE_WORKER_REGISTRATION_UPDATE_VIA_CACHE = "none";
    private const string SERVICE_WORKER_SCRIPT_URL = "fake-url";
    private const string SERVICE_WORKER_STATE = "installed";
    private const string SERVICE_WORKER_EVENT_STATE_CHANGE = "parsed";
    private const string SERVICE_WORKER_EVENT_ERROR_MESSAGE = "fake-error";

    private const string JS_SERVICE_WORKER_CONTAINER_METHODS = $$"""
        navigator.serviceWorker.register = (filePath) => ({{JS_SERVICE_WORKER_REGISTRATION_OBJECT}});

        Object.defineProperty(navigator.serviceWorker, "controller", { get() { return null; } });
        Object.defineProperty(navigator.serviceWorker, "ready", { get() { return Promise.resolve({{JS_SERVICE_WORKER_REGISTRATION_OBJECT}}); } });

        navigator.serviceWorker.getRegistration = (clientUrl) => undefined;
        navigator.serviceWorker.getRegistrations = () => [];
        navigator.serviceWorker.startMessages = () => { };
        """;

    private const string JS_SERVICE_WORKER_REGISTRATION_OBJECT = $$"""
        {
            active: {{JS_SERVICE_WORKER_OBJECT}},
            installing: null,
            waiting: null,
            scope: "{{SERVICE_WORKER_REGISTRATION_SCOPE}}",
            updateViaCache: "{{SERVICE_WORKER_REGISTRATION_UPDATE_VIA_CACHE}}",

            unregister: () => Promise.resolve(true),
            update: () => Promise.resolve(null),

            addEventListener: (type, listener) => window.setTimeout(listener, 300),
            removeEventListener: (type, listener) => { }
        }
        """;

    private const string JS_SERVICE_WORKER_OBJECT = $$"""
        {
            scriptURL: "{{SERVICE_WORKER_SCRIPT_URL}}",
            state: "{{SERVICE_WORKER_STATE}}",

            postMessage: (message) => { },

            addEventListener: (type, listener) => {
                switch (type) {
                    case "statechange": // parameter -> event: BlobEvent
                        const event = { target: { state: "{{SERVICE_WORKER_EVENT_STATE_CHANGE}}" } };
                        window.setTimeout(() => listener(event), 300);
                        break;
                    case "error": // parameter -> event: Event
                        window.setTimeout(() => listener("{{SERVICE_WORKER_EVENT_ERROR_MESSAGE}}"), 300);
                        break;
                    default:
                        throw new Exception("wrong event listener type");
                }
            },
            removeEventListener: (type, listener) => { }
        }
        """;

    public override async Task SetUp() {
        await base.SetUp();
        await Page.EvaluateAsync(JS_SERVICE_WORKER_CONTAINER_METHODS);
        await Task.Delay(SMALL_WAIT_TIME);
    }


    // Service Worker Container

    [Test]
    public async Task Register() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_REGISTER);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(ServiceWorkerInProcessGroup.TEST_REGISTER);
    }

    [Test]
    public async Task RegisterWithWorkerRegistration() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_REGISTER_WITH_WORKER_REGISTRATION);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetController() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_GET_CONTROLLER);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetReady_Property() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_GET_READY_PROPERTY);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetReady_Method() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_GET_READY_METHOD);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetRegistration() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_GET_REGISTRATION);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetRegistrations() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_GET_REGISTRATIONS);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task StartMessages() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_START_MESSAGES);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(ServiceWorkerInProcessGroup.TEST_START_MESSAGES);
    }


    [Test]
    public async Task RegisterOnControllerChange() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_REGISTER_ON_CONTROLLER_CHANGE);
        await Page.EvaluateAsync("navigator.serviceWorker.dispatchEvent(new Event('controllerchange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(ServiceWorkerInProcessGroup.TEST_EVENT_CONTROLLER_CHANGED);
    }

    [Test]
    public async Task RegisterOnMessage() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_REGISTER_ON_MESSAGE);
        await Page.EvaluateAsync("navigator.serviceWorker.dispatchEvent(new MessageEvent('message', { data: 'fake-message' }));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("fake-message");
    }


    // Service Worker Registration

    [Test]
    public async Task Unregister() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_UNREGISTER);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task Active() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_ACTIVE);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task Installing() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_INSTALLING);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task Waiting() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_WAITING);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task Scope() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_SCOPE);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SERVICE_WORKER_REGISTRATION_SCOPE);
    }

    [Test]
    public async Task UpdateViaCache() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_UPDATE_VIA_CACHE);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SERVICE_WORKER_REGISTRATION_UPDATE_VIA_CACHE);
    }


    [Test]
    public async Task Update() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_UPDATE);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task RegisterOnUpdateFound() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_REGISTER_ON_UPDATE_FOUND);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(ServiceWorkerInProcessGroup.TEST_EVENT_UPDATE_FOUND);
    }


    // Service Worker

    [Test]
    public async Task ScriptUrl() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_SCRIPT_URL);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SERVICE_WORKER_SCRIPT_URL);
    }

    [Test]
    public async Task State() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_STATE);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SERVICE_WORKER_STATE);
    }


    [Test]
    public async Task PostMessage() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_POST_MESSAGE);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(ServiceWorkerInProcessGroup.TEST_POST_MESSAGE);
    }


    [Test]
    public async Task RegisterOnStateChange() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_REGISTER_ON_STATE_CHANGE);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SERVICE_WORKER_EVENT_STATE_CHANGE);
    }

    [Test]
    public async Task RegisterOnError() {
        await ExecuteTest(ServiceWorkerInProcessGroup.BUTTON_REGISTER_ON_ERROR);

        string? result = await Page.GetByTestId(ServiceWorkerInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SERVICE_WORKER_EVENT_ERROR_MESSAGE);
    }
}

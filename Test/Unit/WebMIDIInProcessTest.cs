using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class WebMIDIInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    private const string TEST_ID = "123-456-789";
    private const string TEST_MANUFACTURER = "Yoshi";
    private const string TEST_NAME = "fake-port";
    private const string TEST_VERSION = "1.0";
    private const string TEST_STATE = "connected";
    private const string TEST_MESSAGE = "[144,60,127]";

    private const string WEB_MIDI_API = $"""
        const inputMap = new Map();
        inputMap.set({TEST_ID}, {MIDI_INPUT_PORT});

        const outputMap = new Map();
        outputMap.set({TEST_ID}, {MIDI_OUTPUT_PORT});

        navigator.requestMIDIAccess = () => Promise.resolve({MIDI_ACCESS});
        """;

    private const string MIDI_ACCESS = $$"""
        {
            inputs: inputMap,
            outputs: outputMap,
            sysexEnabled: false,

            addEventListener: (type, listener) => window.setTimeout(() => listener({ port: {{MIDI_INPUT_PORT}} }), 300),
            removeEventListener: (type, listener) => { }
        }
        """;

    private const string MIDI_PORT = $$"""
        id: "{{TEST_ID}}",
        manufacturer: "{{TEST_MANUFACTURER}}",
        name: "{{TEST_NAME}}",
        version: "{{TEST_VERSION}}",
        state: "{{TEST_STATE}}",
        connection: "closed",

        open() { Promise.resolve(this.connection = "open"); },
        close() { Promise.resolve(this.connection = "closed"); }
        """;

    private const string MIDI_INPUT_PORT = $$"""
        {
            {{MIDI_PORT}},
            type: "input",

            addEventListener: (type, listener) => {
            console.log(type);
            console.log(listener);
                switch (type) {
                    case "statechange": // parameter us not used
                        window.setTimeout(listener, 300);
                        break;
                    case "midimessage": // parameter -> data: Uint8Array
                        window.setTimeout(() => listener({ data: new Uint8Array({{TEST_MESSAGE}}) }), 300);
                        break;
                    default:
                        throw new Exception("wrong event listener type");
                }
            },
            removeEventListener: (type, listener) => { }
        }
        """;

    private const string MIDI_OUTPUT_PORT = $$"""
        {
            {{MIDI_PORT}},
            type: "output",

            send() { },
            clear() { },

            addEventListener: (type, listener) => window.setTimeout(listener, 300), // parameter us not used
            removeEventListener: (type, listener) => { }
        }
        """;

    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await Page.EvaluateAsync(WEB_MIDI_API);
        await Task.Delay(SMALL_WAIT_TIME);
    }


    // WebMIDI

    [Test]
    public async Task RequestMIDIAccess() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_REQUEST_MIDI_ACCESS);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // MIDIAccess

    [Test]
    public async Task GetInputs() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_GET_INPUTS);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetOututs() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_GET_OUTPUTS);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetSysexEnabled() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_GET_SYSEX_ENABLED);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task RegisterOnStateChange() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_REGISTER_ON_STATE_CHANGE);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WebMIDIInProcessGroup.TEST_EVENT_STATE_CHANGE);
    }


    // MIDIPort

    [Test]
    public async Task GetId() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_GET_ID);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(TEST_ID);
    }

    [Test]
    public async Task GetManufacturer() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_GET_MANUFACTURER);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(TEST_MANUFACTURER);
    }

    [Test]
    public async Task GetName() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_GET_NAME);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(TEST_NAME);
    }

    [Test]
    public new async Task GetType() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_GET_TYPE);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("input");
    }

    [Test]
    public async Task GetVersion() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_GET_VERSION);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(TEST_VERSION);
    }

    [Test]
    public async Task GetState() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_GET_STATE);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(TEST_STATE);
    }

    [Test]
    public async Task GetConnection() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_GET_CONNECTION);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("closed");
    }


    [Test]
    public async Task Open() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_OPEN);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("open");
    }

    [Test]
    public async Task Close() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_CLOSE);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("open -> closed");
    }


    [Test]
    public async Task RegisterOnStateChangePort() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_REGISTER_ON_STATE_CHANGE_PORT);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WebMIDIInProcessGroup.TEST_EVENT_STATE_CHANGE_PORT);
    }


    // MIDIInput

    [Test]
    public async Task RegisterOnMIDIMessage() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_REGISTER_ON_MIDI_MESSAGE);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(TEST_MESSAGE);
    }


    // MIDIOutput

    [Test]
    public async Task Send() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_SEND);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WebMIDIInProcessGroup.TEST_SEND_OUTPUT);
    }

    [Test]
    public async Task Clear() {
        await ExecuteTest(WebMIDIInProcessGroup.BUTTON_CLEAR);

        string? result = await Page.GetByTestId(WebMIDIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WebMIDIInProcessGroup.TEST_CLEAR_OUTPUT);
    }
}

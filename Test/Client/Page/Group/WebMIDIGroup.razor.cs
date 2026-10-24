using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class WebMIDIGroup : ComponentBase {
    public const string TEST_EVENT_STATE_CHANGE = "MIDIAccess state changed";
    public const string TEST_EVENT_STATE_CHANGE_PORT = "MIDIPort state changed";
    public const string TEST_SEND_OUTPUT = "send: Note on middle C, full velocity";
    public const string TEST_CLEAR_OUTPUT = "queue cleared";


    [Inject]
    public required IWebMIDI WebMIDI { private get; init; }


    public const string OUTPUT = "webmidi-output";
    private string output = string.Empty;


    // WebMIDI

    public const string BUTTON_REQUEST_MIDI_ACCESS = "webmidi-request-midi-access";
    private async Task RequestMIDIAccess() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        output = (midiAccess is not null).ToString();
    }


    // MIDIAccess

    public const string BUTTON_GET_INPUTS_PROPERTY = "webmidi-get-inputs-property";
    private async Task GetInputs_Property() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();

        IMIDIInput[] inputPorts = await midiAccess.Inputs;
        output = inputPorts.Length.ToString();

        await inputPorts.DisposeAsync();
    }

    public const string BUTTON_GET_INPUTS_METHOD = "webmidi-get-inputs-method";
    private async Task GetInputs_Method() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();

        IMIDIInput[] inputPorts = await midiAccess.GetInputs(CancellationToken.None);
        output = inputPorts.Length.ToString();

        await inputPorts.DisposeAsync();
    }

    public const string BUTTON_GET_OUTPUTS_PROPERTY = "webmidi-get-outputs-property";
    private async Task GetOutputs_Property() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();

        IMIDIOutput[] outputPorts = await midiAccess.Outputs;
        output = outputPorts.Length.ToString();

        await outputPorts.DisposeAsync();
    }

    public const string BUTTON_GET_OUTPUTS_METHOD = "webmidi-get-outputs-method";
    private async Task GetOutputs_Method() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();

        IMIDIOutput[] outputPorts = await midiAccess.GetOutputs(CancellationToken.None);
        output = outputPorts.Length.ToString();

        await outputPorts.DisposeAsync();
    }

    public const string BUTTON_GET_SYSEX_ENABLED_PROPERTY = "webmidi-get-sysex-enabled-property";
    private async Task GetSysexEnabled_Property() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();

        bool sysexEnabled = await midiAccess.SysexEnabled;
        output = sysexEnabled.ToString();
    }

    public const string BUTTON_GET_SYSEX_ENABLED_METHOD = "webmidi-get-sysex-enabled-method";
    private async Task GetSysexEnabled_Method() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();

        bool sysexEnabled = await midiAccess.GetSysexEnabled(CancellationToken.None);
        output = sysexEnabled.ToString();
    }


    public const string BUTTON_REGISTER_ON_STATE_CHANGE = "webmidi-event-state-change";
    private async Task RegisterOnStateChange() {
        IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();

        midiAccess.OnStateChange += OnStateChange;
        void OnStateChange(IMIDIPort port) {
            output = TEST_EVENT_STATE_CHANGE;
            StateHasChanged();
            midiAccess.OnStateChange -= OnStateChange;
            _ = Dispose();
            async Task Dispose() {
                await Task.Delay(1000);
                await midiAccess.DisposeAsync();
                await port.DisposeAsync();
            }
        }
    }


    // MIDIPort

    public const string BUTTON_GET_ID_PROPERTY = "webmidi-get-id-property";
    private async Task GetId_Property() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.Id;

        await ports.DisposeAsync();
    }

    public const string BUTTON_GET_ID_METHOD = "webmidi-get-id-method";
    private async Task GetId_Method() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.GetId(CancellationToken.None);

        await ports.DisposeAsync();
    }


    public const string BUTTON_GET_MANUFACTURER_PROPERTY = "webmidi-get-manufacturer-property";
    private async Task GetManufacturer_Property() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.Manufacturer;

        await ports.DisposeAsync();
    }

    public const string BUTTON_GET_MANUFACTURER_METHOD = "webmidi-get-manufacturer-method";
    private async Task GetManufacturer_Method() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.GetManufacturer(CancellationToken.None);

        await ports.DisposeAsync();
    }


    public const string BUTTON_GET_NAME_PROPERTY = "webmidi-get-name-property";
    private async Task GetName_Property() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.Name;

        await ports.DisposeAsync();
    }

    public const string BUTTON_GET_NAME_METHOD = "webmidi-get-name-method";
    private async Task GetName_Method() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.GetName(CancellationToken.None);

        await ports.DisposeAsync();
    }


    public const string BUTTON_GET_TYPE_PROPERTY = "webmidi-get-type-property";
    private async Task GetType_Property() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.Type;

        await ports.DisposeAsync();
    }

    public const string BUTTON_GET_TYPE_METHOD = "webmidi-get-type-method";
    private async Task GetType_Method() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.GetType(CancellationToken.None);

        await ports.DisposeAsync();
    }


    public const string BUTTON_GET_VERSION_PROPERTY = "webmidi-get-version-property";
    private async Task GetVersion_Property() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.Version;

        await ports.DisposeAsync();
    }

    public const string BUTTON_GET_VERSION_METHOD = "webmidi-get-version-method";
    private async Task GetVersion_Method() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.GetVersion(CancellationToken.None);

        await ports.DisposeAsync();
    }


    public const string BUTTON_GET_STATE_PROPERTY = "webmidi-get-state-property";
    private async Task GetState_Property() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.State;

        await ports.DisposeAsync();
    }

    public const string BUTTON_GET_STATE_METHOD = "webmidi-get-state-method";
    private async Task GetState_Method() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.GetState(CancellationToken.None);

        await ports.DisposeAsync();
    }


    public const string BUTTON_GET_CONNECTION_PROPERTY = "webmidi-get-connection-property";
    private async Task GetConnection_Property() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.Connection;

        await ports.DisposeAsync();
    }

    public const string BUTTON_GET_CONNECTION_METHOD = "webmidi-get-connection-method";
    private async Task GetConnection_Method() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        output = await port.GetConnection(CancellationToken.None);

        await ports.DisposeAsync();
    }


    public const string BUTTON_OPEN = "webmidi-open";
    private async Task Open() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        await port.Open();
        output = await port.Connection;

        await ports.DisposeAsync();
    }

    public const string BUTTON_CLOSE = "webmidi-close";
    private async Task Close() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        await port.Open();
        string openedState = await port.Connection;
        await port.Close();
        output = $"{openedState} -> {await port.Connection}";

        await ports.DisposeAsync();
    }


    public const string BUTTON_REGISTER_ON_STATE_CHANGE_PORT = "webmidi-event-state-change-port";
    private async Task RegisterOnStateChangePort() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPort[] ports = [.. (await midiAccess.Inputs).Concat<IMIDIPort>(await midiAccess.Outputs)];
        IMIDIPort port = ports[0];

        port.OnStateChange += OnStateChange;
        void OnStateChange() {
            output = TEST_EVENT_STATE_CHANGE_PORT;
            StateHasChanged();
            port.OnStateChange -= OnStateChange;
            _ = port.DisposeAsync().Preserve();
        }

        await ports[1..].DisposeAsync();
    }


    // MIDIInput

    public const string BUTTON_REGISTER_ON_MIDI_MESSAGE = "webmidi-event-midi-message";
    private async Task RegisterOnMIDIMessage() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIInput[] inputPorts = await midiAccess.Inputs;
        IMIDIInput inputPort = inputPorts[0];

        inputPort.OnMIDIMessage += OnMIDIMessage;
        void OnMIDIMessage(byte[]? data) {
            output = $"[{string.Join(',', data ?? [])}]";
            StateHasChanged();
            inputPort.OnMIDIMessage -= OnMIDIMessage;
            _ = inputPort.DisposeAsync().Preserve();
        }

        await inputPorts[1..].DisposeAsync();
    }


    // MIDIOutput

    public const string BUTTON_SEND = "webmidi-send";
    private async Task Send() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIOutput[] outputPorts = await midiAccess.Outputs;
        IMIDIOutput outputPort = outputPorts[0];

        await outputPort.Send([0x90, 60, 0x7f]); // Note on middle C, full velocity
        output = TEST_SEND_OUTPUT;

        await outputPorts.DisposeAsync();
    }

    public const string BUTTON_CLEAR = "webmidi-clear";
    private async Task Clear() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIOutput[] outputPorts = await midiAccess.Outputs;
        IMIDIOutput outputPort = outputPorts[0];

        await outputPort.Clear();
        output = TEST_CLEAR_OUTPUT;

        await outputPorts.DisposeAsync();
    }
}

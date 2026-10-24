using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class WebMIDIInProcessGroup : ComponentBase {
    public const string TEST_EVENT_STATE_CHANGE = "MIDIAccess state changed";
    public const string TEST_EVENT_STATE_CHANGE_PORT = "MIDIPort state changed";
    public const string TEST_SEND_OUTPUT = "send: Note on middle C, full velocity";
    public const string TEST_CLEAR_OUTPUT = "queue cleared";


    [Inject]
    public required IWebMIDIInProcess WebMIDI { private get; init; }


    public const string OUTPUT = "webmidi-inprocess-output";
    private string output = string.Empty;





    // WebMIDI

    public const string BUTTON_REQUEST_MIDI_ACCESS = "webmidi-inprocess-request-midi-access";
    private async Task RequestMIDIAccess() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        output = (midiAccess is not null).ToString();
    }


    // MIDIAccess

    public const string BUTTON_GET_INPUTS = "webmidi-inprocess-get-inputs";
    private async Task GetInputs() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();

        IMIDIInputInProcess[] inputPorts = midiAccess.Inputs;
        output = inputPorts.Length.ToString();

        inputPorts.Dispose();
    }

    public const string BUTTON_GET_OUTPUTS = "webmidi-inprocess-get-outputs";
    private async Task GetOutputs() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();

        IMIDIOutputInProcess[] outputPorts = midiAccess.Outputs;
        output = outputPorts.Length.ToString();

        outputPorts.Dispose();
    }

    public const string BUTTON_GET_SYSEX_ENABLED = "webmidi-inprocess-get-sysex-enabled";
    private async Task GetSysexEnabled() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();

        bool sysexEnabled = midiAccess.SysexEnabled;
        output = sysexEnabled.ToString();
    }


    public const string BUTTON_REGISTER_ON_STATE_CHANGE = "webmidi-inprocess-event-state-change";
    private async Task RegisterOnStateChange() {
        IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();

        midiAccess.OnStateChange += OnStateChange;
        void OnStateChange(IMIDIPortInProcess port) {
            output = TEST_EVENT_STATE_CHANGE;
            StateHasChanged();
            midiAccess.OnStateChange -= OnStateChange;
            _ = Dispose();
            async Task Dispose() {
                await Task.Delay(1000);
                midiAccess.Dispose();
                port.Dispose();
            }
        }
    }


    // MIDIPort

    public const string BUTTON_GET_ID = "webmidi-inprocess-get-id";
    private async Task GetId() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPortInProcess[] ports = [.. (midiAccess.Inputs).Concat<IMIDIPortInProcess>(midiAccess.Outputs)];
        IMIDIPortInProcess port = ports[0];

        output = port.Id;

        ports.Dispose();
    }

    public const string BUTTON_GET_MANUFACTURER = "webmidi-inprocess-get-manufacturer";
    private async Task GetManufacturer() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPortInProcess[] ports = [.. (midiAccess.Inputs).Concat<IMIDIPortInProcess>(midiAccess.Outputs)];
        IMIDIPortInProcess port = ports[0];

        output = port.Manufacturer;

        ports.Dispose();
    }

    public const string BUTTON_GET_NAME = "webmidi-inprocess-get-name";
    private async Task GetName() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPortInProcess[] ports = [.. (midiAccess.Inputs).Concat<IMIDIPortInProcess>(midiAccess.Outputs)];
        IMIDIPortInProcess port = ports[0];

        output = port.Name;

        ports.Dispose();
    }

    public const string BUTTON_GET_TYPE = "webmidi-inprocess-get-type";
    private new async Task GetType() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPortInProcess[] ports = [.. (midiAccess.Inputs).Concat<IMIDIPortInProcess>(midiAccess.Outputs)];
        IMIDIPortInProcess port = ports[0];

        output = port.Type;

        ports.Dispose();
    }

    public const string BUTTON_GET_VERSION = "webmidi-inprocess-get-version";
    private async Task GetVersion() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPortInProcess[] ports = [.. (midiAccess.Inputs).Concat<IMIDIPortInProcess>(midiAccess.Outputs)];
        IMIDIPortInProcess port = ports[0];

        output = port.Version;

        ports.Dispose();
    }

    public const string BUTTON_GET_STATE = "webmidi-inprocess-get-state";
    private async Task GetState() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPortInProcess[] ports = [.. (midiAccess.Inputs).Concat<IMIDIPortInProcess>(midiAccess.Outputs)];
        IMIDIPortInProcess port = ports[0];

        output = port.State;

        ports.Dispose();
    }

    public const string BUTTON_GET_CONNECTION = "webmidi-inprocess-get-connection";
    private async Task GetConnection() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPortInProcess[] ports = [.. (midiAccess.Inputs).Concat<IMIDIPortInProcess>(midiAccess.Outputs)];
        IMIDIPortInProcess port = ports[0];

        output = port.Connection;

        ports.Dispose();
    }


    public const string BUTTON_OPEN = "webmidi-inprocess-open";
    private async Task Open() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPortInProcess[] ports = [.. (midiAccess.Inputs).Concat<IMIDIPortInProcess>(midiAccess.Outputs)];
        IMIDIPortInProcess port = ports[0];

        await port.Open();
        output = port.Connection;

        ports.Dispose();
    }

    public const string BUTTON_CLOSE = "webmidi-inprocess-close";
    private async Task Close() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPortInProcess[] ports = [.. (midiAccess.Inputs).Concat<IMIDIPortInProcess>(midiAccess.Outputs)];
        IMIDIPortInProcess port = ports[0];

        await port.Open();
        string openedState = port.Connection;
        await port.Close();
        output = $"{openedState} -> {port.Connection}";

        ports.Dispose();
    }


    public const string BUTTON_REGISTER_ON_STATE_CHANGE_PORT = "webmidi-inprocess-event-state-change-port";
    private async Task RegisterOnStateChangePort() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIPortInProcess[] ports = [.. (midiAccess.Inputs).Concat<IMIDIPortInProcess>(midiAccess.Outputs)];
        IMIDIPortInProcess port = ports[0];

        port.OnStateChange += OnStateChange;
        void OnStateChange() {
            output = TEST_EVENT_STATE_CHANGE_PORT;
            StateHasChanged();
            port.OnStateChange -= OnStateChange;
            port.Dispose();
        }

        ports[1..].Dispose();
    }


    // MIDIInput

    public const string BUTTON_REGISTER_ON_MIDI_MESSAGE = "webmidi-inprocess-event-midi-message";
    private async Task RegisterOnMIDIMessage() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIInputInProcess[] inputPorts = midiAccess.Inputs;
        IMIDIInputInProcess inputPort = inputPorts[0];

        inputPort.OnMIDIMessage += OnMIDIMessage;
        void OnMIDIMessage(byte[]? data) {
            output = $"[{string.Join(',', data ?? [])}]";
            StateHasChanged();
            inputPort.OnMIDIMessage -= OnMIDIMessage;
            inputPort.Dispose();
        }

        inputPorts[1..].Dispose();
    }


    // MIDIOutput

    public const string BUTTON_SEND = "webmidi-inprocess-send";
    private async Task Send() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIOutputInProcess[] outputPorts = midiAccess.Outputs;
        IMIDIOutputInProcess outputPort = outputPorts[0];

        outputPort.Send([0x90, 60, 0x7f]); // Note on middle C, full velocity
        output = TEST_SEND_OUTPUT;

        outputPorts.Dispose();
    }

    public const string BUTTON_CLEAR = "webmidi-inprocess-clear";
    private async Task Clear() {
        using IMIDIAccessInProcess midiAccess = await WebMIDI.RequestMIDIAccess();
        IMIDIOutputInProcess[] outputPorts = midiAccess.Outputs;
        IMIDIOutputInProcess outputPort = outputPorts[0];

        outputPort.Clear();
        output = TEST_CLEAR_OUTPUT;

        outputPorts.Dispose();
    }
}

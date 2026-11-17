using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class WebMIDI : ComponentBase, IAsyncDisposable {
    private closed class Port<TPort>(TPort port) : IAsyncDisposable where TPort : IMIDIPort {
        protected readonly TPort port = port;

        public string Type { get; private set; } = null!;
        public string Name { get; private set; } = null!;
        public string Id { get; private set; } = null!;
        public string Manufacturer { get; private set; } = null!;
        public string Version { get; private set; } = null!;
        public string State { get; private set; } = null!;
        public string Connection { get; private set; } = null!;

        public bool IsConnected => Connection == "open";

        public ValueTask DisposeAsync() => port.DisposeAsync();


        public async Task Open() {
            await port.Open();
            await RefreshData();
        }

        public virtual async Task Close() {
            await port.Close();
            await RefreshData();
        }


        protected async ValueTask RefreshData() {
            Type = await port.Type;
            Name = await port.Name;
            Id = await port.Id;
            Manufacturer = await port.Manufacturer;
            Version = await port.Version;
            State = await port.State;
            Connection = await port.Connection;
        }
    }

    private sealed class InputPort : Port<IMIDIInput> {
        private InputPort(IMIDIInput port, Action onMIDIMessageCallback) : base(port) {
            this.onMIDIMessageCallback = onMIDIMessageCallback;
        }

        public static async ValueTask<InputPort> CreatePort(IMIDIInput port, Action onMIDIMessageCallback) {
            InputPort result = new(port, onMIDIMessageCallback);
            await result.RefreshData();
            return result;
        }


        public bool IsListening { get; private set; } = false;
        public string Message { get; private set; } = string.Empty;
        private Action? onMIDIMessageCallback;

        public void ListenOnMIDIMessage() {
            IsListening = true;
            port.OnMIDIMessage += OnMIDIMessage;
        }

        public void RemoveOnMIDIMessage() {
            IsListening = false;
            port.OnMIDIMessage -= OnMIDIMessage;
        }

        private void OnMIDIMessage(byte[]? data) {
            Message = string.Join(", ", data ?? []);
            onMIDIMessageCallback!();
        }

        public override async Task Close() {
            Message = string.Empty;
            if (IsListening)
                RemoveOnMIDIMessage();
            await base.Close();
        }
    }

    private sealed class OutputPort : Port<IMIDIOutput> {
        private OutputPort(IMIDIOutput port) : base(port) { }

        public static async ValueTask<OutputPort> CreatePort(IMIDIOutput port) {
            OutputPort result = new(port);
            await result.RefreshData();
            return result;
        }


        public string Output { get; private set; } = string.Empty;

        public async Task Send() {
            await port.Send([0x90, 60, 0x7f]); // Note on middle C, full velocity
            Output = "Note on middle C";
        }

        public override async Task Close() {
            Output = string.Empty;
            await base.Close();
        }
    }


    [Inject]
    public required IWebMIDI PWebMIDI { private get; init; }

    private bool? foundPorts = false;
    private readonly List<InputPort> inputPorts = [];
    private readonly List<OutputPort> outputPorts = [];

    public ValueTask DisposeAsync() => inputPorts.Concat<IAsyncDisposable>(outputPorts).DisposeAsync();

    private async Task FindPorts() {
        foundPorts = null;
        await DisposeAsync();
        inputPorts.Clear();
        outputPorts.Clear();

        await using IMIDIAccess midiAccess = await PWebMIDI.RequestMIDIAccess();

        IMIDIInput[] midiInputs = await midiAccess.Inputs;
        foreach (IMIDIInput midiInput in midiInputs)
            inputPorts.Add(await InputPort.CreatePort(midiInput, () => _ = InvokeAsync(StateHasChanged)));

        IMIDIOutput[] midiOutputs = await midiAccess.Outputs;
        foreach (IMIDIOutput midiOutput in midiOutputs)
            outputPorts.Add(await OutputPort.CreatePort(midiOutput));

        foundPorts = midiInputs.Length + midiOutputs.Length > 0;
    }
}

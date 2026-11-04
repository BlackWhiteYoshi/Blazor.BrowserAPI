using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class DevicePosture : ComponentBase, IDisposable {
    [Inject]
    public required IDevicePosture PDevicePosture { private get; init; }

    public void Dispose() {
        if (isListeningOnChange)
            PDevicePosture.OnChange -= OnChange;
    }


    private bool? isContinuous;

    private async Task ReadDevicePosture() => isContinuous = await PDevicePosture.Type is "continuous";


    // OnChange

    private bool isListeningOnChange = false;

    private void ListenOnChange() {
        isListeningOnChange = true;
        PDevicePosture.OnChange += OnChange;
    }

    private void RemoveOnChange() {
        isListeningOnChange = false;
        PDevicePosture.OnChange -= OnChange;
    }

    private void OnChange() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            await ReadDevicePosture();
            await InvokeAsync(StateHasChanged);
        }
    }
}

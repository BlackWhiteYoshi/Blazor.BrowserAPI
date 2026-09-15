using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class DevicePostureInProcessGroup : ComponentBase {
    [Inject]
    public required IDevicePostureInProcess DevicePosture { private get; init; }


    public const string OUTPUT = "deviceposture-inprocess-output";
    private string output = string.Empty;


    public const string BUTTON_GET_TYPE = "deviceposture-inprocess-get-type";
    private new void GetType() {
        output = DevicePosture.Type;
    }


    public const string BUTTON_REGISTER_ON_CHANGE = "deviceposture-inprocess-change-event";
    private void RegisterOnChange() {
        DevicePosture.OnChange += () => {
            output = DevicePosture.Type;
            StateHasChanged();
        };
    }
}

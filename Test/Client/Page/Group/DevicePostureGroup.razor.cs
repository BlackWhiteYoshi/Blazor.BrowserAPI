using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class DevicePostureGroup : ComponentBase {
    [Inject]
    public required IDevicePosture DevicePosture{ private get; init; }


    public const string OUTPUT = "deviceposture-output";
    private string output = string.Empty;


    public const string BUTTON_GET_TYPE_PROPERTY = "deviceposture-get-type-property";
    private async Task GetType_Property() {
        output = await DevicePosture.Type;
    }

    public const string BUTTON_GET_TYPE_METHOD = "deviceposture-get-type-method";
    private async Task GetType_Method() {
        output = await DevicePosture.GetType(CancellationToken.None);
    }


    public const string BUTTON_REGISTER_ON_CHANGE = "deviceposture-change-event";
    private void RegisterOnChange() {
        DevicePosture.OnChange += () => {
            DoAsync().Preserve();
            async ValueTask DoAsync() {
                output = await DevicePosture.Type;
                StateHasChanged();
            }
        };
    }
}

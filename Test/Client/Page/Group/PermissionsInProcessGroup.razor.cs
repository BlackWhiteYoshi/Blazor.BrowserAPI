using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class PermissionsInProcessGroup : ComponentBase {
    public const string TEST_PERMISSION_NAME = "geolocation";
    public const string TEST_ON_CHANGE_EVENT = "permission state has changed";


    [Inject]
    public required IPermissionsInProcess Permissions { private get; init; }


    public const string LABEL_OUTPUT = "permissions-inprocess-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_QUERY = "permissions-inprocess-query";
    private async Task Query() {
        using IPermissionStatusInProcess permissionStatus = await Permissions.Query(TEST_PERMISSION_NAME);
        labelOutput = (permissionStatus is not null).ToString();
    }


    public const string BUTTON_GET_NAME = "permissions-inprocess-get-name";
    private async Task GetName() {
        using IPermissionStatusInProcess permissionStatus = await Permissions.Query(TEST_PERMISSION_NAME);
        string name = permissionStatus.Name;
        labelOutput = name;
    }

    public const string BUTTON_GET_STATE = "permissions-inprocess-get-state";
    private async Task GetState() {
        using IPermissionStatusInProcess permissionStatus = await Permissions.Query(TEST_PERMISSION_NAME);
        string state = permissionStatus.State;
        labelOutput = state;
    }


    public const string BUTTON_REGISTER_ON_CHANGE = "permissions-inprocess-change-event";
    private async Task RegisterOnChange() {
        IPermissionStatusInProcess permissionStatus = await Permissions.Query(TEST_PERMISSION_NAME);
        permissionStatus.OnChange += OnChange;

        void OnChange() {
            labelOutput = TEST_ON_CHANGE_EVENT;
            StateHasChanged();
            permissionStatus.OnChange -= OnChange;
            permissionStatus.Dispose();
        }
    }
}

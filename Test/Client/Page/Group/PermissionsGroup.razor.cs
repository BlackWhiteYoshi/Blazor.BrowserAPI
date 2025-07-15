using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class PermissionsGroup : ComponentBase {
    public const string TEST_PERMISSION_NAME = "geolocation";
    public const string TEST_ON_CHANGE_EVENT = "permission state has changed";


    [Inject]
    public required IPermissions Permissions { private get; init; }


    public const string LABEL_OUTPUT = "permissions-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_QUERY = "permissions-query";
    private async Task Query() {
        await using IPermissionStatus permissionStatus = await Permissions.Query(TEST_PERMISSION_NAME);
        labelOutput = (permissionStatus is not null).ToString();
    }


    public const string BUTTON_GET_NAME_PROPERTY = "permissions-get-name-property";
    private async Task GetName_Property() {
        await using IPermissionStatus permissionStatus = await Permissions.Query(TEST_PERMISSION_NAME);
        string name = await permissionStatus.Name;
        labelOutput = name;
    }

    public const string BUTTON_GET_NAME_METHOD = "permissions-get-name-method";
    private async Task GetName_Method() {
        await using IPermissionStatus permissionStatus = await Permissions.Query(TEST_PERMISSION_NAME);
        string name = await permissionStatus.GetName(default);
        labelOutput = name;
    }

    public const string BUTTON_GET_STATE_PROPERTY = "permissions-get-state-property";
    private async Task GetState_Property() {
        await using IPermissionStatus permissionStatus = await Permissions.Query(TEST_PERMISSION_NAME);
        string state = await permissionStatus.State;
        labelOutput = state;
    }

    public const string BUTTON_GET_STATE_METHOD = "permissions-get-state-method";
    private async Task GetState_Method() {
        await using IPermissionStatus permissionStatus = await Permissions.Query(TEST_PERMISSION_NAME);
        string state = await permissionStatus.GetState(default);
        labelOutput = state;
    }


    public const string BUTTON_REGISTER_ON_CHANGE = "permissions-change-event";
    private async Task RegisterOnChange() {
        IPermissionStatus permissionStatus = await Permissions.Query(TEST_PERMISSION_NAME);
        permissionStatus.OnChange += OnChange;

        void OnChange() {
            labelOutput = TEST_ON_CHANGE_EVENT;
            StateHasChanged();
            permissionStatus.OnChange -= OnChange;
            _ = permissionStatus.DisposeAsync().Preserve();
        }
    }
}

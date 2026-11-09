using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class WindowManagement : ComponentBase, IAsyncDisposable {
    [Inject]
    public required IWindowManagement PWindowManagement { private get; init; }

    private Task<IScreenDetailed>? _screenDetailedTask;
    private Task<IScreenDetailed> ScreenDetailedTask => _screenDetailedTask ??= GetScreenDetailed();
    private async Task<IScreenDetailed> GetScreenDetailed() {
        await using IScreenDetails screenDetails = await PWindowManagement.GetScreenDetails();
        return await screenDetails.CurrentScreen;
    }

    public async ValueTask DisposeAsync() {
        try {
            if (_screenDetailedTask is not null) {
                IScreenDetailed screenDetailed = await _screenDetailedTask;
                await screenDetailed.DisposeAsync();
            }

            if (isLocked)
                await PWindowManagement.Screen.UnlockOrientation();
        }
        catch (JSDisconnectedException) { }
    }


    private int? width = null;
    private async Task GetWidth() => width = await PWindowManagement.Screen.AvailWidth;

    private int? height = null;
    private async Task GetHeight() => height = await PWindowManagement.Screen.AvailHeight;

    private int? colorDepth = null;
    private async Task GetColorDepth() => colorDepth = await PWindowManagement.Screen.ColorDepth;

    private int? pixelDepth = null;
    private async Task GetPixelDepth() => pixelDepth = await PWindowManagement.Screen.PixelDepth;

    private string? orientation = null;
    private async Task GetOrientation() => orientation = await PWindowManagement.Screen.OrientationType;

    private double? orientationAngle = null;
    private async Task GetOrientationAngle() => orientationAngle = await PWindowManagement.Screen.OrientationAngle;

    private bool? hasMultipleScreens = null;
    private async Task GetHasMultipleScreens() => hasMultipleScreens = await PWindowManagement.Screen.IsExtended;


    private int? left = null;
    private async Task GetLeft() => left = await (await ScreenDetailedTask).AvailLeft;

    private int? top = null;
    private async Task GetTop() => top = await (await ScreenDetailedTask).AvailTop;

    private string? label = null;
    private async Task GetLabel() => label = await (await ScreenDetailedTask).Label;

    private double? devicePixelRatio = null;
    private async Task GetDevicePixelRatio() => devicePixelRatio = await (await ScreenDetailedTask).DevicePixelRatio;

    private bool? isPrimary = null;
    private async Task GetIsPrimary() => isPrimary = await (await ScreenDetailedTask).IsPrimary;

    private bool? isInternal = null;
    private async Task GetIsInternal() => isInternal = await (await ScreenDetailedTask).IsInternal;


    private bool isLocked;

    private async Task LockOrientation() {
        isLocked = true;
        await PWindowManagement.Screen.LockOrientation("any");
    }

    private async Task UnlockOrientation() {
        isLocked = false;
        await PWindowManagement.Screen.UnlockOrientation();
    }
}

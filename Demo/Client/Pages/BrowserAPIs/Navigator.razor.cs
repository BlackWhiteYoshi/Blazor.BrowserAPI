using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class Navigator : ComponentBase {
    [Inject]
    public required INavigator PNavigator { private get; init; }


    private string[] languages = [];
    private async Task GetLanguages() => languages = await PNavigator.Languages;

    private string userAgent = string.Empty;
    private async Task GetUserAgent() => userAgent = await PNavigator.UserAgent;


    private int? maxTouchPoints = null;
    private async Task GetMaxTouchPoints() => maxTouchPoints = await PNavigator.MaxTouchPoints;

    private int? hardwareConcurrency = null;
    private async Task GetHardwareConcurrency() => hardwareConcurrency = await PNavigator.HardwareConcurrency;

    private double? deviceMemory = null;
    private async Task GetDeviceMemory() => deviceMemory = await PNavigator.DeviceMemory;


    private bool? isWebdriver = null;
    private async Task GetWebdriver() => isWebdriver = await PNavigator.Webdriver;

    private bool? isCookieEnabled = null;
    private async Task GetCookieEnabled() => isCookieEnabled = await PNavigator.CookieEnabled;

    private bool? isPdfViewerEnabled = null;
    private async Task GetPdfViewerEnabled() => isPdfViewerEnabled = await PNavigator.PdfViewerEnabled;


    private bool? isVibrating = null;
    private async Task Vibrate() {
        isVibrating = await PNavigator.Vibrate([1000]);
        if (isVibrating == true) {
            StateHasChanged();
            await Task.Delay(1000);
            isVibrating = null;
        }
    }
}

using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class AppNavBar : ComponentBase {
    public static string[] BrowserAPIList { get; } = [
        "BatteryStatus",
        "Clipboard",
        "Console",
        "CookieStorage",
        "DevicePosture",
        "Document",
        "Download",
        "FileSystem",
        "GamepadAPI",
        "Geolocation",
        "History",
        "HTMLDialogElement",
        "HTMLElement",
        "HTMLMediaElement",
        "LocalStorage",
        "MediaDevices",
        "Navigator",
        "NetworkInformation",
        "NotificationsAPI",
        "Permissions",
        "SensorAPI",
        "ServiceWorker",
        "SessionStorage",
        "WebMIDI",
        "Window",
        "WindowManagement"
    ];
}

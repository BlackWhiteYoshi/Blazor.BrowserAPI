using BrowserAPI.Implementation;
using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class GeolocationGroup : ComponentBase {
    [Inject]
    public required IGeolocation Geolocation { private get; init; }

    [Inject]
    public required IGeolocationInProcess GeolocationInProcess { private get; init; }


    public const string LABEL_OUTPUT = "geolocation-output";
    private string labelOutput = string.Empty;


    private readonly List<int> watchRegistrations = [];

    public const string BUTTON_GET_CURRENT_POSITION = "geolocation-get-current-position";
    private async Task GetCurrentPosition() {
        await Geolocation.GetCurrentPosition((GeolocationCoordinates geolocationCoordinates, long timestamp) => {
            labelOutput = $"{geolocationCoordinates}, {timestamp}";
            StateHasChanged();
        });
    }

    public const string BUTTON_WATCH_POSITION = "geolocation-watch-position";
    private async Task WatchPosition() {
        int watchId = await Geolocation.WatchPosition((GeolocationCoordinates geolocationCoordinates, long timestamp) => {
            labelOutput = $"{geolocationCoordinates}, {timestamp}";
            StateHasChanged();
        });
        watchRegistrations.Add(watchId);
        labelOutput = $"{watchId}, {watchRegistrations.Count}";
    }

    public const string BUTTON_CLEAR_WATCH = "geolocation-clear-watch";
    private async Task ClearWatch() {
        int watchId = watchRegistrations[^1];
        await Geolocation.ClearWatch(watchId);
        watchRegistrations.RemoveAt(watchRegistrations.Count - 1);
        labelOutput = $"{watchId}, {watchRegistrations.Count}";
    }


    private readonly List<int> watchRegistrations_InProcess = [];

    public const string BUTTON_GET_CURRENT_POSITION_INPROCESS = "geolocation-get-current-position-inprocess";
    private void GetCurrentPosition_InProcess() {
        GeolocationInProcess.GetCurrentPosition((GeolocationCoordinates geolocationCoordinates, long timestamp) => {
            labelOutput = $"{geolocationCoordinates}, {timestamp}";
            StateHasChanged();
        });
    }

    public const string BUTTON_WATCH_POSITION_INPROCESS = "geolocation-watch-position-inprocess";
    private void WatchPosition_InProcess() {
        int watchId = GeolocationInProcess.WatchPosition((GeolocationCoordinates geolocationCoordinates, long timestamp) => {
            labelOutput = $"{geolocationCoordinates}, {timestamp}";
            StateHasChanged();
        });
        watchRegistrations_InProcess.Add(watchId);
        labelOutput = $"{watchId}, {watchRegistrations_InProcess.Count}";
    }

    public const string BUTTON_CLEAR_WATCH_INPROCESS = "geolocation-clear-watch-inprocess";
    private void ClearWatch_InProcess() {
        int watchId = watchRegistrations_InProcess[^1];
        GeolocationInProcess.ClearWatch(watchId);
        watchRegistrations_InProcess.RemoveAt(watchRegistrations_InProcess.Count - 1);
        labelOutput = $"{watchId}, {watchRegistrations_InProcess.Count}";
    }
}

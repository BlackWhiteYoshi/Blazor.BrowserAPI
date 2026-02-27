using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class GeolocationInProcessGroup : ComponentBase {
    [Inject]
    public required IGeolocationInProcess Geolocation { private get; init; }


    public const string OUTPUT = "geolocation-inprocess-output";
    private string output = string.Empty;


    private readonly List<GeolocationWatchHandle> watchRegistrations = [];

    public const string BUTTON_GET_CURRENT_POSITION = "geolocation-inprocess-get-current-position";
    private void GetCurrentPosition() {
        Geolocation.GetCurrentPosition((GeolocationCoordinates geolocationCoordinates) => {
            output = geolocationCoordinates.ToString();
            StateHasChanged();
        });
    }

    public const string BUTTON_GET_CURRENT_POSITION_ASYNC = "geolocation-inprocess-get-current-position-async";
    private async Task GetCurrentPositionAsync() {
        GeolocationCoordinates geolocationCoordinates = await Geolocation.GetCurrentPositionAsync();
        output = geolocationCoordinates.ToString();
    }

    public const string BUTTON_WATCH_POSITION = "geolocation-inprocess-watch-position";
    private void WatchPosition() {
        GeolocationWatchHandle watchId = Geolocation.WatchPosition((GeolocationCoordinates geolocationCoordinates) => {
            output = geolocationCoordinates.ToString();
            StateHasChanged();
        });
        watchRegistrations.Add(watchId);
        output = $"{watchId.Id}, {watchRegistrations.Count}";
    }

    public const string BUTTON_CLEAR_WATCH = "geolocation-inprocess-clear-watch";
    private void ClearWatch() {
        GeolocationWatchHandle watchId = watchRegistrations[^1];
        Geolocation.ClearWatch(watchId);
        watchRegistrations.RemoveAt(watchRegistrations.Count - 1);
        output = $"watchId: {watchId.Id}, count: {watchRegistrations.Count}";
    }
}

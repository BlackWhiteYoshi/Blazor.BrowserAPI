using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class GeolocationGroup : ComponentBase {
    [Inject]
    public required IGeolocation Geolocation { private get; init; }


    public const string LABEL_OUTPUT = "geolocation-output";
    private string labelOutput = string.Empty;


    private readonly List<GeolocationWatchHandle> watchRegistrations = [];

    public const string BUTTON_GET_CURRENT_POSITION = "geolocation-get-current-position";
    private async Task GetCurrentPosition() {
        await Geolocation.GetCurrentPosition((GeolocationCoordinates geolocationCoordinates) => {
            labelOutput = geolocationCoordinates.ToString();
            StateHasChanged();
        });
    }

    public const string BUTTON_GET_CURRENT_POSITION_ASYNC = "geolocation-get-current-position-async";
    private async Task GetCurrentPositionAsync() {
        GeolocationCoordinates geolocationCoordinates = await Geolocation.GetCurrentPositionAsync();
        labelOutput = geolocationCoordinates.ToString();
    }

    public const string BUTTON_WATCH_POSITION = "geolocation-watch-position";
    private async Task WatchPosition() {
        GeolocationWatchHandle watchHandle = await Geolocation.WatchPosition((GeolocationCoordinates geolocationCoordinates) => {
            labelOutput = geolocationCoordinates.ToString();
            StateHasChanged();
        });
        watchRegistrations.Add(watchHandle);
        labelOutput = $"{watchHandle.Id}, {watchRegistrations.Count}";
    }

    public const string BUTTON_CLEAR_WATCH = "geolocation-clear-watch";
    private async Task ClearWatch() {
        GeolocationWatchHandle watchId = watchRegistrations[^1];
        await Geolocation.ClearWatch(watchId);
        watchRegistrations.RemoveAt(watchRegistrations.Count - 1);
        labelOutput = $"watchId: {watchId.Id}, count: {watchRegistrations.Count}";
    }
}

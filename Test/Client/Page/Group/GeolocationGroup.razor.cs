using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class GeolocationGroup : ComponentBase {
    [Inject]
    public required IGeolocation Geolocation { private get; init; }


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
        labelOutput = $"watchId: {watchId}, count: {watchRegistrations.Count}";
    }
}

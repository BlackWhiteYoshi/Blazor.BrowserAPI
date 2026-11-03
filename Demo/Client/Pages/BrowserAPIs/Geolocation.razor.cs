using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class Geolocation : ComponentBase, IAsyncDisposable {
    [Inject]
    public required IGeolocation PGeolocation { private get; init; }

    private GeolocationCoordinates coordinates = default;
    private bool HasCoordinates => coordinates.Timestamp is not 0;

    private GeolocationWatchHandle watchHandle;
    private bool isWatching = false;

    public async ValueTask DisposeAsync() {
        if (isWatching)
            try {
                await PGeolocation.ClearWatch(watchHandle);
            }
            catch (JSDisconnectedException) { }
    }


    private async Task GetCurrentPosition() => coordinates = await PGeolocation.GetCurrentPositionAsync();


    private async Task WatchPosition() {
        isWatching = true;
        watchHandle = await PGeolocation.WatchPosition((GeolocationCoordinates coordinates) => this.coordinates = coordinates);
    }

    private async Task ClearPosition() {
        isWatching = false;
        await PGeolocation.ClearWatch(watchHandle);
    }
}

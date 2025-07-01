using BrowserAPI.Test.Client;
using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class GeolocationInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await Context.GrantPermissionsAsync(["geolocation"]);
    }


    [Test]
    public async Task GetCurrentPosition() {
        const float LONGITUDE = 10.0f;
        const float LATITUDE = 12.0f;
        const float ACCURACY = 2.0f;
        await Context.SetGeolocationAsync(new Geolocation() {
            Longitude = LONGITUDE,
            Latitude = LATITUDE,
            Accuracy = ACCURACY,
        });

        await Page.GetByTestId(GeolocationInProcessGroup.BUTTON_GET_CURRENT_POSITION).ClickAsync();

        string? result = await Page.GetByTestId(GeolocationInProcessGroup.LABEL_OUTPUT).TextContentAsync();

        string expectedStart = $"GeolocationCoordinates {{ Latitude = {LATITUDE}, Longitude = {LONGITUDE}, Altitude = , Accuracy = {ACCURACY}, AltitudeAccuracy = , Heading = , Speed = , Timestamp = ";
        await Assert.That(result).StartsWith(expectedStart);
        string expectedEnd = " }";
        await Assert.That(result).EndsWith(expectedEnd);
        await Assert.That(long.TryParse(result?[expectedStart.Length..^expectedEnd.Length], out _)).IsTrue();
    }

    [Test]
    public async Task GetCurrentPositionAsync() {
        const float LONGITUDE = 10.0f;
        const float LATITUDE = 12.0f;
        const float ACCURACY = 2.0f;
        await Context.SetGeolocationAsync(new Geolocation() {
            Longitude = LONGITUDE,
            Latitude = LATITUDE,
            Accuracy = ACCURACY,
        });

        await Page.GetByTestId(GeolocationInProcessGroup.BUTTON_GET_CURRENT_POSITION_ASYNC).ClickAsync();

        string? result = await Page.GetByTestId(GeolocationInProcessGroup.LABEL_OUTPUT).TextContentAsync();

        string expectedStart = $"GeolocationCoordinates {{ Latitude = {LATITUDE}, Longitude = {LONGITUDE}, Altitude = , Accuracy = {ACCURACY}, AltitudeAccuracy = , Heading = , Speed = , Timestamp = ";
        await Assert.That(result).StartsWith(expectedStart);
        string expectedEnd = " }";
        await Assert.That(result).EndsWith(expectedEnd);
        await Assert.That(long.TryParse(result?[expectedStart.Length..^expectedEnd.Length], out _)).IsTrue();
    }

    [Test]
    public async Task WatchPosition() {
        const float LONGITUDE = 10.0f;
        const float LATITUDE = 12.0f;
        const float ACCURACY = 1.0f;

        await Page.GetByTestId(GeolocationInProcessGroup.BUTTON_WATCH_POSITION).ClickAsync();

        for (int i = 0; i < 5; i++) {
            await Context.SetGeolocationAsync(new Geolocation() {
                Longitude = LONGITUDE * i,
                Latitude = LATITUDE * i,
                Accuracy = ACCURACY * i,
            });
            await Task.Delay(100);
            string? result = await Page.GetByTestId(GeolocationInProcessGroup.LABEL_OUTPUT).TextContentAsync();

            string expectedStart = $"GeolocationCoordinates {{ Latitude = {LATITUDE * i}, Longitude = {LONGITUDE * i}, Altitude = , Accuracy = {ACCURACY * i}, AltitudeAccuracy = , Heading = , Speed = , Timestamp = ";
            await Assert.That(result).StartsWith(expectedStart);
            string expectedEnd = " }";
            await Assert.That(result).EndsWith(expectedEnd);
            await Assert.That(long.TryParse(result?[expectedStart.Length..^expectedEnd.Length], out _)).IsTrue();
        }
    }

    [Test]
    public async Task ClearWatch() {
        await Page.GetByTestId(GeolocationInProcessGroup.BUTTON_WATCH_POSITION).ClickAsync();
        await Task.Delay(100);

        await Context.SetGeolocationAsync(new Geolocation() {
            Longitude = 1,
            Latitude = 1,
            Accuracy = 1,
        });
        await Task.Delay(100);

        await Page.GetByTestId(GeolocationInProcessGroup.BUTTON_CLEAR_WATCH).ClickAsync();
        await Task.Delay(100);

        await Context.SetGeolocationAsync(new Geolocation() {
            Longitude = 2,
            Latitude = 2,
            Accuracy = 2,
        });
        await Task.Delay(100);

        string? result = await Page.GetByTestId(GeolocationInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("watchId: 3, count: 0");
    }
}

using BrowserAPI.Test.Client;
using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class GeolocationTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await BrowserContext.GrantPermissionsAsync(["geolocation"]);
    }


    [Test]
    public async Task GetCurrentPosition() {
        const float LONGITUDE = 10.0f;
        const float LATITUDE = 12.0f;
        const float ACCURACY = 2.0f;
        await BrowserContext.SetGeolocationAsync(new Geolocation() {
            Longitude = LONGITUDE,
            Latitude = LATITUDE,
            Accuracy = ACCURACY,
        });

        await ExecuteTest(GeolocationGroup.BUTTON_GET_CURRENT_POSITION);

        string? result = await Page.GetByTestId(GeolocationGroup.LABEL_OUTPUT).TextContentAsync();

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
        await BrowserContext.SetGeolocationAsync(new Geolocation() {
            Longitude = LONGITUDE,
            Latitude = LATITUDE,
            Accuracy = ACCURACY,
        });

        await ExecuteTest(GeolocationGroup.BUTTON_GET_CURRENT_POSITION_ASYNC);

        string? result = await Page.GetByTestId(GeolocationGroup.LABEL_OUTPUT).TextContentAsync();

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

        await ExecuteTest(GeolocationGroup.BUTTON_WATCH_POSITION);

        for (int i = 0; i < 5; i++) {
            await BrowserContext.SetGeolocationAsync(new Geolocation() {
                Longitude = LONGITUDE * i,
                Latitude = LATITUDE * i,
                Accuracy = ACCURACY * i,
            });
            await Task.Delay(STANDARD_WAIT_TIME);

            string? result = await Page.GetByTestId(GeolocationGroup.LABEL_OUTPUT).TextContentAsync();

            string expectedStart = $"GeolocationCoordinates {{ Latitude = {LATITUDE * i}, Longitude = {LONGITUDE * i}, Altitude = , Accuracy = {ACCURACY * i}, AltitudeAccuracy = , Heading = , Speed = , Timestamp = ";
            await Assert.That(result).StartsWith(expectedStart);
            string expectedEnd = " }";
            await Assert.That(result).EndsWith(expectedEnd);
            await Assert.That(long.TryParse(result?[expectedStart.Length..^expectedEnd.Length], out _)).IsTrue();
        }
    }

    [Test]
    public async Task ClearWatch() {
        await ExecuteTest(GeolocationGroup.BUTTON_WATCH_POSITION);

        await BrowserContext.SetGeolocationAsync(new Geolocation() {
            Longitude = 1,
            Latitude = 1,
            Accuracy = 1,
        });
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(GeolocationGroup.BUTTON_CLEAR_WATCH);

        await BrowserContext.SetGeolocationAsync(new Geolocation() {
            Longitude = 2,
            Latitude = 2,
            Accuracy = 2,
        });
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(GeolocationGroup.LABEL_OUTPUT).TextContentAsync();

        // "watchId: {ínt}, count: 0"
        const string expectedStart = "watchId: ";
        await Assert.That(result).StartsWith(expectedStart);
        const string expectedEnd = ", count: 0";
        await Assert.That(result).EndsWith(expectedEnd);
        await Assert.That(long.TryParse(result?[expectedStart.Length..^expectedEnd.Length], out _)).IsTrue();
    }
}

using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class GeolocationTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await Context.GrantPermissionsAsync(["geolocation"]);
    }

    public override async Task DisposeAsync() {
        await Context.ClearPermissionsAsync();
        await base.DisposeAsync();
    }


    [Fact]
    public async Task GetCurrentPosition() {
        const float LONGITUDE = 10.0f;
        const float LATITUDE = 12.0f;
        const float ACCURACY = 2.0f;
        await Context.SetGeolocationAsync(new Geolocation() {
            Longitude = LONGITUDE,
            Latitude = LATITUDE,
            Accuracy = ACCURACY,
        });

        await Page.GetByTestId(GeolocationGroup.BUTTON_GET_CURRENT_POSITION).ClickAsync();

        string? result = await Page.GetByTestId(GeolocationGroup.LABEL_OUTPUT).TextContentAsync();

        int secondParameterIndex = result?.LastIndexOf("}, ") ?? throw new Exception("result is null");
        string secondParameter = result[(secondParameterIndex + 3)..];
        Assert.True(long.TryParse(secondParameter, out _));

        string firstParameter = result[..(secondParameterIndex + 1)];

        Assert.Equal($"GeolocationCoordinates {{ Latitude = {LATITUDE}, Longitude = {LONGITUDE}, Altitude = , Accuracy = {ACCURACY}, AltitudeAccuracy = , Heading = , Speed =  }}", firstParameter);
    }

    [Fact]
    public async Task WatchPosition() {
        const float LONGITUDE = 10.0f;
        const float LATITUDE = 12.0f;
        const float ACCURACY = 1.0f;

        await Page.GetByTestId(GeolocationGroup.BUTTON_WATCH_POSITION).ClickAsync();

        for (int i = 0; i < 5; i++) {
            await Context.SetGeolocationAsync(new Geolocation() {
                Longitude = LONGITUDE * i,
                Latitude = LATITUDE * i,
                Accuracy = ACCURACY * i,
            });
            await Task.Delay(100);
            string? result = await Page.GetByTestId(GeolocationGroup.LABEL_OUTPUT).TextContentAsync();

            int secondParameterIndex = result?.LastIndexOf("}, ") ?? throw new Exception("result is null");
            string secondParameter = result[(secondParameterIndex + 3)..];
            Assert.True(long.TryParse(secondParameter, out _));

            string firstParameter = result[..(secondParameterIndex + 1)];

            Assert.Equal($"GeolocationCoordinates {{ Latitude = {LATITUDE * i}, Longitude = {LONGITUDE * i}, Altitude = , Accuracy = {ACCURACY * i}, AltitudeAccuracy = , Heading = , Speed =  }}", firstParameter);
        }
    }

    [Fact]
    public async Task ClearWatch() {
        await Page.GetByTestId(GeolocationGroup.BUTTON_WATCH_POSITION).ClickAsync();
        await Task.Delay(100);

        await Context.SetGeolocationAsync(new Geolocation() {
            Longitude = 1,
            Latitude = 1,
            Accuracy = 1,
        });
        await Task.Delay(100);

        await Page.GetByTestId(GeolocationGroup.BUTTON_CLEAR_WATCH).ClickAsync();
        await Task.Delay(100);

        await Context.SetGeolocationAsync(new Geolocation() {
            Longitude = 2,
            Latitude = 2,
            Accuracy = 2,
        });
        await Task.Delay(100);

        string? result = await Page.GetByTestId(GeolocationGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal("watchId: 3, count: 0", result);
    }
}

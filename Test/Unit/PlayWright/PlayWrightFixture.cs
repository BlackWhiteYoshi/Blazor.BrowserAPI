using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

[CollectionDefinition("PlayWright")]
public sealed class PlayWrightFixture : ICollectionFixture<PlayWrightFixture>, IAsyncLifetime {
    private const string BASE_URL = "https://localhost:5000";

    private readonly WebApplicationFactory<Test.ClientHost.Program.IAssemblyMarker> hostFactory;
    private readonly HttpClient httpClient;
    private IPlaywright playWright = null!;
    private IBrowser browser = null!;

    public PlayWrightFixture() {
        // enusre the right version is installed
        Program.Main(["install"]);

        hostFactory = new();
        hostFactory.WithWebHostBuilder((IWebHostBuilder builder) =>
            builder.ConfigureAppConfiguration((IConfigurationBuilder configBuilder) =>
                configBuilder.AddCommandLine([$"--RenderMode=webassembly", "--Prerender=false"])
            )
        );
        httpClient = hostFactory.CreateClient(new WebApplicationFactoryClientOptions() { BaseAddress = new Uri(BASE_URL) });
    }

    public async Task InitializeAsync() {
        playWright = await Playwright.CreateAsync();
        browser = await playWright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = true });
        //browser = await playWright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = true });
    }

    public async Task DisposeAsync() {
        await browser.DisposeAsync();
        playWright.Dispose();

        httpClient.Dispose();
        await hostFactory.DisposeAsync();
    }


    /// <summary>
    /// Creates a new browser context wired up with in memory server.
    /// </summary>
    /// <returns></returns>
    public async Task<IBrowserContext> NewBrowserContext() {
        IBrowserContext browserContext = await browser.NewContextAsync(new BrowserNewContextOptions() { BaseURL = BASE_URL });

        await browserContext.RouteAsync($"{BASE_URL}/**", async (IRoute route) => {
            using HttpRequestMessage requestMessage = CreateRequestMessage(route);
            static HttpRequestMessage CreateRequestMessage(IRoute route) {
                IRequest request = route.Request;
                HttpRequestMessage requestMessage = new(new HttpMethod(request.Method), request.Url) {
                    Content = request.PostDataBuffer switch {
                        byte[] postDataBuffer => new ByteArrayContent(postDataBuffer),
                        null => null
                    }
                };
                foreach (var header in request.Headers)
                    requestMessage.Headers.Add(header.Key, header.Value);

                return requestMessage;
            }

            using HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

            RouteFulfillOptions routeFulfillOptions = new() {
                BodyBytes = await response.Content.ReadAsByteArrayAsync(),
                Headers = response.Content.Headers.Select(header => new KeyValuePair<string, string>(header.Key, string.Join(',', header.Value))),
                Status = (int)response.StatusCode
            };
            await route.FulfillAsync(routeFulfillOptions);
        });

        return browserContext;
    }
}

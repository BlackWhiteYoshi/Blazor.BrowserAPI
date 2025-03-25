using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

[CollectionDefinition("PlayWright")]
public sealed class PlayWrightFixture : ICollectionFixture<PlayWrightFixture>, IAsyncLifetime {
    private sealed class WebApplicationFactoryWithRenderMode(string renderMode) : WebApplicationFactory<Test.ClientHost.Program.IAssemblyMarker> {
        protected override IHost CreateHost(IHostBuilder builder)
            => base.CreateHost(builder.ConfigureHostConfiguration(configBuilder => configBuilder.AddCommandLine([$"--RenderMode={renderMode}", "--Prerender=true"])));
    }

    private const string BASE_URL = "https://localhost:5000";


    private readonly WebApplicationFactoryWithRenderMode hostFactory;
    private readonly HttpClient httpClient;

    private IPlaywright playWright = null!;
    private IBrowser browser = null!;
    public IBrowserContext BrowserContext { get; private set; } = null!;
    public IPage Page { get; private set; } = null!; // testing in parallel: Page-pool instead of 1 single page


    public PlayWrightFixture() {
        // enusre the right version is installed
        Program.Main(["install"]);

        hostFactory = new WebApplicationFactoryWithRenderMode("static");
        httpClient = hostFactory.CreateClient(new WebApplicationFactoryClientOptions() { BaseAddress = new Uri(BASE_URL) });
    }

    public async Task InitializeAsync() {
        playWright = await Playwright.CreateAsync();
        browser = await playWright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = true });
        //browser = await playWright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = true });

        // wire up with in memory server.
        BrowserContext = await browser.NewContextAsync(new BrowserNewContextOptions() { BaseURL = BASE_URL });
        await BrowserContext.RouteAsync($"{BASE_URL}/**", async (IRoute route) => {
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

        Page = await BrowserContext.NewPageAsync();
    }


    public async Task DisposeAsync() {
        await Page.CloseAsync();
        await BrowserContext.DisposeAsync();
        await browser.DisposeAsync();
        playWright.Dispose();

        httpClient.Dispose();
        await hostFactory.DisposeAsync();
    }
}

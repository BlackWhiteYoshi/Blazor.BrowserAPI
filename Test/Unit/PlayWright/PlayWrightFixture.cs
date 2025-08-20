using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Playwright;
using TUnit.Core.Interfaces;

namespace BrowserAPI.UnitTest;

public sealed class PlayWrightFixture : IAsyncInitializer, IAsyncDisposable {
    private sealed class WebApplicationFactoryWithRenderMode(string renderMode) : WebApplicationFactory<Test.ClientHost.Program.IAssemblyMarker> {
        protected override IHost CreateHost(IHostBuilder builder)
            => base.CreateHost(builder.ConfigureHostConfiguration(configBuilder => configBuilder.AddCommandLine([$"--RenderMode={renderMode}", "--Prerender=true"])));
    }

    private const string BASE_URL = "https://localhost:5000";
#if DEBUG
    private const bool HEADLESS = false;
#else
    private const bool HEADLESS = true;
#endif


    private IPlaywright playWright = null!;

    private WebApplicationFactoryWithRenderMode hostFactory = null!;
    private HttpClient httpClient = null!;

    public async Task InitializeAsync() {
        // enusre the right version is installed
        Program.Main(["install"]);
        playWright = await Playwright.CreateAsync();

        hostFactory = new WebApplicationFactoryWithRenderMode("static");
        httpClient = hostFactory.CreateClient(new WebApplicationFactoryClientOptions() { BaseAddress = new Uri(BASE_URL) });
    }

    public async ValueTask DisposeAsync() {
        if (_chromiumBrowser is not null)
            await (await _chromiumBrowser).DisposeAsync();
        if (_firefoxBrowser is not null)
            await (await _firefoxBrowser).DisposeAsync();
        playWright.Dispose();

        httpClient.Dispose();
        await hostFactory.DisposeAsync();
    }


    private Task<IBrowser>? _chromiumBrowser;
    private Task<IBrowser> ChromiumBrowser => _chromiumBrowser ??= playWright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = HEADLESS });

    /// <summary>
    /// Creates a new browser context in the chromium Browser wired up with in memory server.
    /// </summary>
    /// <returns></returns>
    public async Task<IBrowserContext> NewChromiumBrowserContext() => await NewBrowserContext(await ChromiumBrowser);


    private Task<IBrowser>? _firefoxBrowser;
    private Task<IBrowser> FirefoxBrowser => _firefoxBrowser ??= playWright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = HEADLESS });

    /// <summary>
    /// Creates a new browser context in the firefox Browser wired up with in memory server.
    /// </summary>
    /// <returns></returns>
    public async Task<IBrowserContext> NewFirefoxBrowserContext() => await NewBrowserContext(await FirefoxBrowser);


    private async Task<IBrowserContext> NewBrowserContext(IBrowser browser) {
        IBrowserContext browserContext = await browser.NewContextAsync(new BrowserNewContextOptions() { BaseURL = BASE_URL, HasTouch = true });

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

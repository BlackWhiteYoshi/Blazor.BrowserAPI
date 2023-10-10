using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public abstract class PlayWrightTest : IAsyncLifetime {
    /// <summary>
    /// BrowserContext
    /// </summary>
    protected IBrowserContext Context { get; private set; } = null!;

    /// <summary>
    /// BrowserPage
    /// </summary>
    protected IPage Page { get; private set; } = null!;
    

    private readonly PlayWrightFixture _playWrightFixture;

    public PlayWrightTest(PlayWrightFixture playWrightFixture) => _playWrightFixture = playWrightFixture;


    public async Task InitializeAsync() {
        Context = await _playWrightFixture.NewBrowserContext();
        Page = await Context.NewPageAsync();
        await Page.GotoAsync("/");
    }

    public async Task DisposeAsync() {
        try {
            // Asserts that no exception has been occured.
            await Assertions.Expect(Page.Locator("#blazor-error-ui")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions() { Visible = false });
        }
        finally {
            await Context.DisposeAsync().AsTask();
        }
    }
}

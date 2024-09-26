using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public abstract class PlayWrightTest(PlayWrightFixture playWrightFixture) : IAsyncLifetime {
    /// <summary>
    /// BrowserContext
    /// </summary>
    protected IBrowserContext Context => playWrightFixture.BrowserContext;

    /// <summary>
    /// BrowserPage
    /// </summary>
    protected IPage Page => playWrightFixture.Page;


    public virtual async Task InitializeAsync() {
        // get page from pool
        await Page.GotoAsync("/");
    }

    public virtual async Task DisposeAsync() {
        try {
            // Asserts that no exception has been occured.
            await Assertions.Expect(Page.Locator("#blazor-error-ui")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions() { Visible = false });
        }
        finally {
            // release page from pool
        }
    }
}

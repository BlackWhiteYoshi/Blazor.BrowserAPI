using Microsoft.Playwright;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public abstract class PlayWrightTest(PlayWrightFixture playWrightFixture) : IAsyncLifetime {
    /// <summary>
    /// BrowserContext
    /// </summary>
    protected IBrowserContext Context { get; private set; } = null!;

    /// <summary>
    /// BrowserPage
    /// </summary>
    protected IPage Page { get; private set; } = null!;


    public virtual async Task InitializeAsync() {
        Context = await playWrightFixture.NewBrowserContext();
        Page = await Context.NewPageAsync();
        await Page.GotoAsync("/");
    }

    public virtual async Task DisposeAsync() {
        try {
            // Asserts that no exception has been occured.
            await Assertions.Expect(Page.Locator("#blazor-error-ui")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions() { Visible = false });
        }
        finally {
            await Context.DisposeAsync().AsTask();
        }
    }
}

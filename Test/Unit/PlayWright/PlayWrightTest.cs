using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using TUnit.Core.Interfaces;

namespace BrowserAPI.UnitTest;

public abstract class PlayWrightTest(PlayWrightFixture playWrightFixture) : IAsyncInitializer, IAsyncDisposable {
    /// <summary>
    /// BrowserContext
    /// </summary>
    protected IBrowserContext BrowserContext { get; private set; } = null!;

    /// <summary>
    /// BrowserPage
    /// </summary>
    protected IPage Page { get; private set; } = null!;


    public virtual async Task InitializeAsync() {
        BrowserContext = await playWrightFixture.NewBrowserContext();
        Page = await BrowserContext.NewPageAsync();
        await Page.GotoAsync("/");
    }

    public virtual async ValueTask DisposeAsync() {
        try {
            // Asserts that no exception has been occured.
            await Assertions.Expect(Page.Locator("#blazor-error-ui")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions() { Visible = false });
        }
        finally {
            await Page.CloseAsync();
            await BrowserContext.DisposeAsync();
        }
    }


    /// <summary>
    /// Small waiting time in ms
    /// </summary>
    protected const int SMALL_WAIT_TIME = 50;
    
    /// <summary>
    /// Standard waiting time in ms
    /// </summary>
    protected const int STANDARD_WAIT_TIME = 500;

    /// <summary>
    /// Performs a click on the button with the given data-testid
    /// and then waits <see cref="STANDARD_WAIT_TIME"/>.
    /// </summary>
    /// <param name="testId"></param>
    /// <returns></returns>
    protected async Task ExecuteTest(string testId) {
        await Page.GetByTestId(testId).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);
    }
}

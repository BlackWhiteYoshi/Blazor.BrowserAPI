using Microsoft.Playwright;
using System.Diagnostics;
using TUnit.Core.Interfaces;

namespace BrowserAPI.UnitTest;

public abstract class PlayWrightTest(PlayWrightFixture playWrightFixture) : IAsyncInitializer, IAsyncDisposable {
    /// <summary>
    /// BrowserContext of this test
    /// </summary>
    protected IBrowserContext BrowserContext { get; private set; } = null!;

    /// <summary>
    /// BrowserPage of this test
    /// </summary>
    protected IPage Page { get; private set; } = null!;


    /// <summary>
    /// Executes <see cref="NewPage"/> with <see cref="BrowserId.Chromium"/>.
    /// </summary>
    /// <returns></returns>
    public virtual Task InitializeAsync() => NewPage(BrowserId.Chromium);

    /// <summary>
    /// Asserts that no exception has been occured, closes the Tab and removes the BrowserContext.
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync() {
        try {
            await Assertions.Expect(Page.Locator("#blazor-error-ui")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions() { Visible = false });
        }
        finally {
            await Page.CloseAsync();
            await BrowserContext.DisposeAsync();
        }
    }


    protected enum BrowserId {
        Chromium,
        Firefox
    }

    /// <summary>
    /// Creates a new BrowserContext in the chosen Browser, opens a new Tab and loads the page in that Tab.
    /// </summary>
    /// <param name="browserId">Which Browser to choose to create BrowserContext and Tab.</param>
    /// <returns></returns>
    protected async Task NewPage(BrowserId browserId) {
        BrowserContext = browserId switch {
            BrowserId.Chromium => await playWrightFixture.NewChromiumBrowserContext(),
            BrowserId.Firefox => await playWrightFixture.NewFirefoxBrowserContext(),
            _ => throw new UnreachableException($"enum {nameof(BrowserId)} has members that this switch is missing; current missing member is '{browserId}'")
        };

        Page = await BrowserContext.NewPageAsync();
        await Page.GotoAsync("/");
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

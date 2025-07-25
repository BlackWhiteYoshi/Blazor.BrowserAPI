﻿using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

public abstract class PlayWrightTest(PlayWrightFixture playWrightFixture) {
    /// <summary>
    /// BrowserContext
    /// </summary>
    protected IBrowserContext BrowserContext { get; private set; } = null!;

    /// <summary>
    /// BrowserPage
    /// </summary>
    protected IPage Page { get; private set; } = null!;


    /// <summary>
    /// Creates a new BrowserContext, opens a new Tab and loads the page in that Tab.
    /// </summary>
    /// <returns></returns>
    [Before(HookType.Test)]
    public virtual async Task SetUp() {
        BrowserContext = await playWrightFixture.NewBrowserContext();
        Page = await BrowserContext.NewPageAsync();
        await Page.GotoAsync("/");
    }

    /// <summary>
    /// Asserts that no exception has been occured, closes the Tab and removes the BrowserContext.
    /// </summary>
    /// <returns></returns>
    [After(HookType.Test)]
    public async Task CleanUp() {
        try {
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

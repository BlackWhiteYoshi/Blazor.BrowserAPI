using BrowserAPI.Test.Client;
using Xunit;

namespace Blazor.BrowserAPI.UnitTest;

public sealed class ClipboardTest : PlayWrightTest {
    public ClipboardTest(PlayWrightFixture playWrightFixture) : base(playWrightFixture) { }


    [Fact]
    public async Task ClipboardRead() {
        const string TEST_STR = "clipboard read test";

        await Context.GrantPermissionsAsync(new string[] { "clipboard-read", "clipboard-write" });
        await Page.EvaluateAsync($"navigator.clipboard.writeText('{TEST_STR}')");

        await Page.GetByTestId(ClipboardGroup.DATA_TESTID_READ).ClickAsync();

        string? result = await Page.GetByTestId(ClipboardGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(TEST_STR, result);
    }

    [Fact]
    public async Task ClipboardWrite() {
        await Context.GrantPermissionsAsync(new string[] { "clipboard-read", "clipboard-write" });
        
        await Page.GetByTestId(ClipboardGroup.DATA_TESTID_WRITE).ClickAsync();

        string clipboardContent = await Page.EvaluateAsync<string>($"navigator.clipboard.readText()");
        Assert.Equal(ClipboardGroup.WRITE_TEST, clipboardContent);
    }
}

using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class ClipboardTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await BrowserContext.GrantPermissionsAsync(["clipboard-read", "clipboard-write"]);
    }


    [Test]
    [NotInParallel("ClipboardTest")]
    public async Task Read() {
        const string TEST_STR = "clipboard read test";
        await Page.EvaluateAsync($"navigator.clipboard.writeText('{TEST_STR}');");

        await ExecuteTest(ClipboardGroup.BUTTON_READ);

        string? result = await Page.GetByTestId(ClipboardGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(TEST_STR);
    }

    [Test]
    [NotInParallel("ClipboardTest")]
    public async Task Write() {
        await ExecuteTest(ClipboardGroup.BUTTON_WRITE);

        string clipboardContent = await Page.EvaluateAsync<string>($"navigator.clipboard.readText();");
        await Assert.That(clipboardContent).IsEqualTo(ClipboardGroup.TEST_WRITE);
    }
}

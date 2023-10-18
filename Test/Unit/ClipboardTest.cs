﻿using BrowserAPI.Test.Client;
using Xunit;

namespace BrowserAPI.UnitTest;

public sealed class ClipboardTest : PlayWrightTest {
    public ClipboardTest(PlayWrightFixture playWrightFixture) : base(playWrightFixture) { }

    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await Context.GrantPermissionsAsync(new string[] { "clipboard-read", "clipboard-write" });
    }


    [Fact]
    public async Task ClipboardRead() {
        const string TEST_STR = "clipboard read test";

        await Page.EvaluateAsync($"navigator.clipboard.writeText('{TEST_STR}');");

        await Page.GetByTestId(ClipboardGroup.BUTTON_READ).ClickAsync();

        string? result = await Page.GetByTestId(ClipboardGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(TEST_STR, result);
    }

    [Fact]
    public async Task ClipboardWrite() {
        await Page.GetByTestId(ClipboardGroup.BUTTON_WRITE).ClickAsync();

        string clipboardContent = await Page.EvaluateAsync<string>($"navigator.clipboard.readText();");
        Assert.Equal(ClipboardGroup.TEST_WRITE, clipboardContent);
    }
}

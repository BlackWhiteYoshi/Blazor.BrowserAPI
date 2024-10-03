using BrowserAPI.Test.Client;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class SessionStorageInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task DisposeAsync() {
        await base.DisposeAsync();

        // clean up all entries
        await Page.EvaluateAsync("sessionStorage.clear();");
    }


    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
    public async Task GetLength(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"sessionStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await Page.GetByTestId(SessionStorageInProcessGroup.BUTTON_GET_LENGTH).ClickAsync();

        string? result = await Page.GetByTestId(SessionStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(number.ToString(), result);
    }

    [Fact]
    public async Task Key() {
        const string KEY = "test-key-0";
        await Page.EvaluateAsync($"sessionStorage.setItem('{KEY}', 'test-value-0');");

        await Page.GetByTestId(SessionStorageInProcessGroup.BUTTON_KEY).ClickAsync();

        string? result = await Page.GetByTestId(SessionStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(KEY, result);
    }

    [Fact]
    public async Task GetItem() {
        const string VALUE = "test-getItem-value";
        await Page.EvaluateAsync($"sessionStorage.setItem('{SessionStorageInProcessGroup.TEST_GET_ITEM}', '{VALUE}');");

        await Page.GetByTestId(SessionStorageInProcessGroup.BUTTON_GET_ITEM).ClickAsync();

        string? result = await Page.GetByTestId(SessionStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(VALUE, result);
    }

    [Fact]
    public async Task SetItem() {
        await Page.GetByTestId(SessionStorageInProcessGroup.BUTTON_SET_ITEM).ClickAsync();

        string result = await Page.EvaluateAsync<string>($"sessionStorage.getItem('{SessionStorageInProcessGroup.TEST_SET_ITEM_KEY}');");
        Assert.Equal(SessionStorageInProcessGroup.TEST_SET_ITEM_VALUE, result);
    }

    [Fact]
    public async Task RemoveItem() {
        await Page.EvaluateAsync($"sessionStorage.setItem('{SessionStorageInProcessGroup.TEST_REMOVE_ITEM}', 'test-value');");

        await Page.GetByTestId(SessionStorageInProcessGroup.BUTTON_REMOVE_ITEM).ClickAsync();

        string? result = await Page.EvaluateAsync<string?>($"sessionStorage.getItem('{SessionStorageInProcessGroup.TEST_REMOVE_ITEM}');");
        Assert.Null(result);


    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
    public async Task Clear(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"sessionStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await Page.GetByTestId(SessionStorageInProcessGroup.BUTTON_CLEAR).ClickAsync();

        int length = await Page.EvaluateAsync<int>("sessionStorage.length;");
        Assert.Equal(0, length);
    }
}

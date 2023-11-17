using BrowserAPI.Test.Client;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class LocalStorageInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
    public async Task GetLength(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"localStorage.setItem('test-key-{i}', 'test-value-{i}');");
        
        // strange "blazor-resource-hash:Blazor.BrowserAPI.Test.Client" is also added to localStorage
        number++;

        await Page.GetByTestId(LocalStorageGroup.BUTTON_GET_LENGTH_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(LocalStorageGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(number.ToString(), result);
    }

    [Fact]
    public async Task Key() {
        const string KEY = "test-key-0";
        await Page.EvaluateAsync($"localStorage.setItem('{KEY}', 'test-value-0');");

        await Page.GetByTestId(LocalStorageGroup.BUTTON_KEY_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(LocalStorageGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(KEY, result);
    }

    [Fact]
    public async Task GetItem() {
        const string VALUE = "test-getItem-value";
        await Page.EvaluateAsync($"localStorage.setItem('{LocalStorageGroup.TEST_GET_ITEM}', '{VALUE}');");

        await Page.GetByTestId(LocalStorageGroup.BUTTON_GET_ITEM_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(LocalStorageGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(VALUE, result);
    }

    [Fact]
    public async Task SetItem() {
        await Page.GetByTestId(LocalStorageGroup.BUTTON_SET_ITEM_INPROCESS).ClickAsync();

        string result = await Page.EvaluateAsync<string>($"localStorage.getItem('{LocalStorageGroup.TEST_SET_ITEM_KEY}');");
        Assert.Equal(LocalStorageGroup.TEST_SET_ITEM_VALUE, result);
    }

    [Fact]
    public async Task RemoveItem() {
        await Page.EvaluateAsync($"localStorage.setItem('{LocalStorageGroup.TEST_REMOVE_ITEM}', 'test-value');");

        await Page.GetByTestId(LocalStorageGroup.BUTTON_REMOVE_ITEM_INPROCESS).ClickAsync();

        string? result = await Page.EvaluateAsync<string?>($"localStorage.getItem('{LocalStorageGroup.TEST_REMOVE_ITEM}');");
        Assert.Null(result);

        
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
    public async Task Clear(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"localStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await Page.GetByTestId(LocalStorageGroup.BUTTON_CLEAR_INPROCESS).ClickAsync();

        int length = await Page.EvaluateAsync<int>("localStorage.length;");
        Assert.Equal(0, length);        
    }
}

using BrowserAPI.Test.Client;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class LocalStorageInProcessTest : PlayWrightTest {
    public LocalStorageInProcessTest(PlayWrightFixture playWrightFixture) : base(playWrightFixture) { }


    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
    public async Task GetLength(int number) {

        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"localStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await Page.GetByTestId(LocalStorageGroup.DATA_TESTID_GET_LENGTH_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(LocalStorageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(number.ToString(), result);
    }

    [Fact]
    public async Task Key() {
        const string KEY = "test-key-0";
        await Page.EvaluateAsync($"localStorage.setItem('{KEY}', 'test-value-0');");

        await Page.GetByTestId(LocalStorageGroup.DATA_TESTID_KEY_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(LocalStorageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(KEY, result);
    }

    [Fact]
    public async Task GetItem() {
        const string VALUE = "test-getItem-value";
        await Page.EvaluateAsync($"localStorage.setItem('{LocalStorageGroup.GET_ITEM_TEST}', '{VALUE}');");

        await Page.GetByTestId(LocalStorageGroup.DATA_TESTID_GET_ITEM_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(LocalStorageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(VALUE, result);
    }

    [Fact]
    public async Task SetItem() {
        await Page.GetByTestId(LocalStorageGroup.DATA_TESTID_SET_ITEM_INPROCESS).ClickAsync();

        string result = await Page.EvaluateAsync<string>($"localStorage.getItem('{LocalStorageGroup.SET_ITEM_KEY_TEST}');");
        Assert.Equal(LocalStorageGroup.SET_ITEM_VALUE_TEST, result);
    }

    [Fact]
    public async Task RemoveItem() {
        await Page.EvaluateAsync($"localStorage.setItem('{LocalStorageGroup.REMOVE_ITEM_TEST}', 'test-value');");

        await Page.GetByTestId(LocalStorageGroup.DATA_TESTID_REMOVE_ITEM_INPROCESS).ClickAsync();

        string? result = await Page.EvaluateAsync<string?>($"localStorage.getItem('{LocalStorageGroup.REMOVE_ITEM_TEST}');");
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

        await Page.GetByTestId(LocalStorageGroup.DATA_TESTID_CLEAR_INPROCESS).ClickAsync();

        int length = await Page.EvaluateAsync<int>("localStorage.length;");
        Assert.Equal(0, length);        
    }
}

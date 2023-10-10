using BrowserAPI.Test.Client;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class SessionStorageTest : PlayWrightTest {
    public SessionStorageTest(PlayWrightFixture playWrightFixture) : base(playWrightFixture) { }


    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
    public async Task GetLength_Property(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"sessionStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await Page.GetByTestId(SessionStorageGroup.DATA_TESTID_GET_LENGTH_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SessionStorageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(number.ToString(), result);

    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
    public async Task GetLength_Method(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"sessionStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await Page.GetByTestId(SessionStorageGroup.DATA_TESTID_GET_LENGTH_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SessionStorageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(number.ToString(), result);
    }

    [Fact]
    public async Task Key() {
        const string KEY = "test-key-0";
        await Page.EvaluateAsync($"sessionStorage.setItem('{KEY}', 'test-value-0');");

        await Page.GetByTestId(SessionStorageGroup.DATA_TESTID_KEY).ClickAsync();

        string? result = await Page.GetByTestId(SessionStorageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(KEY, result);
    }

    [Fact]
    public async Task GetItem() {
        const string VALUE = "test-getItem-value";
        await Page.EvaluateAsync($"sessionStorage.setItem('{SessionStorageGroup.GET_ITEM_TEST}', '{VALUE}');");

        await Page.GetByTestId(SessionStorageGroup.DATA_TESTID_GET_ITEM).ClickAsync();

        string? result = await Page.GetByTestId(SessionStorageGroup.DATA_TESTID_OUTPUT).TextContentAsync();
        Assert.Equal(VALUE, result);
    }

    [Fact]
    public async Task SetItem() {
        await Page.GetByTestId(SessionStorageGroup.DATA_TESTID_SET_ITEM).ClickAsync();

        string result = await Page.EvaluateAsync<string>($"sessionStorage.getItem('{SessionStorageGroup.SET_ITEM_KEY_TEST}');");
        Assert.Equal(SessionStorageGroup.SET_ITEM_VALUE_TEST, result);
    }

    [Fact]
    public async Task RemoveItem() {
        await Page.EvaluateAsync($"sessionStorage.setItem('{SessionStorageGroup.REMOVE_ITEM_TEST}', 'test-value');");

        await Page.GetByTestId(SessionStorageGroup.DATA_TESTID_REMOVE_ITEM).ClickAsync();

        string? result = await Page.EvaluateAsync<string?>($"sessionStorage.getItem('{SessionStorageGroup.REMOVE_ITEM_TEST}');");
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

        await Page.GetByTestId(SessionStorageGroup.DATA_TESTID_CLEAR).ClickAsync();

        int length = await Page.EvaluateAsync<int>("sessionStorage.length;");
        Assert.Equal(0, length);
    }
}

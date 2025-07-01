using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class SessionStorageTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetLength_Property(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"sessionStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await Page.GetByTestId(SessionStorageGroup.BUTTON_GET_LENGTH_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SessionStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(number.ToString());

    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetLength_Method(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"sessionStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await Page.GetByTestId(SessionStorageGroup.BUTTON_GET_LENGTH_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SessionStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(number.ToString());
    }

    [Test]
    public async Task Key() {
        const string KEY = "test-key-0";
        await Page.EvaluateAsync($"sessionStorage.setItem('{KEY}', 'test-value-0');");

        await Page.GetByTestId(SessionStorageGroup.BUTTON_KEY).ClickAsync();

        string? result = await Page.GetByTestId(SessionStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(KEY);
    }

    [Test]
    public async Task GetItem() {
        const string VALUE = "test-getItem-value";
        await Page.EvaluateAsync($"sessionStorage.setItem('{SessionStorageGroup.TEST_GET_ITEM}', '{VALUE}');");

        await Page.GetByTestId(SessionStorageGroup.BUTTON_GET_ITEM).ClickAsync();

        string? result = await Page.GetByTestId(SessionStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(VALUE);
    }

    [Test]
    public async Task SetItem() {
        await Page.GetByTestId(SessionStorageGroup.BUTTON_SET_ITEM).ClickAsync();

        string result = await Page.EvaluateAsync<string>($"sessionStorage.getItem('{SessionStorageGroup.TEST_SET_ITEM_KEY}');");
        await Assert.That(result).IsEqualTo(SessionStorageGroup.TEST_SET_ITEM_VALUE);
    }

    [Test]
    public async Task RemoveItem() {
        await Page.EvaluateAsync($"sessionStorage.setItem('{SessionStorageGroup.TEST_REMOVE_ITEM}', 'test-value');");

        await Page.GetByTestId(SessionStorageGroup.BUTTON_REMOVE_ITEM).ClickAsync();

        string? result = await Page.EvaluateAsync<string?>($"sessionStorage.getItem('{SessionStorageGroup.TEST_REMOVE_ITEM}');");
        await Assert.That(result).IsNull();
    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task Clear(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"sessionStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await Page.GetByTestId(SessionStorageGroup.BUTTON_CLEAR).ClickAsync();

        int length = await Page.EvaluateAsync<int>("sessionStorage.length;");
        await Assert.That(length).IsEqualTo(0);
    }
}

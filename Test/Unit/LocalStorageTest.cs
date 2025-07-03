using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class LocalStorageTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetLength_Property(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"localStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await ExecuteTest(LocalStorageGroup.BUTTON_GET_LENGTH_PROPERTY);

        string? result = await Page.GetByTestId(LocalStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(number.ToString());
    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetLength_Method(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"localStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await ExecuteTest(LocalStorageGroup.BUTTON_GET_LENGTH_METHOD);

        string? result = await Page.GetByTestId(LocalStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(number.ToString());
    }

    [Test]
    public async Task Key() {
        const string KEY = "test-key-0";
        await Page.EvaluateAsync($"localStorage.setItem('{KEY}', 'test-value-0');");

        await ExecuteTest(LocalStorageGroup.BUTTON_KEY);

        string? result = await Page.GetByTestId(LocalStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(KEY);
    }

    [Test]
    public async Task GetItem() {
        const string VALUE = "test-getItem-value";
        await Page.EvaluateAsync($"localStorage.setItem('{LocalStorageGroup.TEST_GET_ITEM}', '{VALUE}');");

        await ExecuteTest(LocalStorageGroup.BUTTON_GET_ITEM);

        string? result = await Page.GetByTestId(LocalStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(VALUE);
    }

    [Test]
    public async Task SetItem() {
        await ExecuteTest(LocalStorageGroup.BUTTON_SET_ITEM);

        string result = await Page.EvaluateAsync<string>($"localStorage.getItem('{LocalStorageGroup.TEST_SET_ITEM_KEY}');");
        await Assert.That(result).IsEqualTo(LocalStorageGroup.TEST_SET_ITEM_VALUE);
    }

    [Test]
    public async Task RemoveItem() {
        await Page.EvaluateAsync($"localStorage.setItem('{LocalStorageGroup.TEST_REMOVE_ITEM}', 'test-value');");

        await ExecuteTest(LocalStorageGroup.BUTTON_REMOVE_ITEM);

        string? result = await Page.EvaluateAsync<string?>($"localStorage.getItem('{LocalStorageGroup.TEST_REMOVE_ITEM}');");
        await Assert.That(result).IsNull();
    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task Clear(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"localStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await ExecuteTest(LocalStorageGroup.BUTTON_CLEAR);

        int length = await Page.EvaluateAsync<int>("localStorage.length;");
        await Assert.That(length).IsEqualTo(0);
    }
}

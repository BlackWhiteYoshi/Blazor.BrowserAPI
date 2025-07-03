using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class LocalStorageInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetLength(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"localStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await ExecuteTest(LocalStorageInProcessGroup.BUTTON_GET_LENGTH);

        string? result = await Page.GetByTestId(LocalStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(number.ToString());
    }

    [Test]
    public async Task Key() {
        const string KEY = "test-key-0";
        await Page.EvaluateAsync($"localStorage.setItem('{KEY}', 'test-value-0');");

        await ExecuteTest(LocalStorageInProcessGroup.BUTTON_KEY);

        string? result = await Page.GetByTestId(LocalStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(KEY);
    }

    [Test]
    public async Task GetItem() {
        const string VALUE = "test-getItem-value";
        await Page.EvaluateAsync($"localStorage.setItem('{LocalStorageInProcessGroup.TEST_GET_ITEM}', '{VALUE}');");

        await ExecuteTest(LocalStorageInProcessGroup.BUTTON_GET_ITEM);

        string? result = await Page.GetByTestId(LocalStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(VALUE);
    }

    [Test]
    public async Task SetItem() {
        await ExecuteTest(LocalStorageInProcessGroup.BUTTON_SET_ITEM);

        string result = await Page.EvaluateAsync<string>($"localStorage.getItem('{LocalStorageInProcessGroup.TEST_SET_ITEM_KEY}');");
        await Assert.That(result).IsEqualTo(LocalStorageInProcessGroup.TEST_SET_ITEM_VALUE);
    }

    [Test]
    public async Task RemoveItem() {
        await Page.EvaluateAsync($"localStorage.setItem('{LocalStorageInProcessGroup.TEST_REMOVE_ITEM}', 'test-value');");

        await ExecuteTest(LocalStorageInProcessGroup.BUTTON_REMOVE_ITEM);

        string? result = await Page.EvaluateAsync<string?>($"localStorage.getItem('{LocalStorageInProcessGroup.TEST_REMOVE_ITEM}');");
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

        await ExecuteTest(LocalStorageInProcessGroup.BUTTON_CLEAR);

        int length = await Page.EvaluateAsync<int>("localStorage.length;");
        await Assert.That(length).IsEqualTo(0);
    }
}

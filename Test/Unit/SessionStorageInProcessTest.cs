﻿using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class SessionStorageInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetLength(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"sessionStorage.setItem('test-key-{i}', 'test-value-{i}');");

        await ExecuteTest(SessionStorageInProcessGroup.BUTTON_GET_LENGTH);

        string? result = await Page.GetByTestId(SessionStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(number.ToString());
    }

    [Test]
    public async Task Key() {
        const string KEY = "test-key-0";
        await Page.EvaluateAsync($"sessionStorage.setItem('{KEY}', 'test-value-0');");

        await ExecuteTest(SessionStorageInProcessGroup.BUTTON_KEY);

        string? result = await Page.GetByTestId(SessionStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(KEY);
    }

    [Test]
    public async Task GetItem() {
        const string VALUE = "test-getItem-value";
        await Page.EvaluateAsync($"sessionStorage.setItem('{SessionStorageInProcessGroup.TEST_GET_ITEM}', '{VALUE}');");

        await ExecuteTest(SessionStorageInProcessGroup.BUTTON_GET_ITEM);

        string? result = await Page.GetByTestId(SessionStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(VALUE);
    }

    [Test]
    public async Task SetItem() {
        await ExecuteTest(SessionStorageInProcessGroup.BUTTON_SET_ITEM);

        string result = await Page.EvaluateAsync<string>($"sessionStorage.getItem('{SessionStorageInProcessGroup.TEST_SET_ITEM_KEY}');");
        await Assert.That(result).IsEqualTo(SessionStorageInProcessGroup.TEST_SET_ITEM_VALUE);
    }

    [Test]
    public async Task RemoveItem() {
        await Page.EvaluateAsync($"sessionStorage.setItem('{SessionStorageInProcessGroup.TEST_REMOVE_ITEM}', 'test-value');");

        await ExecuteTest(SessionStorageInProcessGroup.BUTTON_REMOVE_ITEM);

        string? result = await Page.EvaluateAsync<string?>($"sessionStorage.getItem('{SessionStorageInProcessGroup.TEST_REMOVE_ITEM}');");
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

        await ExecuteTest(SessionStorageInProcessGroup.BUTTON_CLEAR);

        int length = await Page.EvaluateAsync<int>("sessionStorage.length;");
        await Assert.That(length).IsEqualTo(0);
    }
}

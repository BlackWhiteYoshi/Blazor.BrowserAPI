using BrowserAPI.Test.Client;
using System.Text;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class CookieStorageTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetAllCookies_Property(int number) {
        string expected = string.Empty;
        if (number > 0) {
            StringBuilder builder = new();
            for (int i = 0; i < number; i++)
                builder.Append($"test-key-{i}=test-value-{i}; ");

            builder.Length -= 2;
            expected = builder.ToString();
        }
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($$"""document.cookie = `test-key-{{i}}=test-value-{{i}};expires=${new Date(Date.now() + 3600000).toUTCString()}`;""");

        await ExecuteTest(CookieStorageGroup.BUTTON_GET_ALL_COOKIES_PROPERTY);

        string? result = await Page.GetByTestId(CookieStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(expected);

    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetAllCookies_Method(int number) {
        string expected = string.Empty;
        if (number > 0) {
            StringBuilder builder = new();
            for (int i = 0; i < number; i++)
                builder.Append($"test-key-{i}=test-value-{i}; ");

            builder.Length -= 2;
            expected = builder.ToString();
        }
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($$"""document.cookie = `test-key-{{i}}=test-value-{{i}};expires=${new Date(Date.now() + 3600000).toUTCString()}`;""");

        await ExecuteTest(CookieStorageGroup.BUTTON_GET_ALL_COOKIES_METHOD);

        string? result = await Page.GetByTestId(CookieStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetLength_Property(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"document.cookie = 'test-key-{i}=test-value-{i}';");

        await ExecuteTest(CookieStorageGroup.BUTTON_GET_LENGTH_PROPERTY);

        string? result = await Page.GetByTestId(CookieStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(number.ToString());

    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetLength_Method(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"document.cookie = 'test-key-{i}=test-value-{i}';");

        await ExecuteTest(CookieStorageGroup.BUTTON_GET_LENGTH_METHOD);

        string? result = await Page.GetByTestId(CookieStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(number.ToString());
    }

    [Test]
    public async Task Key() {
        const string KEY = "test-key-0";
        await Page.EvaluateAsync($"document.cookie = '{KEY}=test-value-0';");

        await ExecuteTest(CookieStorageGroup.BUTTON_KEY);

        string? result = await Page.GetByTestId(CookieStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(KEY);
    }

    [Test]
    public async Task GetCookie() {
        const string VALUE = "test-getCOOKIE-value";
        await Page.EvaluateAsync($"document.cookie = '{CookieStorageGroup.TEST_GET_COOKIE}={VALUE}';");

        await ExecuteTest(CookieStorageGroup.BUTTON_GET_COOKIE);

        string? result = await Page.GetByTestId(CookieStorageGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(VALUE);
    }

    [Test]
    public async Task SetCookie() {
        await ExecuteTest(CookieStorageGroup.BUTTON_SET_COOKIE);

        string result = await Page.EvaluateAsync<string>("document.cookie;");
        await Assert.That(result).IsEqualTo($"{CookieStorageGroup.TEST_SET_COOKIE_KEY}={CookieStorageGroup.TEST_SET_COOKIE_VALUE}");
    }

    [Test]
    public async Task RemoveCookie() {
        await Page.EvaluateAsync($"document.cookie = '{CookieStorageGroup.TEST_REMOVE_COOKIE}=test-value';");

        await ExecuteTest(CookieStorageGroup.BUTTON_REMOVE_COOKIE);

        string result = await Page.EvaluateAsync<string>("document.cookie;");
        await Assert.That(result).IsEmpty();
    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task Clear(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"document.cookie = 'test-key-{i}=test-value-{i}';");

        await ExecuteTest(CookieStorageGroup.BUTTON_CLEAR);

        string result = await Page.EvaluateAsync<string>("document.cookie;");
        await Assert.That(result).IsEmpty();
    }
}

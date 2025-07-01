using BrowserAPI.Test.Client;
using System.Text;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class CookieStorageInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetAllCookies(int number) {
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

        await Page.GetByTestId(CookieStorageInProcessGroup.BUTTON_GET_ALL_COOKIES).ClickAsync();

        string? result = await Page.GetByTestId(CookieStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(3)]
    [Arguments(10)]
    public async Task GetLength(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"document.cookie = 'test-key-{i}=test-value-{i}';");

        await Page.GetByTestId(CookieStorageInProcessGroup.BUTTON_GET_LENGTH).ClickAsync();

        string? result = await Page.GetByTestId(CookieStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(number.ToString());
    }

    [Test]
    public async Task Key() {
        const string KEY = "test-key-0";
        await Page.EvaluateAsync($"document.cookie = '{KEY}=test-value-0';");

        await Page.GetByTestId(CookieStorageInProcessGroup.BUTTON_KEY).ClickAsync();

        string? result = await Page.GetByTestId(CookieStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(KEY);
    }

    [Test]
    public async Task GetCookie() {
        const string VALUE = "test-getCOOKIE-value";
        await Page.EvaluateAsync($"document.cookie = '{CookieStorageInProcessGroup.TEST_GET_COOKIE}={VALUE}';");

        await Page.GetByTestId(CookieStorageInProcessGroup.BUTTON_GET_COOKIE).ClickAsync();

        string? result = await Page.GetByTestId(CookieStorageInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(VALUE);
    }

    [Test]
    public async Task SetCookie() {
        await Page.GetByTestId(CookieStorageInProcessGroup.BUTTON_SET_COOKIE).ClickAsync();

        string result = await Page.EvaluateAsync<string>("document.cookie;");
        await Assert.That(result).IsEqualTo($"{CookieStorageInProcessGroup.TEST_SET_COOKIE_KEY}={CookieStorageInProcessGroup.TEST_SET_COOKIE_VALUE}");
    }

    [Test]
    public async Task RemoveCookie() {
        await Page.EvaluateAsync($"document.cookie = '{CookieStorageInProcessGroup.TEST_REMOVE_COOKIE}=test-value';");

        await Page.GetByTestId(CookieStorageInProcessGroup.BUTTON_REMOVE_COOKIE).ClickAsync();

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

        await Page.GetByTestId(CookieStorageInProcessGroup.BUTTON_CLEAR).ClickAsync();

        string result = await Page.EvaluateAsync<string>("document.cookie;");
        await Assert.That(result).IsEmpty();
    }
}

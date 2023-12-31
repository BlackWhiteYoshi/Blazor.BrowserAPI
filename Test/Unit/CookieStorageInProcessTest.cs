﻿using BrowserAPI.Test.Client;
using System.Text;
using Xunit;

namespace BrowserAPI.UnitTest;

public sealed class CookieStorageInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
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

        await Page.GetByTestId(CookieStorageGroup.BUTTON_GET_ALL_COOKIES_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(CookieStorageGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
    public async Task GetLength(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"document.cookie = 'test-key-{i}=test-value-{i}';");

        await Page.GetByTestId(CookieStorageGroup.BUTTON_GET_LENGTH_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(CookieStorageGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(number.ToString(), result);
    }

    [Fact]
    public async Task Key() {
        const string KEY = "test-key-0";
        await Page.EvaluateAsync($"document.cookie = '{KEY}=test-value-0';");

        await Page.GetByTestId(CookieStorageGroup.BUTTON_KEY_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(CookieStorageGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(KEY, result);
    }

    [Fact]
    public async Task GetCookie() {
        const string VALUE = "test-getCOOKIE-value";
        await Page.EvaluateAsync($"document.cookie = '{CookieStorageGroup.TEST_GET_COOKIE}={VALUE}';");

        await Page.GetByTestId(CookieStorageGroup.BUTTON_GET_COOKIE_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(CookieStorageGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.Equal(VALUE, result);
    }

    [Fact]
    public async Task SetCookie() {
        await Page.GetByTestId(CookieStorageGroup.BUTTON_SET_COOKIE_INPROCESS).ClickAsync();

        string result = await Page.EvaluateAsync<string>("document.cookie;");
        Assert.Equal($"{CookieStorageGroup.TEST_SET_COOKIE_KEY}={CookieStorageGroup.TEST_SET_COOKIE_VALUE}", result);
    }

    [Fact]
    public async Task RemoveCookie() {
        await Page.EvaluateAsync($"document.cookie = '{CookieStorageGroup.TEST_REMOVE_COOKIE}=test-value';");

        await Page.GetByTestId(CookieStorageGroup.BUTTON_REMOVE_COOKIE_INPROCESS).ClickAsync();

        string result = await Page.EvaluateAsync<string>($"document.cookie;");
        Assert.Empty(result);


    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(10)]
    public async Task Clear(int number) {
        for (int i = 0; i < number; i++)
            await Page.EvaluateAsync($"document.cookie = 'test-key-{i}=test-value-{i}';");

        await Page.GetByTestId(CookieStorageGroup.BUTTON_CLEAR_INPROCESS).ClickAsync();

        string result = await Page.EvaluateAsync<string>($"document.cookie;");
        Assert.Empty(result);
    }
}

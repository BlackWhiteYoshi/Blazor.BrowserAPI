using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class CookieStorageGroup : ComponentBase {
    private const int TEST_KEY_INDEX = 0;
    public const string TEST_GET_COOKIE = "get-cookie-test";
    public const string TEST_SET_COOKIE_KEY = "set-cookie-key-test";
    public const string TEST_SET_COOKIE_VALUE = "set-cookie-value-test";
    public const string TEST_REMOVE_COOKIE = "remove-cookie-test";


    [Inject]
    public required ICookieStorage CookieStorage { private get; init; }


    public const string LABEL_OUTPUT = "cookie-storage-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_ALL_COOKIES_PROPERTY = "cookie-storage-get-all-cookies-property";
    private async Task GetAllCookies_Property() {
        labelOutput = await CookieStorage.AllCookies;
    }

    public const string BUTTON_GET_ALL_COOKIES_METHOD = "cookie-storage-get-all-cookies-method";
    private async Task GetAllCookies_Method() {
        labelOutput = await CookieStorage.GetAllCookies(CancellationToken.None);
    }

    public const string BUTTON_GET_LENGTH_PROPERTY = "cookie-storage-get-length-property";
    private async Task GetLength_Property() {
        int length = await CookieStorage.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_GET_LENGTH_METHOD = "cookie-storage-get-length-method";
    private async Task GetLength_Method() {
        int length = await CookieStorage.GetLength(CancellationToken.None);
        labelOutput = length.ToString();
    }

    public const string BUTTON_KEY = "cookie-storage-key";
    private async Task Key() {
        labelOutput = await CookieStorage.Key(TEST_KEY_INDEX) ?? $"key {TEST_KEY_INDEX} is not present";
    }

    public const string BUTTON_GET_COOKIE = "cookie-storage-get-cookie";
    private async Task GetCookie() {
        labelOutput = await CookieStorage.GetCookie(TEST_GET_COOKIE) ?? $"key '{TEST_GET_COOKIE}' is not present";
    }

    public const string BUTTON_SET_COOKIE = "cookie-storage-set-cookie";
    private async Task SetCookie() {
        await CookieStorage.SetCookie(TEST_SET_COOKIE_KEY, TEST_SET_COOKIE_VALUE, sameSite: "strict");
    }

    public const string BUTTON_REMOVE_COOKIE = "cookie-storage-remove-cookie";
    private async Task RemoveCookie() {
        await CookieStorage.RemoveCookie(TEST_REMOVE_COOKIE);
    }

    public const string BUTTON_CLEAR = "cookie-storage-clear";
    private async Task Clear() {
        await CookieStorage.Clear();
    }
}

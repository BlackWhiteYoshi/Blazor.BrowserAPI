using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class CookieStorageInProcessGroup : ComponentBase {
    private const int TEST_KEY_INDEX = 0;
    public const string TEST_GET_COOKIE = "get-cookie-test-inprocess";
    public const string TEST_SET_COOKIE_KEY = "set-cookie-key-test-inprocess";
    public const string TEST_SET_COOKIE_VALUE = "set-cookie-value-test-inprocess";
    public const string TEST_REMOVE_COOKIE = "remove-cookie-test-inprocess";


    [Inject]
    public required ICookieStorageInProcess CookieStorage { private get; init; }


    public const string LABEL_OUTPUT = "cookie-storage-inprocess-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_ALL_COOKIES = "cookie-storage-inprocess-get-all-cookies";
    private void GetAllCookies() {
        labelOutput = CookieStorage.AllCookies;
    }

    public const string BUTTON_GET_LENGTH = "cookie-storage-inprocess-get-length";
    private void GetLength() {
        int length = CookieStorage.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_KEY = "cookie-storage-inprocess-key";
    private void Key() {
        labelOutput = CookieStorage.Key(TEST_KEY_INDEX) ?? $"key ({TEST_KEY_INDEX}) is not present";
    }

    public const string BUTTON_GET_COOKIE = "cookie-storage-inprocess-get-cookie";
    private void GetCookie() {
        labelOutput = CookieStorage.GetCookie(TEST_GET_COOKIE) ?? $"key '{TEST_GET_COOKIE}' is not present";
    }

    public const string BUTTON_SET_COOKIE = "cookie-storage-inprocess-set-cookie";
    private void SetCookie() {
        CookieStorage.SetCookie(TEST_SET_COOKIE_KEY, TEST_SET_COOKIE_VALUE, sameSite: "strict");
    }

    public const string BUTTON_REMOVE_COOKIE = "cookie-storage-inprocess-remove-cookie";
    private void RemoveCookie() {
        CookieStorage.RemoveCookie(TEST_REMOVE_COOKIE);
    }

    public const string BUTTON_CLEAR = "cookie-storage-inprocess-clear";
    private void Clear() {
        CookieStorage.Clear();
    }
}

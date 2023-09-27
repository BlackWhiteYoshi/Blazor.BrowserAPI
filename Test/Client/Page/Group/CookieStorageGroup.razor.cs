using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class CookieStorageGroup {
    public const string DATA_TESTID_GET_ALL_COOKIES_PROPERTY = "cookie-storage-get-all-cookies-property";
    public const string DATA_TESTID_GET_ALL_COOKIES_METHOD = "cookie-storage-get-all-cookies-method";
    public const string DATA_TESTID_GET_LENGTH_PROPERTY = "cookie-storage-get-length-property";
    public const string DATA_TESTID_GET_LENGTH_METHOD = "cookie-storage-get-length-method";
    public const string DATA_TESTID_KEY = "cookie-storage-key";
    public const string DATA_TESTID_GET_COOKIE = "cookie-storage-get-cookie";
    public const string DATA_TESTID_SET_COOKIE = "cookie-storage-set-cookie";
    public const string DATA_TESTID_REMOVE_COOKIE = "cookie-storage-remove-cookie";
    public const string DATA_TESTID_CLEAR = "cookie-storage-clear";

    public const string DATA_TESTID_GET_ALL_COOKIES_INPROCESS = "cookie-storage-get-all-cookies-inprocess";
    public const string DATA_TESTID_GET_LENGTH_INPROCESS = "cookie-storage-get-length-inprocess";
    public const string DATA_TESTID_KEY_INPROCESS = "cookie-storage-key-inprocess";
    public const string DATA_TESTID_GET_COOKIE_INPROCESS = "cookie-storage-get-cookie-inprocess";
    public const string DATA_TESTID_SET_COOKIE_INPROCESS = "cookie-storage-set-cookie-inprocess";
    public const string DATA_TESTID_REMOVE_COOKIE_INPROCESS = "cookie-storage-remove-cookie-inprocess";
    public const string DATA_TESTID_CLEAR_INPROCESS = "cookie-storage-clear-inprocess";

    public const string DATA_TESTID_OUTPUT = "cookie-storage-output";

    private const int KEY_INDEX_TEST = 0;
    public const string GET_COOKIE_TEST = "get-cookie-test";
    public const string SET_COOKIE_KEY_TEST = "set-cookie-key-test";
    public const string SET_COOKIE_VALUE_TEST = "set-cookie-value-test";
    public const string REMOVE_COOKIE_TEST = "remove-cookie-test";


    [Inject]
    public required ICookieStorage CookieStorage { private get; init; }

    [Inject]
    public required ICookieStorageInProcess CookieStorageInProcess { private get; init; }

    private string labelOutput = string.Empty;


    private async Task GetAllCookies_Property() {
        labelOutput = await CookieStorage.AllCookies;
    }

    private async Task GetAllCookies_Method() {
        labelOutput = await CookieStorage.GetAllCookies(default);
    }

    private async Task GetLength_Property() {
        int length = await CookieStorage.Length;
        labelOutput = length.ToString();
    }

    private async Task GetLength_Method() {
        int length = await CookieStorage.GetLength(default);
        labelOutput = length.ToString();
    }

    private async Task Key() {
        labelOutput = await CookieStorage.Key(KEY_INDEX_TEST) ?? throw new Exception($"key {KEY_INDEX_TEST} is not present");
    }

    private async Task GetCookie() {
        labelOutput = await CookieStorage.GetCookie(GET_COOKIE_TEST) ?? throw new Exception($"key '{GET_COOKIE_TEST}' is not present");
    }

    private async Task SetCookie() {
        await CookieStorage.SetCookie(SET_COOKIE_KEY_TEST, SET_COOKIE_VALUE_TEST, sameSite: CookieSameSite.Strict);
    }

    private async Task RemoveCookie() {
        await CookieStorage.RemoveCookie(REMOVE_COOKIE_TEST);
    }

    private async Task Clear() {
        await CookieStorage.Clear();
    }


    private void GetAllCookies_InProcess() {
        labelOutput = CookieStorageInProcess.AllCookies;
    }

    private void GetLength_InProcess() {
        int length = CookieStorageInProcess.Length;
        labelOutput = length.ToString();
    }

    private void Key_InProcess() {
        labelOutput = CookieStorageInProcess.Key(KEY_INDEX_TEST) ?? throw new Exception($"key ({KEY_INDEX_TEST}) is not present");
    }

    private void GetCookie_InProcess() {
        labelOutput = CookieStorageInProcess.GetCookie(GET_COOKIE_TEST) ?? throw new Exception($"key '{GET_COOKIE_TEST}' is not present");
    }

    private void SetCookie_InProcess() {
        CookieStorageInProcess.SetCookie(SET_COOKIE_KEY_TEST, SET_COOKIE_VALUE_TEST, sameSite: CookieSameSite.Strict);
    }

    private void RemoveCookie_InProcess() {
        CookieStorageInProcess.RemoveCookie(REMOVE_COOKIE_TEST);
    }

    private void Clear_InProcess() {
        CookieStorageInProcess.Clear();
    }
}

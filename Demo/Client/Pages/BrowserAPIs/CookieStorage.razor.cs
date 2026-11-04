using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class CookieStorage : ComponentBase {
    [Inject]
    public required ICookieStorage PCookieStorage { private get; init; }

    private (string key, string value)[]? cookies = null;
    private bool CookiesLoaded => cookies is not null;


    private async Task LoadCookies() {
        cookies = new (string, string)[await PCookieStorage.Length];
        for (int i = 0; i < cookies.Length; i++) {
            string key = (await PCookieStorage.Key(i))!;
            string value = (await PCookieStorage.GetCookie(key))!;
            cookies[i] = (key, value);
        }
    }

    private async Task OnCreateCookie() {
        string key;
        int i = 0;
        do {
            key = $"key{i++}";
        } while (cookies!.Any(((string key, string value) cookie) => cookie.key == key));
        const string value = "value";

        await PCookieStorage.SetCookie(key, value, secure: true);
        await LoadCookies();
    }

    private async Task OnKeyUpdate(ChangeEventArgs e, int index) {
        string newKey = (string)e.Value!;
        string oldKey = cookies![index].key;
        string value = cookies[index].value;

        await PCookieStorage.RemoveCookie(oldKey);
        await PCookieStorage.SetCookie(newKey, value, secure: true);
        await LoadCookies();
    }

    private async Task OnValueUpdate(ChangeEventArgs e, int index) {
        string newValue = (string)e.Value!;
        string key = cookies![index].key;

        await PCookieStorage.SetCookie(key, newValue, secure: true);
        await LoadCookies();
    }

    private async Task OnDeleteCookie(int index) {
        string key = cookies![index].key;

        await PCookieStorage.RemoveCookie(key);
        await LoadCookies();
    }

    private async Task OnDeleteAllCookies() {
        cookies = [];
        await PCookieStorage.Clear();
    }
}

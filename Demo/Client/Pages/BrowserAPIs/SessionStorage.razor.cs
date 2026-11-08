using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class SessionStorage : ComponentBase {
    [Inject]
    public required ISessionStorage PSessionStorage { private get; init; }

    private (string key, string value)[]? items = null;
    private bool StorageLoaded => items is not null;


    private async Task LoadSessionStorage() {
        items = new (string, string)[await PSessionStorage.Length];
        for (int i = 0; i < items.Length; i++) {
            string key = (await PSessionStorage.Key(i))!;
            string value = (await PSessionStorage.GetItem(key))!;
            items[i] = (key, value);
        }
    }

    private async Task OnCreateItem() {
        string key;
        int i = 0;
        do {
            key = $"key{i++}";
        } while (items!.Any(((string key, string value) cookie) => cookie.key == key));
        const string value = "value";

        await PSessionStorage.SetItem(key, value);
        await LoadSessionStorage();
    }

    private async Task OnKeyUpdate(ChangeEventArgs e, int index) {
        string newKey = (string)e.Value!;
        string oldKey = items![index].key;
        string value = items[index].value;

        await PSessionStorage.RemoveItem(oldKey);
        await PSessionStorage.SetItem(newKey, value);
        await LoadSessionStorage();
    }

    private async Task OnValueUpdate(ChangeEventArgs e, int index) {
        string newValue = (string)e.Value!;
        string key = items![index].key;

        await PSessionStorage.SetItem(key, newValue);
        await LoadSessionStorage();
    }

    private async Task OnDeleteItem(int index) {
        string key = items![index].key;

        await PSessionStorage.RemoveItem(key);
        await LoadSessionStorage();
    }

    private async Task OnDeleteAllItems() {
        items = [];
        await PSessionStorage.Clear();
    }
}

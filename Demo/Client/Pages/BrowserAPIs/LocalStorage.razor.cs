using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class LocalStorage : ComponentBase {
    [Inject]
    public required ILocalStorage PLocalStorage { private get; init; }

    private (string key, string value)[]? items = null;
    private bool StorageLoaded => items is not null;


    private async Task LoadLocalStorage() {
        items = new (string, string)[await PLocalStorage.Length];
        for (int i = 0; i < items.Length; i++) {
            string key = (await PLocalStorage.Key(i))!;
            string value = (await PLocalStorage.GetItem(key))!;
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

        await PLocalStorage.SetItem(key, value);
        await LoadLocalStorage();
    }

    private async Task OnKeyUpdate(ChangeEventArgs e, int index) {
        string newKey = (string)e.Value!;
        string oldKey = items![index].key;
        string value = items[index].value;

        await PLocalStorage.RemoveItem(oldKey);
        await PLocalStorage.SetItem(newKey, value);
        await LoadLocalStorage();
    }

    private async Task OnValueUpdate(ChangeEventArgs e, int index) {
        string newValue = (string)e.Value!;
        string key = items![index].key;

        await PLocalStorage.SetItem(key, newValue);
        await LoadLocalStorage();
    }

    private async Task OnDeleteItem(int index) {
        string key = items![index].key;

        await PLocalStorage.RemoveItem(key);
        await LoadLocalStorage();
    }

    private async Task OnDeleteAllItems() {
        items = [];
        await PLocalStorage.Clear();
    }
}

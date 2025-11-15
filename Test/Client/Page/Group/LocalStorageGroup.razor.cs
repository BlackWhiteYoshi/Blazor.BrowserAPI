using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public partial class LocalStorageGroup : ComponentBase {
    private const int TEST_KEY_INDEX = 0;
    public const string TEST_GET_ITEM = "get-item-test";
    public const string TEST_SET_ITEM_KEY = "set-item-key-test";
    public const string TEST_SET_ITEM_VALUE = "set-item-value-test";
    public const string TEST_REMOVE_ITEM = "remove-item-test";


    [Inject]
    public required ILocalStorage LocalStorage { private get; init; }


    public const string LABEL_OUTPUT = "local-storage-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_LENGTH_PROPERTY = "local-storage-get-length-property";
    private async Task GetLength_Property() {
        int length = await LocalStorage.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_GET_LENGTH_METHOD = "local-storage-get-length-method";
    private async Task GetLength_Method() {
        int length = await LocalStorage.GetLength(CancellationToken.None);
        labelOutput = length.ToString();
    }

    public const string BUTTON_KEY = "local-storage-key";
    private async Task Key() {
        labelOutput = await LocalStorage.Key(TEST_KEY_INDEX) ?? $"key {TEST_KEY_INDEX} is not present";
    }

    public const string BUTTON_GET_ITEM = "local-storage-get-item";
    private async Task GetItem() {
        labelOutput = await LocalStorage.GetItem(TEST_GET_ITEM) ?? $"key '{TEST_GET_ITEM}' is not present";
    }

    public const string BUTTON_SET_ITEM = "local-storage-set-item";
    private async Task SetItem() {
        await LocalStorage.SetItem(TEST_SET_ITEM_KEY, TEST_SET_ITEM_VALUE);
    }

    public const string BUTTON_REMOVE_ITEM = "local-storage-remove-item";
    private async Task RemoveItem() {
        await LocalStorage.RemoveItem(TEST_REMOVE_ITEM);
    }

    public const string BUTTON_CLEAR = "local-storage-clear";
    private async Task Clear() {
        await LocalStorage.Clear();
    }
}

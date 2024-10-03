using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public partial class SessionStorageGroup : ComponentBase {
    private const int TEST_KEY_INDEX = 0;
    public const string TEST_GET_ITEM = "get-item-test";
    public const string TEST_SET_ITEM_KEY = "set-item-key-test";
    public const string TEST_SET_ITEM_VALUE = "set-item-value-test";
    public const string TEST_REMOVE_ITEM = "remove-item-test";


    [Inject]
    public required ISessionStorage SessionStorage { private get; init; }


    public const string LABEL_OUTPUT = "session-storage-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_LENGTH_PROPERTY = "session-storage-get-length-property";
    private async Task GetLength_Property() {
        int length = await SessionStorage.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_GET_LENGTH_METHOD = "session-storage-get-length-method";
    private async Task GetLength_Method() {
        int length = await SessionStorage.GetLength(default);
        labelOutput = length.ToString();
    }

    public const string BUTTON_KEY = "session-storage-key";
    private async Task Key() {
        labelOutput = await SessionStorage.Key(TEST_KEY_INDEX) ?? $"key {TEST_KEY_INDEX} is not present";
    }

    public const string BUTTON_GET_ITEM = "session-storage-get-item";
    private async Task GetItem() {
        labelOutput = await SessionStorage.GetItem(TEST_GET_ITEM) ?? $"key '{TEST_GET_ITEM}' is not present";
    }

    public const string BUTTON_SET_ITEM = "session-storage-set-item";
    private async Task SetItem() {
        await SessionStorage.SetItem(TEST_SET_ITEM_KEY, TEST_SET_ITEM_VALUE);
    }

    public const string BUTTON_REMOVE_ITEM = "session-storage-remove-item";
    private async Task RemoveItem() {
        await SessionStorage.RemoveItem(TEST_REMOVE_ITEM);
    }

    public const string BUTTON_CLEAR = "session-storage-clear";
    private async Task Clear() {
        await SessionStorage.Clear();
    }
}

using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public partial class LocalStorageInProcessGroup : ComponentBase {
    private const int TEST_KEY_INDEX = 0;
    public const string TEST_GET_ITEM = "get-item-test-inprocess";
    public const string TEST_SET_ITEM_KEY = "set-item-key-test-inprocess";
    public const string TEST_SET_ITEM_VALUE = "set-item-value-test-inprocess";
    public const string TEST_REMOVE_ITEM = "remove-item-test-inprocess";


    [Inject]
    public required ILocalStorageInProcess LocalStorage { private get; init; }


    public const string LABEL_OUTPUT = "local-storage-inprocess-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_LENGTH = "local-storage-inprocess-get-length";
    private void GetLength() {
        int length = LocalStorage.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_KEY = "local-storage-inprocess-key";
    private void Key() {
        labelOutput = LocalStorage.Key(TEST_KEY_INDEX) ?? $"key ({TEST_KEY_INDEX}) is not present";
    }

    public const string BUTTON_GET_ITEM = "local-storage-inprocess-get-item";
    private void GetItem() {
        labelOutput = LocalStorage.GetItem(TEST_GET_ITEM) ?? $"key '{TEST_GET_ITEM}' is not present";
    }

    public const string BUTTON_SET_ITEM = "local-storage-inprocess-set-item";
    private void SetItem() {
        LocalStorage.SetItem(TEST_SET_ITEM_KEY, TEST_SET_ITEM_VALUE);
    }

    public const string BUTTON_REMOVE_ITEM = "local-storage-inprocess-remove-item";
    private void RemoveItem() {
        LocalStorage.RemoveItem(TEST_REMOVE_ITEM);
    }

    public const string BUTTON_CLEAR = "local-storage-inprocess-clear";
    private void Clear() {
        LocalStorage.Clear();
    }
}

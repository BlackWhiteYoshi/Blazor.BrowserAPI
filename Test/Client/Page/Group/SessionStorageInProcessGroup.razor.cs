using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public partial class SessionStorageInProcessGroup : ComponentBase {
    private const int TEST_KEY_INDEX = 0;
    public const string TEST_GET_ITEM = "get-item-test-inprocess";
    public const string TEST_SET_ITEM_KEY = "set-item-key-test-inprocess";
    public const string TEST_SET_ITEM_VALUE = "set-item-value-test-inprocess";
    public const string TEST_REMOVE_ITEM = "remove-item-test-inprocess";


    [Inject]
    public required ISessionStorageInProcess SessionStorage { private get; init; }


    public const string LABEL_OUTPUT = "session-storage-inprocess-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_LENGTH = "session-storage-inprocess-get-length";
    private void GetLength() {
        int length = SessionStorage.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_KEY = "session-storage-inprocess-key";
    private void Key() {
        labelOutput = SessionStorage.Key(TEST_KEY_INDEX) ?? $"key ({TEST_KEY_INDEX}) is not present";
    }

    public const string BUTTON_GET_ITEM = "session-storage-inprocess-get-item";
    private void GetItem() {
        labelOutput = SessionStorage.GetItem(TEST_GET_ITEM) ?? $"key '{TEST_GET_ITEM}' is not present";
    }

    public const string BUTTON_SET_ITEM = "session-storage-inprocess-set-item";
    private void SetItem() {
        SessionStorage.SetItem(TEST_SET_ITEM_KEY, TEST_SET_ITEM_VALUE);
    }

    public const string BUTTON_REMOVE_ITEM = "session-storage-inprocess-remove-item";
    private void RemoveItem() {
        SessionStorage.RemoveItem(TEST_REMOVE_ITEM);
    }

    public const string BUTTON_CLEAR = "session-storage-inprocess-clear";
    private void Clear() {
        SessionStorage.Clear();
    }
}

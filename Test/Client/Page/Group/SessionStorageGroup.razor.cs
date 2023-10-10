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

    [Inject]
    public required ISessionStorageInProcess SessionStorageInProcess { private get; init; }


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
        labelOutput = await SessionStorage.Key(TEST_KEY_INDEX) ?? throw new Exception($"key {TEST_KEY_INDEX} is not present");
    }

    public const string BUTTON_GET_ITEM = "session-storage-get-item";
    private async Task GetItem() {
        labelOutput = await SessionStorage.GetItem(TEST_GET_ITEM) ?? throw new Exception($"key '{TEST_GET_ITEM}' is not present");
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


    public const string BUTTON_GET_LENGTH_INPROCESS = "session-storage-get-length-inprocess";
    private void GetLength_InProcess() {
        int length = SessionStorageInProcess.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_KEY_INPROCESS = "session-storage-key-inprocess";
    private void Key_InProcess() {
        labelOutput = SessionStorageInProcess.Key(TEST_KEY_INDEX) ?? throw new Exception($"key ({TEST_KEY_INDEX}) is not present");
    }

    public const string BUTTON_GET_ITEM_INPROCESS = "session-storage-get-item-inprocess";
    private void GetItem_InProcess() {
        labelOutput = SessionStorageInProcess.GetItem(TEST_GET_ITEM) ?? throw new Exception($"key '{TEST_GET_ITEM}' is not present");
    }

    public const string BUTTON_SET_ITEM_INPROCESS = "session-storage-set-item-inprocess";
    private void SetItem_InProcess() {
        SessionStorageInProcess.SetItem(TEST_SET_ITEM_KEY, TEST_SET_ITEM_VALUE);
    }

    public const string BUTTON_REMOVE_ITEM_INPROCESS = "session-storage-remove-item-inprocess";
    private void RemoveItem_InProcess() {
        SessionStorageInProcess.RemoveItem(TEST_REMOVE_ITEM);
    }

    public const string BUTTON_CLEAR_INPROCESS = "session-storage-clear-inprocess";
    private void Clear_InProcess() {
        SessionStorageInProcess.Clear();
    }
}

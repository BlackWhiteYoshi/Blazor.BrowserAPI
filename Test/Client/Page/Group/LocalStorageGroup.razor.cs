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

    [Inject]
    public required ILocalStorageInProcess LocalStorageInProcess { private get; init; }


    public const string LABEL_OUTPUT = "local-storage-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_LENGTH_PROPERTY = "local-storage-get-length-property";
    private async Task GetLength_Property() {
        int length = await LocalStorage.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_GET_LENGTH_METHOD = "local-storage-get-length-method";
    private async Task GetLength_Method() {
        int length = await LocalStorage.GetLength(default);
        labelOutput = length.ToString();
    }

    public const string BUTTON_KEY = "local-storage-key";
    private async Task Key() {
        labelOutput = await LocalStorage.Key(TEST_KEY_INDEX) ?? throw new Exception($"key {TEST_KEY_INDEX} is not present");
    }

    public const string BUTTON_GET_ITEM = "local-storage-get-item";
    private async Task GetItem() {
        labelOutput = await LocalStorage.GetItem(TEST_GET_ITEM) ?? throw new Exception($"key '{TEST_GET_ITEM}' is not present");
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


    public const string BUTTON_GET_LENGTH_INPROCESS = "local-storage-get-length-inprocess";
    private void GetLength_InProcess() {
        int length = LocalStorageInProcess.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_KEY_INPROCESS = "local-storage-key-inprocess";
    private void Key_InProcess() {
        labelOutput = LocalStorageInProcess.Key(TEST_KEY_INDEX) ?? throw new Exception($"key ({TEST_KEY_INDEX}) is not present");
    }

    public const string BUTTON_GET_ITEM_INPROCESS = "local-storage-get-item-inprocess";
    private void GetItem_InProcess() {
        labelOutput = LocalStorageInProcess.GetItem(TEST_GET_ITEM) ?? throw new Exception($"key '{TEST_GET_ITEM}' is not present");
    }

    public const string BUTTON_SET_ITEM_INPROCESS = "local-storage-set-item-inprocess";
    private void SetItem_InProcess() {
        LocalStorageInProcess.SetItem(TEST_SET_ITEM_KEY, TEST_SET_ITEM_VALUE);
    }

    public const string BUTTON_REMOVE_ITEM_INPROCESS = "local-storage-remove-item-inprocess";
    private void RemoveItem_InProcess() {
        LocalStorageInProcess.RemoveItem(TEST_REMOVE_ITEM);
    }

    public const string BUTTON_CLEAR_INPROCESS = "local-storage-clear-inprocess";
    private void Clear_InProcess() {
        LocalStorageInProcess.Clear();
    }
}

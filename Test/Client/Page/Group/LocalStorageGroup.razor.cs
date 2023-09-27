using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public partial class LocalStorageGroup : ComponentBase {
    public const string DATA_TESTID_GET_LENGTH_PROPERTY = "local-storage-get-length-property";
    public const string DATA_TESTID_GET_LENGTH_METHOD = "local-storage-get-length-method";
    public const string DATA_TESTID_KEY = "local-storage-key";
    public const string DATA_TESTID_GET_ITEM = "local-storage-get-item";
    public const string DATA_TESTID_SET_ITEM = "local-storage-set-item";
    public const string DATA_TESTID_REMOVE_ITEM = "local-storage-remove-item";
    public const string DATA_TESTID_CLEAR = "local-storage-clear";

    public const string DATA_TESTID_GET_LENGTH_INPROCESS = "local-storage-get-length-inprocess";
    public const string DATA_TESTID_KEY_INPROCESS = "local-storage-key-inprocess";
    public const string DATA_TESTID_GET_ITEM_INPROCESS = "local-storage-get-item-inprocess";
    public const string DATA_TESTID_SET_ITEM_INPROCESS = "local-storage-set-item-inprocess";
    public const string DATA_TESTID_REMOVE_ITEM_INPROCESS = "local-storage-remove-item-inprocess";
    public const string DATA_TESTID_CLEAR_INPROCESS = "local-storage-clear-inprocess";

    public const string DATA_TESTID_OUTPUT = "local-storage-output";

    private const int KEY_INDEX_TEST = 0;
    public const string GET_ITEM_TEST = "get-item-test";
    public const string SET_ITEM_KEY_TEST = "set-item-key-test";
    public const string SET_ITEM_VALUE_TEST = "set-item-value-test";
    public const string REMOVE_ITEM_TEST = "remove-item-test";


    [Inject]
    public required ILocalStorage LocalStorage { private get; init; }

    [Inject]
    public required ILocalStorageInProcess LocalStorageInProcess { private get; init; }

    private string labelOutput = string.Empty;


    private async Task GetLength_Property() {
        int length = await LocalStorage.Length;
        labelOutput = length.ToString();
    }

    private async Task GetLength_Method() {
        int length = await LocalStorage.GetLength(default);
        labelOutput = length.ToString();
    }

    private async Task Key() {
        labelOutput = await LocalStorage.Key(KEY_INDEX_TEST) ?? throw new Exception($"key {KEY_INDEX_TEST} is not present");
    }

    private async Task GetItem() {
        labelOutput = await LocalStorage.GetItem(GET_ITEM_TEST) ?? throw new Exception($"key '{GET_ITEM_TEST}' is not present");
    }

    private async Task SetItem() {
        await LocalStorage.SetItem(SET_ITEM_KEY_TEST, SET_ITEM_VALUE_TEST);
    }

    private async Task RemoveItem() {
        await LocalStorage.RemoveItem(REMOVE_ITEM_TEST);
    }

    private async Task Clear() {
        await LocalStorage.Clear();
    }


    private void GetLength_InProcess() {
        int length = LocalStorageInProcess.Length;
        labelOutput = length.ToString();
    }

    private void Key_InProcess() {
        labelOutput = LocalStorageInProcess.Key(KEY_INDEX_TEST) ?? throw new Exception($"key ({KEY_INDEX_TEST}) is not present");
    }

    private void GetItem_InProcess() {
        labelOutput = LocalStorageInProcess.GetItem(GET_ITEM_TEST) ?? throw new Exception($"key '{GET_ITEM_TEST}' is not present");
    }

    private void SetItem_InProcess() {
        LocalStorageInProcess.SetItem(SET_ITEM_KEY_TEST, SET_ITEM_VALUE_TEST);
    }

    private void RemoveItem_InProcess() {
        LocalStorageInProcess.RemoveItem(REMOVE_ITEM_TEST);
    }

    private void Clear_InProcess() {
        LocalStorageInProcess.Clear();
    }
}

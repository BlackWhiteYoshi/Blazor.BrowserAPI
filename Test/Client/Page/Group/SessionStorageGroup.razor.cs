using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public partial class SessionStorageGroup : ComponentBase {
    public const string DATA_TESTID_GET_LENGTH_PROPERTY = "session-storage-get-length-property";
    public const string DATA_TESTID_GET_LENGTH_METHOD = "session-storage-get-length-method";
    public const string DATA_TESTID_KEY = "session-storage-key";
    public const string DATA_TESTID_GET_ITEM = "session-storage-get-item";
    public const string DATA_TESTID_SET_ITEM = "session-storage-set-item";
    public const string DATA_TESTID_REMOVE_ITEM = "session-storage-remove-item";
    public const string DATA_TESTID_CLEAR = "session-storage-clear";

    public const string DATA_TESTID_GET_LENGTH_INPROCESS = "session-storage-get-length-inprocess";
    public const string DATA_TESTID_KEY_INPROCESS = "session-storage-key-inprocess";
    public const string DATA_TESTID_GET_ITEM_INPROCESS = "session-storage-get-item-inprocess";
    public const string DATA_TESTID_SET_ITEM_INPROCESS = "session-storage-set-item-inprocess";
    public const string DATA_TESTID_REMOVE_ITEM_INPROCESS = "session-storage-remove-item-inprocess";
    public const string DATA_TESTID_CLEAR_INPROCESS = "session-storage-clear-inprocess";

    public const string DATA_TESTID_OUTPUT = "session-storage-output";

    private const int KEY_INDEX_TEST = 0;
    public const string GET_ITEM_TEST = "get-item-test";
    public const string SET_ITEM_KEY_TEST = "set-item-key-test";
    public const string SET_ITEM_VALUE_TEST = "set-item-value-test";
    public const string REMOVE_ITEM_TEST = "remove-item-test";


    [Inject]
    public required ISessionStorage SessionStorage { private get; init; }

    [Inject]
    public required ISessionStorageInProcess SessionStorageInProcess { private get; init; }

    private string labelOutput = string.Empty;


    private async Task GetLength_Property() {
        int length = await SessionStorage.Length;
        labelOutput = length.ToString();
    }

    private async Task GetLength_Method() {
        int length = await SessionStorage.GetLength(default);
        labelOutput = length.ToString();
    }

    private async Task Key() {
        labelOutput = await SessionStorage.Key(KEY_INDEX_TEST) ?? throw new Exception($"key {KEY_INDEX_TEST} is not present");
    }

    private async Task GetItem() {
        labelOutput = await SessionStorage.GetItem(GET_ITEM_TEST) ?? throw new Exception($"key '{GET_ITEM_TEST}' is not present");
    }

    private async Task SetItem() {
        await SessionStorage.SetItem(SET_ITEM_KEY_TEST, SET_ITEM_VALUE_TEST);
    }

    private async Task RemoveItem() {
        await SessionStorage.RemoveItem(REMOVE_ITEM_TEST);
    }

    private async Task Clear() {
        await SessionStorage.Clear();
    }


    private void GetLength_InProcess() {
        int length = SessionStorageInProcess.Length;
        labelOutput = length.ToString();
    }

    private void Key_InProcess() {
        labelOutput = SessionStorageInProcess.Key(KEY_INDEX_TEST) ?? throw new Exception($"key ({KEY_INDEX_TEST}) is not present");
    }

    private void GetItem_InProcess() {
        labelOutput = SessionStorageInProcess.GetItem(GET_ITEM_TEST) ?? throw new Exception($"key '{GET_ITEM_TEST}' is not present");
    }

    private void SetItem_InProcess() {
        SessionStorageInProcess.SetItem(SET_ITEM_KEY_TEST, SET_ITEM_VALUE_TEST);
    }

    private void RemoveItem_InProcess() {
        SessionStorageInProcess.RemoveItem(REMOVE_ITEM_TEST);
    }

    private void Clear_InProcess() {
        SessionStorageInProcess.Clear();
    }
}

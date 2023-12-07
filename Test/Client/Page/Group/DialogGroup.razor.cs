using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class DialogGroup : ComponentBase, IAsyncDisposable {
    public const string TEST_RETURN_VALUE = "return-value-test";
    public const string TEST_CANCEL_EVENT = "cancel-event-test";
    public const string TEST_CLOSE_EVENT = "close-event-test";


    [Inject]
    public required IDialogFactory DialogFactory { private get; init; }

    private IDialog? _dialog;
    private IDialog Dialog => _dialog ??= DialogFactory.Create(dialogElement);

    private IDialogInProcess? _dialogInProcess;
    private IDialogInProcess DialogInProcess => _dialogInProcess ??= DialogFactory.CreateInProcess(dialogElement);


    public const string LABEL_OUTPUT = "dialog-output";
    private string labelOutput = string.Empty;

    public const string DIALOG_ELEMENT = "dialog-dialog-element";
    private ElementReference dialogElement;

    public ValueTask DisposeAsync() {
        _dialogInProcess?.Dispose();
        return _dialog?.DisposeAsync() ?? ValueTask.CompletedTask;
    }


    public const string BUTTON_GET_OPEN_PROPERTY = "dialog-get-open-property";
    private async Task GetOpen_Property() {
        bool state = await Dialog.Open;
        labelOutput = state.ToString();
    }

    public const string BUTTON_GET_OPEN_METHOD = "dialog-get-open-method";
    private async Task GetOpen_Method() {
        bool state = await Dialog.GetOpen(default);
        labelOutput = state.ToString();
    }

    public const string BUTTON_SET_OPEN = "dialog-set-open";
    private async Task SetOpen() {
        await Dialog.SetOpen(true);
    }


    public const string BUTTON_GET_RETURN_VALUE_PROPERTY = "dialog-get-return-value-property";
    private async Task GetReturnValue_Property() {
        labelOutput = await Dialog.ReturnValue;
    }

    public const string BUTTON_GET_RETURN_VALUE_METHOD = "dialog-get-return-value-method";
    private async Task GetReturnValue_Method() {
        labelOutput = await Dialog.GetReturnValue(default);
    }

    public const string BUTTON_SET_RETURN_VALUE = "dialog-set-return-value";
    private async Task SetReturnValue() {
        await Dialog.SetReturnValue(TEST_RETURN_VALUE);
    }


    public const string BUTTON_SHOW = "dialog-show";
    private async Task Show() {
        await Dialog.Show();
    }

    public const string BUTTON_SHOW_MODAL = "dialog-show-modal";
    private async Task ShowModal() {
        await Dialog.ShowModal();
    }

    public const string BUTTON_CLOSE = "dialog-close";
    private async Task Close() {
        await Dialog.Close();
    }

    public const string BUTTON_CLOSE_RETURN_VALUE = "dialog-close-return-value";
    private async Task CloseReturnValue() {
        await Dialog.Close(TEST_RETURN_VALUE);
    }


    public const string BUTTON_REGISTER_ON_CANCEL = "dialog-cancel-event";
    private void RegisterOnCancel() {
        Dialog.OnCancel += () => {
            labelOutput = TEST_CANCEL_EVENT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CLOSE = "dialog-close-event";
    private void RegisterOnClose() {
        Dialog.OnClose += () => {
            labelOutput = TEST_CLOSE_EVENT;
            StateHasChanged();
        };
    }



    public const string BUTTON_GET_OPEN_INPROCESS = "dialog-get-open-inprocess";
    private void GetOpen_InProcess() {
        bool state = DialogInProcess.Open;
        labelOutput = state.ToString();
    }

    public const string BUTTON_SET_OPEN_INPROCESS = "dialog-set-open-inprocess";
    private void SetOpen_InProcess() {
        DialogInProcess.Open = true;
    }


    public const string BUTTON_GET_RETURN_VALUE_INPROCESS = "dialog-get-return-value-inprocess";
    private void GetReturnValue_InProcess() {
        labelOutput = DialogInProcess.ReturnValue;
    }

    public const string BUTTON_SET_RETURN_VALUE_INPROCESS = "dialog-set-return-value-inprocess";
    private void SetReturnValue_InProcess() {
        DialogInProcess.ReturnValue = TEST_RETURN_VALUE;
    }


    public const string BUTTON_SHOW_INPROCESS = "dialog-show-inprocess";
    private void Show_InProcess() {
        DialogInProcess.Show();
    }

    public const string BUTTON_SHOW_MODAL_INPROCESS = "dialog-show-modal-inprocess";
    private void ShowModal_InProcess() {
        DialogInProcess.ShowModal();
    }

    public const string BUTTON_CLOSE_INPROCESS = "dialog-close-inprocess";
    private void Close_InProcess() {
        DialogInProcess.Close();
    }

    public const string BUTTON_CLOSE_RETURN_VALUE_INPROCESS = "dialog-close-return-value-inprocess";
    private void CloseReturnValue_InProcess() {
        DialogInProcess.Close(TEST_RETURN_VALUE);
    }


    public const string BUTTON_REGISTER_ON_CANCEL_INPROCESS = "dialog-cancel-event-inprocess";
    private void RegisterOnCancel_InProcess() {
        DialogInProcess.OnCancel += () => {
            labelOutput = TEST_CANCEL_EVENT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CLOSE_INPROCESS = "dialog-close-event-inprocess";
    private void RegisterOnClose_InProcess() {
        DialogInProcess.OnClose += () => {
            labelOutput = TEST_CLOSE_EVENT;
            StateHasChanged();
        };
    }
}

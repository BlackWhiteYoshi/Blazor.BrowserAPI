using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class DialogInProcessGroup : ComponentBase, IDisposable {
    public const string TEST_RETURN_VALUE = "return-value-test-inprocess";
    public const string TEST_CANCEL_EVENT = "cancel-event-test-inprocess";
    public const string TEST_CLOSE_EVENT = "close-event-test-inprocess";


    [Inject]
    public required IElementFactoryInProcess ElementFactory { private get; init; }


    private IDialogInProcess? _dialog;
    private IDialogInProcess Dialog => _dialog ??= ElementFactory.CreateDialog(dialogElement);


    public const string LABEL_OUTPUT = "dialog-inprocess-output";
    private string labelOutput = string.Empty;

    public const string DIALOG_ELEMENT = "dialog-inprocess-dialog-element";
    private ElementReference dialogElement;

    public void Dispose() => _dialog?.Dispose();


    public const string BUTTON_GET_OPEN = "dialog-inprocess-get-open";
    private void GetOpen() {
        bool state = Dialog.Open;
        labelOutput = state.ToString();
    }

    public const string BUTTON_SET_OPEN = "dialog-inprocess-set-open";
    private void SetOpen() {
        Dialog.Open = true;
    }


    public const string BUTTON_GET_RETURN_VALUE = "dialog-inprocess-get-return-value";
    private void GetReturnValue() {
        labelOutput = Dialog.ReturnValue;
    }

    public const string BUTTON_SET_RETURN_VALUE = "dialog-inprocess-set-return-value";
    private void SetReturnValue() {
        Dialog.ReturnValue = TEST_RETURN_VALUE;
    }


    public const string BUTTON_SHOW = "dialog-inprocess-show";
    private void Show() {
        Dialog.Show();
    }

    public const string BUTTON_SHOW_MODAL = "dialog-inprocess-show-modal";
    private void ShowModal() {
        Dialog.ShowModal();
    }

    public const string BUTTON_CLOSE = "dialog-inprocess-close";
    private void Close() {
        Dialog.Close();
    }

    public const string BUTTON_CLOSE_RETURN_VALUE = "dialog-inprocess-close-return-value";
    private void CloseReturnValue() {
        Dialog.Close(TEST_RETURN_VALUE);
    }


    public const string BUTTON_REGISTER_ON_CANCEL = "dialog-inprocess-cancel-event";
    private void RegisterOnCancel() {
        Dialog.OnCancel += () => {
            labelOutput = TEST_CANCEL_EVENT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CLOSE = "dialog-inprocess-close-event";
    private void RegisterOnClose() {
        Dialog.OnClose += () => {
            labelOutput = TEST_CLOSE_EVENT;
            StateHasChanged();
        };
    }
}

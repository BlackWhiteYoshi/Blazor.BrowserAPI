using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class HTMLDialogElementInProcessGroup : ComponentBase, IDisposable {
    public const string TEST_CLOSED_BY = "any";
    public const string TEST_RETURN_VALUE = "return-value-test-inprocess";
    public const string TEST_EVENT_CLOSE = "close-event-test-inprocess";
    public const string TEST_EVENT_CANCEL = "cancel-event-test-inprocess";


    [Inject]
    public required IElementFactoryInProcess ElementFactory { private get; init; }


    private IHTMLDialogElementInProcess? _dialog;
    private IHTMLDialogElementInProcess Dialog => _dialog ??= ElementFactory.CreateHTMLDialogElement(dialogElement);


    public const string LABEL_OUTPUT = "htmldialogelement-inprocess-output";
    private string labelOutput = string.Empty;

    public const string DIALOG_ELEMENT = "htmldialogelement-inprocess-dialog-element";
    private ElementReference dialogElement;

    public void Dispose() => _dialog?.Dispose();


    public const string BUTTON_TO_HTML_ELEMENT = "htmldialogelement-inprocess-to-html-element";
    private void ToHTMLElement() {
        using IHTMLElementInProcess htmlElement = Dialog.ToHTMLElement();
        labelOutput = (htmlElement is not null).ToString();
    }


    public const string BUTTON_GET_CLOSED_BY = "htmldialogelement-inprocess-get-closed-by";
    private void GetClosedBy() {
        labelOutput = Dialog.ClosedBy;
    }

    public const string BUTTON_SET_CLOSED_BY = "htmldialogelement-inprocess-set-closed-by";
    private void SetClosedBy() {
        Dialog.ClosedBy = TEST_CLOSED_BY;
    }


    public const string BUTTON_GET_OPEN = "htmldialogelement-inprocess-get-open";
    private void GetOpen() {
        bool state = Dialog.Open;
        labelOutput = state.ToString();
    }

    public const string BUTTON_SET_OPEN = "htmldialogelement-inprocess-set-open";
    private void SetOpen() {
        Dialog.Open = true;
    }


    public const string BUTTON_GET_RETURN_VALUE = "htmldialogelement-inprocess-get-return-value";
    private void GetReturnValue() {
        labelOutput = Dialog.ReturnValue;
    }

    public const string BUTTON_SET_RETURN_VALUE = "htmldialogelement-inprocess-set-return-value";
    private void SetReturnValue() {
        Dialog.ReturnValue = TEST_RETURN_VALUE;
    }


    public const string BUTTON_SHOW = "htmldialogelement-inprocess-show";
    private void Show() {
        Dialog.Show();
    }

    public const string BUTTON_SHOW_MODAL = "htmldialogelement-inprocess-show-modal";
    private void ShowModal() {
        Dialog.ShowModal();
    }

    public const string BUTTON_CLOSE = "htmldialogelement-inprocess-close";
    private void Close() {
        Dialog.Close();
    }

    public const string BUTTON_CLOSE_RETURN_VALUE = "htmldialogelement-inprocess-close-return-value";
    private void CloseReturnValue() {
        Dialog.Close(TEST_RETURN_VALUE);
    }

    public const string BUTTON_REQUEST_CLOSE = "htmldialogelement-inprocess-request-close";
    private void RequestClose() {
        Dialog.RequestClose();
    }


    public const string BUTTON_REGISTER_ON_CLOSE = "htmldialogelement-inprocess-close-event";
    private void RegisterOnClose() {
        Dialog.OnClose += () => {
            labelOutput = TEST_EVENT_CLOSE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CANCEL = "htmldialogelement-inprocess-cancel-event";
    private void RegisterOnCancel() {
        Dialog.OnCancel += () => {
            labelOutput = TEST_EVENT_CANCEL;
            StateHasChanged();
        };
    }
}

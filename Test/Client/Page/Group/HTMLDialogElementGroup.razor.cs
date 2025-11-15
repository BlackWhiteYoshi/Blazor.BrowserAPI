using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class HTMLDialogElementGroup : ComponentBase, IAsyncDisposable {
    public const string TEST_CLOSED_BY = "any";
    public const string TEST_RETURN_VALUE = "return-value-test";
    public const string TEST_EVENT_CLOSE = "close-event-test";
    public const string TEST_EVENT_CANCEL = "cancel-event-test";


    [Inject]
    public required IElementFactory ElementFactory { private get; init; }


    private IHTMLDialogElement? _dialog;
    private IHTMLDialogElement Dialog => _dialog ??= ElementFactory.CreateHTMLDialogElement(dialogElement);


    public const string LABEL_OUTPUT = "htmldialogelement-output";
    private string labelOutput = string.Empty;

    public const string DIALOG_ELEMENT = "htmldialogelement-dialog-element";
    private ElementReference dialogElement;

    public async ValueTask DisposeAsync() {
        if (_dialog is not null)
            await _dialog.DisposeAsync();
    }


    public const string BUTTON_TO_HTML_ELEMENT = "htmldialogelement-to-html-element";
    private async Task ToHTMLElement() {
        await using IHTMLElement htmlElement = await Dialog.ToHTMLElement();
        labelOutput = (htmlElement is not null).ToString();
    }


    public const string BUTTON_GET_CLOSED_BY_PROPERTY = "htmldialogelement-get-closed-by-property";
    private async Task GetClosedBy_Property() {
        labelOutput = await Dialog.ClosedBy;
    }

    public const string BUTTON_GET_CLOSED_BY_METHOD = "htmldialogelement-get-closed-by-method";
    private async Task GetClosedBy_Method() {
        labelOutput = await Dialog.GetClosedBy(CancellationToken.None);
    }

    public const string BUTTON_SET_CLOSED_BY = "htmldialogelement-set-closed-by";
    private async Task SetClosedBy() {
        await Dialog.SetClosedBy(TEST_CLOSED_BY);
    }


    public const string BUTTON_GET_OPEN_PROPERTY = "htmldialogelement-get-open-property";
    private async Task GetOpen_Property() {
        bool state = await Dialog.Open;
        labelOutput = state.ToString();
    }

    public const string BUTTON_GET_OPEN_METHOD = "htmldialogelement-get-open-method";
    private async Task GetOpen_Method() {
        bool state = await Dialog.GetOpen(CancellationToken.None);
        labelOutput = state.ToString();
    }

    public const string BUTTON_SET_OPEN = "htmldialogelement-set-open";
    private async Task SetOpen() {
        await Dialog.SetOpen(true);
    }


    public const string BUTTON_GET_RETURN_VALUE_PROPERTY = "htmldialogelement-get-return-value-property";
    private async Task GetReturnValue_Property() {
        labelOutput = await Dialog.ReturnValue;
    }

    public const string BUTTON_GET_RETURN_VALUE_METHOD = "htmldialogelement-get-return-value-method";
    private async Task GetReturnValue_Method() {
        labelOutput = await Dialog.GetReturnValue(CancellationToken.None);
    }

    public const string BUTTON_SET_RETURN_VALUE = "htmldialogelement-set-return-value";
    private async Task SetReturnValue() {
        await Dialog.SetReturnValue(TEST_RETURN_VALUE);
    }


    public const string BUTTON_SHOW = "htmldialogelement-show";
    private async Task Show() {
        await Dialog.Show();
    }

    public const string BUTTON_SHOW_MODAL = "htmldialogelement-show-modal";
    private async Task ShowModal() {
        await Dialog.ShowModal();
    }

    public const string BUTTON_CLOSE = "htmldialogelement-close";
    private async Task Close() {
        await Dialog.Close();
    }

    public const string BUTTON_CLOSE_RETURN_VALUE = "htmldialogelement-close-return-value";
    private async Task CloseReturnValue() {
        await Dialog.Close(TEST_RETURN_VALUE);
    }

    public const string BUTTON_REQUEST_CLOSE = "htmldialogelement-request-close";
    private async Task RequestClose() {
        await Dialog.RequestClose();
    }


    public const string BUTTON_REGISTER_ON_CLOSE = "htmldialogelement-close-event";
    private void RegisterOnClose() {
        Dialog.OnClose += () => {
            labelOutput = TEST_EVENT_CLOSE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CANCEL = "htmldialogelement-cancel-event";
    private void RegisterOnCancel() {
        Dialog.OnCancel += () => {
            labelOutput = TEST_EVENT_CANCEL;
            StateHasChanged();
        };
    }
}

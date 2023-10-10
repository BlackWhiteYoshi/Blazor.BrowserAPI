using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class DialogGroup : ComponentBase {
    public const string DATA_TESTID_GET_OPEN_PROPERTY = "dialog-get-open-property";
    public const string DATA_TESTID_GET_OPEN_METHOD = "dialog-get-open-method";
    public const string DATA_TESTID_SET_OPEN = "dialog-set-open";
    public const string DATA_TESTID_GET_RETURN_VALUE_PROPERTY = "dialog-get-return-value-property";
    public const string DATA_TESTID_GET_RETURN_VALUE_METHOD = "dialog-get-return-value-method";
    public const string DATA_TESTID_SET_RETURN_VALUE = "dialog-set-return-value";
    public const string DATA_TESTID_SHOW = "dialog-show";
    public const string DATA_TESTID_SHOW_MODAL = "dialog-show-modal";
    public const string DATA_TESTID_CLOSE = "dialog-close";
    public const string DATA_TESTID_CLOSE_RETURN_VALUE = "dialog-close-return-value";
    public const string DATA_TESTID_REGISTER_ON_CANCEL = "dialog-cancel-event";
    public const string DATA_TESTID_REGISTER_ON_CLOSE = "dialog-close-event";

    public const string DATA_TESTID_GET_OPEN_INPROCESS = "dialog-get-open-inprocess";
    public const string DATA_TESTID_SET_OPEN_INPROCESS = "dialog-set-open-inprocess";
    public const string DATA_TESTID_GET_RETURN_VALUE_INPROCESS = "dialog-get-return-value-inprocess";
    public const string DATA_TESTID_SET_RETURN_VALUE_INPROCESS = "dialog-set-return-value-inprocess";
    public const string DATA_TESTID_SHOW_INPROCESS = "dialog-show-inprocess";
    public const string DATA_TESTID_SHOW_MODAL_INPROCESS = "dialog-show-modal-inprocess";
    public const string DATA_TESTID_CLOSE_INPROCESS = "dialog-close-inprocess";
    public const string DATA_TESTID_CLOSE_RETURN_VALUE_INPROCESS = "dialog-close-return-value-inprocess";
    public const string DATA_TESTID_REGISTER_ON_CANCEL_INPROCESS = "dialog-cancel-event-inprocess";
    public const string DATA_TESTID_REGISTER_ON_CLOSE_INPROCESS = "dialog-close-event-inprocess";

    public const string DATA_TESTID_OUTPUT = "dialog-output";
    public const string DATA_TESTID_DIALOG = "dialog-dialog-element";

    public const string RETURN_VALUE_TEST = "return-value-test";
    public const string CANCEL_EVENT_TEST = "cancel-event-test";
    public const string CLOSE_EVENT_TEST = "close-event-test";


    [Inject]
    public required IDialogFactory DialogFactory { private get; init; }

    private Task<IDialog>? dialog;
    private Task<IDialog> Dialog => dialog ??= DialogFactory.Create(dialogElement).AsTask();


    [Inject]
    public required IDialogInProcessFactory DialogInProcessFactory { private get; init; }

    private IDialogInProcess? dialogInProcess;
    private IDialogInProcess DialogInProcess => dialogInProcess ??= DialogInProcessFactory.Create(dialogElement);


    private ElementReference dialogElement;
    private string labelOutput = string.Empty;



    private async Task GetOpen_Property() {
        IDialog dialog = await Dialog;
        bool state = await dialog.Open;
        labelOutput = state.ToString();
    }

    private async Task GetOpen_Method() {
        IDialog dialog = await Dialog;
        bool state = await dialog.GetOpen(default);
        labelOutput = state.ToString();
    }

    private async Task SetOpen() {
        IDialog dialog = await Dialog;
        await dialog.SetOpen(true);
    }


    private async Task GetReturnValue_Property() {
        IDialog dialog = await Dialog;
        labelOutput = await dialog.ReturnValue;
    }

    private async Task GetReturnValue_Method() {
        IDialog dialog = await Dialog;
        labelOutput = await dialog.GetReturnValue(default);
    }

    private async Task SetReturnValue() {
        IDialog dialog = await Dialog;
        await dialog.SetReturnValue(RETURN_VALUE_TEST);
    }


    private async Task Show() {
        IDialog dialog = await Dialog;
        await dialog.Show();
    }

    private async Task ShowModal() {
        IDialog dialog = await Dialog;
        await dialog.ShowModal();
    }

    private async Task Close() {
        IDialog dialog = await Dialog;
        await dialog.Close();
    }

    private async Task CloseReturnValue() {
        IDialog dialog = await Dialog;
        await dialog.Close(RETURN_VALUE_TEST);
    }


    private async Task RegisterOnCancel() {
        IDialog dialog = await Dialog;
        dialog.OnCancel += () => {
            labelOutput = CANCEL_EVENT_TEST;
            StateHasChanged();
        };
    }

    private async Task RegisterOnClose() {
        IDialog dialog = await Dialog;
        dialog.OnClose += () => {
            labelOutput = CLOSE_EVENT_TEST;
            StateHasChanged();
        };
    }



    private void GetOpen_InProcess() {
        bool state = DialogInProcess.Open;
        labelOutput = state.ToString();
    }

    private void SetOpen_InProcess() {
        DialogInProcess.Open = true;
    }


    private void GetReturnValue_InProcess() {
        labelOutput = DialogInProcess.ReturnValue;
    }

    private void SetReturnValue_InProcess() {
        DialogInProcess.ReturnValue = RETURN_VALUE_TEST;
    }


    private void Show_InProcess() {
        DialogInProcess.Show();
    }

    private void ShowModal_InProcess() {
        DialogInProcess.ShowModal();
    }

    private void Close_InProcess() {
        DialogInProcess.Close();
    }

    private void CloseReturnValue_InProcess() {
        DialogInProcess.Close(RETURN_VALUE_TEST);
    }


    private void RegisterOnCancel_InProcess() {
        DialogInProcess.OnCancel += () => {
            labelOutput = CANCEL_EVENT_TEST;
            StateHasChanged();
        };
    }

    private void RegisterOnClose_InProcess() {
        DialogInProcess.OnClose += () => {
            labelOutput = CLOSE_EVENT_TEST;
            StateHasChanged();
        };
    }
}

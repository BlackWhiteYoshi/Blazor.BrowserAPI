using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class App : ComponentBase {
    [Inject]
    public required IElementFactory ElementFactory  { private get; init; }

    private ElementReference dialogElement;
    private IHTMLDialogElement? dialog;

    private JSExceptionBoundary? jsExceptionBoundary;


    protected override void OnAfterRender(bool firstRender) {
        if (firstRender) {
            dialog = ElementFactory.CreateHTMLDialogElement(dialogElement);
            jsExceptionBoundary!.Dialog = dialog;
        }
    }

    public async ValueTask DisposeAsync() {
        if (dialog is not null)
            try {
                await dialog.DisposeAsync();
            }
            catch (JSDisconnectedException) { }
    }


    private async Task CloseDialog() => await dialog!.Close();
}

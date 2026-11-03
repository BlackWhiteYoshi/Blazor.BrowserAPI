using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class HTMLDialogElement : ComponentBase {
    [Inject]
    public required IElementFactory ElementFactory { private get; init; }

    private ElementReference dialogElement;
    private IHTMLDialogElement? _dialog;
    private IHTMLDialogElement Dialog => _dialog ??= ElementFactory.CreateHTMLDialogElement(dialogElement);
    
    private bool isOpen = false;

    public async ValueTask DisposeAsync() {
        if (_dialog is not null)
            try {
                await _dialog.DisposeAsync();
            }
            catch (JSDisconnectedException) { }
    }


    private async Task Open() {
        isOpen = true;
        await Dialog.Show();
    }

    private async Task OpenModal() {
        isOpen = true;
        await Dialog.ShowModal();
    }

    private async Task Close() {
        isOpen = false;
        await Dialog.Close();
    }
}

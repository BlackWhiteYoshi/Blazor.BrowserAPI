using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class JSExceptionBoundary : ErrorBoundaryBase {
    public IHTMLDialogElement? Dialog { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder) => builder.AddContent(0, ChildContent);

    protected override async Task OnErrorAsync(Exception exception) {
        Recover();
        
        if (exception is JSException && Dialog is not null)
            await Dialog.Show();
        else
            await DispatchExceptionAsync(exception);
    }
}

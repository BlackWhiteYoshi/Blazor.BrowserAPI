using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class HTMLElement : ComponentBase {
    [Inject]
    public required IElementFactory ElementFactory { private get; init; }

    private ElementReference divElement;
    private IHTMLElement? _div;
    private IHTMLElement Div => _div ??= ElementFactory.CreateHTMLElement(divElement);


    private int circleCount = 0;
    
    private int width = 35;
    private int height = 35;

    private bool updateOutput = false;


    protected override async Task OnAfterRenderAsync(bool firstRender) {
        if (updateOutput) {
            updateOutput = false;
            width = await Div.ScrollWidth;
            height = await Div.ScrollHeight;
            StateHasChanged();
        }
    }
    
    private async Task AddCircle() {
        circleCount++;
        updateOutput = true;
    }

    private async Task RemoveCircle() {
        circleCount--;
        updateOutput = true;
    }
}

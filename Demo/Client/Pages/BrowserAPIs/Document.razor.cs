using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class Document : ComponentBase, IAsyncDisposable {
    [Inject]
    public required IDocument PDocument { private get; init; }

    public async ValueTask DisposeAsync() {
        try {
            if (originalTitle is not null)
                await PDocument.SetTitle(originalTitle);

            if (linksAltered) {
                IHTMLElement[] links = await PDocument.Links;
                foreach (IHTMLElement link in links)
                    await link.RemoveAttributeStyleMap("color");

                await links.DisposeAsync();
            }
        }
        catch (JSDisconnectedException) { }
    }


    // change title

    private string? originalTitle = null;

    private async Task ChangeTitle() {
        originalTitle = await PDocument.Title;
        Title = originalTitle;
    }

    private string Title {
        get => field;
        set {
            field = value;
            _ = PDocument.SetTitle(value).Preserve();
        }
    } = string.Empty;


    // remove active element

    private async Task RemoveActiveElement() {
        await using IHTMLElement? activeElement = await PDocument.ActiveElement;
        if (activeElement is not null)
            await activeElement.Remove();
    }


    // cOlor hyper links

    private bool linksAltered = false;

    private async Task ColorAllHyperLinks() {
        IHTMLElement[] links = await PDocument.Links;
        foreach (IHTMLElement link in links)
            await link.SetAttributeStyleMap("color", "#F0F");

        linksAltered = true;
        await links.DisposeAsync();
    }


    // list DOM tree

    private readonly record struct DomElement(string TagName, Dictionary<string, string> Attributes, DomElement[] Children);

    private DomElement? domTree = null;

    private async Task ListEntireDOM() {
        await using IHTMLElement document = PDocument.DocumentElement;
        domTree = await TraverseTree(document);

        static async ValueTask<DomElement> TraverseTree(IHTMLElement current) {
            string tagName = await current.TagName;
            Dictionary<string, string> attributes = await current.Attributes;
            IHTMLElement[] children = await current.Children;

            DomElement element = new(tagName, attributes, new DomElement[children.Length]);
            foreach ((int i, IHTMLElement child) in children.Index())
                element.Children[i] = await TraverseTree(child);

            await children.DisposeAsync();
            return element;
        }
    }
}

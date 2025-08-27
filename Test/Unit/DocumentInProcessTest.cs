using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class DocumentInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    // Properties - HTMLElement reference

    [Test]
    public async Task GetDocumentElement() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_DOCUMENT_ELEMENT);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetHead() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_HEAD);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetBody() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_BODY);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetBody() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_SET_BODY);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_SET_BODY);
    }

    [Test]
    public async Task GetScrollingElement() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_SCROLLING_ELEMENT);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // Properties - HTMLElement Collection

    [Test]
    public async Task GetEmbeds() {
        await Page.EvaluateAsync("""
            const embedElement = document.createElement("embed");
            embedElement.style.display = "none";
            document.body.appendChild(embedElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_EMBEDS);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetForms() {
        await Page.EvaluateAsync("""
            const formElement = document.createElement("form");
            formElement.style.display = "none";
            document.body.appendChild(formElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_FORMS);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetImages() {
        await Page.EvaluateAsync("""
            const imgElement = document.createElement("img");
            imgElement.style.display = "none";
            document.body.appendChild(imgElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_IMAGES);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetLinks() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_LINKS);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetPlugins() {
        await Page.EvaluateAsync("""
            const embedElement = document.createElement("embed");
            embedElement.style.display = "none";
            document.body.appendChild(embedElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_PLUGINS);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetScripts() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_SCRIPTS);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThanOrEqualTo(1);
    }


    // Properties - HTMLElement situational

    [Test]
    public async Task GetActiveElement() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_ACTIVE_ELEMENT);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetCurrentScript() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_CURRENT_SCRIPT);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetFullscreenElement() {
        await Page.GetByTestId(DocumentInProcessGroup.BUTTON_GET_FULLSCREEN_ELEMENT).EvaluateAsync("node => node.requestFullscreen();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_FULLSCREEN_ELEMENT);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetPictureInPictureElement() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_PICTURE_IN_PICTURE_ELEMENT);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetPointerLockElement() {
        await Page.GetByTestId(DocumentInProcessGroup.BUTTON_GET_POINTER_LOCK_ELEMENT).EvaluateAsync("node => node.requestPointerLock();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await Page.Mouse.DownAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.UpAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // Properties

    [Test]
    public async Task GetCharacterSet() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_CHARACTER_SET);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("UTF-8");
    }

    [Test]
    public async Task GetCompatMode() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_COMPAT_MODE);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("CSS1Compat");
    }

    [Test]
    public async Task GetContentType() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_CONTENT_TYPE);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("text/html");
    }

    [Test]
    public async Task GetDesignMode() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_DESIGN_MODE);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("off");
    }

    [Test]
    public async Task SetDesignMode() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_SET_DESIGN_MODE);

        string result = await Page.EvaluateAsync<string>("document.designMode;");
        await Assert.That(result).IsEqualTo("on");
    }

    [Test]
    public async Task GetDir() {
        await Page.EvaluateAsync("document.dir = 'ltr';");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_DIR);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("ltr");
    }

    [Test]
    public async Task SetDir() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_SET_DIR);

        string result = await Page.EvaluateAsync<string>("document.dir;");
        await Assert.That(result).IsEqualTo("rtl");
    }

    [Test]
    public async Task GetDocumentURI() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_DOCUMENT_URI);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("https://localhost");
    }

    [Test]
    public async Task GetFullscreenEnabled() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_FULLSCREEN_ENABLED);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetHidden() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_HIDDEN);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetLastModified() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_LAST_MODIFIED);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isDateTime = DateTime.TryParseExact(result, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
        await Assert.That(isDateTime).IsTrue();
    }

    [Test]
    public async Task GetPictureInPictureEnabled() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_PICTURE_IN_PICTURE_ENABLED);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetReadyState() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_READY_STATE);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("complete");
    }

    [Test]
    public async Task GetReferrer() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_REFERRER);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_NO_REFFERER);
    }

    [Test]
    public async Task GetTitle() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_TITLE);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("BrowserAPI Test");
    }

    [Test]
    public async Task SetTitle() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_SET_TITLE);

        string result = await Page.EvaluateAsync<string>("document.title;");
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_SET_TITLE);
    }

    [Test]
    public async Task GetURL() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_URL);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("https://localhost");
    }

    [Test]
    public async Task GetVisibilityState() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_VISIBILITY_STATE);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("visible");
    }


    // Properties - Node

    [Test]
    public async Task GetBaseURI() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_BASE_URI);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("https://localhost");
    }

    [Test]
    public async Task GetNodeName() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_NODE_NAME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("#document");
    }

    [Test]
    public async Task GetNodeType() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_NODE_TYPE);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("9");
    }



    // methods - DOM

    [Test]
    public async Task CreateElement() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_CREATE_ELEMENT);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task CreateElementNS() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_CREATE_ELEMENT_NS);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetElementById() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_ELEMENT_BY_ID);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetElementsByClassName() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_ELEMENTS_BY_CLASS_NAME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThanOrEqualTo(1);
    }

    [Test]
    public async Task GetElementsByTagName() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_ELEMENTS_BY_TAG_NAME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThanOrEqualTo(1);
    }

    [Test]
    public async Task GetElementsByTagNameNS() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_ELEMENTS_BY_TAG_NAME_NS);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThanOrEqualTo(1);
    }

    [Test]
    public async Task GetElementsByName() {
        await Page.GetByTestId(DocumentInProcessGroup.BUTTON_GET_ELEMENTS_BY_NAME).WaitForAsync();
        await Page.EvaluateAsync($"""
            const divs = document.querySelectorAll(".group");
            for (let i = 0; i < divs.length; i++)
                divs[i].setAttribute("name", "{DocumentInProcessGroup.TEST_ELEMENT_NAME}");
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentInProcessGroup.BUTTON_GET_ELEMENTS_BY_NAME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThanOrEqualTo(1);
    }

    [Test]
    public async Task QuerySelector() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_QUERY_SELECTOR);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task QuerySelectorAll() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_QUERY_SELECTOR_ALL);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThanOrEqualTo(1);
    }

    [Test]
    public async Task ElementFromPoint() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_ELEMENT_FROM_POINT);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task ElementsFromPoint() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_ELEMENTS_FROM_POINT);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThanOrEqualTo(1);
    }

    [Test]
    public async Task ReplaceChildren() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REPLACE_CHILDREN);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // methods - StorageAccess

    [Test]
    public async Task RequestStorageAccess() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REQUEST_STORAGE_ACCESS);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_REQUEST_STORAGE_ACCESS);
    }

    [Test]
    public async Task RequestStorageAccessFor() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REQUEST_STORAGE_ACCESS_FOR);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_REQUEST_STORAGE_ACCESS_FOR);
    }

    [Test]
    public async Task HasStorageAccess() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_HAS_STORAGE_ACCESS);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // methods - exit

    [Test]
    public async Task ExitFullscreen() {
        await Page.GetByTestId(DocumentInProcessGroup.BUTTON_EXIT_FULLSCREEN).EvaluateAsync("""
            node => {
                window.counter = 0;
                document.onfullscreenchange = () => counter++;
                node.requestFullscreen();
            };
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentInProcessGroup.BUTTON_EXIT_FULLSCREEN);

        int counter = await Page.EvaluateAsync<int>("window.counter;");
        await Assert.That(counter).IsEqualTo(2);
    }

    [Test]
    public async Task ExitPictureInPicture() {
        // TODO ExitPictureInPicture
        await ExecuteTest(DocumentInProcessGroup.BUTTON_EXIT_PICTURE_IN_PICTURE);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Failed to execute 'exitPictureInPicture' on 'Document': There is no Picture-in-Picture element in this document.");
    }

    [Test]
    public async Task ExitPointerLock() {
        await Page.GetByTestId(DocumentInProcessGroup.BUTTON_EXIT_POINTER_LOCK).EvaluateAsync("node => node.requestPointerLock();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await Page.Mouse.DownAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.UpAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).ClickAsync();
    }


    // methods

    [Test]
    public async Task HasFocus() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_HAS_FOCUS);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // methods - Node

    [Test]
    public async Task CompareDocumentPosition() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_COMPARE_DOCUMENT_POSITION);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isInteger = int.TryParse(result, out _);
        await Assert.That(isInteger).IsTrue();
    }

    [Test]
    public async Task Contains() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_CONTAINS);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task IsDefaultNamespace() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_IS_DEFAULT_NAMESPACE);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task LookupPrefix() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_LOOKUP_PREFIX);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(no prefix)");
    }

    [Test]
    public async Task LookupNamespaceURI() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_LOOKUP_NAMESPACE_URI);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("http://www.w3.org/1999/xhtml");
    }

    [Test]
    public async Task Normalize() {
        await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).EvaluateAsync("node => node.append('-textNode1-', '-textNode2-');");
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(DocumentInProcessGroup.BUTTON_NORMALIZE);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).EvaluateAsync<string?>("node => node.lastChild.textContent;");
        await Assert.That(result).IsEqualTo("-textNode1--textNode2-");
    }
}

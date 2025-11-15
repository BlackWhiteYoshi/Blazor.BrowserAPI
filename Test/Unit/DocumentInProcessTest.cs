using BrowserAPI.Test.Client;
using Microsoft.Playwright;

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



    // events - Document

    [Test]
    public async Task RegisterOnSecurityPolicyViolation() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_SECURITY_POLICY_VIOLATION);

        await Page.EvaluateAsync("""
            //const script = document.createElement("script");
            //script.innerText = "console.log('inline script');";
            //document.body.appendChild(script);

            const event = new Event("securitypolicyviolation");
            event.blockedURI = "s1";
            event.effectiveDirective = "s2";
            event.documentURI = "s3";
            event.lineNumber = 4;
            event.columnNumber = 5;
            event.originalPolicy = "s6";
            event.referrer = "s7";
            event.sourceFile = "s8";
            event.sample = "s9";
            event.statusCode = 10;
            event.disposition = "s11";
            document.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("SecurityPolicyViolationEvent { BlockedURI = s1, EffectiveDirective = s2, DocumentURI = s3, LineNumber = 4, ColumnNumber = 5, OriginalPolicy = s6, Referrer = s7, SourceFile = s8, Sample = s9, StatusCode = 10, Disposition = s11 }");
    }

    [Test]
    public async Task RegisterOnVisibilityChange() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_VISIBILITY_CHANGE);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('visibilitychange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_VISIBILITY_CHANGE);
    }


    [Test]
    public async Task RegisterOnFullscreenChange() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_FULLSCREEN_CHANGE);

        await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).EvaluateAsync("node => node.requestFullscreen();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_FULLSCREEN_CHANGE);
    }

    [Test]
    public async Task RegisterOnFullscreenError() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_FULLSCREEN_ERROR);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('fullscreenerror'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_FULLSCREEN_ERROR);
    }


    [Test]
    public async Task RegisterOnDOMContentLoaded() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_DOM_CONTENT_LOADED);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('DOMContentLoaded'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_DOM_CONTENT_LOADED);
    }

    [Test]
    public async Task RegisterOnReadyStateChange() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_READY_STATE_CHANGE);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('readystatechange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_READY_STATE_CHANGE);
    }


    [Test]
    public async Task RegisterOnPointerLockChange() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_POINTER_LOCK_CHANGE);

        await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).EvaluateAsync("node => node.requestPointerLock();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_POINTER_LOCK_CHANGE);
    }

    [Test]
    public async Task RegisterOnPointerLockError() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_POINTER_LOCK_ERROR);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('pointerlockerror'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_POINTER_LOCK_ERROR);
    }


    [Test]
    public async Task RegisterOnScroll() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_SCROLL);

        await Page.Mouse.WheelAsync(0, 1);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_SCROLL);
    }

    [Test]
    public async Task RegisterOnScrollEnd() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_SCROLL_END);

        await Page.Mouse.WheelAsync(0, 1);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_SCROLL_END);
    }


    [Test]
    public async Task RegisterOnSelectionChange() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_SELECTION_CHANGE);

        await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_SELECTION_CHANGE);
    }

    [Test]
    public async Task RegisterOnSelectStart() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_SELECT_START);

        await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_SELECT_START);
    }


    // events - HTMLElement

    [Test]
    public async Task RegisterOnChange() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_CHANGE);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("input");
            tempElement.setAttribute("data-testid", "temp");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").FillAsync("something");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").BlurAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_CHANGE);
    }

    [Test]
    public async Task RegisterOnLoad() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_LOAD);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('load'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_LOAD);
    }

    [Test]
    public async Task RegisterOnError() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_ERROR);

        await Page.EvaluateAsync("""
            const event = new Event('error');
            event.text = "error message";
            document.dispatchEvent(event);
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }


    [Test]
    public async Task RegisterOnDrag() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_DRAG);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragStart() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_DRAG_START);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragEnd() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_DRAG_END);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragEnter() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_DRAG_ENTER);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragLeave() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_DRAG_LEAVE);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragOver() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_DRAG_OVER);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDrop() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_DROP);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            dragTarget.addEventListener("dragover", e => e.preventDefault());
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='copy', effectAllowed='all', types='[]', files='[]'");
    }


    [Test]
    public async Task RegisterOnToggle() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_TOGGLE);

        await Page.EvaluateAsync("""
            const event = new Event("toggle");
            event.oldState = "closed";
            event.newState = "open";
            document.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("oldState='closed', newState='open'");
    }

    [Test]
    public async Task RegisterOnBeforeToggle() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_BEFORE_TOGGLE);

        await Page.EvaluateAsync("""
            const event = new Event("beforetoggle");
            event.oldState = "closed";
            event.newState = "open";
            document.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("oldState='closed', newState='open'");
    }


    // events - Element

    [Test]
    public async Task RegisterOnInput() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_INPUT);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("input");
            tempElement.setAttribute("data-testid", "temp");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").FillAsync("something");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("data=something, inputType=insertText, isComposing=False");
    }

    [Test]
    public async Task RegisterOnBeforeInput() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_BEFORE_INPUT);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("input");
            tempElement.setAttribute("data-testid", "temp");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").FillAsync("something");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("data=something, inputType=insertText, isComposing=False");
    }

    [Test]
    public async Task RegisterOnBeforeMatch() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_BEFORE_MATCH);

        await Page.EvaluateAsync("""
            const hiddenElement = document.createElement("div");
            hiddenElement.setAttribute("id", "htmlelement-fragment");
            hiddenElement.setAttribute("hidden", "until-found");
            document.body.appendChild(hiddenElement);

            const a = document.createElement("a");
            a.href = "#htmlelement-fragment";
            document.body.appendChild(a);
            a.click();
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_BEFORE_MATCH);
    }


    [Test]
    public async Task RegisterOnKeyDown() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_KEY_DOWN);

        await Page.Keyboard.PressAsync("a");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("KeyboardEvent { Key = a, Code = KeyA, Location = 0, CtrlKey = False, ShiftKey = False, AltKey = False, MetaKey = False, Repeat = False, IsComposing = False }");
    }

    [Test]
    public async Task RegisterOnKeyUp() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_KEY_UP);

        await Page.Keyboard.PressAsync("a");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("KeyboardEvent { Key = a, Code = KeyA, Location = 0, CtrlKey = False, ShiftKey = False, AltKey = False, MetaKey = False, Repeat = False, IsComposing = False }");
    }


    [Test]
    public async Task RegisterOnClick() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_CLICK);

        await Page.Mouse.ClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnDblClick() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_DBL_CLICK);

        await Page.Mouse.DblClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnAuxClick() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_AUX_CLICK);

        await Page.Mouse.ClickAsync(1.0f, 1.0f, new MouseClickOptions() { Button = MouseButton.Right });
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnContextMenu() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_CONTEXT_MENU);

        await Page.Mouse.ClickAsync(1.0f, 1.0f, new MouseClickOptions() { Button = MouseButton.Right });
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseDown() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_MOUSE_DOWN);

        await Page.Mouse.ClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseUp() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_MOUSE_UP);

        await Page.Mouse.ClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnWheel() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_WHEEL);

        await Page.Mouse.WheelAsync(0.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("WheelEvent { DeltaX = 0, DeltaY = 1, DeltaZ = 0, DeltaMode = 0 }");
    }

    [Test]
    public async Task RegisterOnMouseMove() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_MOUSE_MOVE);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseOver() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_MOUSE_OVER);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseOut() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_MOUSE_OUT);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseEnter() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_MOUSE_ENTER);

        await Page.Mouse.MoveAsync(-1.0f, -1.0f);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.MoveAsync(2.0f, 2.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseLeave() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_MOUSE_LEAVE);

        await Page.Mouse.MoveAsync(-1.0f, -1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }


    [Test]
    public async Task RegisterOnTouchStart() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_TOUCH_START);

        await Page.Touchscreen.TapAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }

    [Test]
    public async Task RegisterOnTouchEnd() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_TOUCH_END);

        await Page.Touchscreen.TapAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }

    [Test]
    public async Task RegisterOnTouchMove() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_TOUCH_MOVE);

        await Page.EvaluateAsync("""
            const event = new Event("touchmove");
            event.touches = [];
            event.targetTouches = [];
            event.changedTouches = [];
            event.ctrlKey = false;
            event.shiftKey = false;
            event.altKey = false;
            event.metaKey = false;
            document.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }

    [Test]
    public async Task RegisterOnTouchCancel() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_TOUCH_CANCEL);

        await Page.EvaluateAsync("""
            const event = new Event("touchcancel");
            event.touches = [];
            event.targetTouches = [];
            event.changedTouches = [];
            event.ctrlKey = false;
            event.shiftKey = false;
            event.altKey = false;
            event.metaKey = false;
            document.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }


    [Test]
    public async Task RegisterOnPointerDown() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_POINTER_DOWN);

        await Page.Mouse.ClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerUp() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_POINTER_UP);

        await Page.Mouse.ClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerMove() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_POINTER_MOVE);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerOver() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_POINTER_OVER);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerOut() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_POINTER_OUT);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerEnter() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_POINTER_ENTER);

        await Page.Mouse.MoveAsync(-1.0f, -1.0f);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.MoveAsync(2.0f, 2.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerLeave() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_POINTER_LEAVE);

        await Page.Mouse.MoveAsync(-1.0f, -1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerCancel() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_POINTER_CANCEL);

        await Page.EvaluateAsync("""
            const event = new Event("pointercancel");
            event.pointerId = 0;
            event.persistentDeviceId = 0;
            event.pointerType = "";
            event.width = 1;
            event.height = 1;
            event.pressure = 1;
            event.tangentialPressure = 0;
            event.twist = 0;
            event.tiltX = 0;
            event.tiltY = 0;
            event.altitudeAngle = 0;
            event.azimuthAngle = 0;
            event.isPrimary = true;
            event.button = 0;
            event.buttons = 0;
            event.movementX = 0;
            event.movementY = 0;
            event.clientX = 0;
            event.clientY = 0;
            event.offsetX = 0;
            event.offsetY = 0;
            event.pageX = 0;
            event.pageY = 0;
            event.screenX = 0;
            event.screenY = 0;
            event.ctrlKey = false;
            event.shiftKey = false;
            event.altKey = false;
            event.metaKey = false;
            document.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerRawUpdate() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_POINTER_RAW_UPDATE);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnGotPointerCapture() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_GOT_POINTER_CAPTURE);

        await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).EvaluateAsync("node => node.addEventListener('pointerdown', event => node.setPointerCapture(event.pointerId));");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnLostPointerCapture() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_LOST_POINTER_CAPTURE);

        await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).EvaluateAsync("""
            node => {
                node.addEventListener("pointerdown", event => node.setPointerCapture(event.pointerId));
                node.addEventListener("pointerup", event => node.releasePointerCapture(event.pointerId));
            }
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }


    [Test]
    public async Task RegisterOnFocus() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_FOCUS);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('focus'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_FOCUS);
    }

    [Test]
    public async Task RegisterOnFocusIn() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_FOCUS_IN);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('focusin'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_FOCUS_IN);
    }

    [Test]
    public async Task RegisterOnBlur() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_BLUR);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('blur'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_BLUR);
    }

    [Test]
    public async Task RegisterOnFocusOut() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_FOCUS_OUT);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('focusout'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_FOCUS_OUT);
    }


    [Test]
    public async Task RegisterOnCopy() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_COPY);

        await Page.Keyboard.PressAsync("Control+c");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_COPY);
    }

    [Test]
    public async Task RegisterOnPaste() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_PASTE);

        await Page.Keyboard.PressAsync("Control+v");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_PASTE);
    }

    [Test]
    public async Task RegisterOnCut() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_CUT);

        await Page.Keyboard.PressAsync("Control+x");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_CUT);
    }


    [Test]
    public async Task RegisterOnTransitionStart() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_TRANSITION_START);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_TRANSITION_START);
    }

    [Test]
    public async Task RegisterOnTransitionEnd() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_TRANSITION_END);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_TRANSITION_END);
    }

    [Test]
    public async Task RegisterOnTransitionRun() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_TRANSITION_RUN);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_TRANSITION_RUN);
    }

    [Test]
    public async Task RegisterOnTransitionCancel() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_TRANSITION_CANCEL);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.style.backgroundColor = '#222';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_TRANSITION_CANCEL);
    }


    [Test]
    public async Task RegisterOnAnimationStart() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_ANIMATION_START);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_ANIMATION_START);
    }

    [Test]
    public async Task RegisterOnAnimationnEnd() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_ANIMATION_END);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_ANIMATION_END);
    }

    [Test]
    public async Task RegisterOnAnimationIteration() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_ANIMATION_ITERATION);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_ANIMATION_ITERATION);
    }

    [Test]
    public async Task RegisterOnAnimationCancel() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_ANIMATION_CANCEL);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.classList.remove('animation-start-infinite');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(DocumentInProcessGroup.TEST_EVENT_ANIMATION_CANCEL);
    }


    // HTMLMediaElement - Ready

    [Test]
    public async Task RegisterOnCanPlay() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_CAN_PLAY);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('canplay'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_CAN_PLAY);
    }

    [Test]
    public async Task RegisterOnCanPlayThrough() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_CAN_PLAY_THROUGH);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('canplaythrough'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_CAN_PLAY_THROUGH);
    }

    [Test]
    public async Task RegisterOnPlaying() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_PLAYING);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('playing'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_PLAYING);
    }

    // HTMLMediaElement - Data

    [Test]
    public async Task RegisterOnLoadStart() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_LOAD_START);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('loadstart'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_LOAD_START);
    }

    [Test]
    public async Task RegisterOnProgress() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_PROGRESS);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('progress'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_PROGRESS);
    }

    [Test]
    public async Task RegisterOnLoadedData() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_LOADED_DATA);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('loadeddata'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_LOADED_DATA);
    }

    [Test]
    public async Task RegisterOnLoadedMetadata() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_LOADED_METADATA);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('loadedmetadata'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_LOADED_METADATA);
    }

    [Test]
    public async Task RegisterOnStalled() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_STALLED);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('stalled'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_STALLED);
    }

    [Test]
    public async Task RegisterOnSuspend() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_SUSPEND);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('suspend'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_SUSPEND);
    }

    [Test]
    public async Task RegisterOnWaiting() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_WAITING);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('waiting'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_WAITING);
    }

    [Test]
    public async Task RegisterOnAbort() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_ABORT);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('abort'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_ABORT);
    }

    [Test]
    public async Task RegisterOnEmptied() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_EMPTIED);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('emptied'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_EMPTIED);
    }

    // HTMLMediaElement - Timing

    [Test]
    public async Task RegisterOnPlay() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_PLAY);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('play'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_PLAY);
    }

    [Test]
    public async Task RegisterOnPause() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_PAUSE);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('pause'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_PAUSE);
    }

    [Test]
    public async Task RegisterOnEnded() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_ENDED);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('ended'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_ENDED);
    }

    [Test]
    public async Task RegisterOnSeeking() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_SEEKING);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('seeking'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_SEEKING);
    }

    [Test]
    public async Task RegisterOnSeeked() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_SEEKED);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('seeked'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_SEEKED);
    }

    [Test]
    public async Task RegisterOnTimeUpdate() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_TIME_UPDATE);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('timeupdate'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_TIME_UPDATE);
    }

    // HTMLMediaElement - Setting

    [Test]
    public async Task RegisterOnVolumeChange() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_VOLUME_CHANGE);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('volumechange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_VOLUME_CHANGE);
    }

    [Test]
    public async Task RegisterOnRateChange() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_RATE_CHANGE);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('ratechange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_RATE_CHANGE);
    }

    [Test]
    public async Task RegisterOnDurationChange() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_DURATION_CHANGE);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('durationchange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_DURATION_CHANGE);
    }

    // HTMLMediaElement - Video

    [Test]
    public async Task RegisterOnResize() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_RESIZE);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('resize'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_RESIZE);
    }


    // HTMLDialogElement

    [Test]
    public async Task RegisterOnClose() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_CLOSE);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('close'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_CLOSE);
    }

    [Test]
    public async Task RegisterOnCancel() {
        await ExecuteTest(DocumentInProcessGroup.BUTTON_REGISTER_ON_CANCEL);

        await Page.EvaluateAsync("document.dispatchEvent(new Event('cancel'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentInProcessGroup.TEST_EVENT_CANCEL);
    }
}

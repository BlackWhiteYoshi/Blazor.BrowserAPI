using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class DocumentTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    // Properties - HTMLElement reference

    [Test]
    public async Task GetDocumentElement() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_DOCUMENT_ELEMENT);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetHead() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_HEAD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetBody() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_BODY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SetBody() {
        await ExecuteTest(DocumentGroup.BUTTON_SET_BODY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentGroup.TEST_SET_BODY);
    }

    [Test]
    public async Task GetScrollingElement() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_SCROLLING_ELEMENT);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // Properties - HTMLElement Collection

    [Test]
    public async Task GetEmbeds_Property() {
        await Page.EvaluateAsync("""
            const embedElement = document.createElement("embed");
            embedElement.style.display = "none";
            document.body.appendChild(embedElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_EMBEDS_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetEmbeds_Method() {
        await Page.EvaluateAsync("""
            const embedElement = document.createElement("embed");
            embedElement.style.display = "none";
            document.body.appendChild(embedElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_EMBEDS_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    [Test]
    public async Task GetForms_Property() {
        await Page.EvaluateAsync("""
            const formElement = document.createElement("form");
            formElement.style.display = "none";
            document.body.appendChild(formElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_FORMS_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetForms_Method() {
        await Page.EvaluateAsync("""
            const formElement = document.createElement("form");
            formElement.style.display = "none";
            document.body.appendChild(formElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_FORMS_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    [Test]
    public async Task GetImages_Property() {
        await Page.EvaluateAsync("""
            const imgElement = document.createElement("img");
            imgElement.style.display = "none";
            document.body.appendChild(imgElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_IMAGES_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetImages_Method() {
        await Page.EvaluateAsync("""
            const imgElement = document.createElement("img");
            imgElement.style.display = "none";
            document.body.appendChild(imgElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_IMAGES_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    [Test]
    public async Task GetLinks_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_LINKS_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetLinks_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_LINKS_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    [Test]
    public async Task GetPlugins_Property() {
        await Page.EvaluateAsync("""
            const embedElement = document.createElement("embed");
            embedElement.style.display = "none";
            document.body.appendChild(embedElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_PLUGINS_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }

    [Test]
    public async Task GetPlugins_Method() {
        await Page.EvaluateAsync("""
            const embedElement = document.createElement("embed");
            embedElement.style.display = "none";
            document.body.appendChild(embedElement);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_PLUGINS_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    [Test]
    public async Task GetScripts_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_SCRIPTS_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThanOrEqualTo(1);
    }

    [Test]
    public async Task GetScripts_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_SCRIPTS_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        int.TryParse(result, out int resultNumber);
        await Assert.That(resultNumber).IsGreaterThanOrEqualTo(1);
    }


    // Properties - HTMLElement situational

    [Test]
    public async Task GetActiveElement_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_ACTIVE_ELEMENT_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetActiveElement_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_ACTIVE_ELEMENT_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetCurrentScript_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_CURRENT_SCRIPT_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetCurrentScript_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_CURRENT_SCRIPT_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetFullscreenElement_Property() {
        await Page.GetByTestId(DocumentGroup.BUTTON_GET_FULLSCREEN_ELEMENT_PROPERTY).EvaluateAsync("node => node.requestFullscreen();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_FULLSCREEN_ELEMENT_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetFullscreenElement_Method() {
        await Page.GetByTestId(DocumentGroup.BUTTON_GET_FULLSCREEN_ELEMENT_METHOD).EvaluateAsync("node => node.requestFullscreen();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_FULLSCREEN_ELEMENT_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetPictureInPictureElement_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_PICTURE_IN_PICTURE_ELEMENT_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetPictureInPictureElement_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_PICTURE_IN_PICTURE_ELEMENT_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetPointerLockElement_Property() {
        await Page.GetByTestId(DocumentGroup.BUTTON_GET_POINTER_LOCK_ELEMENT_PROPERTY).EvaluateAsync("node => node.requestPointerLock();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await Page.Mouse.DownAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.UpAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetPointerLockElement_Method() {
        await Page.GetByTestId(DocumentGroup.BUTTON_GET_POINTER_LOCK_ELEMENT_METHOD).EvaluateAsync("node => node.requestPointerLock();");
        await Task.Delay(STANDARD_WAIT_TIME);

        await Page.Mouse.DownAsync();
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.Mouse.UpAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // Properties

    [Test]
    public async Task GetCharacterSet_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_CHARACTER_SET_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("UTF-8");
    }

    [Test]
    public async Task GetCharacterSet_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_CHARACTER_SET_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("UTF-8");
    }


    [Test]
    public async Task GetCompatMode_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_COMPAT_MODE_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("CSS1Compat");
    }

    [Test]
    public async Task GetCompatMode_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_COMPAT_MODE_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("CSS1Compat");
    }


    [Test]
    public async Task GetContentType_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_CONTENT_TYPE_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("text/html");
    }

    [Test]
    public async Task GetContentType_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_CONTENT_TYPE_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("text/html");
    }


    [Test]
    public async Task GetDesignMode_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_DESIGN_MODE_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("off");
    }

    [Test]
    public async Task GetDesignMode_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_DESIGN_MODE_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("off");
    }

    [Test]
    public async Task SetDesignMode() {
        await ExecuteTest(DocumentGroup.BUTTON_SET_DESIGN_MODE);

        string result = await Page.EvaluateAsync<string>("document.designMode;");
        await Assert.That(result).IsEqualTo("on");
    }


    [Test]
    public async Task GetDir_Property() {
        await Page.EvaluateAsync("document.dir = 'ltr';");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_DIR_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("ltr");
    }

    [Test]
    public async Task GetDir_Method() {
        await Page.EvaluateAsync("document.dir = 'ltr';");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(DocumentGroup.BUTTON_GET_DIR_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("ltr");
    }

    [Test]
    public async Task SetDir() {
        await ExecuteTest(DocumentGroup.BUTTON_SET_DIR);

        string result = await Page.EvaluateAsync<string>("document.dir;");
        await Assert.That(result).IsEqualTo("rtl");
    }


    [Test]
    public async Task GetDocumentURI_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_DOCUMENT_URI_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("https://localhost");
    }

    [Test]
    public async Task GetDocumentURI_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_DOCUMENT_URI_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("https://localhost");
    }


    [Test]
    public async Task GetFullscreenEnabled_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_FULLSCREEN_ENABLED_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetFullscreenEnabled_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_FULLSCREEN_ENABLED_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetHidden_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_HIDDEN_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetHidden_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_HIDDEN_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task GetLastModified_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_LAST_MODIFIED_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        bool isDateTime = DateTime.TryParseExact(result, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
        await Assert.That(isDateTime).IsTrue();
    }

    [Test]
    public async Task GetLastModified_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_LAST_MODIFIED_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        bool isDateTime = DateTime.TryParseExact(result, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
        await Assert.That(isDateTime).IsTrue();
    }


    [Test]
    public async Task GetPictureInPictureEnabled_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_PICTURE_IN_PICTURE_ENABLED_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetPictureInPictureEnabled_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_PICTURE_IN_PICTURE_ENABLED_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetReadyState_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_READY_STATE_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("complete");
    }

    [Test]
    public async Task GetReadyState_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_READY_STATE_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("complete");
    }


    [Test]
    public async Task GetReferrer_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_REFERRER_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentGroup.TEST_NO_REFFERER);
    }

    [Test]
    public async Task GetReferrer_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_REFERRER_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(DocumentGroup.TEST_NO_REFFERER);
    }


    [Test]
    public async Task GetTitle_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_TITLE_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("BrowserAPI Test");
    }

    [Test]
    public async Task GetTitle_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_TITLE_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("BrowserAPI Test");
    }

    [Test]
    public async Task SetTitle() {
        await ExecuteTest(DocumentGroup.BUTTON_SET_TITLE);

        string result = await Page.EvaluateAsync<string>("document.title;");
        await Assert.That(result).IsEqualTo(DocumentGroup.TEST_SET_TITLE);
    }


    [Test]
    public async Task GetURL_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_URL_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("https://localhost");
    }

    [Test]
    public async Task GetURL_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_URL_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("https://localhost");
    }


    [Test]
    public async Task GetVisibilityState_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_VISIBILITY_STATE_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("visible");
    }

    [Test]
    public async Task GetVisibilityState_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_VISIBILITY_STATE_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("visible");
    }


    // Properties - Node

    [Test]
    public async Task GetBaseURI_Property() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_BASE_URI_PROPERTY);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("https://localhost");
    }

    [Test]
    public async Task GetBaseURI_Method() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_BASE_URI_METHOD);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("https://localhost");
    }

    [Test]
    public async Task GetNodeName() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_NODE_NAME);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("#document");
    }

    [Test]
    public async Task GetNodeType() {
        await ExecuteTest(DocumentGroup.BUTTON_GET_NODE_TYPE);

        string? result = await Page.GetByTestId(DocumentGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("9");
    }
}

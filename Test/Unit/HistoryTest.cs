using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HistoryTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetLength_Property() {
        await ExecuteTest(HistoryGroup.BUTTON_GET_LENGTH_PROPERTY);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("2");
    }

    [Test]
    public async Task GetLength_Method() {
        await ExecuteTest(HistoryGroup.BUTTON_GET_LENGTH_METHOD);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("2");
    }


    [Test]
    public async Task GetScrollRestoration_Property() {
        await ExecuteTest(HistoryGroup.BUTTON_GET_SCROLL_RESTORATION_PROPERTY);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("auto");
    }

    [Test]
    public async Task GetScrollRestoration_Method() {
        await ExecuteTest(HistoryGroup.BUTTON_GET_SCROLL_RESTORATION_METHOD);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("auto");
    }

    [Test]
    public async Task SetScrollRestoration() {
        await ExecuteTest(HistoryGroup.BUTTON_SET_SCROLL_RESTORATION);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("manual");
    }


    [Test]
    public async Task GetState_Property() {
        await ExecuteTest(HistoryGroup.BUTTON_GET_STATE_PROPERTY);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(null)");
    }

    [Test]
    public async Task GetState_Method() {
        await ExecuteTest(HistoryGroup.BUTTON_GET_STATE_METHOD);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(null)");
    }



    [Test]
    public async Task Forward() {
        await Page.EvaluateAsync("history.pushState(null, '', '/test'); history.back();");
        await ExecuteTest(HistoryGroup.BUTTON_FORWARD);

        int historyLength = await Page.EvaluateAsync<int>("history.length;");
        await Assert.That(historyLength).IsEqualTo(3);

        string url = await Page.EvaluateAsync<string>("window.location.href;");
        await Assert.That(url).EndsWith("/test");
    }

    [Test]
    public async Task Back() {
        await Page.EvaluateAsync("history.pushState(null, '', '/test');");
        await ExecuteTest(HistoryGroup.BUTTON_BACK);

        int historyLength = await Page.EvaluateAsync<int>("history.length;");
        await Assert.That(historyLength).IsEqualTo(3);

        string url = await Page.EvaluateAsync<string>("window.location.href;");
        await Assert.That(url).EndsWith("/");
    }

    [Test]
    public async Task Go() {
        await Page.EvaluateAsync("""
            const label = document.createElement('label');
            label.setAttribute("data-testid", "temp");
            document.body.appendChild(label);
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        await ExecuteTest(HistoryGroup.BUTTON_GO);

        int tempLabelCount = await Page.GetByTestId("temp").CountAsync();
        await Assert.That(tempLabelCount).IsEqualTo(0);
    }

    [Test]
    public async Task PushState() {
        await ExecuteTest(HistoryGroup.BUTTON_PUSH_STATE);

        int historyLength = await Page.EvaluateAsync<int>("history.length;");
        await Assert.That(historyLength).IsEqualTo(3);

        string url = await Page.EvaluateAsync<string>("window.location.href;");
        await Assert.That(url).EndsWith("/test");
    }

    [Test]
    public async Task ReplaceState() {
        await ExecuteTest(HistoryGroup.BUTTON_REPLACE_STATE);

        int historyLength = await Page.EvaluateAsync<int>("history.length;");
        await Assert.That(historyLength).IsEqualTo(2);

        string url = await Page.EvaluateAsync<string>("window.location.href;");
        await Assert.That(url).EndsWith("/test");
    }


    [Test]
    public async Task RegisterOnPageReveal() {
        await ExecuteTest(HistoryGroup.BUTTON_REGISTER_ON_PAGE_REVEAL);
        await Page.EvaluateAsync("window.dispatchEvent(new Event('pagereveal'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HistoryGroup.TEST_EVENT_PAGE_REVEAL);
    }

    [Test]
    public async Task RegisterOnPageSwap() {
        await ExecuteTest(HistoryGroup.BUTTON_REGISTER_ON_PAGE_SWAP);
        await Page.EvaluateAsync("window.dispatchEvent(new Event('pageswap'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(HistoryGroup.TEST_EVENT_PAGE_SWAP);
    }

    [Test]
    public async Task RegisterOnPageShow() {
        await ExecuteTest(HistoryGroup.BUTTON_REGISTER_ON_PAGE_SHOW);
        await Page.EvaluateAsync("""
            const event = new Event("pageshow");
            event.persisted = true;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task RegisterOnPageHide() {
        await ExecuteTest(HistoryGroup.BUTTON_REGISTER_ON_PAGE_HIDE);
        await Page.EvaluateAsync("""
            const event = new Event("pagehide");
            event.persisted = true;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task RegisterOnPopState() {
        await ExecuteTest(HistoryGroup.BUTTON_REGISTER_ON_POP_STATE);
        await Page.EvaluateAsync("history.pushState(null, '', '/test'); history.back();");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(null)");
    }

    [Test]
    public async Task RegisterOnHashChange() {
        await ExecuteTest(HistoryGroup.BUTTON_REGISTER_ON_HASH_CHANGE);
        await Page.EvaluateAsync("window.location.href = 'https://localhost:5000/#anchor';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("new = https://localhost:5000/#anchor, old = https://localhost:5000/");
    }
}

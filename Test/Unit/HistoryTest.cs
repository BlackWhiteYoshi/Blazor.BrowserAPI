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
    public async Task RegisterOnPopState() {
        await ExecuteTest(HistoryGroup.BUTTON_REGISTER_ON_POP_STATE);
        await Page.EvaluateAsync("history.pushState(null, '', '/test'); history.back();");

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(null)");
    }
}

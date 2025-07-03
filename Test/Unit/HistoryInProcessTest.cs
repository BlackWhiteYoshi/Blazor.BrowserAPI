using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HistoryInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetLength() {
        await ExecuteTest(HistoryInProcessGroup.BUTTON_GET_LENGTH);

        string? result = await Page.GetByTestId(HistoryInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("2");
    }


    [Test]
    public async Task GetScrollRestoration() {
        await ExecuteTest(HistoryInProcessGroup.BUTTON_GET_SCROLL_RESTORATION);

        string? result = await Page.GetByTestId(HistoryInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("auto");
    }

    [Test]
    public async Task SetScrollRestoration() {
        await ExecuteTest(HistoryInProcessGroup.BUTTON_SET_SCROLL_RESTORATION);

        string? result = await Page.GetByTestId(HistoryInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("manual");
    }


    [Test]
    public async Task GetState() {
        await ExecuteTest(HistoryInProcessGroup.BUTTON_GET_STATE);

        string? result = await Page.GetByTestId(HistoryInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(null)");
    }



    [Test]
    public async Task Forward() {
        await Page.EvaluateAsync("history.pushState(null, '', '/test'); history.back();");
        await ExecuteTest(HistoryInProcessGroup.BUTTON_FORWARD);

        int historyLength = await Page.EvaluateAsync<int>("history.length;");
        await Assert.That(historyLength).IsEqualTo(3);

        string url = await Page.EvaluateAsync<string>("window.location.href;");
        await Assert.That(url).EndsWith("/test");
    }

    [Test]
    public async Task Back() {
        await Page.EvaluateAsync("history.pushState(null, '', '/test');");
        await ExecuteTest(HistoryInProcessGroup.BUTTON_BACK);

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

        await ExecuteTest(HistoryInProcessGroup.BUTTON_GO);

        int tempLabelCount = await Page.GetByTestId("temp").CountAsync();
        await Assert.That(tempLabelCount).IsEqualTo(0);
    }

    [Test]
    public async Task PushState() {
        await ExecuteTest(HistoryInProcessGroup.BUTTON_PUSH_STATE);

        int historyLength = await Page.EvaluateAsync<int>("history.length;");
        await Assert.That(historyLength).IsEqualTo(3);

        string url = await Page.EvaluateAsync<string>("window.location.href;");
        await Assert.That(url).EndsWith("/test");
    }

    [Test]
    public async Task ReplaceState() {
        await ExecuteTest(HistoryInProcessGroup.BUTTON_REPLACE_STATE);

        int historyLength = await Page.EvaluateAsync<int>("history.length;");
        await Assert.That(historyLength).IsEqualTo(2);

        string url = await Page.EvaluateAsync<string>("window.location.href;");
        await Assert.That(url).EndsWith("/test");
    }


    [Test]
    public async Task RegisterOnPopState() {
        await ExecuteTest(HistoryInProcessGroup.BUTTON_REGISTER_ON_POP_STATE);
        await Page.EvaluateAsync("history.pushState(null, '', '/test'); history.back();");

        string? result = await Page.GetByTestId(HistoryInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(null)");
    }
}

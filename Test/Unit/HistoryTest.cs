using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class HistoryTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetLength_Property() {
        await Page.GetByTestId(HistoryGroup.BUTTON_GET_LENGTH_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("2");
    }

    [Test]
    public async Task GetLength_Method() {
        await Page.GetByTestId(HistoryGroup.BUTTON_GET_LENGTH_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("2");
    }


    [Test]
    public async Task GetScrollRestoration_Property() {
        await Page.GetByTestId(HistoryGroup.BUTTON_GET_SCROLL_RESTORATION_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("auto");
    }

    [Test]
    public async Task GetScrollRestoration_Method() {
        await Page.GetByTestId(HistoryGroup.BUTTON_GET_SCROLL_RESTORATION_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("auto");
    }

    [Test]
    public async Task SetScrollRestoration() {
        await Page.GetByTestId(HistoryGroup.BUTTON_SET_SCROLL_RESTORATION).ClickAsync();

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("manual");
    }


    [Test]
    public async Task GetState_Property() {
        await Page.GetByTestId(HistoryGroup.BUTTON_GET_STATE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(null)");
    }

    [Test]
    public async Task GetState_Method() {
        await Page.GetByTestId(HistoryGroup.BUTTON_GET_STATE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(null)");
    }



    [Test]
    public async Task Forward() {
        await Page.EvaluateAsync("history.pushState(null, '', '/test'); history.back();");
        await Page.GetByTestId(HistoryGroup.BUTTON_FORWARD).ClickAsync();

        int historyLength = await Page.EvaluateAsync<int>("history.length;");
        await Assert.That(historyLength).IsEqualTo(3);

        string url = await Page.EvaluateAsync<string>("window.location.href;");
        await Assert.That(url).EndsWith("/test");
    }

    [Test]
    public async Task Back() {
        await Page.EvaluateAsync("history.pushState(null, '', '/test');");
        await Page.GetByTestId(HistoryGroup.BUTTON_BACK).ClickAsync();

        int historyLength = await Page.EvaluateAsync<int>("history.length;");
        await Assert.That(historyLength).IsEqualTo(3);

        string url = await Page.EvaluateAsync<string>("window.location.href;");
        await Assert.That(url).EndsWith("/");
    }

    [Test]
    public async Task Go() {
        await Page.GetByTestId(HistoryGroup.BUTTON_GO).ClickAsync();

        bool loadingSvgVisible = await Page.Locator(".loading-progress").IsVisibleAsync();
        await Assert.That(loadingSvgVisible).IsTrue();

        bool loadingPercentageVisible = await Page.Locator(".loading-progress-text").IsVisibleAsync();
        await Assert.That(loadingPercentageVisible).IsTrue();
    }

    [Test]
    public async Task PushState() {
        await Page.GetByTestId(HistoryGroup.BUTTON_PUSH_STATE).ClickAsync();

        int historyLength = await Page.EvaluateAsync<int>("history.length;");
        await Assert.That(historyLength).IsEqualTo(3);
        
        string url = await Page.EvaluateAsync<string>("window.location.href;");
        await Assert.That(url).EndsWith("/test");
    }

    [Test]
    public async Task ReplaceState() {
        await Page.GetByTestId(HistoryGroup.BUTTON_REPLACE_STATE).ClickAsync();

        int historyLength = await Page.EvaluateAsync<int>("history.length;");
        await Assert.That(historyLength).IsEqualTo(2);

        string url = await Page.EvaluateAsync<string>("window.location.href;");
        await Assert.That(url).EndsWith("/test");
    }


    [Test]
    public async Task RegisterOnPopState() {
        await Page.GetByTestId(HistoryGroup.BUTTON_REGISTER_ON_POP_STATE).ClickAsync();
        await Page.EvaluateAsync("history.pushState(null, '', '/test'); history.back();");

        string? result = await Page.GetByTestId(HistoryGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(null)");
    }
}

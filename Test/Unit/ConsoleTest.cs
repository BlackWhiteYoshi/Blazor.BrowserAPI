using BrowserAPI.Test.Client;
using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class ConsoleTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    private sealed class ConsoleMessageCapture : IDisposable {
        public string? Text { get; private set; } = null;

        private readonly IPage page;

        public ConsoleMessageCapture(IPage page) {
            this.page = page;
            page.Console += OnConsoleMessage;
        }

        public void Dispose() => page.Console -= OnConsoleMessage;


        private void OnConsoleMessage(object? sender, IConsoleMessage message) {
            if (message.Text.StartsWith("Debugging hotkey"))
                return;

            if (Text is not null)
                throw new Exception("Second Console Output: Each Test must produce only a single console output!");

            Text = message.Text;
        }
    }


    [Test]
    public async Task Assert_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_ASSERT_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleGroup.TEST_ASSERT);
    }

    [Test]
    public async Task Assert_Test() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_ASSERT).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleGroup.TEST_ASSERT}, {ConsoleGroup.TEST_ASSERT}]");
    }

    [Test]
    public async Task Clear() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_CLEAR).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("console.clear");
    }


    [Test]
    public async Task Count() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("default: 1");
    }

    [Test]
    public async Task Count_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"{ConsoleGroup.TEST_COUNT_LABEL}: 1");
    }

    [Test]
    public async Task CountReset() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT_RESET).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("Count for 'default' does not exist");
    }

    [Test]
    public async Task CountReset_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT_RESET_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"Count for '{ConsoleGroup.TEST_COUNT_LABEL}' does not exist");
    }


    [Test]
    public async Task Debug_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_DEBUG_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleGroup.TEST_DEBUG);
    }

    [Test]
    public async Task Debug() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_DEBUG).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleGroup.TEST_DEBUG}, {ConsoleGroup.TEST_DEBUG}]");
    }

    [Test]
    public async Task Dir() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_DIR).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleGroup.TEST_DIR);
    }

    [Test]
    public async Task Dirxml() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_DIRXML).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleGroup.TEST_DIRXML);
    }

    [Test]
    public async Task Error_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_ERROR_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleGroup.TEST_ERROR);
    }

    [Test]
    public async Task Error() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_ERROR).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleGroup.TEST_ERROR}, {ConsoleGroup.TEST_ERROR}]");
    }


    [Test]
    public async Task Group() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("undefined");
    }

    [Test]
    public async Task Group_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleGroup.TEST_GROUP_LABEL);
    }

    [Test]
    public async Task GroupCollapsed() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP_COLLAPSED).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("undefined");
    }

    [Test]
    public async Task GroupCollapsed_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP_COLLAPSED_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleGroup.TEST_GROUP_COLLAPSED_LABEL);
    }



    [Test]
    public async Task Info_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_INFO_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleGroup.TEST_INFO);
    }

    [Test]
    public async Task Info() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_INFO).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleGroup.TEST_INFO}, {ConsoleGroup.TEST_INFO}]");
    }

    [Test]
    public async Task Log_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_LOG_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleGroup.TEST_LOG);
    }

    [Test]
    public async Task Log() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_LOG).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleGroup.TEST_LOG}, {ConsoleGroup.TEST_LOG}]");
    }

    [Test]
    public async Task Table() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_TABLE).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleGroup.TEST_TABLE}, {ConsoleGroup.TEST_TABLE}]");
    }

    [Test]
    public async Task Table_Columns() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_TABLE_COLUMNS).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleGroup.TEST_TABLE_COLUMNS}, {ConsoleGroup.TEST_TABLE_COLUMNS}]");
    }


    [Test]
    public async Task Time() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME).ClickAsync();
        await Page.EvaluateAsync("console.timeEnd();");

        await Assert.That(consoleMessageCapture.Text).Matches("^default: .* ms$");
    }

    [Test]
    public async Task Time_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LABEL).ClickAsync();
        await Page.EvaluateAsync($"console.timeEnd('{ConsoleGroup.TEST_TIME_LABEL}');");

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms$");
    }

    [Test]
    public async Task TimeEnd() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync("console.time();");
        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_END).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).Matches("^default: .* ms$");
    }

    [Test]
    public async Task TimeEnd_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync($"console.time('{ConsoleGroup.TEST_TIME_LABEL}');");
        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_END_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms$");
    }

    [Test]
    public async Task TimeLog() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync("console.time();");
        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LOG).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).Matches("^default: .* ms$");
    }

    [Test]
    public async Task TimeLog_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync($"console.time('{ConsoleGroup.TEST_TIME_LABEL}');");
        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LOG_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms$");
    }

    [Test]
    public async Task TimeLog_LabelData() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync($"console.time('{ConsoleGroup.TEST_TIME_LABEL}');");
        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LOG_LABEL_DATA).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms \\[{ConsoleGroup.TEST_TIME_LOG_DATA}, {ConsoleGroup.TEST_TIME_LOG_DATA}\\]$");
    }


    [Test]
    public async Task Trace_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_TRACE_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleGroup.TEST_TRACE);
    }

    [Test]
    public async Task Trace() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_TRACE).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleGroup.TEST_TRACE}, {ConsoleGroup.TEST_TRACE}]");
    }

    [Test]
    public async Task Warn_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_WARN_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleGroup.TEST_WARN);
    }

    [Test]
    public async Task Warn() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleGroup.BUTTON_WARN).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleGroup.TEST_WARN}, {ConsoleGroup.TEST_WARN}]");
    }
}

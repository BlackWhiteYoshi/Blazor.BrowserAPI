using BrowserAPI.Test.Client;
using Microsoft.Playwright;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class ConsoleInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
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
    [Retry(3)]
    public async Task Assert_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_ASSERT_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_ASSERT);
    }

    [Test]
    [Retry(3)]
    public async Task Assert_Test() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_ASSERT).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_ASSERT}, {ConsoleInProcessGroup.TEST_ASSERT}]");
    }

    [Test]
    [Retry(3)]
    public async Task Clear() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_CLEAR).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("console.clear");
    }


    [Test]
    [Retry(3)]
    public async Task Count() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_COUNT).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("default: 1");
    }

    [Test]
    [Retry(3)]
    public async Task Count_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_COUNT_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"{ConsoleInProcessGroup.TEST_COUNT_LABEL}: 1");
    }

    [Test]
    [Retry(3)]
    public async Task CountReset() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_COUNT_RESET).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("Count for 'default' does not exist");
    }

    [Test]
    [Retry(3)]
    public async Task CountReset_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_COUNT_RESET_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"Count for '{ConsoleInProcessGroup.TEST_COUNT_LABEL}' does not exist");
    }


    [Test]
    [Retry(3)]
    public async Task Debug_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_DEBUG_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_DEBUG);
    }

    [Test]
    [Retry(3)]
    public async Task Debug() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_DEBUG).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_DEBUG}, {ConsoleInProcessGroup.TEST_DEBUG}]");
    }

    [Test]
    [Retry(3)]
    public async Task Dir() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_DIR).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_DIR);
    }

    [Test]
    [Retry(3)]
    public async Task Dirxml() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_DIRXML).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_DIRXML);
    }

    [Test]
    [Retry(3)]
    public async Task Error_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_ERROR_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_ERROR);
    }

    [Test]
    [Retry(3)]
    public async Task Error() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_ERROR).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_ERROR}, {ConsoleInProcessGroup.TEST_ERROR}]");
    }


    [Test]
    [Retry(3)]
    public async Task Group() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_GROUP).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("undefined");
    }

    [Test]
    [Retry(3)]
    public async Task Group_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_GROUP_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_GROUP_LABEL);
    }

    [Test]
    [Retry(3)]
    public async Task GroupCollapsed() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_GROUP_COLLAPSED).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("undefined");
    }

    [Test]
    [Retry(3)]
    public async Task GroupCollapsed_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_GROUP_COLLAPSED_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_GROUP_COLLAPSED_LABEL);
    }



    [Test]
    [Retry(3)]
    public async Task Info_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_INFO_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_INFO);
    }

    [Test]
    [Retry(3)]
    public async Task Info() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_INFO).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_INFO}, {ConsoleInProcessGroup.TEST_INFO}]");
    }

    [Test]
    [Retry(3)]
    public async Task Log_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_LOG_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_LOG);
    }

    [Test]
    [Retry(3)]
    public async Task Log() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_LOG).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_LOG}, {ConsoleInProcessGroup.TEST_LOG}]");
    }

    [Test]
    [Retry(3)]
    public async Task Table() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TABLE).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_TABLE}, {ConsoleInProcessGroup.TEST_TABLE}]");
    }

    [Test]
    [Retry(3)]
    public async Task Table_Columns() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TABLE_COLUMNS).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_TABLE_COLUMNS}, {ConsoleInProcessGroup.TEST_TABLE_COLUMNS}]");
    }


    [Test]
    [Retry(3)]
    public async Task Time() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME).ClickAsync();
        await Page.EvaluateAsync("console.timeEnd();");

        await Assert.That(consoleMessageCapture.Text).Matches("^default: .* ms$");
    }

    [Test]
    [Retry(3)]
    public async Task Time_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_LABEL).ClickAsync();
        await Page.EvaluateAsync($"console.timeEnd('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms$");
    }

    [Test]
    [Retry(3)]
    public async Task TimeEnd() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync("console.time();");
        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_END).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).Matches("^default: .* ms$");
    }

    [Test]
    [Retry(3)]
    public async Task TimeEnd_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync($"console.time('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");
        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_END_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms$");
    }

    [Test]
    [Retry(3)]
    public async Task TimeLog() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync("console.time();");
        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_LOG).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).Matches("^default: .* ms$");
    }

    [Test]
    [Retry(3)]
    public async Task TimeLog_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync($"console.time('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");
        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_LOG_LABEL).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms$");
    }

    [Test]
    [Retry(3)]
    public async Task TimeLog_LabelData() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync($"console.time('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");
        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_LOG_LABEL_DATA).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms \\[{ConsoleInProcessGroup.TEST_TIME_LOG_DATA}, {ConsoleInProcessGroup.TEST_TIME_LOG_DATA}\\]$");
    }


    [Test]
    [Retry(3)]
    public async Task Trace_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TRACE_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_TRACE);
    }

    [Test]
    [Retry(3)]
    public async Task Trace() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TRACE).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_TRACE}, {ConsoleInProcessGroup.TEST_TRACE}]");
    }

    [Test]
    [Retry(3)]
    public async Task Warn_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_WARN_STRING).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_WARN);
    }

    [Test]
    [Retry(3)]
    public async Task Warn() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_WARN).ClickAsync();

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_WARN}, {ConsoleInProcessGroup.TEST_WARN}]");
    }
}

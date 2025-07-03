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
    public async Task Assert_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_ASSERT_STRING);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_ASSERT);
    }

    [Test]
    public async Task Assert_Test() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_ASSERT);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_ASSERT}, {ConsoleInProcessGroup.TEST_ASSERT}]");
    }

    [Test]
    public async Task Clear() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_CLEAR);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("console.clear");
    }


    [Test]
    public async Task Count() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_COUNT);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("default: 1");
    }

    [Test]
    public async Task Count_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_COUNT_LABEL);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"{ConsoleInProcessGroup.TEST_COUNT_LABEL}: 1");
    }

    [Test]
    public async Task CountReset() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_COUNT_RESET);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("Count for 'default' does not exist");
    }

    [Test]
    public async Task CountReset_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_COUNT_RESET_LABEL);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"Count for '{ConsoleInProcessGroup.TEST_COUNT_LABEL}' does not exist");
    }


    [Test]
    public async Task Debug_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_DEBUG_STRING);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_DEBUG);
    }

    [Test]
    public async Task Debug() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_DEBUG);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_DEBUG}, {ConsoleInProcessGroup.TEST_DEBUG}]");
    }

    [Test]
    public async Task Dir() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_DIR);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_DIR);
    }

    [Test]
    public async Task Dirxml() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_DIRXML);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_DIRXML);
    }

    [Test]
    public async Task Error_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_ERROR_STRING);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_ERROR);
    }

    [Test]
    public async Task Error() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_ERROR);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_ERROR}, {ConsoleInProcessGroup.TEST_ERROR}]");
    }


    [Test]
    public async Task Group() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_GROUP);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("undefined");
    }

    [Test]
    public async Task Group_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_GROUP_LABEL);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_GROUP_LABEL);
    }

    [Test]
    public async Task GroupCollapsed() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_GROUP_COLLAPSED);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo("undefined");
    }

    [Test]
    public async Task GroupCollapsed_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_GROUP_COLLAPSED_LABEL);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_GROUP_COLLAPSED_LABEL);
    }



    [Test]
    public async Task Info_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_INFO_STRING);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_INFO);
    }

    [Test]
    public async Task Info() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_INFO);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_INFO}, {ConsoleInProcessGroup.TEST_INFO}]");
    }

    [Test]
    public async Task Log_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_LOG_STRING);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_LOG);
    }

    [Test]
    public async Task Log() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_LOG);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_LOG}, {ConsoleInProcessGroup.TEST_LOG}]");
    }

    [Test]
    public async Task Table() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_TABLE);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_TABLE}, {ConsoleInProcessGroup.TEST_TABLE}]");
    }

    [Test]
    public async Task Table_Columns() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_TABLE_COLUMNS);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_TABLE_COLUMNS}, {ConsoleInProcessGroup.TEST_TABLE_COLUMNS}]");
    }


    [Test]
    public async Task Time() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_TIME);
        await Page.EvaluateAsync("console.timeEnd();");

        await Assert.That(consoleMessageCapture.Text).Matches("^default: .* ms$");
    }

    [Test]
    public async Task Time_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_TIME_LABEL);
        await Page.EvaluateAsync($"console.timeEnd('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms$");
    }

    [Test]
    public async Task TimeEnd() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync("console.time();");
        await ExecuteTest(ConsoleInProcessGroup.BUTTON_TIME_END);

        await Assert.That(consoleMessageCapture.Text).Matches("^default: .* ms$");
    }

    [Test]
    public async Task TimeEnd_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync($"console.time('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");
        await ExecuteTest(ConsoleInProcessGroup.BUTTON_TIME_END_LABEL);

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms$");
    }

    [Test]
    public async Task TimeLog() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync("console.time();");
        await ExecuteTest(ConsoleInProcessGroup.BUTTON_TIME_LOG);

        await Assert.That(consoleMessageCapture.Text).Matches("^default: .* ms$");
    }

    [Test]
    public async Task TimeLog_Label() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync($"console.time('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");
        await ExecuteTest(ConsoleInProcessGroup.BUTTON_TIME_LOG_LABEL);

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms$");
    }

    [Test]
    public async Task TimeLog_LabelData() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await Page.EvaluateAsync($"console.time('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");
        await ExecuteTest(ConsoleInProcessGroup.BUTTON_TIME_LOG_LABEL_DATA);

        await Assert.That(consoleMessageCapture.Text).Matches($"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms \\[{ConsoleInProcessGroup.TEST_TIME_LOG_DATA}, {ConsoleInProcessGroup.TEST_TIME_LOG_DATA}\\]$");
    }


    [Test]
    public async Task Trace_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_TRACE_STRING);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_TRACE);
    }

    [Test]
    public async Task Trace() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_TRACE);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_TRACE}, {ConsoleInProcessGroup.TEST_TRACE}]");
    }

    [Test]
    public async Task Warn_String() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_WARN_STRING);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo(ConsoleInProcessGroup.TEST_WARN);
    }

    [Test]
    public async Task Warn() {
        using ConsoleMessageCapture consoleMessageCapture = new(Page);

        await ExecuteTest(ConsoleInProcessGroup.BUTTON_WARN);

        await Assert.That(consoleMessageCapture.Text).IsEqualTo($"[{ConsoleInProcessGroup.TEST_WARN}, {ConsoleInProcessGroup.TEST_WARN}]");
    }
}

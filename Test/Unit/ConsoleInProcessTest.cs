using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class ConsoleInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    private string? assertValue = null;
    private bool assertRegex = false;
    private bool assertSuccess = false;

    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        Page.Console += Assertion;
    }

    public override async Task DisposeAsync() {
        Page.Console -= Assertion;
        await base.DisposeAsync();
        Assert.True(assertSuccess);
    }

    private void Assertion(object? sender, IConsoleMessage message) {
        if (assertRegex) {
            if (assertValue != null && Regex.Match(message.Text, assertValue).Success)
                assertSuccess = true;
        }
        else {
            if (assertValue == message.Text)
                assertSuccess = true;
        }
    }


    [Fact]
    public async Task Assert_String() {
        assertValue = ConsoleInProcessGroup.TEST_ASSERT;

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_ASSERT_STRING).ClickAsync();
    }

    [Fact]
    public async Task Assert_Test() {
        assertValue = $"[{ConsoleInProcessGroup.TEST_ASSERT}, {ConsoleInProcessGroup.TEST_ASSERT}]";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_ASSERT).ClickAsync();
    }

    [Fact]
    public async Task Clear() {
        assertValue = "console.clear";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_CLEAR).ClickAsync();
    }


    [Fact]
    public async Task Count() {
        assertValue = "default: 1";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_COUNT).ClickAsync();
    }

    [Fact]
    public async Task Count_Label() {
        assertValue = $"{ConsoleInProcessGroup.TEST_COUNT_LABEL}: 1";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_COUNT_LABEL).ClickAsync();
    }

    [Fact]
    public async Task CountReset() {
        assertValue = "Count for 'default' does not exist";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_COUNT_RESET).ClickAsync();
    }

    [Fact]
    public async Task CountReset_Label() {
        assertValue = $"Count for '{ConsoleInProcessGroup.TEST_COUNT_LABEL}' does not exist";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_COUNT_RESET_LABEL).ClickAsync();
    }


    [Fact]
    public async Task Debug_String() {
        assertValue = ConsoleInProcessGroup.TEST_DEBUG;

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_DEBUG_STRING).ClickAsync();
    }

    [Fact]
    public async Task Debug() {
        assertValue = $"[{ConsoleInProcessGroup.TEST_DEBUG}, {ConsoleInProcessGroup.TEST_DEBUG}]";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_DEBUG).ClickAsync();
    }

    [Fact]
    public async Task Dir() {
        assertValue = ConsoleInProcessGroup.TEST_DIR;

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_DIR).ClickAsync();
    }

    [Fact]
    public async Task Dirxml() {
        assertValue = ConsoleInProcessGroup.TEST_DIRXML;

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_DIRXML).ClickAsync();
    }

    [Fact]
    public async Task Error_String() {
        assertValue = ConsoleInProcessGroup.TEST_ERROR;

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_ERROR_STRING).ClickAsync();
    }

    [Fact]
    public async Task Error() {
        assertValue = $"[{ConsoleInProcessGroup.TEST_ERROR}, {ConsoleInProcessGroup.TEST_ERROR}]";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_ERROR).ClickAsync();
    }


    [Fact]
    public async Task Group() {
        assertValue = "undefined";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_GROUP).ClickAsync();
    }

    [Fact]
    public async Task Group_Label() {
        assertValue = ConsoleInProcessGroup.TEST_GROUP_LABEL;

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_GROUP_LABEL).ClickAsync();
    }

    [Fact]
    public async Task GroupCollapsed() {
        assertValue = "undefined";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_GROUP_COLLAPSED).ClickAsync();
    }

    [Fact]
    public async Task GroupCollapsed_Label() {
        assertValue = ConsoleInProcessGroup.TEST_GROUP_COLLAPSED_LABEL;

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_GROUP_COLLAPSED_LABEL).ClickAsync();
    }



    [Fact]
    public async Task Info_String() {
        assertValue = ConsoleInProcessGroup.TEST_INFO;

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_INFO_STRING).ClickAsync();
    }

    [Fact]
    public async Task Info() {
        assertValue = $"[{ConsoleInProcessGroup.TEST_INFO}, {ConsoleInProcessGroup.TEST_INFO}]";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_INFO).ClickAsync();
    }

    [Fact]
    public async Task Log_String() {
        assertValue = ConsoleInProcessGroup.TEST_LOG;

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_LOG_STRING).ClickAsync();
    }

    [Fact]
    public async Task Log() {
        assertValue = $"[{ConsoleInProcessGroup.TEST_LOG}, {ConsoleInProcessGroup.TEST_LOG}]";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_LOG).ClickAsync();
    }

    [Fact]
    public async Task Table() {
        assertValue = $"[{ConsoleInProcessGroup.TEST_TABLE}, {ConsoleInProcessGroup.TEST_TABLE}]";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TABLE).ClickAsync();
    }

    [Fact]
    public async Task Table_Columns() {
        assertValue = $"[{ConsoleInProcessGroup.TEST_TABLE_COLUMNS}, {ConsoleInProcessGroup.TEST_TABLE_COLUMNS}]";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TABLE_COLUMNS).ClickAsync();
    }


    [Fact]
    public async Task Time() {
        assertRegex = true;
        assertValue = "^default: .* ms$";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME).ClickAsync();
        await Page.EvaluateAsync("console.timeEnd();");
    }

    [Fact]
    public async Task Time_Label() {
        assertRegex = true;
        assertValue = $"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms$";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_LABEL).ClickAsync();
        await Page.EvaluateAsync($"console.timeEnd('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");
    }

    [Fact]
    public async Task TimeEnd() {
        assertRegex = true;
        assertValue = "^default: .* ms$";
        await Page.EvaluateAsync($"console.time();");

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_END).ClickAsync();
    }

    [Fact]
    public async Task TimeEnd_Label() {
        assertRegex = true;
        assertValue = $"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms$";
        await Page.EvaluateAsync($"console.time('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_END_LABEL).ClickAsync();
    }

    [Fact]
    public async Task TimeLog() {
        assertRegex = true;
        assertValue = "^default: .* ms$";
        await Page.EvaluateAsync($"console.time();");

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_LOG).ClickAsync();
    }

    [Fact]
    public async Task TimeLog_Label() {
        assertRegex = true;
        assertValue = $"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms$";
        await Page.EvaluateAsync($"console.time('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_LOG_LABEL).ClickAsync();
    }

    [Fact]
    public async Task TimeLog_LabelData() {
        assertRegex = true;
        assertValue = $"^{ConsoleInProcessGroup.TEST_TIME_LABEL}: .* ms \\[{ConsoleInProcessGroup.TEST_TIME_LOG_DATA}, {ConsoleInProcessGroup.TEST_TIME_LOG_DATA}\\]$";
        await Page.EvaluateAsync($"console.time('{ConsoleInProcessGroup.TEST_TIME_LABEL}');");

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TIME_LOG_LABEL_DATA).ClickAsync();
    }


    [Fact]
    public async Task Trace_String() {
        assertValue = ConsoleInProcessGroup.TEST_TRACE;

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TRACE_STRING).ClickAsync();
    }

    [Fact]
    public async Task Trace() {
        assertValue = $"[{ConsoleInProcessGroup.TEST_TRACE}, {ConsoleInProcessGroup.TEST_TRACE}]";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_TRACE).ClickAsync();
    }

    [Fact]
    public async Task Warn_String() {
        assertValue = ConsoleInProcessGroup.TEST_WARN;

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_WARN_STRING).ClickAsync();
    }

    [Fact]
    public async Task Warn() {
        assertValue = $"[{ConsoleInProcessGroup.TEST_WARN}, {ConsoleInProcessGroup.TEST_WARN}]";

        await Page.GetByTestId(ConsoleInProcessGroup.BUTTON_WARN).ClickAsync();
    }
}

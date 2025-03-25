using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class ConsoleTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    private string? assertValue = null;
    private bool assertRegex = false;
    private bool assertSuccess = false;

    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        Page.Console += Assertion;
    }

    public override async Task DisposeAsync() {
        Assert.True(assertSuccess);
        await base.DisposeAsync();
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
        assertValue = ConsoleGroup.TEST_ASSERT;

        await Page.GetByTestId(ConsoleGroup.BUTTON_ASSERT_STRING).ClickAsync();
    }

    [Fact]
    public async Task Assert_Test() {
        assertValue = $"[{ConsoleGroup.TEST_ASSERT}, {ConsoleGroup.TEST_ASSERT}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_ASSERT).ClickAsync();
    }

    [Fact]
    public async Task Clear() {
        assertValue = "console.clear";

        await Page.GetByTestId(ConsoleGroup.BUTTON_CLEAR).ClickAsync();
    }


    [Fact]
    public async Task Count() {
        assertValue = "default: 1";

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT).ClickAsync();
    }

    [Fact]
    public async Task Count_Label() {
        assertValue = $"{ConsoleGroup.TEST_COUNT_LABEL}: 1";

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT_LABEL).ClickAsync();
    }

    [Fact]
    public async Task CountReset() {
        assertValue = "Count for 'default' does not exist";

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT_RESET).ClickAsync();
    }

    [Fact]
    public async Task CountReset_Label() {
        assertValue = $"Count for '{ConsoleGroup.TEST_COUNT_LABEL}' does not exist";

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT_RESET_LABEL).ClickAsync();
    }


    [Fact]
    public async Task Debug_String() {
        assertValue = ConsoleGroup.TEST_DEBUG;

        await Page.GetByTestId(ConsoleGroup.BUTTON_DEBUG_STRING).ClickAsync();
    }

    [Fact]
    public async Task Debug() {
        assertValue = $"[{ConsoleGroup.TEST_DEBUG}, {ConsoleGroup.TEST_DEBUG}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_DEBUG).ClickAsync();
    }

    [Fact]
    public async Task Dir() {
        assertValue = ConsoleGroup.TEST_DIR;

        await Page.GetByTestId(ConsoleGroup.BUTTON_DIR).ClickAsync();
    }

    [Fact]
    public async Task Dirxml() {
        assertValue = ConsoleGroup.TEST_DIRXML;

        await Page.GetByTestId(ConsoleGroup.BUTTON_DIRXML).ClickAsync();
    }

    [Fact]
    public async Task Error_String() {
        assertValue = ConsoleGroup.TEST_ERROR;

        await Page.GetByTestId(ConsoleGroup.BUTTON_ERROR_STRING).ClickAsync();
    }

    [Fact]
    public async Task Error() {
        assertValue = $"[{ConsoleGroup.TEST_ERROR}, {ConsoleGroup.TEST_ERROR}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_ERROR).ClickAsync();
    }


    [Fact]
    public async Task Group() {
        assertValue = "undefined";

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP).ClickAsync();
    }

    [Fact]
    public async Task Group_Label() {
        assertValue = ConsoleGroup.TEST_GROUP_LABEL;

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP_LABEL).ClickAsync();
    }

    [Fact]
    public async Task GroupCollapsed() {
        assertValue = "undefined";

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP_COLLAPSED).ClickAsync();
    }

    [Fact]
    public async Task GroupCollapsed_Label() {
        assertValue = ConsoleGroup.TEST_GROUP_COLLAPSED_LABEL;

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP_COLLAPSED_LABEL).ClickAsync();
    }



    [Fact]
    public async Task Info_String() {
        assertValue = ConsoleGroup.TEST_INFO;

        await Page.GetByTestId(ConsoleGroup.BUTTON_INFO_STRING).ClickAsync();
    }

    [Fact]
    public async Task Info() {
        assertValue = $"[{ConsoleGroup.TEST_INFO}, {ConsoleGroup.TEST_INFO}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_INFO).ClickAsync();
    }

    [Fact]
    public async Task Log_String() {
        assertValue = ConsoleGroup.TEST_LOG;

        await Page.GetByTestId(ConsoleGroup.BUTTON_LOG_STRING).ClickAsync();
    }

    [Fact]
    public async Task Log() {
        assertValue = $"[{ConsoleGroup.TEST_LOG}, {ConsoleGroup.TEST_LOG}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_LOG).ClickAsync();
    }

    [Fact]
    public async Task Table() {
        assertValue = $"[{ConsoleGroup.TEST_TABLE}, {ConsoleGroup.TEST_TABLE}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_TABLE).ClickAsync();
    }

    [Fact]
    public async Task Table_Columns() {
        assertValue = $"[{ConsoleGroup.TEST_TABLE_COLUMNS}, {ConsoleGroup.TEST_TABLE_COLUMNS}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_TABLE_COLUMNS).ClickAsync();
    }


    [Fact]
    public async Task Time() {
        assertRegex = true;
        assertValue = "^default: .* ms$";

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME).ClickAsync();
        await Page.EvaluateAsync("console.timeEnd();");
    }

    [Fact]
    public async Task Time_Label() {
        assertRegex = true;
        assertValue = $"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms$";

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LABEL).ClickAsync();
        await Page.EvaluateAsync($"console.timeEnd('{ConsoleGroup.TEST_TIME_LABEL}');");
    }

    [Fact]
    public async Task TimeEnd() {
        assertRegex = true;
        assertValue = "^default: .* ms$";
        await Page.EvaluateAsync($"console.time();");

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_END).ClickAsync();
    }

    [Fact]
    public async Task TimeEnd_Label() {
        assertRegex = true;
        assertValue = $"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms$";
        await Page.EvaluateAsync($"console.time('{ConsoleGroup.TEST_TIME_LABEL}');");

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_END_LABEL).ClickAsync();
    }

    [Fact]
    public async Task TimeLog() {
        assertRegex = true;
        assertValue = "^default: .* ms$";
        await Page.EvaluateAsync($"console.time();");

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LOG).ClickAsync();
    }

    [Fact]
    public async Task TimeLog_Label() {
        assertRegex = true;
        assertValue = $"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms$";
        await Page.EvaluateAsync($"console.time('{ConsoleGroup.TEST_TIME_LABEL}');");

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LOG_LABEL).ClickAsync();
    }

    [Fact]
    public async Task TimeLog_LabelData() {
        assertRegex = true;
        assertValue = $"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms \\[{ConsoleGroup.TEST_TIME_LOG_DATA}, {ConsoleGroup.TEST_TIME_LOG_DATA}\\]$";
        await Page.EvaluateAsync($"console.time('{ConsoleGroup.TEST_TIME_LABEL}');");

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LOG_LABEL_DATA).ClickAsync();
    }


    [Fact]
    public async Task Trace_String() {
        assertValue = ConsoleGroup.TEST_TRACE;

        await Page.GetByTestId(ConsoleGroup.BUTTON_TRACE_STRING).ClickAsync();
    }

    [Fact]
    public async Task Trace() {
        assertValue = $"[{ConsoleGroup.TEST_TRACE}, {ConsoleGroup.TEST_TRACE}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_TRACE).ClickAsync();
    }

    [Fact]
    public async Task Warn_String() {
        assertValue = ConsoleGroup.TEST_WARN;

        await Page.GetByTestId(ConsoleGroup.BUTTON_WARN_STRING).ClickAsync();
    }

    [Fact]
    public async Task Warn() {
        assertValue = $"[{ConsoleGroup.TEST_WARN}, {ConsoleGroup.TEST_WARN}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_WARN).ClickAsync();
    }
}

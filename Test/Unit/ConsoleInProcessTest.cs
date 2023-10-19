using BrowserAPI.Test.Client;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using Xunit;

namespace BrowserAPI.UnitTest;

public sealed class ConsoleInProcessTest : PlayWrightTest {
    private string? assertValue = null;
    private bool assertRegex = false;
    private bool assertSuccess = false;

    public ConsoleInProcessTest(PlayWrightFixture playWrightFixture) : base(playWrightFixture) { }

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
        assertValue = ConsoleGroup.TEST_ASSERT;
        
        await Page.GetByTestId(ConsoleGroup.BUTTON_ASSERT_STRING_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Assert_Test() {
        assertValue = $"[{ConsoleGroup.TEST_ASSERT}, {ConsoleGroup.TEST_ASSERT}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_ASSERT_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Clear() {
        assertValue = "console.clear";

        await Page.GetByTestId(ConsoleGroup.BUTTON_CLEAR_INPROCESS).ClickAsync();
    }


    [Fact]
    public async Task Count() {
        assertValue = "default: 1";

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Count_Label() {
        assertValue = $"{ConsoleGroup.TEST_COUNT_LABEL}: 1";

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT_LABEL_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task CountReset() {
        assertValue = "Count for 'default' does not exist";

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT_RESET_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task CountReset_Label() {
        assertValue = $"Count for '{ConsoleGroup.TEST_COUNT_LABEL}' does not exist";

        await Page.GetByTestId(ConsoleGroup.BUTTON_COUNT_RESET_LABEL_INPROCESS).ClickAsync();
    }


    [Fact]
    public async Task Debug_String() {
        assertValue = ConsoleGroup.TEST_DEBUG;

        await Page.GetByTestId(ConsoleGroup.BUTTON_DEBUG_STRING_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Debug() {
        assertValue = $"[{ConsoleGroup.TEST_DEBUG}, {ConsoleGroup.TEST_DEBUG}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_DEBUG_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Dir() {
        assertValue = ConsoleGroup.TEST_DIR;

        await Page.GetByTestId(ConsoleGroup.BUTTON_DIR_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Dirxml() {
        assertValue = ConsoleGroup.TEST_DIRXML;

        await Page.GetByTestId(ConsoleGroup.BUTTON_DIRXML_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Error_String() {
        assertValue = ConsoleGroup.TEST_ERROR;

        await Page.GetByTestId(ConsoleGroup.BUTTON_ERROR_STRING_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Error() {
        assertValue = $"[{ConsoleGroup.TEST_ERROR}, {ConsoleGroup.TEST_ERROR}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_ERROR_INPROCESS).ClickAsync();
    }


    [Fact]
    public async Task Group() {
        assertValue = "undefined";

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Group_Label() {
        assertValue = ConsoleGroup.TEST_GROUP_LABEL;

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP_LABEL_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task GroupCollapsed() {
        assertValue = "undefined";

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP_COLLAPSED_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task GroupCollapsed_Label() {
        assertValue = ConsoleGroup.TEST_GROUP_COLLAPSED_LABEL;

        await Page.GetByTestId(ConsoleGroup.BUTTON_GROUP_COLLAPSED_LABEL_INPROCESS).ClickAsync();
    }



    [Fact]
    public async Task Info_String() {
        assertValue = ConsoleGroup.TEST_INFO;

        await Page.GetByTestId(ConsoleGroup.BUTTON_INFO_STRING_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Info() {
        assertValue = $"[{ConsoleGroup.TEST_INFO}, {ConsoleGroup.TEST_INFO}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_INFO_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Log_String() {
        assertValue = ConsoleGroup.TEST_LOG;

        await Page.GetByTestId(ConsoleGroup.BUTTON_LOG_STRING_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Log() {
        assertValue = $"[{ConsoleGroup.TEST_LOG}, {ConsoleGroup.TEST_LOG}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_LOG_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Table() {
        assertValue = $"[{ConsoleGroup.TEST_TABLE}, {ConsoleGroup.TEST_TABLE}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_TABLE_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Table_Columns() {
        assertValue = $"[{ConsoleGroup.TEST_TABLE_COLUMNS}, {ConsoleGroup.TEST_TABLE_COLUMNS}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_TABLE_COLUMNS_INPROCESS).ClickAsync();
    }


    [Fact]
    public async Task Time() {
        assertRegex = true;
        assertValue = "^default: .* ms$";

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_INPROCESS).ClickAsync();
        await Page.EvaluateAsync("console.timeEnd();");
    }

    [Fact]
    public async Task Time_Label() {
        assertRegex = true;
        assertValue = $"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms$";

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LABEL_INPROCESS).ClickAsync();
        await Page.EvaluateAsync($"console.timeEnd('{ConsoleGroup.TEST_TIME_LABEL}');");
    }

    [Fact]
    public async Task TimeEnd() {
        assertRegex = true;
        assertValue = "^default: .* ms$";
        await Page.EvaluateAsync($"console.time();");

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_END_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task TimeEnd_Label() {
        assertRegex = true;
        assertValue = $"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms$";
        await Page.EvaluateAsync($"console.time('{ConsoleGroup.TEST_TIME_LABEL}');");

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_END_LABEL_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task TimeLog() {
        assertRegex = true;
        assertValue = "^default: .* ms$";
        await Page.EvaluateAsync($"console.time();");

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LOG_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task TimeLog_Label() {
        assertRegex = true;
        assertValue = $"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms$";
        await Page.EvaluateAsync($"console.time('{ConsoleGroup.TEST_TIME_LABEL}');");

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LOG_LABEL_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task TimeLog_LabelData() {
        assertRegex = true;
        assertValue = $"^{ConsoleGroup.TEST_TIME_LABEL}: .* ms \\[{ConsoleGroup.TEST_TIME_LOG_DATA}, {ConsoleGroup.TEST_TIME_LOG_DATA}\\]$";
        await Page.EvaluateAsync($"console.time('{ConsoleGroup.TEST_TIME_LABEL}');");

        await Page.GetByTestId(ConsoleGroup.BUTTON_TIME_LOG_LABEL_DATA_INPROCESS).ClickAsync();
    }


    [Fact]
    public async Task Trace_String() {
        assertValue = ConsoleGroup.TEST_TRACE;

        await Page.GetByTestId(ConsoleGroup.BUTTON_TRACE_STRING_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Trace() {
        assertValue = $"[{ConsoleGroup.TEST_TRACE}, {ConsoleGroup.TEST_TRACE}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_TRACE_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Warn_String() {
        assertValue = ConsoleGroup.TEST_WARN;

        await Page.GetByTestId(ConsoleGroup.BUTTON_WARN_STRING_INPROCESS).ClickAsync();
    }

    [Fact]
    public async Task Warn() {
        assertValue = $"[{ConsoleGroup.TEST_WARN}, {ConsoleGroup.TEST_WARN}]";

        await Page.GetByTestId(ConsoleGroup.BUTTON_WARN_INPROCESS).ClickAsync();
    }
}

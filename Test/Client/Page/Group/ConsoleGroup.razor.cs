using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class ConsoleGroup : ComponentBase {
    public const string TEST_ASSERT = "console assert test";
    public const string TEST_COUNT_LABEL = "console count label test";
    public const string TEST_DEBUG = "console debug test";
    public const string TEST_DIR = "console dir test";
    public const string TEST_DIRXML = "console dirxml test";
    public const string TEST_ERROR = "console error test";
    public const string TEST_GROUP_LABEL = "console group label test";
    public const string TEST_GROUP_COLLAPSED_LABEL = "console groupcollapsed label test";
    public const string TEST_INFO = "console info test";
    public const string TEST_LOG = "console log test";
    public const string TEST_TABLE = "console table test";
    public const string TEST_TABLE_COLUMNS = "console table test column";
    public const string TEST_TIME_LABEL = "console time label test";
    public const string TEST_TIME_LOG_DATA = "console time log data test";
    public const string TEST_TRACE = "console trace test";
    public const string TEST_WARN = "console warn test";


    [Inject]
    public required IConsole Console { private get; init; }


    public const string BUTTON_ASSERT_STRING = "console-assert-string";
    private async Task Assert_String() {
        await Console.Assert(false, TEST_ASSERT);
    }

    public const string BUTTON_ASSERT = "console-assert";
    private async Task Assert() {
        await Console.Assert(false, [TEST_ASSERT, TEST_ASSERT]);
    }

    public const string BUTTON_CLEAR = "console-clear";
    private async Task Clear() {
        await Console.Clear();
    }


    public const string BUTTON_COUNT = "console-count";
    private async Task Count() {
        await Console.Count();
    }

    public const string BUTTON_COUNT_LABEL = "console-count-label";
    private async Task Count_Label() {
        await Console.Count(TEST_COUNT_LABEL);
    }

    public const string BUTTON_COUNT_RESET = "console-count-reset";
    private async Task CountReset() {
        await Console.CountReset();
    }

    public const string BUTTON_COUNT_RESET_LABEL = "console-count-reset-label";
    private async Task CountReset_Label() {
        await Console.CountReset(TEST_COUNT_LABEL);
    }


    public const string BUTTON_DEBUG_STRING = "console-debug-string";
    private async Task Debug_String() {
        await Console.Debug(TEST_DEBUG);
    }

    public const string BUTTON_DEBUG = "console-debug";
    private async Task Debug() {
        await Console.Debug([TEST_DEBUG, TEST_DEBUG]);
    }

    public const string BUTTON_DIR = "console-dir";
    private async Task Dir() {
        await Console.Dir(TEST_DIR);
    }

    public const string BUTTON_DIRXML = "console-dirxml";
    private async Task Dirxml() {
        await Console.Dirxml(TEST_DIRXML);
    }

    public const string BUTTON_ERROR_STRING = "console-error-string";
    private async Task Error_String() {
        await Console.Error(TEST_ERROR);
    }

    public const string BUTTON_ERROR = "console-error";
    private async Task Error() {
        await Console.Error([TEST_ERROR, TEST_ERROR]);
    }


    public const string BUTTON_GROUP = "console-group";
    private async Task Group() {
        await Console.Group();
    }

    public const string BUTTON_GROUP_LABEL = "console-group-label";
    private async Task Group_Label() {
        await Console.Group(TEST_GROUP_LABEL);
    }

    public const string BUTTON_GROUP_COLLAPSED = "console-group-collapsed";
    private async Task GroupCollapsed() {
        await Console.GroupCollapsed();
    }

    public const string BUTTON_GROUP_COLLAPSED_LABEL = "console-group-collapsed-label";
    private async Task GroupCollapsed_Label() {
        await Console.GroupCollapsed(TEST_GROUP_COLLAPSED_LABEL);
    }

    public const string BUTTON_GROUP_END = "console-group-end";
    private async Task GroupEnd() {
        await Console.GroupEnd();
    }


    public const string BUTTON_INFO_STRING = "console-info-string";
    private async Task Info_String() {
        await Console.Info(TEST_INFO);
    }

    public const string BUTTON_INFO = "console-info";
    private async Task Info() {
        await Console.Info([TEST_INFO, TEST_INFO]);
    }

    public const string BUTTON_LOG_STRING = "console-log-string";
    private async Task Log_String() {
        await Console.Log(TEST_LOG);
    }

    public const string BUTTON_LOG = "console-log";
    private async Task Log() {
        await Console.Log([TEST_LOG, TEST_LOG]);
    }

    public const string BUTTON_TABLE = "console-table";
    private async Task Table() {
        await Console.Table((object[])[TEST_TABLE, TEST_TABLE]);
    }

    public const string BUTTON_TABLE_COLUMNS = "console-table-columns";
    private async Task Table_Columns() {
        await Console.Table((string[])[TEST_TABLE_COLUMNS, TEST_TABLE_COLUMNS], []);
    }


    public const string BUTTON_TIME = "console-time";
    private async Task Time() {
        await Console.Time();
    }

    public const string BUTTON_TIME_LABEL = "console-time-label";
    private async Task Time_Label() {
        await Console.Time(TEST_TIME_LABEL);
    }

    public const string BUTTON_TIME_END = "console-time-end";
    private async Task TimeEnd() {
        await Console.TimeEnd();
    }

    public const string BUTTON_TIME_END_LABEL = "console-time-end-label";
    private async Task TimeEnd_Label() {
        await Console.TimeEnd(TEST_TIME_LABEL);
    }

    public const string BUTTON_TIME_LOG = "console-time-log";
    private async Task TimeLog() {
        await Console.TimeLog();
    }

    public const string BUTTON_TIME_LOG_LABEL = "console-time-log-label";
    private async Task TimeLog_Label() {
        await Console.TimeLog(TEST_TIME_LABEL);
    }

    public const string BUTTON_TIME_LOG_LABEL_DATA = "console-time-log-label-data";
    private async Task TimeLog_LabelData() {
        await Console.TimeLog(TEST_TIME_LABEL, [TEST_TIME_LOG_DATA, TEST_TIME_LOG_DATA]);
    }


    public const string BUTTON_TRACE_STRING = "console-trace-string";
    private async Task Trace_String() {
        await Console.Trace(TEST_TRACE);
    }

    public const string BUTTON_TRACE = "console-trace";
    private async Task Trace() {
        await Console.Trace([TEST_TRACE, TEST_TRACE]);
    }

    public const string BUTTON_WARN_STRING = "console-warn-string";
    private async Task Warn_String() {
        await Console.Warn(TEST_WARN);
    }

    public const string BUTTON_WARN = "console-warn";
    private async Task Warn() {
        await Console.Warn([TEST_WARN, TEST_WARN]);
    }
}

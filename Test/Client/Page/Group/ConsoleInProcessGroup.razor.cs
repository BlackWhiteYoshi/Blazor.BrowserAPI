using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class ConsoleInProcessGroup : ComponentBase {
    public const string TEST_ASSERT = "console-inprocess assert test";
    public const string TEST_COUNT_LABEL = "console-inprocess count label test";
    public const string TEST_DEBUG = "console-inprocess debug test";
    public const string TEST_DIR = "console-inprocess dir test";
    public const string TEST_DIRXML = "console-inprocess dirxml test";
    public const string TEST_ERROR = "console-inprocess error test";
    public const string TEST_GROUP_LABEL = "console-inprocess group label test";
    public const string TEST_GROUP_COLLAPSED_LABEL = "console-inprocess groupcollapsed label test";
    public const string TEST_INFO = "console-inprocess info test";
    public const string TEST_LOG = "console-inprocess log test";
    public const string TEST_TABLE = "console-inprocess table test";
    public const string TEST_TABLE_COLUMNS = "console-inprocess table test column";
    public const string TEST_TIME_LABEL = "console-inprocess time label test";
    public const string TEST_TIME_LOG_DATA = "console-inprocess time log data test";
    public const string TEST_TRACE = "console-inprocess trace test";
    public const string TEST_WARN = "console-inprocess warn test";


    [Inject]
    public required IConsoleInProcess Console { private get; init; }


    public const string BUTTON_ASSERT_STRING = "console-inprocess-assert-string";
    private void Assert_String() {
        Console.Assert(true, TEST_ASSERT);
        Console.Assert(false, TEST_ASSERT);
    }

    public const string BUTTON_ASSERT = "console-inprocess-assert";
    private void Assert() {
        Console.Assert(true, [TEST_ASSERT, TEST_ASSERT]);
        Console.Assert(false, [TEST_ASSERT, TEST_ASSERT]);
    }

    public const string BUTTON_CLEAR = "console-inprocess-clear";
    private void Clear() {
        Console.Clear();
    }


    public const string BUTTON_COUNT = "console-inprocess-count";
    private void Count() {
        Console.Count();
    }

    public const string BUTTON_COUNT_LABEL = "console-inprocess-count-label";
    private void Count_Label() {
        Console.Count(TEST_COUNT_LABEL);
    }

    public const string BUTTON_COUNT_RESET = "console-inprocess-count-reset";
    private void CountReset() {
        Console.CountReset();
    }

    public const string BUTTON_COUNT_RESET_LABEL = "console-inprocess-count-reset-label";
    private void CountReset_Label() {
        Console.CountReset(TEST_COUNT_LABEL);
    }


    public const string BUTTON_DEBUG_STRING = "console-inprocess-debug-string";
    private void Debug_String() {
        Console.Debug(TEST_DEBUG);
    }

    public const string BUTTON_DEBUG = "console-inprocess-debug";
    private void Debug() {
        Console.Debug([TEST_DEBUG, TEST_DEBUG]);
    }

    public const string BUTTON_DIR = "console-inprocess-dir";
    private void Dir() {
        Console.Dir(TEST_DIR);
    }

    public const string BUTTON_DIRXML = "console-inprocess-dirxml";
    private void Dirxml() {
        Console.Dirxml(TEST_DIRXML);
    }

    public const string BUTTON_ERROR_STRING = "console-inprocess-error-string";
    private void Error_String() {
        Console.Error(TEST_ERROR);
    }

    public const string BUTTON_ERROR = "console-inprocess-error";
    private void Error() {
        Console.Error([TEST_ERROR, TEST_ERROR]);
    }


    public const string BUTTON_GROUP = "console-inprocess-group";
    private void Group() {
        Console.Group();
    }

    public const string BUTTON_GROUP_LABEL = "console-inprocess-group-label";
    private void Group_Label() {
        Console.Group(TEST_GROUP_LABEL);
    }

    public const string BUTTON_GROUP_COLLAPSED = "console-inprocess-group-collapsed";
    private void GroupCollapsed() {
        Console.GroupCollapsed();
    }

    public const string BUTTON_GROUP_COLLAPSED_LABEL = "console-inprocess-group-collapsed-label";
    private void GroupCollapsed_Label() {
        Console.GroupCollapsed(TEST_GROUP_COLLAPSED_LABEL);
    }

    public const string BUTTON_GROUP_END = "console-inprocess-group-end";
    private void GroupEnd() {
        Console.GroupEnd();
    }


    public const string BUTTON_INFO_STRING = "console-inprocess-info-string";
    private void Info_String() {
        Console.Info(TEST_INFO);
    }

    public const string BUTTON_INFO = "console-inprocess-info";
    private void Info() {
        Console.Info([TEST_INFO, TEST_INFO]);
    }

    public const string BUTTON_LOG_STRING = "console-inprocess-log-string";
    private void Log_String() {
        Console.Log(TEST_LOG);
    }

    public const string BUTTON_LOG = "console-inprocess-log";
    private void Log() {
        Console.Log([TEST_LOG, TEST_LOG]);
    }

    public const string BUTTON_TABLE = "console-inprocess-table";
    private void Table() {
        Console.Table((object[])[TEST_TABLE, TEST_TABLE]);
    }

    public const string BUTTON_TABLE_COLUMNS = "console-inprocess-table-columns";
    private void Table_Columns() {
        Console.Table((string[])[TEST_TABLE_COLUMNS, TEST_TABLE_COLUMNS], []);
    }


    public const string BUTTON_TIME = "console-inprocess-time";
    private void Time() {
        Console.Time();
    }

    public const string BUTTON_TIME_LABEL = "console-inprocess-time-label";
    private void Time_Label() {
        Console.Time(TEST_TIME_LABEL);
    }

    public const string BUTTON_TIME_END = "console-inprocess-time-end";
    private void TimeEnd() {
        Console.TimeEnd();
    }

    public const string BUTTON_TIME_END_LABEL = "console-inprocess-time-end-label";
    private void TimeEnd_Label() {
        Console.TimeEnd(TEST_TIME_LABEL);
    }

    public const string BUTTON_TIME_LOG = "console-inprocess-time-log";
    private void TimeLog() {
        Console.TimeLog();
    }

    public const string BUTTON_TIME_LOG_LABEL = "console-inprocess-time-log-label";
    private void TimeLog_Label() {
        Console.TimeLog(TEST_TIME_LABEL);
    }

    public const string BUTTON_TIME_LOG_LABEL_DATA = "console-inprocess-time-log-label-data";
    private void TimeLog_LabelData() {
        Console.TimeLog(TEST_TIME_LABEL, [TEST_TIME_LOG_DATA, TEST_TIME_LOG_DATA]);
    }


    public const string BUTTON_TRACE_STRING = "console-inprocess-trace-string";
    private void Trace_String() {
        Console.Trace(TEST_TRACE);
    }

    public const string BUTTON_TRACE = "console-inprocess-trace";
    private void Trace() {
        Console.Trace([TEST_TRACE, TEST_TRACE]);
    }

    public const string BUTTON_WARN_STRING = "console-inprocess-warn-string";
    private void Warn_String() {
        Console.Warn(TEST_WARN);
    }

    public const string BUTTON_WARN = "console-inprocess-warn";
    private void Warn() {
        Console.Warn([TEST_WARN, TEST_WARN]);
    }
}

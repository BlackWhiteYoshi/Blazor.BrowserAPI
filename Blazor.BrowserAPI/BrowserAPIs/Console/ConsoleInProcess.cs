using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>console</i> object provides access to the browser's debugging console (e.g. the Web console in Firefox). The specifics of how it works varies from browser to browser, but there is a de facto set of features that are typically provided.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class ConsoleInProcess(IModuleManager moduleManager) : IConsoleInProcess {
    /// <summary>
    /// The <i>console.assert()</i> method writes an error message to the console if the assertion is false. If the assertion is true, nothing happens.
    /// </summary>
    /// <param name="condition">Any boolean expression. If the assertion is false, the message is written to the console.</param>
    /// <param name="message">The text that will be displayed in the console.</param>
    public void Assert(bool condition, string? message) => moduleManager.InvokeSync("ConsoleAPI.assert", [condition, message]);

    /// <summary>
    /// The <i>console.assert()</i> method writes an error message to the console if the assertion is false. If the assertion is true, nothing happens.
    /// </summary>
    /// <param name="condition">Any boolean expression. If the assertion is false, the message is written to the console.</param>
    /// <param name="data">
    /// <para>A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</para>
    /// <para>or</para>
    /// <para>A JavaScript string containing zero or more substitution strings: JavaScript objects with which to replace substitution strings within msg. This parameter gives you additional control over the format of the output.</para>
    /// </param>
    public void Assert(bool condition, object?[]? data) => moduleManager.InvokeSync("ConsoleAPI.assert", [condition, data]);

    /// <summary>
    /// The <i>console.clear()</i> method clears the console if the console allows it.
    /// A graphical console, like those running on browsers, will allow it; a console displaying on the terminal, like the one running on Node, will not support it, and will have no effect (and no error).
    /// </summary>
    public void Clear() => moduleManager.InvokeSync("ConsoleAPI.clear");


    /// <summary>
    /// The <i>console.count()</i> method logs the number of times that this particular call to count() has been called.
    /// </summary>
    public void Count() => moduleManager.InvokeSync("ConsoleAPI.count");

    /// <summary>
    /// The <i>console.count()</i> method logs the number of times that this particular call to count() has been called.
    /// </summary>
    /// <param name="label">A string. If supplied, <i>count()</i> outputs the number of times it has been called with that label. If omitted, <i>count()</i> behaves as though it was called with the "default" label.</param>
    public void Count(string label) => moduleManager.InvokeSync("ConsoleAPI.count", [label]);

    /// <summary>
    /// The <i>console.countReset()</i> method resets counter used with <see cref="Count()"/>.
    /// </summary>
    public void CountReset() => moduleManager.InvokeSync("ConsoleAPI.countReset");

    /// <summary>
    /// The <i>console.countReset()</i> method resets counter used with <see cref="Count(string)"/>.
    /// </summary>
    /// <param name="label">A string. If supplied, <i>countReset()</i> resets the count for that label to 0. If omitted, <i>countReset()</i> resets the default counter to 0.</param>
    public void CountReset(string label) => moduleManager.InvokeSync("ConsoleAPI.countReset", [label]);


    /// <summary>
    /// The <i>console.debug()</i> method outputs a message to the web console at the "debug" log level.
    /// The message is only displayed to the user if the console is configured to display debug output.
    /// In most cases, the log level is configured within the console UI. This log level might correspond to the Debug or Verbose log level.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    public void Debug(string? message) => moduleManager.InvokeSync("ConsoleAPI.debug", [message]);

    /// <summary>
    /// The <i>console.debug()</i> method outputs a message to the web console at the "debug" log level.
    /// The message is only displayed to the user if the console is configured to display debug output.
    /// In most cases, the log level is configured within the console UI. This log level might correspond to the Debug or Verbose log level.
    /// </summary>
    /// <param name="data">
    /// <para>A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</para>
    /// <para>or</para>
    /// <para>A JavaScript string containing zero or more substitution strings: JavaScript objects with which to replace substitution strings within msg. This parameter gives you additional control over the format of the output.</para>
    /// </param>
    public void Debug(object?[]? data) => moduleManager.InvokeSync("ConsoleAPI.debug", [data]);

    /// <summary>
    /// <para>The method <i>console.dir()</i> displays an interactive list of the properties of the specified JavaScript object. The output is presented as a hierarchical listing with disclosure triangles that let you see the contents of child objects.</para>
    /// <para>In other words, <i>console.dir()</i> is the way to see all the properties of a specified JavaScript object in console by which the developer can easily get the properties of the object.</para>
    /// </summary>
    /// <param name="item">A JavaScript object whose properties should be output.</param>
    public void Dir(object? item) => moduleManager.InvokeSync("ConsoleAPI.dir", [item]);

    /// <summary>
    /// The <i>console.dirxml()</i> method displays an interactive tree of the descendant elements of the specified XML/HTML element.
    /// If it is not possible to display as an element the JavaScript Object view is shown instead.
    /// The output is presented as a hierarchical listing of expandable nodes that let you see the contents of child nodes.
    /// </summary>
    /// <param name="item">A JavaScript object whose properties should be output.</param>
    public void Dirxml(object? item) => moduleManager.InvokeSync("ConsoleAPI.dirxml", [item]);

    /// <summary>
    /// The <i>console.error()</i> method outputs an error message to the Web console.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    public void Error(string? message) => moduleManager.InvokeSync("ConsoleAPI.error", [message]);

    /// <summary>
    /// The <i>console.error()</i> method outputs an error message to the Web console.
    /// </summary>
    /// <param name="data">
    /// <para>A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</para>
    /// <para>or</para>
    /// <para>A JavaScript string containing zero or more substitution strings: JavaScript objects with which to replace substitution strings within msg. This parameter gives you additional control over the format of the output.</para>
    /// </param>
    public void Error(object?[]? data) => moduleManager.InvokeSync("ConsoleAPI.error", [data]);


    /// <summary>
    /// The <i>console.group()</i> method creates a new inline group in the Web console log, causing any subsequent console messages to be indented by an additional level, until <see cref="GroupEnd"/> is called.
    /// </summary>
    public void Group() => moduleManager.InvokeSync("ConsoleAPI.group");

    /// <summary>
    /// The <i>console.group()</i> method creates a new inline group in the Web console log, causing any subsequent console messages to be indented by an additional level, until <see cref="GroupEnd"/> is called.
    /// </summary>
    /// <param name="label">Label for the group.</param>
    public void Group(string label) => moduleManager.InvokeSync("ConsoleAPI.group", [label]);

    /// <summary>
    /// <para>
    /// The <i>console.groupCollapsed()</i> method creates a new inline group in the Web Console. Unlike <see cref="Group()"/>, however, the new group is created collapsed.
    /// The user will need to use the disclosure button next to it to expand it, revealing the entries created in the group.
    /// </para>
    /// <para>Call <see cref="GroupEnd"/> to back out to the parent group.</para>
    /// </summary>
    public void GroupCollapsed() => moduleManager.InvokeSync("ConsoleAPI.groupCollapsed");

    /// <summary>
    /// <para>
    /// The <i>console.groupCollapsed()</i> method creates a new inline group in the Web Console. Unlike <see cref="Group(string)"/>, however, the new group is created collapsed.
    /// The user will need to use the disclosure button next to it to expand it, revealing the entries created in the group.
    /// </para>
    /// <para>Call <see cref="GroupEnd"/> to back out to the parent group.</para>
    /// </summary>
    /// <param name="label">Label for the group.</param>
    public void GroupCollapsed(string label) => moduleManager.InvokeSync("ConsoleAPI.groupCollapsed", [label]);

    /// <summary>
    /// The <i>console.groupEnd()</i> method exits the current inline group in the Web console.
    /// </summary>
    public void GroupEnd() => moduleManager.InvokeSync("ConsoleAPI.groupEnd");


    /// <summary>
    /// The <i>console.info()</i> method outputs an informational message to the Web console.
    /// In Firefox, a small "i" icon is displayed next to these items in the Web console's log.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    public void Info(string? message) => moduleManager.InvokeSync("ConsoleAPI.info", [message]);

    /// <summary>
    /// The <i>console.info()</i> method outputs an informational message to the Web console.
    /// In Firefox, a small "i" icon is displayed next to these items in the Web console's log.
    /// </summary>
    /// <param name="data">
    /// <para>A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</para>
    /// <para>or</para>
    /// <para>A JavaScript string containing zero or more substitution strings: JavaScript objects with which to replace substitution strings within msg. This parameter gives you additional control over the format of the output.</para>
    /// </param>
    public void Info(object?[]? data) => moduleManager.InvokeSync("ConsoleAPI.info", [data]);

    /// <summary>
    /// The <i>console.log()</i> method outputs a message to the web console.
    /// The message may be a single string (with optional substitution values), or it may be any one or more JavaScript objects.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    public void Log(string? message) => moduleManager.InvokeSync("ConsoleAPI.log", [message]);

    /// <summary>
    /// The <i>console.log()</i> method outputs a message to the web console.
    /// The message may be a single string (with optional substitution values), or it may be any one or more JavaScript objects.
    /// </summary>
    /// <param name="data">
    /// <para>A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</para>
    /// <para>or</para>
    /// <para>A JavaScript string containing zero or more substitution strings: JavaScript objects with which to replace substitution strings within msg. This parameter gives you additional control over the format of the output.</para>
    /// </param>
    public void Log(object?[]? data) => moduleManager.InvokeSync("ConsoleAPI.log", [data]);

    /// <summary>
    /// <para>The <i>console.table()</i> method displays tabular data as a table.</para>
    /// <para>It logs data as a table. Each element in the array (or enumerable property if data is an object) will be a row in the table.</para>
    /// <para>
    /// The first column in the table will be labeled (index).
    /// If data is an array, then its values will be the array indices.
    /// If data is an object, then its values will be the property names.
    /// Note that (in Firefox) <i>console.table</i> is limited to displaying 1000 rows (first row is the labeled index).
    /// </para>
    /// </summary>
    /// <param name="data">The data to display. This must be either an array or an object.</param>
    public void Table(object data) => moduleManager.InvokeSync("ConsoleAPI.table", [data]);

    /// <summary>
    /// <para>The <i>console.table()</i> method displays tabular data as a table.</para>
    /// <para>It logs data as a table. Each element in the array (or enumerable property if data is an object) will be a row in the table.</para>
    /// <para>
    /// The first column in the table will be labeled (index).
    /// If data is an array, then its values will be the array indices.
    /// If data is an object, then its values will be the property names.
    /// Note that (in Firefox) <i>console.table</i> is limited to displaying 1000 rows (first row is the labeled index).
    /// </para>
    /// </summary>
    /// <param name="data">The data to display. This must be either an array or an object.</param>
    /// <param name="columns">An array containing the names of columns to include in the output.</param>
    public void Table(object data, string[] columns) => moduleManager.InvokeSync("ConsoleAPI.table", [data, columns]);


    /// <summary>
    /// The <i>console.time()</i> method starts a timer you can use to track how long an operation takes.
    /// You give each timer a unique name, and may have up to 10,000 timers running on a given page.
    /// When you call <see cref="TimeEnd()"/>, the browser will output the time, in milliseconds, that elapsed since the timer was started.
    /// </summary>
    public void Time() => moduleManager.InvokeSync("ConsoleAPI.time");

    /// <summary>
    /// The <i>console.time()</i> method starts a timer you can use to track how long an operation takes.
    /// You give each timer a unique name, and may have up to 10,000 timers running on a given page.
    /// When you call <see cref="TimeEnd(string)"/> with the same name, the browser will output the time, in milliseconds, that elapsed since the timer was started.
    /// </summary>
    /// <param name="label">A string representing the name to give the new timer. This will identify the timer; use the same name when calling console.timeEnd() to stop the timer and get the time output to the console. If omitted, the label "default" is used.</param>
    public void Time(string label) => moduleManager.InvokeSync("ConsoleAPI.time", [label]);

    /// <summary>
    /// The <i>console.timeEnd()</i> stops a timer that was previously started by calling <see cref="Time()"/>.
    /// </summary>
    public void TimeEnd() => moduleManager.InvokeSync("ConsoleAPI.timeEnd");

    /// <summary>
    /// The <i>console.timeEnd()</i> stops a timer that was previously started by calling <see cref="Time(string)"/>.
    /// </summary>
    /// <param name="label">A string representing the name of the timer to stop. Once stopped, the elapsed time is automatically displayed in the Web console along with an indicator that the time has ended. If omitted, the label "default" is used.</param>
    public void TimeEnd(string label) => moduleManager.InvokeSync("ConsoleAPI.timeEnd", [label]);

    /// <summary>
    /// The <i>console.timeLog()</i> method logs the current value of a timer that was previously started by calling <see cref="Time()"/>.
    /// </summary>
    public void TimeLog() => moduleManager.InvokeSync("ConsoleAPI.timeLog");

    /// <summary>
    /// The <i>console.timeLog()</i> method logs the current value of a timer that was previously started by calling <see cref="Time(string)"/>.
    /// </summary>
    /// <param name="label">The name of the timer to log to the console. If this is omitted the label "default" is used.</param>
    public void TimeLog(string label) => moduleManager.InvokeSync("ConsoleAPI.timeLog", [label]);

    /// <summary>
    /// The <i>console.timeLog()</i> method logs the current value of a timer that was previously started by calling <see cref="Time(string)"/>.
    /// </summary>
    /// <param name="label">The name of the timer to log to the console. If this is omitted the label "default" is used.</param>
    /// <param name="data">Additional values to be logged to the console after the timer output.</param>
    public void TimeLog(string label, object?[]? data) => moduleManager.InvokeSync("ConsoleAPI.timeLog", [label, data]);


    /// <summary>
    /// The <i>console.trace()</i> method outputs a stack trace to the Web console.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    public void Trace(string? message) => moduleManager.InvokeSync("ConsoleAPI.trace", [message]);

    /// <summary>
    /// The <i>console.trace()</i> method outputs a stack trace to the Web console.
    /// </summary>
    /// <param name="objects">Zero or more objects to be output to console along with the trace. These are assembled and formatted the same way they would be if passed to the <see cref="Log(object?[])"/> method.</param>
    public void Trace(object?[]? objects) => moduleManager.InvokeSync("ConsoleAPI.trace", [objects]);

    /// <summary>
    /// The <i>console.warn()</i> method outputs a warning message to the Web console.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    public void Warn(string? message) => moduleManager.InvokeSync("ConsoleAPI.warn", [message]);

    /// <summary>
    /// The <i>console.warn()</i> method outputs a warning message to the Web console.
    /// </summary>
    /// <param name="data">
    /// <para>A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</para>
    /// <para>or</para>
    /// <para>A JavaScript string containing zero or more substitution strings: JavaScript objects with which to replace substitution strings within msg. This parameter gives you additional control over the format of the output.</para>
    /// </param>
    public void Warn(object?[]? data) => moduleManager.InvokeSync("ConsoleAPI.warn", [data]);
}

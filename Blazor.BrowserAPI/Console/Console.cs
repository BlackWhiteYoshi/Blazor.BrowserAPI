using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>console</i> object provides access to the browser's debugging console (e.g. the Web console in Firefox). The specifics of how it works varies from browser to browser, but there is a de facto set of features that are typically provided.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class Console(IModuleManager moduleManager) : IConsole {
    /// <summary>
    /// The <i>console.assert()</i> method writes an error message to the console if the assertion is false. If the assertion is true, nothing happens.
    /// </summary>
    /// <param name="condition">Any boolean expression. If the assertion is false, the message is written to the console.</param>
    /// <param name="message">The text that will be displayed in the console.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Assert(bool condition, string? message, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleAssert", cancellationToken, [condition, message]);

    /// <summary>
    /// The <i>console.assert()</i> method writes an error message to the console if the assertion is false. If the assertion is true, nothing happens.
    /// </summary>
    /// <param name="condition">Any boolean expression. If the assertion is false, the message is written to the console.</param>
    /// <param name="data">
    /// <para>A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</para>
    /// <para>or</para>
    /// <para>A JavaScript string containing zero or more substitution strings: JavaScript objects with which to replace substitution strings within msg. This parameter gives you additional control over the format of the output.</para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Assert(bool condition, object?[]? data, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleAssert", cancellationToken, [condition, data]);

    /// <summary>
    /// The <i>console.clear()</i> method clears the console if the console allows it.
    /// A graphical console, like those running on browsers, will allow it; a console displaying on the terminal, like the one running on Node, will not support it, and will have no effect (and no error).
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Clear(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleClear", cancellationToken);


    /// <summary>
    /// The <i>console.count()</i> method logs the number of times that this particular call to count() has been called.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Count(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleCount", cancellationToken);

    /// <summary>
    /// The <i>console.count()</i> method logs the number of times that this particular call to count() has been called.
    /// </summary>
    /// <param name="label">A string. If supplied, <i>count()</i> outputs the number of times it has been called with that label.
    /// If omitted, <i>count()</i> behaves as though it was called with the "default" label.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Count(string label, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleCount", cancellationToken, [label]);

    /// <summary>
    /// The <i>console.countReset()</i> method resets counter used with <see cref="Count"/>.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask CountReset(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleCountReset", cancellationToken);

    /// <summary>
    /// The <i>console.countReset()</i> method resets counter used with <see cref="Count(string)"/>.
    /// </summary>
    /// <param name="label">A string. If supplied, <i>countReset()</i> resets the count for that label to 0.
    /// If omitted, <i>countReset()</i> resets the default counter to 0.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask CountReset(string label, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleCountReset", cancellationToken, [label]);


    /// <summary>
    /// The <i>console.debug()</i> method outputs a message to the web console at the "debug" log level.
    /// The message is only displayed to the user if the console is configured to display debug output.
    /// In most cases, the log level is configured within the console UI. This log level might correspond to the Debug or Verbose log level.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Debug(string? message, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleDebug", cancellationToken, [message]);

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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Debug(object?[]? data, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleDebug", cancellationToken, [data]);

    /// <summary>
    /// <para>The method <i>console.dir()</i> displays an interactive list of the properties of the specified JavaScript object. The output is presented as a hierarchical listing with disclosure triangles that let you see the contents of child objects.</para>
    /// <para>In other words, <i>console.dir()</i> is the way to see all the properties of a specified JavaScript object in console by which the developer can easily get the properties of the object.</para>
    /// </summary>
    /// <param name="item">A JavaScript object whose properties should be output.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Dir(object? item, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleDir", cancellationToken, [item]);

    /// <summary>
    /// The <i>console.dirxml()</i> method displays an interactive tree of the descendant elements of the specified XML/HTML element.
    /// If it is not possible to display as an element the JavaScript Object view is shown instead.
    /// The output is presented as a hierarchical listing of expandable nodes that let you see the contents of child nodes.
    /// </summary>
    /// <param name="item">A JavaScript object whose properties should be output.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Dirxml(object? item, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleDirxml", cancellationToken, [item]);

    /// <summary>
    /// The <i>console.error()</i> method outputs an error message to the Web console.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Error(string? message, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleError", cancellationToken, [message]);

    /// <summary>
    /// The <i>console.error()</i> method outputs an error message to the Web console.
    /// </summary>
    /// <param name="data">
    /// <para>A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</para>
    /// <para>or</para>
    /// <para>A JavaScript string containing zero or more substitution strings: JavaScript objects with which to replace substitution strings within msg. This parameter gives you additional control over the format of the output.</para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Error(object?[]? data, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleError", cancellationToken, [data]);


    /// <summary>
    /// The <i>console.group()</i> method creates a new inline group in the Web console log, causing any subsequent console messages to be indented by an additional level, until <see cref="GroupEnd"/> is called.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Group(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleGroup", cancellationToken);

    /// <summary>
    /// The <i>console.group()</i> method creates a new inline group in the Web console log, causing any subsequent console messages to be indented by an additional level, until <see cref="GroupEnd"/> is called.
    /// </summary>
    /// <param name="label">Label for the group.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Group(string label, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleGroup", cancellationToken, [label]);

    /// <summary>
    /// <para>
    /// The <i>console.groupCollapsed()</i> method creates a new inline group in the Web Console. Unlike <see cref="Group"/>, however, the new group is created collapsed.
    /// The user will need to use the disclosure button next to it to expand it, revealing the entries created in the group.
    /// </para>
    /// <para>Call <see cref="GroupEnd"/> to back out to the parent group.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask GroupCollapsed(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleGroupCollapsed", cancellationToken);

    /// <summary>
    /// <para>
    /// The <i>console.groupCollapsed()</i> method creates a new inline group in the Web Console. Unlike <see cref="Group(string)"/>, however, the new group is created collapsed.
    /// The user will need to use the disclosure button next to it to expand it, revealing the entries created in the group.
    /// </para>
    /// <para>Call <see cref="GroupEnd"/> to back out to the parent group.</para>
    /// </summary>
    /// <param name="label">Label for the group.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask GroupCollapsed(string label, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleGroupCollapsed", cancellationToken, [label]);

    /// <summary>
    /// The <i>console.groupEnd()</i> method exits the current inline group in the Web console.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask GroupEnd(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleGroupEnd", cancellationToken);


    /// <summary>
    /// The <i>console.info()</i> method outputs an informational message to the Web console.
    /// In Firefox, a small "i" icon is displayed next to these items in the Web console's log.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Info(string? message, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleInfo", cancellationToken, [message]);

    /// <summary>
    /// The <i>console.info()</i> method outputs an informational message to the Web console.
    /// In Firefox, a small "i" icon is displayed next to these items in the Web console's log.
    /// </summary>
    /// <param name="data">
    /// <para>A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</para>
    /// <para>or</para>
    /// <para>A JavaScript string containing zero or more substitution strings: JavaScript objects with which to replace substitution strings within msg. This parameter gives you additional control over the format of the output.</para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Info(object?[]? data, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleInfo", cancellationToken, [data]);

    /// <summary>
    /// The <i>console.log()</i> method outputs a message to the web console.
    /// The message may be a single string (with optional substitution values), or it may be any one or more JavaScript objects.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Log(string? message, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleLog", cancellationToken, [message]);

    /// <summary>
    /// The <i>console.log()</i> method outputs a message to the web console.
    /// The message may be a single string (with optional substitution values), or it may be any one or more JavaScript objects.
    /// </summary>
    /// <param name="data">
    /// <para>A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</para>
    /// <para>or</para>
    /// <para>A JavaScript string containing zero or more substitution strings: JavaScript objects with which to replace substitution strings within msg. This parameter gives you additional control over the format of the output.</para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Log(object?[]? data, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleLog", cancellationToken, [data]);

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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Table(object data, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleTable", cancellationToken, [data]);

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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Table(object data, string[] columns, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleTable", cancellationToken, [data, columns]);


    /// <summary>
    /// The <i>console.time()</i> method starts a timer you can use to track how long an operation takes.
    /// You give each timer a unique name, and may have up to 10,000 timers running on a given page.
    /// When you call <see cref="TimeEnd"/>, the browser will output the time, in milliseconds, that elapsed since the timer was started.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Time(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleTime", cancellationToken);

    /// <summary>
    /// The <i>console.time()</i> method starts a timer you can use to track how long an operation takes.
    /// You give each timer a unique name, and may have up to 10,000 timers running on a given page.
    /// When you call <see cref="TimeEnd(string)"/> with the same name, the browser will output the time, in milliseconds, that elapsed since the timer was started.
    /// </summary>
    /// <param name="label">
    /// A string representing the name to give the new timer.
    /// This will identify the timer; use the same name when calling console.timeEnd() to stop the timer and get the time output to the console.
    /// If omitted, the label "default" is used.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Time(string label, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleTime", cancellationToken, [label]);

    /// <summary>
    /// The <i>console.timeEnd()</i> stops a timer that was previously started by calling <see cref="Time"/>.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask TimeEnd(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleTimeEnd", cancellationToken);

    /// <summary>
    /// The <i>console.timeEnd()</i> stops a timer that was previously started by calling <see cref="Time(string)"/>.
    /// </summary>
    /// <param name="label">
    /// A string representing the name of the timer to stop.
    /// Once stopped, the elapsed time is automatically displayed in the Web console along with an indicator that the time has ended.
    /// If omitted, the label "default" is used.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask TimeEnd(string label, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleTimeEnd", cancellationToken, [label]);

    /// <summary>
    /// The <i>console.timeLog()</i> method logs the current value of a timer that was previously started by calling <see cref="Time"/>.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask TimeLog(CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleTimeLog", cancellationToken);

    /// <summary>
    /// The <i>console.timeLog()</i> method logs the current value of a timer that was previously started by calling <see cref="Time(string)"/>.
    /// </summary>
    /// <param name="label">The name of the timer to log to the console. If this is omitted the label "default" is used.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask TimeLog(string label, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleTimeLog", cancellationToken, [label]);

    /// <summary>
    /// The <i>console.timeLog()</i> method logs the current value of a timer that was previously started by calling <see cref="Time(string)"/>.
    /// </summary>
    /// <param name="label">The name of the timer to log to the console. If this is omitted the label "default" is used.</param>
    /// <param name="data">Additional values to be logged to the console after the timer output.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask TimeLog(string label, object?[]? data, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleTimeLog", cancellationToken, [label, data]);


    /// <summary>
    /// The <i>console.trace()</i> method outputs a stack trace to the Web console.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Trace(string? message, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleTrace", cancellationToken, [message]);

    /// <summary>
    /// The <i>console.trace()</i> method outputs a stack trace to the Web console.
    /// </summary>
    /// <param name="objects">
    /// Zero or more objects to be output to console along with the trace.
    /// These are assembled and formatted the same way they would be if passed to the <see cref="Log(object?[]?)"/> method.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Trace(object?[]? objects, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleTrace", cancellationToken, [objects]);

    /// <summary>
    /// The <i>console.warn()</i> method outputs a warning message to the Web console.
    /// </summary>
    /// <param name="message">The text that will be displayed in the console.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Warn(string? message, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleWarn", cancellationToken, [message]);

    /// <summary>
    /// The <i>console.warn()</i> method outputs a warning message to the Web console.
    /// </summary>
    /// <param name="data">
    /// <para>A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</para>
    /// <para>or</para>
    /// <para>A JavaScript string containing zero or more substitution strings: JavaScript objects with which to replace substitution strings within msg. This parameter gives you additional control over the format of the output.</para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Warn(object?[]? data, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("consoleWarn", cancellationToken, [data]);
}

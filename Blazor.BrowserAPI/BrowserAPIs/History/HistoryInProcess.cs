using AutoInterfaceAttributes;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>History</i> interface of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/History_API">History API</see> allows manipulation of the browser session history, that is the pages visited in the tab or frame that the current page is loaded in.</para>
/// <para>There is only one instance of history (It is a singleton.) accessible via the global object <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window/history">history</see>.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class HistoryInProcess(IModuleManager moduleManager) : HistoryBase(moduleManager), IHistoryInProcess {
    /// <summary>
    /// Returns an Integer representing the number of elements in the session history, including the currently loaded page. For example, for a page loaded in a new tab this property returns 1.
    /// </summary>
    public int Length => moduleManager.InvokeSync<int>("HistoryAPI.getLength");

    /// <summary>
    /// <para>Allows web applications to explicitly set default scroll restoration behavior on history navigation.</para>
    /// <para>This property can be either "auto" or "manual".</para>
    /// </summary>
    public string ScrollRestoration {
        get => moduleManager.InvokeSync<string>("HistoryAPI.getScrollRestoration");
        set => moduleManager.InvokeSync("HistoryAPI.setScrollRestoration", [value]);
    }

    /// <summary>
    /// Returns an <i>any</i> value representing the state at the top of the history stack. This is a way to look at the state without having to wait for a <i>popstate</i> event.
    /// </summary>
    public JsonElement? State => moduleManager.InvokeSync<JsonElement?>("HistoryAPI.getState");


    /// <summary>
    /// <para>This asynchronous method goes to the next page in session history, the same action as when the user clicks the browser's <i>Forward</i> button; this is equivalent to <i>history.go(1)</i>.</para>
    /// <para>Calling this method to go forward beyond the most recent page in the session history has no effect and doesn't raise an exception.</para>
    /// </summary>
    /// <returns></returns>
    public void Forward() => moduleManager.InvokeSync("HistoryAPI.forward");

    /// <summary>
    /// <para>This asynchronous method goes to the previous page in session history, the same action as when the user clicks the browser's <i>Back</i> button. Equivalent to <i>history.go(-1)</i>.</para>
    /// <para>Calling this method to go forward beyond the most recent page in the session history has no effect and doesn't raise an exception.</para>
    /// </summary>
    /// <returns></returns>
    public void Back() => moduleManager.InvokeSync("HistoryAPI.back");

    /// <summary>
    /// Asynchronously loads a page from the session history, identified by its relative location to the current page, for example -1 for the previous page or 1 for the next page.
    /// If you specify an out-of-bounds value (for instance, specifying -1 when there are no previously-visited pages in the session history), this method silently has no effect.
    /// Calling <i>go()</i> without parameters or a value of 0 reloads the current page.
    /// </summary>
    /// <param name="delta">
    /// The position in the history to which you want to move, relative to the current page.
    /// A negative value moves backwards, a positive value moves forwards.
    /// So, for example, history.go(2) moves forward two pages and history.go(-2) moves back two pages.
    /// If no value is passed or if delta equals 0, it has the same result as calling location.reload().</param>
    /// <returns></returns>
    public void Go(int delta) => moduleManager.InvokeSync("HistoryAPI.go", [delta]);

    /// <summary>
    /// Pushes the given data onto the session history stack with the specified title (and, if provided, URL).
    /// The data is treated as opaque by the DOM; you may specify any JavaScript object that can be serialized.
    /// Note that all browsers but Safari currently ignore the title parameter.
    /// For more information, see <see href="https://developer.mozilla.org/en-US/docs/Web/API/History_API/Working_with_the_History_API">Working with the History API</see>.
    /// </summary>
    /// <param name="data">
    /// <para>
    /// The state object is a JavaScript object which is associated with the new history entry created by pushState().
    /// Whenever the user navigates to the new state, a popstate event is fired, and the state property of the event contains a copy of the history entry's state object.
    /// </para>
    /// <para>The state object can be anything that can be serialized.</para>
    /// </param>
    /// <param name="title">This parameter exists for historical reasons, and cannot be omitted; passing an empty string is safe against future changes to the method. (Safari uses it as title though)</param>
    /// <param name="url">
    /// The new history entry's URL.
    /// Note that the browser won't attempt to load this URL after a call to pushState(), but it may attempt to load the URL later, for instance, after the user restarts the browser.
    /// The new URL does not need to be absolute; if it's relative, it's resolved relative to the current URL.
    /// The new URL must be of the same origin as the current URL; otherwise, pushState() will throw an exception.
    /// If this parameter isn't specified, it's set to the document's current URL.
    /// </param>
    /// <returns></returns>
    public void PushState(object? data, string title, string? url = null) => moduleManager.InvokeSync("HistoryAPI.pushState", [data, title, url]);

    /// <summary>
    /// Updates the most recent entry on the history stack to have the specified data, title, and, if provided, URL.
    /// The data is treated as opaque by the DOM; you may specify any JavaScript object that can be serialized.
    /// Note that all browsers but Safari currently ignore the title parameter.
    /// For more information, see Working with the History API.
    /// </summary>
    /// <param name="data">An object which is associated with the history entry passed to the replaceState() method. The state object can be null.</param>
    /// <param name="title">This parameter exists for historical reasons, and cannot be omitted; passing the empty string is traditional, and safe against future changes to the method.</param>
    /// <param name="url">The URL of the history entry. The new URL must be of the same origin as the current URL; otherwise the replaceState() method throws an exception.</param>
    /// <returns></returns>
    public void ReplaceState(object? data, string title, string? url = null) => moduleManager.InvokeSync("HistoryAPI.replaceState", [data, title, url]);
}

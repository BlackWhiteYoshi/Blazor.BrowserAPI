using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>Window Management API</i> allows you to get detailed information on the displays connected to your device and more easily place windows on specific screens,
/// paving the way towards more effective multi-screen applications.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class WindowManagement(IModuleManager moduleManager) : IWindowManagement {
    /// <summary>
    /// The Window property <i>screen</i> returns a reference to the screen object associated with the window.
    /// The screen object, implementing the Screen interface, is a special object for inspecting properties of the screen on which the current window is being rendered.
    /// </summary>
    public IScreen Screen { get; } = new Screen(moduleManager);


    /// <summary>
    /// The <i>getScreenDetails()</i> method of the Window interface returns a Promise that fulfills with a ScreenDetails object instance representing the details of all the screens available to the user's device.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IScreenDetails> GetScreenDetails(CancellationToken cancellationToken = default) {
        IJSObjectReference screenDetailsJS = await moduleManager.InvokeAsync<IJSObjectReference>("WindowManagementAPI.getScreenDetails", cancellationToken);
        return new ScreenDetails(screenDetailsJS);
    }

    /// <summary>
    /// The <i>open()</i> method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name.
    /// </summary>
    /// <param name="url">
    /// A string indicating the URL or path of the resource to be loaded.
    /// If an empty string ("") is specified or this parameter is omitted, a blank page is opened into the targeted browsing context.
    /// </param>
    /// <param name="target">
    /// <para>
    /// A string, without whitespace, specifying the name of the browsing context the resource is being loaded into.<br />
    /// If the name doesn't identify an existing context, a new context is created and given the specified name.<br />
    /// The special target keywords, "<i>_self</i>", "<i>_blank</i>" (default), "<i>_parent</i>", "<i>_top</i>", and "<i>_unfencedTop</i>" can also be used.<br />
    /// "<i>_unfencedTop</i>" is only relevant to fenced frames.
    /// </para>
    /// <para>This name can be used as the target attribute of &lt;a&gt; or &lt;form&gt; elements.</para>
    /// </param>
    /// <param name="features">
    /// <para>
    /// A string containing a comma-separated list of window features in the form <i>name=value</i>.
    /// Boolean values can be set to true using one of: <i>name</i>, <i>name=yes</i>, <i>name=true</i>, or <i>name=n</i> where n is any non-zero integer.
    /// These features include options such as the window's default size and position, whether or not to open a minimal popup window, and so forth.
    /// The following options are supported:</para>
    /// <para>
    /// - "attributionsrc": By default, window.open opens the page in a new tab. If popup is set to true, it requests that a minimal popup window be used. The UI features included in the popup window will be automatically decided by the browser, generally including an address bar only. If popup is present and set to false, a new tab is still opened.<br />
    /// - "popup": By default, window.open opens the page in a new tab. If popup is set to true, it requests that a minimal popup window be used. The UI features included in the popup window will be automatically decided by the browser, generally including an address bar only. If popup is present and set to false, a new tab is still opened.<br />
    /// - "width" or "innerWidth": Specifies the width of the content area, including scrollbars. The minimum required value is 100.<br />
    /// - "height" or "innerHeight": Specifies the height of the content area, including scrollbars. The minimum required value is 100.<br />
    /// - "left" or "screenX": Specifies the distance in pixels from the left side of the work area as defined by the user's operating system where the new window will be generated.<br />
    /// - "top" or "screenY": Specifies the distance in pixels from the top side of the work area as defined by the user's operating system where the new window will be generated.<br />
    /// - "noopener": If this feature is set, the new window will not have access to the originating window via Window.opener and returns null. When noopener is used, non-empty target names, other than <i>_top</i>, <i>_self</i>, and <i>_parent</i>, are treated like <i>_blank</i> in terms of deciding whether to open a new browsing context.<br />
    /// - "noreferrer": If this feature is set, the browser will omit the Referer header, as well as set noopener to true. See rel="noreferrer" for more information.
    /// </para>
    /// <para>A null value is treated the same as the empty string ("").</para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Open(string? url = null, string? target = null, string? features = null, CancellationToken cancellationToken = default)
        => moduleManager.InvokeTrySync("WindowManagementAPI.open", cancellationToken, [url, target, features]);
}

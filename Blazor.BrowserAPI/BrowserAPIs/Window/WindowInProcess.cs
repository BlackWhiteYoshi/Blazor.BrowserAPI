using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The Window interface represents a window containing a DOM document; the document property points to the DOM document loaded in that window.</para>
/// <para>A window for a given document can be obtained using the document.defaultView property.</para>
/// <para>A global variable, window, representing the window in which the script is running, is exposed to JavaScript code.</para>
/// ^<para>
/// The Window interface is home to a variety of functions, namespaces, objects, and constructors which are not necessarily directly associated with the concept of a user interface window.
/// However, the Window interface is a suitable place to include these items that need to be globally available.
/// Many of these are documented in the <see href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference">JavaScript Reference</see>
/// and the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document_Object_Model">DOM Reference</see>.
/// </para>
/// <para>
/// In a tabbed browser, each tab is represented by its own Window object; the global window seen by JavaScript code running within a given tab always represents the tab in which the code is running.
/// That said, even in a tabbed browser, some properties and methods still apply to the overall window that contains the tab, such as <see cref="ResizeTo"/> and <see cref="InnerHeight"/>.
/// Generally, anything that can't reasonably pertain to a tab pertains to the window instead.
/// </para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class WindowInProcess(IModuleManager moduleManager) : WindowBase(moduleManager), IWindowInProcess {
    // Properties

    /// <summary>
    /// <para>
    /// Returns the interior width of the window in pixels (that is, the width of the window's layout viewport).
    /// That includes the width of the vertical scroll bar, if one is present.
    /// </para>
    /// <para>
    /// Similarly, the interior height of the window (that is, the height of the layout viewport) can be obtained using the innerHeight property.
    /// That measurement also accounts for the height of the horizontal scroll bar, if it is visible.
    /// </para>
    /// </summary>
    public int InnerWidth => moduleManager.InvokeSync<int>("WindowAPI.getInnerWidth", [windowJS]);

    /// <summary>
    /// <para>Returns the interior height of the window in pixels, including the height of the horizontal scroll bar, if present.</para>
    /// <para>The value of innerHeight is taken from the height of the window's layout viewport. The width can be obtained using the <see cref="InnerWidth"/> property.</para>
    /// </summary>
    public int InnerHeight => moduleManager.InvokeSync<int>("WindowAPI.getInnerHeight", [windowJS]);

    /// <summary>
    /// Returns the width of the outside of the browser window.
    /// It represents the width of the whole browser window including sidebar (if expanded), window chrome and window resizing borders/handles.
    /// </summary>
    public int OuterWidth => moduleManager.InvokeSync<int>("WindowAPI.getOuterWidth", [windowJS]);

    /// <summary>
    /// Returns the height in pixels of the whole browser window, including any sidebar, window chrome, and window-resizing borders/handles.
    /// </summary>
    public int OuterHeight => moduleManager.InvokeSync<int>("WindowAPI.getOuterHeight", [windowJS]);

    /// <summary>
    /// <para>Returns the ratio of the resolution in physical pixels to the resolution in CSS pixels for the current display device.</para>
    /// <para>
    /// This value could also be interpreted as the ratio of pixel sizes: the size of one CSS pixel to the size of one physical pixel.
    /// In simpler terms, this tells the browser how many of the screen's actual pixels should be used to draw a single CSS pixel.
    /// </para>
    /// <para>
    /// Page zooming affects the value of devicePixelRatio.
    /// When a page is zoomed in (made larger), the size of a CSS pixel increases, and so the devicePixelRatio value increases.
    /// Pinch-zooming does not affect devicePixelRatio, because this magnifies the page without changing the size of a CSS pixel.
    /// </para>
    /// <para>
    /// This is useful when dealing with the difference between rendering on a standard display versus a HiDPI or Retina display,
    /// which use more screen pixels to draw the same objects, resulting in a sharper image.
    /// </para>
    /// </summary>
    public double DevicePixelRatio => moduleManager.InvokeSync<double>("WindowAPI.getDevicePixelRatio", [windowJS]);


    /// <summary>
    /// Returns the number of pixels by which the document is currently scrolled horizontally.
    /// This value is subpixel precise in modern browsers, meaning that it isn't necessarily a whole number.
    /// You can get the number of pixels the document is scrolled vertically from the <see cref="ScrollY"/> property.
    /// </summary>
    public double ScrollX => moduleManager.InvokeSync<double>("WindowAPI.getScrollX", [windowJS]);

    /// <summary>
    /// Returns the number of pixels by which the document is currently scrolled vertically.
    /// This value is subpixel precise in modern browsers, meaning that it isn't necessarily a whole number.
    /// You can get the number of pixels the document is scrolled horizontally from the <see cref="ScrollX"/> property.
    /// </summary>
    public double ScrollY => moduleManager.InvokeSync<double>("WindowAPI.getScrollY", [windowJS]);

    /// <summary>
    /// Returns the horizontal distance, in CSS pixels, of the left border of the user's browser viewport to the left side of the screen.
    /// </summary>
    public int ScreenX => moduleManager.InvokeSync<int>("WindowAPI.getScreenX", [windowJS]);

    /// <summary>
    /// Returns the vertical distance, in CSS pixels, of the top border of the user's browser viewport to the top edge of the screen.
    /// </summary>
    public int ScreenY => moduleManager.InvokeSync<int>("WindowAPI.getScreenY", [windowJS]);


    /// <summary>
    /// Returns the origin of the global scope, serialized as a string.
    /// </summary>
    public string Origin => moduleManager.InvokeSync<string>("WindowAPI.getOrigin", [windowJS]);

    /// <summary>
    /// <para>Gets/Sets the name of the window's browsing context.</para>
    /// <para>The name of the window is used primarily for setting targets for hyperlinks and forms. Browsing contexts do not need to have names.</para>
    /// <para>
    /// Modern browsers will reset Window.name to an empty string if a tab loads a page from a different domain,
    /// and restore the name if the original page is reloaded (e.g., by selecting the "back" button).
    /// This prevents an untrusted page from accessing any information that the previous page might have stored in the property
    /// (potentially the new page might also modify such data, which might then be read by the original page if it was reloaded).
    /// </para>
    /// </summary>
    public string Name {
        get => moduleManager.InvokeSync<string>("WindowAPI.getName", [windowJS]);
        set => moduleManager.InvokeSync("WindowAPI.setName", [windowJS, value]);
    }


    /// <summary>
    /// Indicates whether the referenced window is closed or not.
    /// </summary>
    public bool Closed => moduleManager.InvokeSync<bool>("WindowAPI.getClosed", [windowJS]);

    /// <summary>
    /// <para>Indicates whether the current document was loaded inside a credentialless &lt;iframe&gt;, meaning that it is loaded in a new, ephemeral context.</para>
    /// <para>
    /// This context doesn't have access to the network, cookies, and storage data associated with its origin.
    /// It uses a new context local to the top-level document lifetime.
    /// In return, the Cross-Origin-Embedder-Policy (COEP) embedding rules can be lifted, so documents with COEP set can embed third-party documents that do not.
    /// </para>
    /// <para>See <see href="https://developer.mozilla.org/en-US/docs/Web/Security/IFrame_credentialless">IFrame credentialless</see> for a deeper explanation.</para>
    /// </summary>
    public bool Credentialless => moduleManager.InvokeSync<bool>("WindowAPI.getCredentialless", [windowJS]);

    /// <summary>
    /// <para>Indicates whether the document is cross-origin isolated.</para>
    /// <para>
    /// A cross-origin isolated document only shares its browsing context group with same-origin documents in popups and navigations,
    /// and resources (both same-origin and cross-origin) that the document has opted into using via CORS (and COEP for &lt;iframe&gt;).
    /// The relationship between a cross-origin opener of the document or any cross-origin popups that it opens are severed.
    /// The document may also be hosted in a separate OS process alongside other documents with which it can communicate by operating on shared memory.
    /// This mitigates the risk of side-channel attacks and cross-origin attacks referred to as XS-Leaks.
    /// </para>
    /// </summary>
    public bool CrossOriginIsolated => moduleManager.InvokeSync<bool>("WindowAPI.getCrossOriginIsolated", [windowJS]);

    /// <summary>
    /// Indicates whether the current context is secure (true) or not (false).
    /// </summary>
    public bool IsSecureContext => moduleManager.InvokeSync<bool>("WindowAPI.getIsSecureContext", [windowJS]);

    /// <summary>
    /// <para>
    /// Returns true if this window belongs to an origin-keyed agent cluster:
    /// this means that the operating system has provided dedicated resources (for example an operating system process) to this window's origin that are not shared with windows from other origins.
    /// </para>
    /// <para>Otherwise this property returns false.</para>
    /// </summary>
    public bool OriginAgentCluster => moduleManager.InvokeSync<bool>("WindowAPI.getOriginAgentCluster", [windowJS]);

    /// <summary>
    /// <para>Returns the menubar object.</para>
    /// <para>This is one of a group of Window properties that contain a boolean visible property, that used to represent whether or not a particular part of a web browser's user interface was visible.</para>
    /// <para>For privacy and interoperability reasons, the value of the visible property is now false if this Window is a popup, and true otherwise.</para>
    /// </summary>
    public bool Menubar => moduleManager.InvokeSync<bool>("WindowAPI.getMenubar", [windowJS]);


    /// <summary>
    /// Returns the element (such as &lt;iframe&gt; or &lt;object&gt;) in which the window is embedded.
    /// </summary>
    public IHTMLElementInProcess? FrameElement {
        get {
            IJSInProcessObjectReference?[] singleReference = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("WindowAPI.getFrameElement", [windowJS]);
            if (singleReference[0] is IJSInProcessObjectReference element)
                return new HTMLElementInProcess(element);
            else
                return null;
        }
    }



    // Methods

    /// <summary>
    /// Loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name.
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
    /// <returns></returns>
    public IWindowInProcess? Open(string? url = null, string? target = null, string? features = null) {
        IJSInProcessObjectReference?[] singleReference = moduleManager.InvokeSync<IJSInProcessObjectReference?[]>("WindowAPI.open", [windowJS, url, target, features]);
        if (singleReference[0] is IJSInProcessObjectReference window)
            return new WindowInProcess(moduleManager) { windowJS = window };
        else
            return null;
    }

    /// <summary>
    /// <para>Closes the current window, or the window on which it was called.</para>
    /// <para>
    /// Windows are script-closable if they were created by web content. This generally includes:<br/>
    /// - Windows opened using <see cref="Open"/><br/>
    /// - Windows opened via web content, such as links (&lt;a target="_blank"&gt;) or forms (&lt;form target="_blank"&gt;), without user modifier actions
    /// </para>
    /// <para>
    /// Windows opened by browser UI actions — such as right-click → Open in new tab, Ctrl+Click, Shift+Click, or middle-click — are often not script-closable.
    /// They may only be closed if they have not been navigated (history length remains 1).
    /// Calling close() otherwise typically shows a console warning: Scripts may not close windows that were not opened by script.
    /// </para>
    /// <para>Note also that close() has no effect when called on Window objects returned by <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLIFrameElement/contentWindow">HTMLIFrameElement.contentWindow</see>.</para>
    /// </summary>
    /// <returns></returns>
    public void Close() => moduleManager.InvokeSync("WindowAPI.close", [windowJS]);

    /// <summary>
    /// <para>Stops further resource loading in the current browsing context, equivalent to the stop button in the browser.</para>
    /// <para>Because of how scripts are executed, this method cannot interrupt its parent document's loading, but it will stop its images, new windows, and other still-loading objects.</para>
    /// </summary>
    /// <returns></returns>
    public void Stop() => moduleManager.InvokeSync("WindowAPI.stop", [windowJS]);

    /// <summary>
    /// Makes a request to bring the window to the front. It may fail due to user settings and the window isn't guaranteed to be frontmost before this method returns.
    /// </summary>
    /// <returns></returns>
    public void Focus() => moduleManager.InvokeSync("WindowAPI.focus", [windowJS]);

    /// <summary>
    /// <para>Opens the print dialog to print the current document.</para>
    /// <para>If the document is still loading when this function is called, then the document will finish loading before opening the print dialog.</para>
    /// <para>This method will block while the print dialog is open.</para>
    /// </summary>
    /// <returns></returns>
    public void Print() => moduleManager.InvokeSync("WindowAPI.print", [windowJS]);

    /// <summary>
    /// <para>May be used to report errors to the console or event handlers of global scopes, emulating an uncaught JavaScript exception.</para>
    /// <para>
    /// This feature is primarily intended for custom event-dispatching or callback-manipulating libraries.
    /// Libraries can use this feature to catch errors in callback code and re-throw them to the top level handler.
    /// This ensures that an exception in one callback will not prevent others from being handled,
    /// while at the same time ensuring that stack trace information is still readily available for debugging at the top level.
    /// </para>
    /// </summary>
    /// <param name="error">An error object such as a TypeError.</param>
    /// <returns></returns>
    public void ReportError(object error) => moduleManager.InvokeSync("WindowAPI.reportError", [windowJS, error]);

    /// <summary>
    /// <para>Instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog.</para>
    /// <para>Under some conditions (when the user switches tabs, for example) the browser may not display a dialog, or may not wait for the user to submit text or to cancel the dialog.</para>
    /// </summary>
    /// <param name="message">A string of text to display to the user. Can be omitted if there is nothing to show in the prompt window.</param>
    /// <param name="defaultValue">A string containing the default value displayed in the text input field.</param>
    /// <returns>A string containing the text entered by the user, or null.</returns>
    public string? Prompt(string? message = null, string? defaultValue = null) => moduleManager.InvokeSync<string?>("WindowAPI.prompt", [windowJS, message, defaultValue]);

    /// <summary>
    /// <para>Instructs the browser to display a dialog with an optional message, and to wait until the user either confirms or cancels the dialog.</para>
    /// <para>Under some conditions — for example, when the user switches tabs — the browser may not actually display a dialog, or may not wait for the user to confirm or cancel the dialog.</para>
    /// </summary>
    /// <param name="message">A string you want to display in the confirmation dialog.</param>
    /// <returns>Whether OK (true) or Cancel (false) was selected. If a browser is ignoring in-page dialogs, then the returned value is always false.</returns>
    public bool Confirm(string? message = null) => moduleManager.InvokeSync<bool>("WindowAPI.confirm", [windowJS, message]);

    /// <summary>
    /// <para>Instructs the browser to display a dialog with an optional message, and to wait until the user dismisses the dialog.</para>
    /// <para>Under some conditions — for example, when the user switches tabs — the browser may not actually display a dialog, or may not wait for the user to dismiss the dialog.</para>
    /// </summary>
    /// <param name="message">A string you want to display in the alert dialog, or, alternatively, an object that is converted into a string and displayed.</param>
    /// <returns></returns>
    public void Alert(string? message = null) => moduleManager.InvokeSync("WindowAPI.alert", [windowJS, message]);


    /// <summary>
    /// Moves the current window by a specified amount.
    /// </summary>
    /// <remarks>Note: This function moves the window relative to its current location. In contrast, <see cref="MoveTo"/> moves the window to an absolute location.</remarks>
    /// <param name="deltaX">The amount of pixels to move the window horizontally. Positive values are to the right, while negative values are to the left.</param>
    /// <param name="deltaY">The amount of pixels to move the window vertically. Positive values are down, while negative values are up.</param>
    /// <returns></returns>
    public void MoveBy(int deltaX, int deltaY) => moduleManager.InvokeSync("WindowAPI.moveBy", [windowJS, deltaX, deltaY]);

    /// <summary>
    /// Moves the current window to the specified coordinates.
    /// </summary>
    /// <remarks>Note: This function moves the window to an absolute location. In contrast, <see cref="MoveBy"/> moves the window relative to its current location.</remarks>
    /// <param name="x">The horizontal coordinate to be moved to.</param>
    /// <param name="y">The vertical coordinate to be moved to.</param>
    /// <returns></returns>
    public void MoveTo(int x, int y) => moduleManager.InvokeSync("WindowAPI.moveTo", [windowJS, x, y]);

    /// <summary>
    /// Resizes the current window by a specified amount.
    /// </summary>
    /// <param name="xDelta">The number of pixels to grow/shrink the window horizontally.</param>
    /// <param name="yDelta">The number of pixels to grow/shrink the window vertically.</param>
    /// <returns></returns>
    public void ResizeBy(int xDelta, int yDelta) => moduleManager.InvokeSync("WindowAPI.resizeBy", [windowJS, xDelta, yDelta]);

    /// <summary>
    /// Dynamically resizes the window.
    /// </summary>
    /// <param name="width">An integer representing the new <see cref="OuterWidth"/> in pixels (including scroll bars, title bars, etc.).</param>
    /// <param name="height">An integer value representing the new <see cref="OuterHeight"/> in pixels (including scroll bars, title bars, etc.).</param>
    /// <returns></returns>
    public void ResizeTo(int width, int height) => moduleManager.InvokeSync("WindowAPI.resizeTo", [windowJS, width, height]);

    /// <summary>
    /// Scrolls the window to a particular place in the document.
    /// </summary>
    /// <param name="left">Specifies the number of pixels along the X axis to scroll the window or element.</param>
    /// <param name="top">Specifies the number of pixels along the Y axis to scroll the window or element.</param>
    /// <param name="behavior">
    /// Determines whether scrolling is instant or animates smoothly. This option is a string which must take one of the following values:<br />
    /// - "smooth": scrolling should animate smoothly<br />
    /// - "instant": scrolling should happen instantly in a single jump<br />
    /// - "auto": scroll behavior is determined by the computed value of scroll-behavior
    /// </param>
    /// <returns></returns>
    public void Scroll(int left, int top, string? behavior = null) => moduleManager.InvokeSync("WindowAPI.scroll", [windowJS, left, top, behavior]);

    /// <summary>
    /// Scrolls to a particular set of coordinates in the document.
    /// </summary>
    /// <param name="left">Specifies the number of pixels along the X axis to scroll the window or element.</param>
    /// <param name="top">Specifies the number of pixels along the Y axis to scroll the window or element.</param>
    /// <param name="behavior">
    /// Determines whether scrolling is instant or animates smoothly. This option is a string which must take one of the following values:<br />
    /// - "smooth": scrolling should animate smoothly<br />
    /// - "instant": scrolling should happen instantly in a single jump<br />
    /// - "auto": scroll behavior is determined by the computed value of scroll-behavior
    /// </param>
    /// <returns></returns>
    public void ScrollTo(int left, int top, string? behavior = null) => moduleManager.InvokeSync("WindowAPI.scrollTo", [windowJS, left, top, behavior]);

    /// <summary>
    /// Scrolls the document in the window by the given amount.
    /// </summary>
    /// <param name="deltaX">The horizontal pixel value that you want to scroll by.</param>
    /// <param name="deltaY">The vertical pixel value that you want to scroll by.</param>
    /// <param name="behavior">
    /// Determines whether scrolling is instant or animates smoothly. This option is a string which must take one of the following values:<br />
    /// - "smooth": scrolling should animate smoothly<br />
    /// - "instant": scrolling should happen instantly in a single jump<br />
    /// - "auto": scroll behavior is determined by the computed value of scroll-behavior
    /// </param>
    /// <returns></returns>
    public void ScrollBy(int deltaX, int deltaY, string? behavior = null) => moduleManager.InvokeSync("WindowAPI.scrollBy", [windowJS, deltaX, deltaY, behavior]);


    /// <summary>
    /// Sets a timer which executes a function or specified piece of code once the timer expires.
    /// </summary>
    /// <param name="handler">A function to be executed after the timer expires.</param>
    /// <param name="delay">
    /// <para>
    /// The time, in milliseconds that the timer should wait before the specified function or code is executed.
    /// If this parameter is omitted, a value of 0 is used, meaning execute "immediately", or more accurately, the next event cycle.
    /// </para>
    /// <para>Note that in either case, the actual delay may be longer than intended; see Reasons for delays longer than specified below.</para>
    /// </param>
    /// <returns>
    /// <para>
    /// A value that uniquely identifies the timer created by the call.
    /// This identifier, often referred to as a "timeout ID", can be passed to <see cref="ClearTimeout"/> to cancel the timer.
    /// </para>
    /// <para>
    /// Within the same global environment (e.g., a specific window or worker) the timeout ID is guaranteed not to be reused for any new timer as long as the original timer remains active.
    /// However, separate global environments maintain their own independent pools of timer IDs.
    /// </para>
    /// </returns>
    public TimeoutHandle SetTimeout(Action handler, int delay) {
        DotNetObjectReference<VoidCallback> voidCallback = DotNetObjectReference.Create(new VoidCallback(null!));
        voidCallback.Value.HandlerValue = () => {
            handler();
            voidCallback.Dispose();
        };

        int id = moduleManager.InvokeSync<int>("WindowAPI.setTimeout", [windowJS, voidCallback, delay]);
        return new TimeoutHandle(id, voidCallback);
    }

    /// <summary>
    /// <para>Cancels a timeout previously established by calling <see cref="SetTimeout"/>.</para>
    /// <para>If the parameter provided does not identify a previously established action, this method does nothing.</para>
    /// </summary>
    /// <remarks>
    /// It's worth noting that the pool of IDs used by <see cref="SetTimeout"/> and <see cref="SetInterval"/> are shared,
    /// which means you can technically use <see cref="ClearTimeout"/> and <see cref="ClearInterval"/> interchangeably.
    /// However, for clarity, you should avoid doing so.
    /// </remarks>
    /// <param name="timeoutHandle">The identifier of the timeout you want to cancel. This ID was returned by the corresponding call to <see cref="SetTimeout"/>.</param>
    /// <returns></returns>
    public void ClearTimeout(TimeoutHandle timeoutHandle) {
        moduleManager.InvokeSync("WindowAPI.clearTimeout", [windowJS, timeoutHandle.id]);
        timeoutHandle.callback.Dispose();
    }

    /// <summary>
    /// Repeatedly calls a function or executes a code snippet, with a fixed time delay between each call.
    /// </summary>
    /// <param name="handler">A function to be executed every delay milliseconds. The first execution happens after delay milliseconds.</param>
    /// <param name="delay">
    /// The time, in milliseconds (thousandths of a second), the timer should delay in between executions of the specified function or code.
    /// Defaults to 0 if not specified.
    /// See <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window/setInterval#delay_restrictions">Delay restrictions</see> below for details on the permitted range of delay values.
    /// </param>
    /// <returns>
    /// <para>
    /// A value that uniquely identifies the interval timer created by the call.
    /// This identifier, often referred to as an "interval ID", can be passed to <see cref="ClearInterval"/> to stop the repeated execution of the specified function.
    /// </para>
    /// <para>
    /// Within the same global environment (e.g., a particular window or worker), the interval ID is ensured to remain unique and is not reused for any new interval timer as long as the original timer is still active.
    /// However, different global environments maintain their own independent pools of interval IDs.
    /// </para>
    /// </returns>
    public IntervalHandle SetInterval(Action handler, int delay) {
        DotNetObjectReference<VoidCallback> voidCallback = DotNetObjectReference.Create(new VoidCallback(handler));
        int id = moduleManager.InvokeSync<int>("WindowAPI.setInterval", [windowJS, voidCallback, delay]);
        return new IntervalHandle(id, voidCallback);
    }

    /// <summary>
    /// Cancels a timed, repeating action which was previously established by a call to <see cref="SetInterval"/>.
    /// If the parameter provided does not identify a previously established action, this method does nothing.
    /// </summary>
    /// <remarks>
    /// It's worth noting that the pool of IDs used by <see cref="SetInterval"/> and <see cref="SetTimeout"/> are shared,
    /// which means you can technically use <see cref="ClearInterval"/> and <see cref="ClearTimeout"/> interchangeably.
    /// However, for clarity, you should avoid doing so.
    /// </remarks>
    /// <param name="intervalHandle">The identifier of the repeated action you want to cancel. This ID was returned by the corresponding call to <see cref="SetInterval"/>.</param>
    /// <returns></returns>
    public void ClearInterval(IntervalHandle intervalHandle) {
        moduleManager.InvokeSync("WindowAPI.clearInterval", [windowJS, intervalHandle.id]);
        intervalHandle.callback.Dispose();
    }

    /// <summary>
    /// <para>Tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint.</para>
    /// <para>
    /// The frequency of calls to the callback function will generally match the display refresh rate.
    /// The most common refresh rate is 60hz, (60 cycles/frames per second), though 75hz, 120hz, and 144hz are also widely used.
    /// requestAnimationFrame() calls are paused in most browsers when running in background tabs or hidden &lt;iframe&gt;s, in order to improve performance and battery life.
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>Note: Your callback function must call requestAnimationFrame() again if you want to animate another frame. requestAnimationFrame() is one-shot.</para>
    /// <para>
    /// Warning: Be sure always to use the first argument (or some other method for getting the current time) to calculate how much the animation will progress in a frame
    /// — otherwise, the animation will run faster on high refresh-rate screens.
    /// For ways to do that, see <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window/requestAnimationFrame#examples">the examples below</see>.
    /// </para>
    /// </remarks>
    /// <param name="handler">
    /// <para>
    /// The function to call when it's time to update your animation for the next repaint. This callback function is passed a single argument:
    /// </para>
    /// - timestamp:<br />
    /// A DOMHighResTimeStamp indicating the end time of the previous frame's rendering (based on the number of milliseconds since time origin).
    /// The timestamp is a decimal number, in milliseconds, but with a minimal precision of 1 millisecond.
    /// For Window objects (not Workers), it is equal to document.timeline.currentTime.
    /// This timestamp is shared between all windows that run on the same agent (all same-origin windows and, more importantly, same-origin iframes)
    /// — which allows synchronizing animations across multiple requestAnimationFrame callbacks.
    /// The timestamp value is also similar to calling performance.now() at the start of the callback function, but it is never the same value.<br />
    /// When multiple callbacks queued by requestAnimationFrame() begin to fire in a single frame,
    /// each receives the same timestamp even though time has passed during the computation of every previous callback's workload.
    /// </param>
    /// <returns>
    /// The request ID, that uniquely identifies the entry in the callback list.
    /// You should not make any assumptions about its value.
    /// You can pass this value to <see cref="CancelAnimationFrame"/> to cancel the refresh callback request.
    /// </returns>
    public AnimationFrameHandle RequestAnimationFrame(Action<double> handler) {
        DotNetObjectReference<AnimationFrameCallback> animationFrameCallback = DotNetObjectReference.Create(new AnimationFrameCallback(null!));
        animationFrameCallback.Value.HandlerValue = (double timeStamp) => {
            handler(timeStamp);
            animationFrameCallback.Dispose();
        };

        ulong id = moduleManager.InvokeSync<ulong>("WindowAPI.requestAnimationFrame", [windowJS, animationFrameCallback]);
        return new AnimationFrameHandle(id, animationFrameCallback);
    }

    /// <summary>
    /// Cancels an animation frame request previously scheduled through a call to <see cref="RequestAnimationFrame"/>.
    /// </summary>
    /// <param name="animationFrameHandle">The ID value returned by the call to <see cref="RequestAnimationFrame"/> that requested the callback.</param>
    /// <returns></returns>
    public void CancelAnimationFrame(AnimationFrameHandle animationFrameHandle) {
        moduleManager.InvokeSync("WindowAPI.cancelAnimationFrame", [windowJS, animationFrameHandle.id]);
        animationFrameHandle.callback.Dispose();
    }

    /// <summary>
    /// <para>
    /// Queues a function to be called during a browser's idle periods.
    /// This enables developers to perform background and low priority work on the main thread, without impacting latency-critical events such as animation and input response.
    /// Functions are generally called in first-in-first-out order;
    /// however, callbacks which have a timeout specified may be called out-of-order if necessary in order to run them before the timeout elapses.
    /// </para>
    /// <para>You can call <see cref="RequestIdleCallback"/> within an idle callback function to schedule another callback to take place no sooner than the next pass through the event loop.</para>
    /// </summary>
    /// <param name="handler">
    /// A reference to a function that should be called in the near future, when the event loop is idle.
    /// The callback function is passed an IdleDeadline object describing the amount of time available and whether or not the callback has been run because the timeout period expired.
    /// </param>
    /// <param name="timeout">
    /// <para>
    /// If the number of milliseconds represented by this parameter has elapsed and the callback has not already been called,
    /// then a task to execute the callback is queued in the event loop (even if doing so risks causing a negative performance impact).
    /// timeout must be a positive value or it is ignored.
    /// </para>
    /// <para>Note: A timeout option is strongly recommended for required work, as otherwise it's possible multiple seconds will elapse before the callback is fired.</para>
    /// </param>
    /// <returns>An ID which can be used to cancel the callback by passing it into the <see cref="CancelIdleCallback"/> method.</returns>
    public IdleCallbackHandle RequestIdleCallback(Action handler, int? timeout = null) {
        DotNetObjectReference<VoidCallback> voidCallback = DotNetObjectReference.Create(new VoidCallback(null!));
        voidCallback.Value.HandlerValue = () => {
            handler();
            voidCallback.Dispose();
        };

        ulong id = moduleManager.InvokeSync<ulong>("WindowAPI.requestIdleCallback", [windowJS, voidCallback, timeout]);
        return new IdleCallbackHandle(id, voidCallback);
    }

    /// <summary>
    /// Cancels a callback previously scheduled with <see cref="RequestIdleCallback"/>.
    /// </summary>
    /// <param name="idleCallbackHandle">The ID value returned by <see cref="RequestIdleCallback"/> when the callback was established.</param>
    /// <returns></returns>
    public void CancelIdleCallback(IdleCallbackHandle idleCallbackHandle) {
        idleCallbackHandle.callback.Dispose();
        moduleManager.InvokeSync("WindowAPI.cancelIdleCallback", [windowJS, idleCallbackHandle.id]);
    }

    /// <summary>
    /// <para>Queues a microtask to be executed at a safe time prior to control returning to the browser's event loop.</para>
    /// <para>
    /// The microtask is a short function which will run after the current task has completed its work
    /// and when there is no other code waiting to be run before control of the execution context is returned to the browser's event loop.
    /// </para>
    /// <para>
    /// This lets your code run without interfering with any other, potentially higher priority, code that is pending,
    /// but before the browser regains control over the execution context, potentially depending on work you need to complete.
    /// You can learn more about how to use microtasks and why you might choose to do so in our <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTML_DOM_API/Microtask_guide">microtask guide</see>.
    /// </para>
    /// <para>
    /// The importance of microtasks comes in its ability to perform tasks asynchronously but in a specific order.
    /// See <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTML_DOM_API/Microtask_guide">Using microtasks in JavaScript with queueMicrotask()</see> for more details.
    /// </para>
    /// <para>Microtasks are especially useful for libraries and frameworks that need to perform final cleanup or other just-before-rendering tasks.</para>
    /// </summary>
    /// <param name="handler">
    /// A function to be executed when the browser engine determines it is safe to call your code.
    /// Enqueued microtasks are executed after all pending tasks have completed but before yielding control to the browser's event loop.
    /// </param>
    /// <returns></returns>
    public void QueueMicrotask(Action handler) {
        DotNetObjectReference<VoidCallback> voidCallback = DotNetObjectReference.Create(new VoidCallback(null!));
        voidCallback.Value.HandlerValue = () => {
            handler();
            voidCallback.Dispose();
        };

        moduleManager.InvokeSync("WindowAPI.queueMicrotask", [windowJS, voidCallback]);
    }


    /// <summary>
    /// Decodes a string of data which has been encoded using Base64 encoding.
    /// You can use the <see cref="Btoa"/> to encode and transmit data which may otherwise cause communication problems, then transmit it and use this method to decode the data again.
    /// For example, you can encode, transmit, and decode control characters such as ASCII values 0 through 31.
    /// </summary>
    /// <param name="base64">A base64-encoded string, using the alphabet produced by <see cref="Btoa"/>.</param>
    /// <returns>
    /// A binary string containing raw bytes decoded from the input.
    /// Strings in JavaScript are encoded as UTF-16, so this means each character must have a code point less than 256, representing one byte of data.
    /// </returns>
    public string Atob(string base64) => moduleManager.InvokeSync<string>("WindowAPI.atob", [windowJS, base64]);

    /// <summary>
    /// <para>Creates a Base64-encoded ASCII string from a binary string (i.e., a string in which each character in the string is treated as a byte of binary data).</para>
    /// <para>
    /// You can use this method to encode data which may otherwise cause communication problems, transmit it, then use the <see cref="Atob"/> method to decode the data again.
    /// For example, you can encode control characters such as ASCII values 0 through 31.
    /// </para>
    /// </summary>
    /// <param name="ascii">The binary string to encode. Strings in JavaScript are encoded as UTF-16, so this means each character must have a code point less than 256, representing one byte of data.</param>
    /// <returns>An ASCII string containing the Base64 representation of the input.</returns>
    public string Btoa(string ascii) => moduleManager.InvokeSync<string>("WindowAPI.btoa", [windowJS, ascii]);

    /// <summary>
    /// <para>
    /// Safely enables cross-origin communication between Window objects;
    /// e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it.
    /// </para>
    /// <para>
    /// Normally, scripts on different pages are allowed to access each other if and only if the pages they originate from share the same origin (also known as the "same-origin policy").
    /// window.postMessage() provides a controlled mechanism to securely circumvent this restriction (if used properly).
    /// </para>
    /// <para>
    /// Furthermore, an accessing script must have obtained the window object of the accessed document beforehand.
    /// This can occur through methods such as <see cref="Open"/> for popups or <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLIFrameElement/contentWindow">iframe.contentWindow</see> for iframes.
    /// </para>
    /// <para>
    /// Broadly, one window may obtain a reference to another (e.g., via targetWindow = window.opener), and then dispatch a MessageEvent on it with targetWindow.postMessage().
    /// The receiving window is then free to handle this event as needed.
    /// The arguments passed to window.postMessage() (i.e., the "message") are exposed to the receiving window through the <see cref="IWindowInProcess.OnMessage">event object</see>.
    /// </para>
    /// </summary>
    /// <param name="message">
    /// Data to be dispatched to the other window.
    /// The data is serialized using the <see cref="StructuredClone">structured clone algorithm</see>.
    /// This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself.
    /// </param>
    /// <param name="targetOrigin">
    /// <para>
    /// Specifies the origin the recipient window must have in order to receive the event.
    /// In order for the event to be dispatched, the origin must match exactly (including scheme, hostname, and port).
    /// If omitted, it defaults to "/", which is the origin that is calling the method.
    /// This mechanism provides control over where messages are sent;
    /// for example, if postMessage() was used to transmit a password,
    /// it would be absolutely critical that this argument be a URI whose origin is the same as the intended receiver of the message containing the password,
    /// to prevent interception of the password by a malicious third party.
    /// </para>
    /// <para>"*" may also be provided, which means the message can be dispatched to a listener with any origin.</para>
    /// </param>
    /// <returns></returns>
    public void PostMessage(object message, string targetOrigin) => moduleManager.InvokeSync("WindowAPI.postMessage", [windowJS, message, targetOrigin]);

    /// <summary>
    /// Creates a deep clone of a given value using the <see href="https://developer.mozilla.org/en-US/docs/Web/API/Web_Workers_API/Structured_clone_algorithm">structured clone algorithm</see>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The object to be cloned. This can be any structured-cloneable type.</param>
    /// <returns></returns>
    public T StructuredClone<T>(T value) => moduleManager.InvokeSync<T>("WindowAPI.structuredClone", [windowJS, value]);



    // Events

    private protected override void InvokeDrag(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDrag?.Invoke(new DragEventInProcess(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEventInProcess>? _onDrag;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired every few hundred milliseconds as an element or text selection is being dragged by the user.<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEventInProcess> OnDrag {
        add {
            if (_onDrag == null)
                _ = ActivateJSEvent("activateOndrag").Preserve();
            _onDrag += value;
        }
        remove {
            _onDrag -= value;
            if (_onDrag == null)
                _ = DeactivateJSEvent("deactivateOndrag").Preserve();
        }
    }

    private protected override void InvokeDragStart(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDragStart?.Invoke(new DragEventInProcess(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEventInProcess>? _onDragStart;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when the user starts dragging an element or text selection.<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEventInProcess> OnDragStart {
        add {
            if (_onDragStart == null)
                _ = ActivateJSEvent("activateOndragstart").Preserve();
            _onDragStart += value;
        }
        remove {
            _onDragStart -= value;
            if (_onDragStart == null)
                _ = DeactivateJSEvent("deactivateOndragstart").Preserve();
        }
    }

    private protected override void InvokeDragEnd(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDragEnd?.Invoke(new DragEventInProcess(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEventInProcess>? _onDragEnd;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when a drag operation ends (by releasing a mouse button or hitting the escape key).<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEventInProcess> OnDragEnd {
        add {
            if (_onDragEnd == null)
                _ = ActivateJSEvent("activateOndragend").Preserve();
            _onDragEnd += value;
        }
        remove {
            _onDragEnd -= value;
            if (_onDragEnd == null)
                _ = DeactivateJSEvent("deactivateOndragend").Preserve();
        }
    }

    private protected override void InvokeDragEnter(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDragEnter?.Invoke(new DragEventInProcess(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEventInProcess>? _onDragEnter;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when a dragged element or text selection enters a valid drop target.
    /// The target object is the immediate user selection (the element directly indicated by the user as the drop target), or the &lt;body&gt; element.<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEventInProcess> OnDragEnter {
        add {
            if (_onDragEnter == null)
                _ = ActivateJSEvent("activateOndragenter").Preserve();
            _onDragEnter += value;
        }
        remove {
            _onDragEnter -= value;
            if (_onDragEnter == null)
                _ = DeactivateJSEvent("deactivateOndragenter").Preserve();
        }
    }

    private protected override void InvokeDragLeave(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDragLeave?.Invoke(new DragEventInProcess(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEventInProcess>? _onDragLeave;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when a dragged element or text selection leaves a valid drop target.<br />
    /// This event is not cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEventInProcess> OnDragLeave {
        add {
            if (_onDragLeave == null)
                _ = ActivateJSEvent("activateOndragleave").Preserve();
            _onDragLeave += value;
        }
        remove {
            _onDragLeave -= value;
            if (_onDragLeave == null)
                _ = DeactivateJSEvent("deactivateOndragleave").Preserve();
        }
    }

    private protected override void InvokeDragOver(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDragOver?.Invoke(new DragEventInProcess(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEventInProcess>? _onDragOver;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when an element or text selection is being dragged over a valid drop target (every few hundred milliseconds).<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEventInProcess> OnDragOver {
        add {
            if (_onDragOver == null)
                _ = ActivateJSEvent("activateOndragover").Preserve();
            _onDragOver += value;
        }
        remove {
            _onDragOver -= value;
            if (_onDragOver == null)
                _ = DeactivateJSEvent("deactivateOndragover").Preserve();
        }
    }

    private protected override void InvokeDrop(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => _onDrop?.Invoke(new DragEventInProcess(dropEffect, effectAllowed, types, WrapFiles(files)));
    private Action<DragEventInProcess>? _onDrop;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when an element or text selection is dropped on a valid drop target.
    /// To ensure that the drop event always fires as expected, you should always include a preventDefault() call in the part of your code which handles the dragover event.<br />
    /// This event is cancelable and may bubble up to the Document and Window objects.
    /// </para>
    /// <para>The parameter holds the content of the <see href="https://developer.mozilla.org/en-US/docs/Web/API/DragEvent/dataTransfer">DragEvent.dataTransfer</see> property,</para>
    /// </summary>
    public event Action<DragEventInProcess> OnDrop {
        add {
            if (_onDrop == null)
                _ = ActivateJSEvent("activateOndrop").Preserve();
            _onDrop += value;
        }
        remove {
            _onDrop -= value;
            if (_onDrop == null)
                _ = DeactivateJSEvent("deactivateOndrop").Preserve();
        }
    }

    private static IFileInProcess[] WrapFiles(IJSObjectReference[] files) {
        FileInProcess[] result = new FileInProcess[files.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new FileInProcess(files[i]);
        return result;
    }
}

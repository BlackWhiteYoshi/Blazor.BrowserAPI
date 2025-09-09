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
public sealed class Window(IModuleManager moduleManager) : WindowBase(moduleManager), IWindow {
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
    public ValueTask<int> InnerWidth => GetInnerWidth(default);

    /// <inheritdoc cref="InnerWidth" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetInnerWidth(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("WindowAPI.getInnerWidth", cancellationToken);


    /// <summary>
    /// <para>Returns the interior height of the window in pixels, including the height of the horizontal scroll bar, if present.</para>
    /// <para>The value of innerHeight is taken from the height of the window's layout viewport. The width can be obtained using the <see cref="InnerWidth"/> property.</para>
    /// </summary>
    public ValueTask<int> InnerHeight => GetInnerHeight(default);

    /// <inheritdoc cref="InnerHeight" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetInnerHeight(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("WindowAPI.getInnerHeight", cancellationToken);


    /// <summary>
    /// Returns the width of the outside of the browser window.
    /// It represents the width of the whole browser window including sidebar (if expanded), window chrome and window resizing borders/handles.
    /// </summary>
    public ValueTask<int> OuterWidth => GetOuterWidth(default);

    /// <inheritdoc cref="OuterWidth" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetOuterWidth(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("WindowAPI.getOuterWidth", cancellationToken);


    /// <summary>
    /// Returns the height in pixels of the whole browser window, including any sidebar, window chrome, and window-resizing borders/handles.
    /// </summary>
    public ValueTask<int> OuterHeight => GetOuterHeight(default);

    /// <inheritdoc cref="OuterHeight" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetOuterHeight(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("WindowAPI.getOuterHeight", cancellationToken);


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
    /// <para>
    /// You can use <see cref="MatchMedia"/> to check if the value of devicePixelRatio changes (which can happen, for example, if the user drags the window to a display with a different pixel density).
    /// See <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window/devicePixelRatio#monitoring_screen_resolution_or_zoom_level_changes">the example below</see>.
    /// </para>
    /// </summary>
    public ValueTask<double> DevicePixelRatio => GetDevicePixelRatio(default);

    /// <inheritdoc cref="DevicePixelRatio" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetDevicePixelRatio(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<double>("WindowAPI.getDevicePixelRatio", cancellationToken);



    /// <summary>
    /// Returns the number of pixels by which the document is currently scrolled horizontally.
    /// This value is subpixel precise in modern browsers, meaning that it isn't necessarily a whole number.
    /// You can get the number of pixels the document is scrolled vertically from the <see cref="ScrollY"/> property.
    /// </summary>
    public ValueTask<double> ScrollX => GetScrollX(default);

    /// <inheritdoc cref="ScrollX" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetScrollX(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<double>("WindowAPI.getScrollX", cancellationToken);


    /// <summary>
    /// Returns the number of pixels by which the document is currently scrolled vertically.
    /// This value is subpixel precise in modern browsers, meaning that it isn't necessarily a whole number.
    /// You can get the number of pixels the document is scrolled horizontally from the <see cref="ScrollX"/> property.
    /// </summary>
    public ValueTask<double> ScrollY => GetScrollY(default);

    /// <inheritdoc cref="ScrollY" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetScrollY(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<double>("WindowAPI.getScrollY", cancellationToken);


    /// <summary>
    /// Returns the horizontal distance, in CSS pixels, of the left border of the user's browser viewport to the left side of the screen.
    /// </summary>
    public ValueTask<int> ScreenX => GetScreenX(default);

    /// <inheritdoc cref="ScreenX" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetScreenX(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("WindowAPI.getScreenX", cancellationToken);


    /// <summary>
    /// Returns the vertical distance, in CSS pixels, of the top border of the user's browser viewport to the top edge of the screen.
    /// </summary>
    public ValueTask<int> ScreenY => GetScreenY(default);

    /// <inheritdoc cref="ScreenY" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetScreenY(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("WindowAPI.getScreenY", cancellationToken);



    /// <summary>
    /// Returns the origin of the global scope, serialized as a string.
    /// </summary>
    public ValueTask<string> Origin => GetOrigin(default);

    /// <inheritdoc cref="Origin" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetOrigin(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("WindowAPI.getOrigin", cancellationToken);


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
    public ValueTask<string> Name => GetName(default);

    /// <inheritdoc cref="Name" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetName(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("WindowAPI.getName", cancellationToken);

    /// <inheritdoc cref="Name" />
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetName(string value, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("WindowAPI.setName", cancellationToken, [value]);



    /// <summary>
    /// Indicates whether the referenced window is closed or not.
    /// </summary>
    public ValueTask<bool> Closed => GetClosed(default);

    /// <inheritdoc cref="Closed" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetClosed(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("WindowAPI.getClosed", cancellationToken);


    /// <summary>
    /// <para>Indicates whether the current document was loaded inside a credentialless &lt;iframe&gt;, meaning that it is loaded in a new, ephemeral context.</para>
    /// <para>
    /// This context doesn't have access to the network, cookies, and storage data associated with its origin.
    /// It uses a new context local to the top-level document lifetime.
    /// In return, the Cross-Origin-Embedder-Policy (COEP) embedding rules can be lifted, so documents with COEP set can embed third-party documents that do not.
    /// </para>
    /// <para>See <see href="https://developer.mozilla.org/en-US/docs/Web/Security/IFrame_credentialless">IFrame credentialless</see> for a deeper explanation.</para>
    /// </summary>
    public ValueTask<bool> Credentialless => GetCredentialless(default);

    /// <inheritdoc cref="Credentialless" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetCredentialless(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("WindowAPI.getCredentialless", cancellationToken);


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
    public ValueTask<bool> CrossOriginIsolated => GetCrossOriginIsolated(default);

    /// <inheritdoc cref="CrossOriginIsolated" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetCrossOriginIsolated(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("WindowAPI.getCrossOriginIsolated", cancellationToken);


    /// <summary>
    /// Indicates whether the current context is secure (true) or not (false).
    /// </summary>
    public ValueTask<bool> IsSecureContext => GetIsSecureContext(default);

    /// <inheritdoc cref="IsSecureContext" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetIsSecureContext(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("WindowAPI.getIsSecureContext", cancellationToken);


    /// <summary>
    /// <para>
    /// Returns true if this window belongs to an origin-keyed agent cluster:
    /// this means that the operating system has provided dedicated resources (for example an operating system process) to this window's origin that are not shared with windows from other origins.
    /// </para>
    /// <para>Otherwise this property returns false.</para>
    /// </summary>
    public ValueTask<bool> OriginAgentCluster => GetOriginAgentCluster(default);

    /// <inheritdoc cref="OriginAgentCluster" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetOriginAgentCluster(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("WindowAPI.getOriginAgentCluster", cancellationToken);


    /// <summary>
    /// <para>Returns the menubar object.</para>
    /// <para>This is one of a group of Window properties that contain a boolean visible property, that used to represent whether or not a particular part of a web browser's user interface was visible.</para>
    /// <para>For privacy and interoperability reasons, the value of the visible property is now false if this Window is a popup, and true otherwise.</para>
    /// </summary>
    public ValueTask<bool> Menubar => GetMenubar(default);

    /// <inheritdoc cref="Menubar" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetMenubar(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("WindowAPI.getMenubar", cancellationToken);



    /// <summary>
    /// Returns the element (such as &lt;iframe&gt; or &lt;object&gt;) in which the window is embedded.
    /// </summary>
    public ValueTask<IHTMLElement?> FrameElement => GetFrameElement(default);

    /// <inheritdoc cref="FrameElement" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IHTMLElement?> GetFrameElement(CancellationToken cancellationToken) {
        IJSObjectReference?[] singleReference = await moduleManager.InvokeTrySync<IJSObjectReference?[]>("WindowAPI.getFrameElement", cancellationToken);
        if (singleReference[0] is IJSObjectReference element)
            return new HTMLElement(Task.FromResult(element));
        else
            return null;
    }
}

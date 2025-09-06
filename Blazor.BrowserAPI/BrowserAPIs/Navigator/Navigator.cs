using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The Navigator interface represents the state and the identity of the user agent.
/// It allows scripts to query it and to register themselves to carry on some activities.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class Navigator(IModuleManager moduleManager) : NavigatorBase(moduleManager), INavigator {
    /// <summary>
    /// <para>Represents the preferred language of the user, usually the language of the browser UI.</para>
    /// <para>
    /// The value represents the language version as defined in <see href="https://datatracker.ietf.org/doc/html/rfc5646">RFC 5646: Tags for Identifying Languages (also known as BCP 47)</see>.
    /// Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc.
    /// </para>
    /// <para>Note that in Safari on iOS prior to 10.2, the country code returned is lowercase: "en-us", "fr-fr" etc.</para>
    /// </summary>
    public ValueTask<string> Language => GetLanguage(default);

    /// <inheritdoc cref="Language" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetLanguage(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("NavigatorAPI.getLanguage", cancellationToken);

    /// <summary>
    /// <para>Represents the user's preferred languages.</para>
    /// <para>
    /// The language is described using language tags according to <see href="https://datatracker.ietf.org/doc/html/rfc5646">RFC 5646: Tags for Identifying Languages (also known as BCP 47)</see>.
    /// In the returned array they are ordered by preference with the most preferred language first.
    /// </para>
    /// <para>The value of <see cref="Language"/> is the first element of the returned array.</para>
    /// <para>When its value changes, as the user's preferred languages are changed a <see cref="IWindow.OnLanguageChange"/> event is fired on the <see cref="IWindow"/> object.</para>
    /// <para>
    /// The Accept-Language HTTP header in every HTTP request from the user's browser generally lists the same locales as the navigator.languages property, with decreasing q values (quality values).
    /// Some browsers (Chrome and Safari) add language-only fallback tags in Accept-Language—for example, en-US,en;q=0.9,zh-CN;q=0.8,zh;q=0.7 when navigator.languages is ["en-US", "zh-CN"].
    /// For privacy purposes (reducing fingerprinting), both Accept-Language and navigator.languages may not include the full list of user preferences,
    /// such as in Safari (always) and Chrome's incognito mode, where only one language is listed.
    /// </para>
    /// </summary>
    public ValueTask<string[]> Languages => GetLanguages(default);

    /// <inheritdoc cref="Languages" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string[]> GetLanguages(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string[]>("NavigatorAPI.getLanguages", cancellationToken);


    /// <summary>
    /// <para>Returns the user agent string for the current browser.</para>
    /// <para>
    /// Browser identification based on detecting the user agent string is unreliable and is not recommended, as the user agent string is user configurable. For example:<br />
    /// - In Firefox, you can change the preference general.useragent.override in about:config.
    /// Some Firefox extensions do that; however, this only changes the HTTP header that gets sent and that is returned by navigator.userAgent.
    /// There might be other methods that utilize JavaScript code to identify the browser.<br />
    /// - Opera 6+ allows users to set the browser identification string via a menu.
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Note:
    /// The specification asks browsers to provide as little information via this field as possible.
    /// Never assume that the value of this property will stay the same in future versions of the same browser.
    /// Try not to use it at all, or only for current and past versions of a browser.
    /// New browsers may start using the same UA, or part of it, as an older browser:
    /// you really have no guarantee that the browser agent is indeed the one advertised by this property.<br />
    /// Also keep in mind that users of a browser can change the value of this field if they want (UA spoofing).
    /// </para>
    /// </remarks>
    public ValueTask<string> UserAgent => GetUserAgent(default);

    /// <inheritdoc cref="UserAgent" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetUserAgent(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<string>("NavigatorAPI.getUserAgent", cancellationToken);

    /// <summary>
    /// <para>Indicates whether the user agent is controlled by automation.</para>
    /// <para>It defines a standard way for co-operating user agents to inform the document that it is controlled by WebDriver, for example, so that alternate code paths can be triggered during automation.</para>
    /// <para>
    /// The navigator.webdriver property is true when in:<br />
    /// - Chrome: The --enable-automation or --headless flag is used, or the --remote-debugging-port flag specifying port 0 is used.<br />
    /// - Firefox: The marionette.enabled preference or --marionette flag is passed.
    /// </para>
    /// </summary>
    public ValueTask<bool> Webdriver => GetWebdriver(default);

    /// <inheritdoc cref="Webdriver" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetWebdriver(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("NavigatorAPI.getWebdriver", cancellationToken);


    /// <summary>
    /// <para>Indicates whether the current window has transient user activation (the user is currently interacting with the page.)</para>
    /// <para>
    /// This property is from the UserActivation interface that provides information about whether a user is currently interacting with the page,
    /// or has completed an interaction since page load.
    /// </para>
    /// </summary>
    public ValueTask<bool> UserActivationIsActive => GetUserActivationIsActive(default);

    /// <inheritdoc cref="UserActivationIsActive" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetUserActivationIsActive(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("NavigatorAPI.getUserActivationIsActive", cancellationToken);

    /// <summary>
    /// <para>Indicates whether the current window has sticky user activation (the user has interacted with the page since it was loaded.)</para>
    /// <para>
    /// This property is from the UserActivation interface that provides information about whether a user is currently interacting with the page,
    /// or has completed an interaction since page load.
    /// </para>
    /// </summary>
    public ValueTask<bool> UserActivationHasBeenActive => GetUserActivationHasBeenActive(default);

    /// <inheritdoc cref="UserActivationHasBeenActive" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetUserActivationHasBeenActive(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("NavigatorAPI.getUserActivationHasBeenActive", cancellationToken);


    /// <summary>
    /// Indicates whether cookies are enabled or not.
    /// </summary>
    /// <remarks>
    /// Note:
    /// Web browsers may prevent writing certain cookies in certain scenarios.
    /// For example, Chrome-based browsers, as well as some experimental version of Firefox, does not allow creating cookies with SameSite=None attribute,
    /// unless they are created over HTTPS and with Secure attribute.
    /// </remarks>
    public ValueTask<bool> CookieEnabled => GetCookieEnabled(default);

    /// <inheritdoc cref="CookieEnabled" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetCookieEnabled(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("NavigatorAPI.getCookieEnabled", cancellationToken);

    /// <summary>
    /// <para>Indicates whether the browser supports inline display of PDF files when navigating to them.</para>
    /// <para>If inline viewing is not supported the PDF is downloaded and may then be handled by some external application.</para>
    /// </summary>
    /// <remarks>Note: This method replaces a number of legacy methods of inferring support for inline viewing of PDF files.</remarks>
    public ValueTask<bool> PdfViewerEnabled => GetPdfViewerEnabled(default);

    /// <inheritdoc cref="PdfViewerEnabled" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetPdfViewerEnabled(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<bool>("NavigatorAPI.getPdfViewerEnabled", cancellationToken);


    /// <summary>
    /// Returns the maximum number of simultaneous touch contact points that are supported by the current device.
    /// </summary>
    public ValueTask<int> MaxTouchPoints => GetMaxTouchPoints(default);

    /// <inheritdoc cref="MaxTouchPoints" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetMaxTouchPoints(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("NavigatorAPI.getMaxTouchPoints", cancellationToken);

    /// <summary>
    /// <para>Returns the number of logical processors available to run threads on the user's computer.</para>
    /// <para>The number is between 1 and the number of logical processors potentially available to the user agent.</para>
    /// <para>
    /// Modern computers have multiple physical processor cores in their CPU (two or four cores is typical),
    /// but each physical core is also usually able to run more than one thread at a time using advanced scheduling techniques.
    /// So a four-core CPU may offer eight logical processor cores, for example.
    /// The number of logical processor cores can be used to measure the number of threads which can effectively be run at once without them having to context switch.
    /// </para>
    /// <para>
    /// The browser may, however, choose to report a lower number of logical cores in order to represent more accurately the number of Workers that can run at once,
    /// so don't treat this as an absolute measurement of the number of cores in the user's system.
    /// </para>
    /// </summary>
    public ValueTask<int> HardwareConcurrency => GetHardwareConcurrency(default);

    /// <inheritdoc cref="HardwareConcurrency" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int> GetHardwareConcurrency(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<int>("NavigatorAPI.getHardwareConcurrency", cancellationToken);

    /// <summary>
    /// <para>Returns the approximate amount of device memory in gigabytes.</para>
    /// <para>
    /// The reported value is imprecise to curtail fingerprinting.
    /// It's approximated by rounding down to the nearest power of 2, then dividing that number by 1024.
    /// It is then clamped within lower and upper bounds to protect the privacy of owners of very low-memory or high-memory devices.
    /// </para>
    /// <para>
    /// The value is one of:<br />
    /// - 0.25<br />
    /// - 0.5<br />
    /// - 1.0<br />
    /// - 2.0<br />
    /// - 4.0<br />
    /// - 8.0
    /// </para>
    /// </summary>
    public ValueTask<double> DeviceMemory => GetDeviceMemory(default);

    /// <inheritdoc cref="DeviceMemory" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetDeviceMemory(CancellationToken cancellationToken) => moduleManager.InvokeTrySync<double>("NavigatorAPI.getDeviceMemory", cancellationToken);



    /// <summary>
    /// <para>Returns true if the equivalent call to <see cref="Share"/> would succeed.</para>
    /// <para>
    /// The method returns false if the data cannot be validated. Reasons the data might be invalid include:<br />
    /// - The data parameter has been omitted or only contains properties with unknown values. Note that any properties that are not recognized by the user agent are ignored.<br/>
    /// - A URL is badly formatted.<br />
    /// - Files are specified but the implementation does not support file sharing.<br />
    /// - Sharing the specified data would be considered a "hostile share" by the user-agent.
    /// </para>
    /// <para>The Web Share API is gated by the web-share permission policy. The canShare() method will return false if the permission is supported but has not been granted.</para>
    /// </summary>
    /// <param name="url">Representing a URL to be shared.</param>
    /// <param name="text">Representing text to be shared.</param>
    /// <param name="title">Representing the title to be shared.</param>
    /// <param name="files">Representing files to be shared.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> CanShare(string? url = null, string? text = null, string? title = null, IFile[]? files = null, CancellationToken cancellationToken = default) {
        IJSObjectReference[]? filesJS = null;
        if (files is not null) {
            filesJS = new IJSObjectReference[files.Length];
            for (int i = 0; i < filesJS.Length; i++)
                filesJS[i] = files[i].FileJS;
        }

        return moduleManager.InvokeTrySync<bool>("NavigatorAPI.canShare", cancellationToken, [url, text, title, filesJS]);
    }

    /// <summary>
    /// <para>
    /// Invokes the native sharing mechanism of the device to share data such as text, URLs, or files.
    /// The available share targets depend on the device, but might include the clipboard, contacts and email applications, websites, Bluetooth, etc.
    /// </para>
    /// <para>
    /// The method resolves a Promise with undefined.
    /// On Windows this happens when the share popup is launched, while on Android the promise resolves once the data has successfully been passed to the share target.
    /// </para>
    /// <para>The Web Share API is gated by the web-share permission policy. The share() method will throw exceptions if the permission is supported but has not been granted.</para>
    /// </summary>
    /// <param name="url">Representing a URL to be shared.</param>
    /// <param name="text">Representing text to be shared.</param>
    /// <param name="title">Representing a title to be shared. May be ignored by the target.</param>
    /// <param name="files">Representing files to be shared. See <see href="https://developer.mozilla.org/en-US/docs/Web/API/Navigator/share#shareable_file_types">below for shareable file types</see>.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Share(string? url = null, string? text = null, string? title = null, IFile[]? files = null, CancellationToken cancellationToken = default) {
        IJSObjectReference[]? filesJS = null;
        if (files is not null) {
            filesJS = new IJSObjectReference[files.Length];
            for (int i = 0; i < filesJS.Length; i++)
                filesJS[i] = files[i].FileJS;
        }

        return moduleManager.InvokeAsync("NavigatorAPI.share", cancellationToken, [url, text, title, filesJS]);
    }


    /// <summary>
    /// <para>Lets websites register their ability to open or handle particular URL schemes (also known as protocols).</para>
    /// <para>For example, this API lets webmail sites open mailto: URLs, or VoIP sites open tel: URLs.</para>
    /// <para>To register a protocol handler, a website calls <i>registerProtocolHandler()</i>, passing in the protocol to register and a template URL.</para>
    /// <para>
    /// When the user activates a link that uses the registered protocol,
    /// the browser will insert the href from the activated link into the URL template supplied during handler registration,
    /// and navigate the current page to the resulting URL.
    /// </para>
    /// <para>The browser may ask the user to confirm that they want the page to be allowed to handle the protocol, either when the protocol is registered or when the user activates the link.</para>
    /// </summary>
    /// <param name="scheme">
    /// <para>Contains the scheme for the protocol that the site wishes to handle.</para>
    /// <para>
    /// This may be a custom scheme, in which case the scheme's name:<br />
    /// - Begins with web+<br />
    /// - Contains at least one letter after the web+ prefix<br />
    /// - Contains only lowercase ASCII letters.
    /// </para>
    /// <para>
    /// Otherwise, the scheme must be one of the following:<br />
    /// "bitcoin", "ftp", "ftps", "geo", "im", "irc", "ircs", "magnet", "mailto", "matrix", "mms", "news", "nntp", "openpgp4fpr", "sftp", "sip", "sms", "smsto", "ssh", "tel", "urn", "webcal", "wtai", "xmpp"
    /// </para>
    /// </param>
    /// <param name="url">
    /// <para>Contains the URL of the handler. This URL must include %s, as a placeholder that will be replaced with the escaped URL to be handled.</para>
    /// <para>The handler URL must use the https scheme, and must be of the same origin as the webpage that is attempting to register the handler.</para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask RegisterProtocolHandler(string scheme, string url, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("NavigatorAPI.registerProtocolHandler", cancellationToken, [scheme, url]);

    /// <summary>
    /// <para>Removes a protocol handler for a given URL scheme.</para>
    /// <para>This method is the inverse of <see cref="RegisterProtocolHandler"/>.</para>
    /// </summary>
    /// <param name="scheme">Contains the permitted scheme in the protocol handler that will be unregistered. For example, you can unregister the handler for SMS text message links by passing the "sms" scheme.</param>
    /// <param name="url">Contains the URL of the handler. This URL should match the one that was used to register the handler (e.g., it must include %s).</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask UnregisterProtocolHandler(string scheme, string url, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync("NavigatorAPI.unregisterProtocolHandler", cancellationToken, [scheme, url]);


    /// <summary>
    /// <para>Asynchronously sends an HTTP POST request containing a small amount of data to a web server.</para>
    /// <para>It's intended to be used for sending analytics data to a web server, and avoids some of the problems with legacy techniques for sending analytics, such as the use of XMLHttpRequest.</para>
    /// </summary>
    /// <remarks>
    /// Note: For use cases that need the ability to send requests with methods other than POST, or to change any request properties, or that need access to the server response,
    /// instead use the <see cref="IWindow.Fetch"/> method with <i>keepalive</i> set to true.
    /// </remarks>
    /// <param name="url">The URL that will receive the data. Can be relative or absolute.</param>
    /// <param name="data">Contais the data to send.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> SendBeacon(string url, string? data = null, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync<bool>("NavigatorAPI.sendBeacon_String", cancellationToken, [url, data]);

    /// <inheritdoc cref="SendBeacon(string, string?, CancellationToken)" />
    public ValueTask<bool> SendBeacon(string url, byte[] data, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync<bool>("NavigatorAPI.sendBeacon_Bytes", cancellationToken, [url, data]);

    /// <summary>
    /// <para>
    /// Pulses the vibration hardware on the device, if such hardware exists.
    /// If the device doesn't support vibration, this method has no effect.
    /// If a vibration pattern is already in progress when this method is called, the previous pattern is halted and the new one begins instead.<br />
    /// Passing an empty array or an array containing all zeros will cancel any currently ongoing vibration pattern.
    /// </para>
    /// <para>
    /// If the method was unable to vibrate because of invalid parameters, it will return false, else it returns true.
    /// If the pattern leads to a too long vibration, it is truncated: the max length depends on the implementation.
    /// </para>
    /// <para>
    /// Some devices may not vibrate if they are in Silent mode or Do Not Disturb (DND) mode.
    /// To ensure vibration works, make sure these modes are turned off and that vibration is enabled in the system settings.
    /// </para>
    /// </summary>
    /// <param name="pattern">
    /// Provides a pattern of vibration and pause intervals.
    /// Each value indicates a number of milliseconds to vibrate or pause, in alternation.
    /// You may provide either a single value (to vibrate once for that many milliseconds) or an array of values to alternately vibrate, pause, then vibrate again.
    /// See <see href="https://developer.mozilla.org/en-US/docs/Web/API/Vibration_API">Vibration API</see> for details.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> Vibrate(int[] pattern, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync<bool>("NavigatorAPI.vibrate", cancellationToken, [pattern]);


    /// <summary>
    /// <para>Provides information about whether autoplay of media elements and audio contexts is allowed, disallowed, or only allowed if the audio is muted.</para>
    /// <para>
    /// Applications can use this information to provide an appropriate user experience.
    /// For example, if the user agent policy only allows autoplay of inaudible content, the application might mute videos so that they can still autoplay.
    /// </para>
    /// <para>The method can be used to get either the broad autoplay policy for all items of a particular type in the document, or for specific media elements or audio contexts.</para>
    /// <para>
    /// The return value contains one of the following values:<br />
    /// - "allowed": Autoplay is allowed.<br />
    /// - "allowed-muted": Autoplay is allowed only for inaudible media. This includes media that has no audio track, or for which the audio has been muted.<br />
    /// - "disallowed": Autoplay is not allowed.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Note that the autoplay policy returned for a type parameter is the broad policy for items of the indicated type.
    /// On page load, all items of a type will have the same policy as the type.
    /// Once the user has interacted with the page/site, on some browsers individual items may have a different policy to the corresponding type.
    /// </remarks>
    /// <param name="type">
    /// <para>Indicating the media playing feature for which the broad autoplay policy is required.</para>
    /// <para>
    /// The supported values are:<br />
    /// - "mediaelement": Get the broad autoplay policy for media elements in the document. Media elements are HTMLMediaElement derived objects such as HTMLAudioElement and HTMLVideoElement, and their corresponding tags &lt;audio&gt; and &lt;video&gt;.<br />
    /// - "audiocontext": Get the broad autoplay policy for <see href="https://developer.mozilla.org/en-US/docs/Web/API/Web_Audio_API">Web Audio API</see> players in the document.
    /// </para>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetAutoplayPolicy(string type, CancellationToken cancellationToken = default) => moduleManager.InvokeTrySync<string>("NavigatorAPI.getAutoplayPolicy_String", cancellationToken, [type]);

    /// <inheritdoc cref="GetAutoplayPolicy(string, CancellationToken)" />
    /// <param name="element">A specific media element.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<string> GetAutoplayPolicy(IHTMLMediaElement element, CancellationToken cancellationToken = default) => await moduleManager.InvokeTrySync<string>("NavigatorAPI.getAutoplayPolicy_Element", cancellationToken, [await element.HTMLMediaElementTask]);
}

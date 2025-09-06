using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "INavigator")]
[AutoInterface(Namespace = "BrowserAPI", Name = "INavigatorInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class NavigatorBase(IModuleManager moduleManager) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;


    /// <summary>
    /// Sets a badge on the icon associated with this app.
    /// If a value is passed to the method, this will be set as the value of the badge.
    /// Otherwise the badge will display as a dot, or other indicator as defined by the platform.
    /// </summary>
    /// <param name="contents">A number which will be used as the value of the badge. If contents is 0 then the badge will be set to nothing, indicating a cleared badge.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask SetAppBadge(int? contents = null, CancellationToken cancellationToken = default) => moduleManager.InvokeAsync("NavigatorAPI.setAppBadge", cancellationToken, [contents]);

    /// <summary>
    /// Clears a badge on the current app's icon by setting it to nothing.
    /// The value nothing indicates that no badge is currently set, and the status of the badge is cleared.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask ClearAppBadge(CancellationToken cancellationToken = default) => moduleManager.InvokeAsync("NavigatorAPI.clearAppBadge", cancellationToken);


    /// <summary>
    /// <para>
    /// Returns a promise that resolves with an array of objects representing any related platform-specific apps or Progressive Web Apps that the user has installed.
    /// This could be used for content personalization such as removing "install our app" banners from the web app if the platform-specific app and/or PWA is already installed.
    /// </para>
    /// <para>It can be used to check for the installation of Universal Windows Platform (UWP) apps, Android apps, and PWAs that are related to the web app calling this method.</para>
    /// <para>
    /// To associate the invoking web app with a platform-specific app or PWA, two things must be done:<br />
    /// 1. The invoking web app must be specified in the <see href="https://developer.mozilla.org/en-US/docs/Web/Progressive_web_apps/Manifest/Reference/related_applications">related_applications</see> member
    /// of its <see href="https://developer.mozilla.org/en-US/docs/Web/Progressive_web_apps/Manifest">manifest file</see>.<br />
    /// 2. The platform-specific app or PWA must have its relationship with the invoking app defined.
    /// </para>
    /// <para>
    /// Defining the relationship is done in a different way depending on the type of app:<br />
    /// - An Android app does this via the <see href="https://developers.google.com/digital-asset-links/v1/getting-started">Digital Asset Links system</see>.<br />
    /// - A Windows UWP app does this via <see href="https://learn.microsoft.com/en-us/windows/apps/develop/launch/web-to-app-linking">URI Handlers</see>.<br />
    /// - A PWA does this via:<br />
    /// --- A self-defining entry inside its own <i>related_applications</i> manifest member in the case of a PWA checking if it is installed on the underlying platform.<br />
    /// --- An assetlinks.json file in its <see href="https://datatracker.ietf.org/doc/html/rfc5785">/.well-known/</see> directory in the case of an app outside the scope of the PWA checking whether it is installed.
    /// </para>
    /// </summary>
    /// <remarks>Note: This method must be invoked in a top-level secure context, that is, not embedded in an &lt;iframe&gt;.</remarks>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<InstalledRelatedApps[]> GetInstalledRelatedApps(CancellationToken cancellationToken = default) => moduleManager.InvokeAsync<InstalledRelatedApps[]>("NavigatorAPI.getInstalledRelatedApps", cancellationToken);
}

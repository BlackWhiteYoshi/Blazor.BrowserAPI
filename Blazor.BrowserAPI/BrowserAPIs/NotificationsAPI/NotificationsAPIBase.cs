using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "INotificationsAPI")]
[AutoInterface(Namespace = "BrowserAPI", Name = "INotificationsAPIInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class NotificationsAPIBase(IModuleManager moduleManager) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;


    /// <summary>
    /// <para>Requests permission from the user to display notifications.</para>
    /// <para>
    /// Possible values for this string are:<br/>
    /// - "granted": The user has explicitly granted permission for the current origin to display system notifications.<br/>
    /// - "denied": The user has explicitly denied permission for the current origin to display system notifications.<br/>
    /// - "default": The user decision is unknown; in this case the application will act as if permission was denied.
    /// </para>
    /// </summary>
    /// <returns>"granted" | "denied" | "default"</returns>
    public async ValueTask<string> RequestPermission(CancellationToken cancellationToken = default) => await moduleManager.InvokeAsync<string>("NotificationsAPI.requestPermission", cancellationToken);
}

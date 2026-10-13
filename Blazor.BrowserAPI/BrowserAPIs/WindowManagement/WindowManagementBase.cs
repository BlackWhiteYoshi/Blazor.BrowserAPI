using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// Base interface of <see cref="IWindowManagement"/> and <see cref="IWindowManagementInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class WindowManagementBase<TJSObjectReference, TScreenDetails>(IModuleManager moduleManager)
    where TJSObjectReference : IJSObjectReference
    where TScreenDetails : IScreenDetailsBase<TJSObjectReference> {
    private protected IModuleManager moduleManager = moduleManager;


    /// <summary>
    /// The <i>getScreenDetails()</i> method of the Window interface returns a Promise that fulfills with a ScreenDetails object instance representing the details of all the screens available to the user's device.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TScreenDetails> GetScreenDetails(CancellationToken cancellationToken = default) {
        TJSObjectReference screenDetailsJS = await moduleManager.InvokeAsync<TJSObjectReference>("WindowManagementAPI.getScreenDetails", cancellationToken);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TScreenDetails)(IScreenDetails)new ScreenDetails(screenDetailsJS);
        else
            return (TScreenDetails)(IScreenDetailsInProcess)new ScreenDetailsInProcess((IJSInProcessObjectReference)screenDetailsJS);
    }
}

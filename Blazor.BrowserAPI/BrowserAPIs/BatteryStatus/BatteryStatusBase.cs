using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IBatteryStatus"/> and <see cref="IBatteryStatusInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <typeparam name="TBatteryManager"></typeparam>
/// <param name="moduleManager"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class BatteryStatusBase<TJSObjectReference, TBatteryManager>(IModuleManager moduleManager)
    where TJSObjectReference : IJSObjectReference
    where TBatteryManager : IBatteryManagerBase<TJSObjectReference> {
    private protected IModuleManager moduleManager = moduleManager;


    /// <summary>
    /// Provides information about the system's battery.
    /// It returns a battery promise, which resolves with a BatteryManager object providing some properties to get the battery status also some events you can handle to monitor the battery status.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>Each method call produces a new instance that should be disposed when you are done with it.</remarks>
    public async ValueTask<TBatteryManager> GetBattery(CancellationToken cancellationToken = default) {
        TJSObjectReference batteryManagerJS = await moduleManager.InvokeAsync<TJSObjectReference>("BatteryStatusAPI.getBattery", cancellationToken);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TBatteryManager)(IBatteryManager)new BatteryManager(batteryManagerJS);
        else
            return (TBatteryManager)(IBatteryManagerInProcess)new BatteryManagerInProcess((IJSInProcessObjectReference)batteryManagerJS);
    }
}

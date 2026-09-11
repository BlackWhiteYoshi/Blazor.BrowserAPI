using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>Battery Status API</i>, more often referred to as the Battery API, provides information about the system's battery charge level
/// and lets you be notified by events that are sent when the battery level or charging status change.
/// This can be used to adjust your app's resource usage to reduce battery drain when the battery is low, or to save changes before the battery runs out in order to prevent data loss.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class BatteryStatusInProcess(IModuleManager moduleManager) : IBatteryStatusInProcess {
    /// <summary>
    /// Provides information about the system's battery.
    /// It returns a battery promise, which resolves with a BatteryManager object providing some properties to get the battery status also some events you can handle to monitor the battery status.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <remarks>Each method call produces a new instance that should be disposed when you are done with it.</remarks>
    public async ValueTask<IBatteryManagerInProcess> GetBattery(CancellationToken cancellationToken = default) {
        IJSInProcessObjectReference batteryManagerJS = await moduleManager.InvokeAsync<IJSInProcessObjectReference>("BatteryStatusAPI.getBattery", cancellationToken);
        return new BatteryManagerInProcess(batteryManagerJS);
    }

}

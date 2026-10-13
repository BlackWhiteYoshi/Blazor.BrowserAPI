using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>Battery Status API</i>, more often referred to as the Battery API, provides information about the system's battery charge level
/// and lets you be notified by events that are sent when the battery level or charging status change.
/// This can be used to adjust your app's resource usage to reduce battery drain when the battery is low, or to save changes before the battery runs out in order to prevent data loss.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IBatteryStatusBase<IJSObjectReference, IBatteryManager>)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class BatteryStatus(IModuleManager moduleManager) : BatteryStatusBase<IJSObjectReference, IBatteryManager>(moduleManager), IBatteryStatus;

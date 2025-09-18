using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "ISensorAPI")]
[AutoInterface(Namespace = "BrowserAPI", Name = "ISensorAPIInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class SensorAPIBase(IModuleManager moduleManager) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;


    #region Events

    [method: DynamicDependency(nameof(InvokeDeviceMotion))]
    [method: DynamicDependency(nameof(InvokeDeviceOrientation))]
    [method: DynamicDependency(nameof(InvokeDeviceOrientationAbsolute))]
    private sealed class EventTrigger(SensorAPIBase sensorAPI) {
        [JSInvokable] public void InvokeDeviceMotion(DeviceMotionEvent deviceMotionEvent) => sensorAPI._onDeviceMotion?.Invoke(deviceMotionEvent);
        [JSInvokable] public void InvokeDeviceOrientation(DeviceOrientationEvent deviceOrientationEvent) => sensorAPI._onDeviceOrientation?.Invoke(deviceOrientationEvent);
        [JSInvokable] public void InvokeDeviceOrientationAbsolute(DeviceOrientationEvent deviceOrientationEvent) => sensorAPI._onDeviceOrientationAbsolute?.Invoke(deviceOrientationEvent);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return moduleManager.InvokeTrySync("SensorAPI.initEventsWindow", default, [_objectReferenceEventTrigger]);
    }


    private protected async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await moduleManager.InvokeTrySync(jsMethodName, default);
    }

    private protected ValueTask DeactivateJSEvent(string jsMethodName) => moduleManager.InvokeTrySync(jsMethodName, default);


    private Action<DeviceMotionEvent>? _onDeviceMotion;
    /// <summary>
    /// <para>
    /// Is fired at a regular interval and indicates the acceleration rate of the device with/without the contribution of the gravity force at that time.
    /// It also provides information about the rate of rotation, if available.
    /// </para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action<DeviceMotionEvent> OnDeviceMotion {
        add {
            if (_onDeviceMotion == null)
                _ = ActivateJSEvent("SensorAPI.activateOndevicemotion").Preserve();
            _onDeviceMotion += value;
        }
        remove {
            _onDeviceMotion -= value;
            if (_onDeviceMotion == null)
                _ = DeactivateJSEvent("SensorAPI.deactivateOndevicemotion").Preserve();
        }
    }

    private Action<DeviceOrientationEvent>? _onDeviceOrientation;
    /// <summary>
    /// <para>
    /// Is fired when fresh data is available from an orientation sensor about the current orientation of the device as compared to the Earth coordinate frame.
    /// This data is gathered from a magnetometer inside the device.
    /// </para>
    /// <para>See <see href="https://developer.mozilla.org/en-US/docs/Web/API/Device_orientation_events/Orientation_and_motion_data_explained">Orientation and motion data explained</see> for details.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action<DeviceOrientationEvent> OnDeviceOrientation {
        add {
            if (_onDeviceOrientation == null)
                _ = ActivateJSEvent("SensorAPI.activateOndeviceorientation").Preserve();
            _onDeviceOrientation += value;
        }
        remove {
            _onDeviceOrientation -= value;
            if (_onDeviceOrientation == null)
                _ = DeactivateJSEvent("SensorAPI.deactivateOndeviceorientation").Preserve();
        }
    }

    private Action<DeviceOrientationEvent>? _onDeviceOrientationAbsolute;
    /// <summary>
    /// <para>Is fired when absolute device orientation changes.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action<DeviceOrientationEvent> OnDeviceOrientationAbsolute {
        add {
            if (_onDeviceOrientationAbsolute == null)
                _ = ActivateJSEvent("SensorAPI.activateOndeviceorientationabsolute").Preserve();
            _onDeviceOrientationAbsolute += value;
        }
        remove {
            _onDeviceOrientationAbsolute -= value;
            if (_onDeviceOrientationAbsolute == null)
                _ = DeactivateJSEvent("SensorAPI.deactivateOndeviceorientationabsolute").Preserve();
        }
    }

    #endregion
}

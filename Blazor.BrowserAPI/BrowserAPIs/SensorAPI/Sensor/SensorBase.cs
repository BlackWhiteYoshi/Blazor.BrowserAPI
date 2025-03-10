﻿using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "ISensor")]
[AutoInterface(Namespace = "BrowserAPI", Name = "ISensorInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class SensorBase {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected abstract IJSObjectReference SensorJS { get; }


    #region Events

    [method: DynamicDependency(nameof(InvokeError))]
    [method: DynamicDependency(nameof(InvokeActivate))]
    [method: DynamicDependency(nameof(InvokeReading))]
    private sealed class EventTrigger(SensorBase sensor) {
        [JSInvokable] public void InvokeError(object message) => sensor._onError?.Invoke(message.ToString()!);
        [JSInvokable] public void InvokeActivate() => sensor._onActivate?.Invoke();
        [JSInvokable] public void InvokeReading() => sensor._onReading?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return SensorJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger, SensorJS is IJSInProcessObjectReference]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await SensorJS.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => SensorJS.InvokeVoidTrySync(jsMethodName);


    private Action<string>? _onError;
    /// <summary>
    /// <para>
    /// The error event is fired when an exception occurs on a sensor.
    /// After this event has occurred, the Sensor object becomes idle. If the sensor was reading values, it will stop until it restarts.
    /// </para>
    /// <para>Parameter is of type <see href="https://developer.mozilla.org/en-US/docs/Web/API/Event">Event</see> as JSON.</para>
    /// </summary>
    public event Action<string> OnError {
        add {
            if (_onError == null)
                _ = ActivateJSEvent("activateOnerror").Preserve();
            _onError += value;
        }
        remove {
            _onError -= value;
            if (_onError == null)
                _ = DeactivateJSEvent("deactivateOnerror").Preserve();
        }
    }

    private Action? _onActivate;
    /// <summary>
    /// The activate event is fired when a sensor becomes activated. It means that it will start obtaining readings.
    /// </summary>
    public event Action OnActivate {
        add {
            if (_onActivate == null)
                _ = ActivateJSEvent("activateOnactivate").Preserve();
            _onActivate += value;
        }
        remove {
            _onActivate -= value;
            if (_onActivate == null)
                _ = DeactivateJSEvent("deactivateOnactivate").Preserve();
        }
    }

    private Action? _onReading;
    /// <summary>
    /// The reading event is fired when a new reading is available on a sensor.
    /// </summary>
    public event Action OnReading {
        add {
            if (_onReading == null)
                _ = ActivateJSEvent("activateOnreading").Preserve();
            _onReading += value;
        }
        remove {
            _onReading -= value;
            if (_onReading == null)
                _ = DeactivateJSEvent("deactivateOnreading").Preserve();
        }
    }

    #endregion
}

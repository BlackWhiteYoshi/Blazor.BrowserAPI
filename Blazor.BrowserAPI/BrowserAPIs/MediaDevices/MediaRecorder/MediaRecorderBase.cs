using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IMediaRecorder")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IMediaRecorderInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class MediaRecorderBase(IJSObjectReference mediaRecorderJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference mediaRecorderJS = mediaRecorderJS;

    
    #region Events

    [method: DynamicDependency(nameof(InvokeDataavailable))]
    [method: DynamicDependency(nameof(InvokeError))]
    [method: DynamicDependency(nameof(InvokeStart))]
    [method: DynamicDependency(nameof(InvokeStop))]
    [method: DynamicDependency(nameof(InvokeResume))]
    [method: DynamicDependency(nameof(InvokePause))]
    private sealed class EventTrigger(MediaRecorderBase mediaRecorder) {
        [JSInvokable] public void InvokeDataavailable(byte[] data) => mediaRecorder._onDataavailable?.Invoke(data);
        [JSInvokable] public void InvokeError(JsonElement errorEvent) => mediaRecorder._onError?.Invoke(errorEvent);
        [JSInvokable] public void InvokeStart() => mediaRecorder._onStart?.Invoke();
        [JSInvokable] public void InvokeStop() => mediaRecorder._onStop?.Invoke();
        [JSInvokable] public void InvokeResume() => mediaRecorder._onResume?.Invoke();
        [JSInvokable] public void InvokePause() => mediaRecorder._onPause?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return mediaRecorderJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger, mediaRecorderJS is IJSInProcessObjectReference]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await mediaRecorderJS.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => mediaRecorderJS.InvokeVoidTrySync(jsMethodName);


    private Action<byte[]>? _onDataavailable;
    /// <summary>
    /// <para>
    /// Fires periodically each time timeslice milliseconds of media have been recorded (or when the entire media has been recorded, if timeslice wasn't specified).
    /// The event, of type BlobEvent, contains the recorded media in its data property.
    /// </para>
    /// <para>Parameter is the recorded binary data.</para>
    /// </summary>
    public event Action<byte[]> OnDataavailable {
        add {
            if (_onDataavailable == null)
                _ = ActivateJSEvent("activateOndataavailable").Preserve();
            _onDataavailable += value;
        }
        remove {
            _onDataavailable -= value;
            if (_onDataavailable == null)
                _ = DeactivateJSEvent("deactivateOndataavailable").Preserve();
        }
    }

    private Action<JsonElement>? _onError;
    /// <summary>
    /// <para>
    /// Fired when there are fatal errors that stop recording.
    /// The received event is based on the MediaRecorderErrorEvent interface, whose error property contains a DOMException that describes the actual error that occurred.
    /// </para>
    /// <para>Parameter is of type <see href="https://developer.mozilla.org/en-US/docs/Web/API/Event">Event</see> as JSON.</para>
    /// </summary>
    public event Action<JsonElement> OnError {
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

    private Action? _onStart;
    /// <summary>
    /// Fired when media recording starts.
    /// </summary>
    public event Action OnStart {
        add {
            if (_onStart == null)
                _ = ActivateJSEvent("activateOnstart").Preserve();
            _onStart += value;
        }
        remove {
            _onStart -= value;
            if (_onStart == null)
                _ = DeactivateJSEvent("deactivateOnstart").Preserve();
        }
    }

    private Action? _onStop;
    /// <summary>
    /// Fired when media recording ends, either when the MediaStream ends, or after the MediaRecorder.stop() method is called.
    /// </summary>
    public event Action OnStop {
        add {
            if (_onStop == null)
                _ = ActivateJSEvent("activateOnstop").Preserve();
            _onStop += value;
        }
        remove {
            _onStop -= value;
            if (_onStop == null)
                _ = DeactivateJSEvent("deactivateOnstop").Preserve();
        }
    }

    private Action? _onResume;
    /// <summary>
    /// Fired when media recording resumes after being paused.
    /// </summary>
    public event Action OnResume {
        add {
            if (_onResume == null)
                _ = ActivateJSEvent("activateOnresume").Preserve();
            _onResume += value;
        }
        remove {
            _onResume -= value;
            if (_onResume == null)
                _ = DeactivateJSEvent("deactivateOnresume").Preserve();
        }
    }

    private Action? _onPause;
    /// <summary>
    /// Fired when media recording is paused.
    /// </summary>
    public event Action OnPause {
        add {
            if (_onPause == null)
                _ = ActivateJSEvent("activateOnpause").Preserve();
            _onPause += value;
        }
        remove {
            _onPause -= value;
            if (_onPause == null)
                _ = DeactivateJSEvent("deactivateOnpause").Preserve();
        }
    }

    #endregion
}

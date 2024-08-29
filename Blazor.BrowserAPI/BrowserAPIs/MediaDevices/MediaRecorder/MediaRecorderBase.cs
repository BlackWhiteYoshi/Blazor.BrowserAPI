using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IMediaRecorder")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IMediaRecorderInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class MediaRecorderBase {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected abstract IJSObjectReference MediaRecorderJS { get; }


    #region Events

    [method: DynamicDependency(nameof(InvokeDataavailable))]
    [method: DynamicDependency(nameof(InvokeError))]
    [method: DynamicDependency(nameof(InvokeStart))]
    [method: DynamicDependency(nameof(InvokeStop))]
    [method: DynamicDependency(nameof(InvokeResume))]
    [method: DynamicDependency(nameof(InvokePause))]
    private sealed class EventTrigger(MediaRecorderBase mediaRecorder) {
        [JSInvokable] public void InvokeDataavailable(byte[] data) => mediaRecorder._onDataavailable?.Invoke(data);
        [JSInvokable] public void InvokeError(object message) => mediaRecorder._onError?.Invoke(message.ToString()!);
        [JSInvokable] public void InvokeStart() => mediaRecorder._onStart?.Invoke();
        [JSInvokable] public void InvokeStop() => mediaRecorder._onStop?.Invoke();
        [JSInvokable] public void InvokeResume() => mediaRecorder._onResume?.Invoke();
        [JSInvokable] public void InvokePause() => mediaRecorder._onPause?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;
    private DotNetObjectReference<EventTrigger> ObjectReferenceEventTrigger => _objectReferenceEventTrigger ??= DotNetObjectReference.Create(new EventTrigger(this));

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


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
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("activateOndataavailable", [ObjectReferenceEventTrigger]));
            _onDataavailable += value;
        }
        remove {
            _onDataavailable -= value;
            if (_onDataavailable == null)
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("deactivateOndataavailable"));
        }
    }

    private Action<string>? _onError;
    /// <summary>
    /// <para>
    /// Fired when there are fatal errors that stop recording.
    /// The received event is based on the MediaRecorderErrorEvent interface, whose error property contains a DOMException that describes the actual error that occurred.
    /// </para>
    /// <para>Parameter is of type <see href="https://developer.mozilla.org/en-US/docs/Web/API/Event">Event</see> as JSON.</para>
    /// </summary>
    public event Action<string> OnError {
        add {
            if (_onError == null)
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("activateOnerror", [ObjectReferenceEventTrigger]));
            _onError += value;
        }
        remove {
            _onError -= value;
            if (_onError == null)
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("deactivateOnerror"));
        }
    }

    private Action? _onStart;
    /// <summary>
    /// Fired when media recording starts.
    /// </summary>
    public event Action OnStart {
        add {
            if (_onStart == null)
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("activateOnstart", [ObjectReferenceEventTrigger]));
            _onStart += value;
        }
        remove {
            _onStart -= value;
            if (_onStart == null)
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("deactivateOnstart"));
        }
    }

    private Action? _onStop;
    /// <summary>
    /// Fired when media recording ends, either when the MediaStream ends, or after the MediaRecorder.stop() method is called.
    /// </summary>
    public event Action OnStop {
        add {
            if (_onStop == null)
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("activateOnstop", [ObjectReferenceEventTrigger]));
            _onStop += value;
        }
        remove {
            _onStop -= value;
            if (_onStop == null)
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("deactivateOnstop"));
        }
    }

    private Action? _onResume;
    /// <summary>
    /// Fired when media recording resumes after being paused.
    /// </summary>
    public event Action OnResume {
        add {
            if (_onResume == null)
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("activateOnresume", [ObjectReferenceEventTrigger]));
            _onResume += value;
        }
        remove {
            _onResume -= value;
            if (_onResume == null)
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("deactivateOnresume"));
        }
    }

    private Action? _onPause;
    /// <summary>
    /// Fired when media recording is paused.
    /// </summary>
    public event Action OnPause {
        add {
            if (_onPause == null)
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("activateOnpause", [ObjectReferenceEventTrigger]));
            _onPause += value;
        }
        remove {
            _onPause -= value;
            if (_onPause == null)
                Task.Factory.StartNew(async () => await MediaRecorderJS.InvokeVoidTrySync("deactivateOnpause"));
        }
    }

    #endregion
}

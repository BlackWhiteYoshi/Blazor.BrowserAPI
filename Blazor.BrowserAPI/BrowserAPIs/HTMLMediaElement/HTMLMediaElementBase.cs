using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>Base class for <see cref="HTMLMediaElement"/> and <see cref="HTMLMediaElementInProcess"/>.</para>
/// <para>Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call <see cref="DisposeEventTrigger"/> there.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Name = "IHTMLMediaElement")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IHTMLMediaElementInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class HTMLMediaElementBase {
    private protected abstract Task<IJSObjectReference> HTMLMediaElementTask { get; }


    /// <summary>
    /// Attempts to begin playback of the media. It returns a Promise which is resolved when playback has been successfully started.<br />
    /// Failure to begin playback for any reason, such as permission issues, result in the promise being rejected.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Play(CancellationToken cancellationToken = default) => await (await HTMLMediaElementTask).InvokeVoidAsync("play", cancellationToken);


    #region Events

    // Ready
    [method: DynamicDependency(nameof(InvokeError))]
    [method: DynamicDependency(nameof(InvokeCanplay))]
    [method: DynamicDependency(nameof(InvokeCanplaythrough))]
    [method: DynamicDependency(nameof(InvokePlaying))]

    // Data
    [method: DynamicDependency(nameof(InvokeLoadstart))]
    [method: DynamicDependency(nameof(InvokeProgress))]
    [method: DynamicDependency(nameof(InvokeLoadeddata))]
    [method: DynamicDependency(nameof(InvokeLoadedmetadata))]
    [method: DynamicDependency(nameof(InvokeStalled))]
    [method: DynamicDependency(nameof(InvokeSuspend))]
    [method: DynamicDependency(nameof(InvokeWaiting))]
    [method: DynamicDependency(nameof(InvokeAbort))]
    [method: DynamicDependency(nameof(InvokeEmptied))]

    // Timing
    [method: DynamicDependency(nameof(InvokePlay))]
    [method: DynamicDependency(nameof(InvokePause))]
    [method: DynamicDependency(nameof(InvokeEnded))]
    [method: DynamicDependency(nameof(InvokeSeeking))]
    [method: DynamicDependency(nameof(InvokeSeeked))]
    [method: DynamicDependency(nameof(InvokeTimeupdate))]

    // Setting
    [method: DynamicDependency(nameof(InvokeVolumechange))]
    [method: DynamicDependency(nameof(InvokeRatechange))]
    [method: DynamicDependency(nameof(InvokeDurationchange))]
    private sealed class EventTrigger(HTMLMediaElementBase htmlMediaElement) {
        // Ready
        [JSInvokable] public void InvokeError(int code, string message) => htmlMediaElement._onError?.Invoke(code, message);
        [JSInvokable] public void InvokeCanplay() => htmlMediaElement._onCanplay?.Invoke();
        [JSInvokable] public void InvokeCanplaythrough() => htmlMediaElement._onCanplaythrough?.Invoke();
        [JSInvokable] public void InvokePlaying() => htmlMediaElement._onPlaying?.Invoke();

        // Data
        [JSInvokable] public void InvokeLoadstart() => htmlMediaElement._onLoadstart?.Invoke();
        [JSInvokable] public void InvokeProgress() => htmlMediaElement._onProgress?.Invoke();
        [JSInvokable] public void InvokeLoadeddata() => htmlMediaElement._onLoadeddata?.Invoke();
        [JSInvokable] public void InvokeLoadedmetadata() => htmlMediaElement._onLoadedmetadata?.Invoke();
        [JSInvokable] public void InvokeStalled() => htmlMediaElement._onStalled?.Invoke();
        [JSInvokable] public void InvokeSuspend() => htmlMediaElement._onSuspend?.Invoke();
        [JSInvokable] public void InvokeWaiting() => htmlMediaElement._onWaiting?.Invoke();
        [JSInvokable] public void InvokeAbort() => htmlMediaElement._onAbort?.Invoke();
        [JSInvokable] public void InvokeEmptied() => htmlMediaElement._onEmptied?.Invoke();

        // Timing
        [JSInvokable] public void InvokePlay() => htmlMediaElement._onPlay?.Invoke();
        [JSInvokable] public void InvokePause() => htmlMediaElement._onPause?.Invoke();
        [JSInvokable] public void InvokeEnded() => htmlMediaElement._onEnded?.Invoke();
        [JSInvokable] public void InvokeSeeking() => htmlMediaElement._onSeeking?.Invoke();
        [JSInvokable] public void InvokeSeeked() => htmlMediaElement._onSeeked?.Invoke();
        [JSInvokable] public void InvokeTimeupdate() => htmlMediaElement._onTimeupdate?.Invoke();

        // Setting
        [JSInvokable] public void InvokeVolumechange() => htmlMediaElement._onVolumechange?.Invoke();
        [JSInvokable] public void InvokeRatechange() => htmlMediaElement._onRatechange?.Invoke();
        [JSInvokable] public void InvokeDurationchange() => htmlMediaElement._onDurationchange?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;
    private DotNetObjectReference<EventTrigger> ObjectReferenceEventTrigger => _objectReferenceEventTrigger ??= DotNetObjectReference.Create(new EventTrigger(this));

    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    #region Ready Events

    private Action<int, string>? _onError;
    /// <summary>
    /// <para>Fired when the resource could not be loaded due to an error (for example, a network connectivity problem).</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// <para>
    /// If an error already occurred when subscribing (<see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLMediaElement/error">error</see> property is not empty), this event is fired immediately.<br />
    /// Note: When <see href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLMediaElement/error">error</see> is not empty, this event is fired with every subscription.
    /// </para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - int <i>code</i>:<br />
    /// A number which represents the general type of error that occurred.<br />
    /// Possible values are:<br />
    /// 1 = MEDIA_ERR_ABORTED: The fetching of the associated resource was aborted by the user's request.<br />
    /// 2 = MEDIA_ERR_NETWORK: Some kind of network error occurred which prevented the media from being successfully fetched, despite having previously been available.<br />
    /// 3 = MEDIA_ERR_DECODE: Despite having previously been determined to be usable, an error occurred while trying to decode the media resource, resulting in an error.<br />
    /// 4 = MEDIA_ERR_SRC_NOT_SUPPORTED: The associated resource or media provider object (such as a MediaStream) has been found to be unsuitable.<br />
    /// - string <i>message</i>:<br />
    /// A human-readable string which provides specific diagnostic information to help the reader understand the error condition which occurred;
    /// specifically, it isn't a summary of what the error code means, but actual diagnostic information to help in understanding what exactly went wrong.
    /// This text and its format is not defined by the specification and will vary from one user agent to another.
    /// If no diagnostics are available, or no explanation can be provided, this value is an empty string ("").
    /// </para>
    /// </summary>
    public event Action<int, string> OnError {
        add {
            if (_onError == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnerror", default, [ObjectReferenceEventTrigger]));
            _onError += value;
        }
        remove {
            _onError -= value;
            if (_onError == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnerror", default));
        }
    }

    private Action? _onCanplay;
    /// <summary>
    /// <para>Fired when the user agent can play the media, but estimates that not enough data has been loaded to play the media up to its end without having to stop for further buffering of content.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnCanplay {
        add {
            if (_onCanplay == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOncanplay", default, [ObjectReferenceEventTrigger]));
            _onCanplay += value;
        }
        remove {
            _onCanplay -= value;
            if (_onCanplay == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOncanplay", default));
        }
    }

    private Action? _onCanplaythrough;
    /// <summary>
    /// <para>Fired when the user agent can play the media, and estimates that enough data has been loaded to play the media up to its end without having to stop for further buffering of content.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnCanplaythrough {
        add {
            if (_onCanplaythrough == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOncanplaythrough", default, [ObjectReferenceEventTrigger]));
            _onCanplaythrough += value;
        }
        remove {
            _onCanplaythrough -= value;
            if (_onCanplaythrough == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOncanplaythrough", default));
        }
    }

    private Action? _onPlaying;
    /// <summary>
    /// <para>Fired after playback is first started, and whenever it is restarted. For example it is fired when playback resumes after having been paused or delayed due to lack of data.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnPlaying {
        add {
            if (_onPlaying == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnplaying", default, [ObjectReferenceEventTrigger]));
            _onPlaying += value;
        }
        remove {
            _onPlaying -= value;
            if (_onPlaying == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnplaying", default));
        }
    }

    #endregion


    #region Data Events

    private Action? _onLoadstart;
    /// <summary>
    /// Fired when the browser has started to load a resource.
    /// </summary>
    public event Action OnLoadstart {
        add {
            if (_onLoadstart == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnloadstart", default, [ObjectReferenceEventTrigger]));
            _onLoadstart += value;
        }
        remove {
            _onLoadstart -= value;
            if (_onLoadstart == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnloadstart", default));
        }
    }

    private Action? _onProgress;
    /// <summary>
    /// <para>Fired periodically as the browser loads a resource.></para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnProgress {
        add {
            if (_onProgress == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnprogress", default, [ObjectReferenceEventTrigger]));
            _onProgress += value;
        }
        remove {
            _onProgress -= value;
            if (_onProgress == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnprogress", default));
        }
    }

    private Action? _onLoadeddata;
    /// <summary>
    /// Fired when the first frame of the media has finished loading; often the first frame.
    /// </summary>
    public event Action OnLoadeddata {
        add {
            if (_onLoadeddata == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnloadeddata", default, [ObjectReferenceEventTrigger]));
            _onLoadeddata += value;
        }
        remove {
            _onLoadeddata -= value;
            if (_onLoadeddata == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnloadeddata", default));
        }
    }

    private Action? _onLoadedmetadata;
    /// <summary>
    /// Fired when the metadata has been loaded.
    /// </summary>
    public event Action OnLoadedmetadata {
        add {
            if (_onLoadedmetadata == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnloadedmetadata", default, [ObjectReferenceEventTrigger]));
            _onLoadedmetadata += value;
        }
        remove {
            _onLoadedmetadata -= value;
            if (_onLoadedmetadata == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnloadedmetadata", default));
        }
    }

    private Action? _onStalled;
    /// <summary>
    /// <para>Fired when the user agent is trying to fetch media data, but data is unexpectedly not forthcoming.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnStalled {
        add {
            if (_onStalled == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnstalled", default, [ObjectReferenceEventTrigger]));
            _onStalled += value;
        }
        remove {
            _onStalled -= value;
            if (_onStalled == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnstalled", default));
        }
    }

    private Action? _onSuspend;
    /// <summary>
    /// <para>Fired when the media data loading has been suspended.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnSuspend {
        add {
            if (_onSuspend == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnsuspend", default, [ObjectReferenceEventTrigger]));
            _onSuspend += value;
        }
        remove {
            _onSuspend -= value;
            if (_onSuspend == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnsuspend", default));
        }
    }

    private Action? _onWaiting;
    /// <summary>
    /// <para>Fired when playback has stopped because of a temporary lack of data.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnWaiting {
        add {
            if (_onWaiting == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnwaiting", default, [ObjectReferenceEventTrigger]));
            _onWaiting += value;
        }
        remove {
            _onWaiting -= value;
            if (_onWaiting == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnwaiting", default));
        }
    }

    private Action? _onAbort;
    /// <summary>
    /// <para>Fired when the resource was not fully loaded, but not as the result of an error.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnAbort {
        add {
            if (_onAbort == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnabort", default, [ObjectReferenceEventTrigger]));
            _onAbort += value;
        }
        remove {
            _onAbort -= value;
            if (_onAbort == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnabort", default));
        }
    }

    private Action? _onEmptied;
    /// <summary>
    /// <para>Fired when the media has become empty; for example, when the media has already been loaded (or partially loaded), and the <see cref="HTMLMediaElement.Load">Load()</see> method is called to reload it.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnEmptied {
        add {
            if (_onEmptied == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnemptied", default, [ObjectReferenceEventTrigger]));
            _onEmptied += value;
        }
        remove {
            _onEmptied -= value;
            if (_onEmptied == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnemptied", default));
        }
    }

    #endregion


    #region Timing Events

    private Action? _onPlay;
    /// <summary>
    /// <para>Fired when the paused property is changed from true to false, as a result of the <see cref="Play">Play()</see> method, or the autoplay attribute.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnPlay {
        add {
            if (_onPlay == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnplay", default, [ObjectReferenceEventTrigger]));
            _onPlay += value;
        }
        remove {
            _onPlay -= value;
            if (_onPlay == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnplay", default));
        }
    }

    private Action? _onPause;
    /// <summary>
    /// <para>Fired when a request to pause play is handled and the activity has entered its paused state, most commonly occurring when the media's <see cref="HTMLMediaElement.Pause">Pause()</see> method is called.</para>
    /// <para>The event is sent once the <see cref="HTMLMediaElement.Pause">Pause()</see> method returns and after the media element's paused property has been changed to true.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnPause {
        add {
            if (_onPause == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnpause", default, [ObjectReferenceEventTrigger]));
            _onPause += value;
        }
        remove {
            _onPause -= value;
            if (_onPause == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnpause", default));
        }
    }

    private Action? _onEnded;
    /// <summary>
    /// <para>Fired when playback stops when end of the media (&lt;audio&gt; and &lt;video&gt;) is reached or because no further data is available.</para>
    /// <para>This event occurs based upon HTMLMediaElement (&lt;audio&gt; and &lt;video&gt;) fire ended when playback reaches the end of the media.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnEnded {
        add {
            if (_onEnded == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnended", default, [ObjectReferenceEventTrigger]));
            _onEnded += value;
        }
        remove {
            _onEnded -= value;
            if (_onEnded == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnended", default));
        }
    }

    private Action? _onSeeking;
    /// <summary>
    /// <para>Fired when a seek operation starts, meaning the Boolean seeking attribute has changed to true and the media is seeking a new position.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnSeeking {
        add {
            if (_onSeeking == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnseeking", default, [ObjectReferenceEventTrigger]));
            _onSeeking += value;
        }
        remove {
            _onSeeking -= value;
            if (_onSeeking == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnseeking", default));
        }
    }

    private Action? _onSeeked;
    /// <summary>
    /// <para>Fired when a seek operation completed, the current playback position has changed, and the Boolean seeking attribute is changed to false.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnSeeked {
        add {
            if (_onSeeked == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnseeked", default, [ObjectReferenceEventTrigger]));
            _onSeeked += value;
        }
        remove {
            _onSeeked -= value;
            if (_onSeeked == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnseeked", default));
        }
    }

    private Action? _onTimeupdate;
    /// <summary>
    /// <para>Fired when the time indicated by the currentTime attribute has been updated.</para>
    /// <para>
    /// The event frequency is dependent on the system load, but will be thrown between about 4Hz and 66Hz (assuming the event handlers don't take longer than 250ms to run).
    /// User agents are encouraged to vary the frequency of the event based on the system load and the average cost of processing the event each time,
    /// so that the UI updates are not any more frequent than the user agent can comfortably handle while decoding the video.
    /// </para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnTimeupdate {
        add {
            if (_onTimeupdate == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOntimeupdate", default, [ObjectReferenceEventTrigger]));
            _onTimeupdate += value;
        }
        remove {
            _onTimeupdate -= value;
            if (_onTimeupdate == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOntimeupdate", default));
        }
    }

    #endregion


    #region Setting Events

    private Action? _onVolumechange;
    /// <summary>
    /// <para>Fired when either the volume attribute or the muted attribute has changed.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnVolumechange {
        add {
            if (_onVolumechange == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnvolumechange", default, [ObjectReferenceEventTrigger]));
            _onVolumechange += value;
        }
        remove {
            _onVolumechange -= value;
            if (_onVolumechange == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnvolumechange", default));
        }
    }

    private Action? _onRatechange;
    /// <summary>
    /// <para>Fired when the playback rate has changed.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnRatechange {
        add {
            if (_onRatechange == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnratechange", default, [ObjectReferenceEventTrigger]));
            _onRatechange += value;
        }
        remove {
            _onRatechange -= value;
            if (_onRatechange == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnratechange", default));
        }
    }

    private Action? _onDurationchange;
    /// <summary>
    /// Fired when the duration attribute has been updated.
    /// </summary>
    public event Action OnDurationchange {
        add {
            if (_onDurationchange == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOndurationchange", default, [ObjectReferenceEventTrigger]));
            _onDurationchange += value;
        }
        remove {
            _onDurationchange -= value;
            if (_onDurationchange == null)
                Task.Factory.StartNew(async () => await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOndurationchange", default));
        }
    }

    #endregion

    #endregion
}

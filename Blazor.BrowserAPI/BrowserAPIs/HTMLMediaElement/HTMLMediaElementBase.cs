using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IHTMLMediaElement")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IHTMLMediaElementInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class HTMLMediaElementBase(Task<IJSObjectReference> htmlMediaElementTask) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected Task<IJSObjectReference> htmlMediaElementTask = htmlMediaElementTask;


    /// <summary>
    /// Attempts to begin playback of the media. It returns a Promise which is resolved when playback has been successfully started.<br />
    /// Failure to begin playback for any reason, such as permission issues, result in the promise being rejected.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask Play(CancellationToken cancellationToken = default) => await (await htmlMediaElementTask).InvokeVoidAsync("play", cancellationToken);


    #region Events

    // Ready
    [method: DynamicDependency(nameof(InvokeError))]
    [method: DynamicDependency(nameof(InvokeCanPlay))]
    [method: DynamicDependency(nameof(InvokeCanPlayThrough))]
    [method: DynamicDependency(nameof(InvokePlaying))]

    // Data
    [method: DynamicDependency(nameof(InvokeLoadStart))]
    [method: DynamicDependency(nameof(InvokeProgress))]
    [method: DynamicDependency(nameof(InvokeLoadedData))]
    [method: DynamicDependency(nameof(InvokeLoadedMetadata))]
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
    [method: DynamicDependency(nameof(InvokeTimeUpdate))]

    // Setting
    [method: DynamicDependency(nameof(InvokeVolumeChange))]
    [method: DynamicDependency(nameof(InvokeRateChange))]
    [method: DynamicDependency(nameof(InvokeDurationChange))]

    // Video
    [method: DynamicDependency(nameof(InvokeResize))]
    [method: DynamicDependency(nameof(InvokeEnterPictureInPicture))]
    [method: DynamicDependency(nameof(InvokeLeavePictureInPicture))]
    private sealed class EventTrigger(HTMLMediaElementBase htmlMediaElement) {
        // Ready
        [JSInvokable] public void InvokeError(int code, string message) => htmlMediaElement._onError?.Invoke(code, message);
        [JSInvokable] public void InvokeCanPlay() => htmlMediaElement._onCanPlay?.Invoke();
        [JSInvokable] public void InvokeCanPlayThrough() => htmlMediaElement._onCanPlayThrough?.Invoke();
        [JSInvokable] public void InvokePlaying() => htmlMediaElement._onPlaying?.Invoke();

        // Data
        [JSInvokable] public void InvokeLoadStart() => htmlMediaElement._onLoadStart?.Invoke();
        [JSInvokable] public void InvokeProgress() => htmlMediaElement._onProgress?.Invoke();
        [JSInvokable] public void InvokeLoadedData() => htmlMediaElement._onLoadedData?.Invoke();
        [JSInvokable] public void InvokeLoadedMetadata() => htmlMediaElement._onLoadedMetadata?.Invoke();
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
        [JSInvokable] public void InvokeTimeUpdate() => htmlMediaElement._onTimeUpdate?.Invoke();

        // Setting
        [JSInvokable] public void InvokeVolumeChange() => htmlMediaElement._onVolumeChange?.Invoke();
        [JSInvokable] public void InvokeRateChange() => htmlMediaElement._onRateChange?.Invoke();
        [JSInvokable] public void InvokeDurationChange() => htmlMediaElement._onDurationChange?.Invoke();

        // Video
        [JSInvokable] public void InvokeResize() => htmlMediaElement._onResize?.Invoke();
        [JSInvokable] public void InvokeEnterPictureInPicture(IJSObjectReference pictureInPictureWindow) => htmlMediaElement.InvokeEnterPictureInPicture(pictureInPictureWindow);
        [JSInvokable] public void InvokeLeavePictureInPicture(IJSObjectReference pictureInPictureWindow) => htmlMediaElement.InvokeLeavePictureInPicture(pictureInPictureWindow);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger(IJSObjectReference htmlMediaElement) {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return htmlMediaElement.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private protected async ValueTask ActivateJSEvent(string jsMethodName) {
        IJSObjectReference htmlMediaElement = await htmlMediaElementTask;
        await InitEventTrigger(htmlMediaElement);
        await htmlMediaElement.InvokeVoidTrySync(jsMethodName);
    }

    private protected async ValueTask DeactivateJSEvent(string jsMethodName) {
        IJSObjectReference htmlMediaElement = await htmlMediaElementTask;
        await htmlMediaElement.InvokeVoidTrySync(jsMethodName);
    }


    // Ready Events

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
                _ = ActivateJSEvent("activateOnerror").Preserve();
            _onError += value;
        }
        remove {
            _onError -= value;
            if (_onError == null)
                _ = DeactivateJSEvent("deactivateOnerror").Preserve();
        }
    }

    private Action? _onCanPlay;
    /// <summary>
    /// <para>Fired when the user agent can play the media, but estimates that not enough data has been loaded to play the media up to its end without having to stop for further buffering of content.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnCanPlay {
        add {
            if (_onCanPlay == null)
                _ = ActivateJSEvent("activateOncanplay").Preserve();
            _onCanPlay += value;
        }
        remove {
            _onCanPlay -= value;
            if (_onCanPlay == null)
                _ = DeactivateJSEvent("deactivateOncanplay").Preserve();
        }
    }

    private Action? _onCanPlayThrough;
    /// <summary>
    /// <para>Fired when the user agent can play the media, and estimates that enough data has been loaded to play the media up to its end without having to stop for further buffering of content.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnCanPlayThrough {
        add {
            if (_onCanPlayThrough == null)
                _ = ActivateJSEvent("activateOncanplaythrough").Preserve();
            _onCanPlayThrough += value;
        }
        remove {
            _onCanPlayThrough -= value;
            if (_onCanPlayThrough == null)
                _ = DeactivateJSEvent("deactivateOncanplaythrough").Preserve();
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
                _ = ActivateJSEvent("activateOnplaying").Preserve();
            _onPlaying += value;
        }
        remove {
            _onPlaying -= value;
            if (_onPlaying == null)
                _ = DeactivateJSEvent("deactivateOnplaying").Preserve();
        }
    }


    // Data Events

    private Action? _onLoadStart;
    /// <summary>
    /// Fired when the browser has started to load a resource.
    /// </summary>
    public event Action OnLoadStart {
        add {
            if (_onLoadStart == null)
                _ = ActivateJSEvent("activateOnloadstart").Preserve();
            _onLoadStart += value;
        }
        remove {
            _onLoadStart -= value;
            if (_onLoadStart == null)
                _ = DeactivateJSEvent("deactivateOnloadstart").Preserve();
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
                _ = ActivateJSEvent("activateOnprogress").Preserve();
            _onProgress += value;
        }
        remove {
            _onProgress -= value;
            if (_onProgress == null)
                _ = DeactivateJSEvent("deactivateOnprogress").Preserve();
        }
    }

    private Action? _onLoadedData;
    /// <summary>
    /// Fired when the first frame of the media has finished loading; often the first frame.
    /// </summary>
    public event Action OnLoadedData {
        add {
            if (_onLoadedData == null)
                _ = ActivateJSEvent("activateOnloadeddata").Preserve();
            _onLoadedData += value;
        }
        remove {
            _onLoadedData -= value;
            if (_onLoadedData == null)
                _ = DeactivateJSEvent("deactivateOnloadeddata").Preserve();
        }
    }

    private Action? _onLoadedMetadata;
    /// <summary>
    /// Fired when the metadata has been loaded.
    /// </summary>
    public event Action OnLoadedMetadata {
        add {
            if (_onLoadedMetadata == null)
                _ = ActivateJSEvent("activateOnloadedmetadata").Preserve();
            _onLoadedMetadata += value;
        }
        remove {
            _onLoadedMetadata -= value;
            if (_onLoadedMetadata == null)
                _ = DeactivateJSEvent("deactivateOnloadedmetadata").Preserve();
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
                _ = ActivateJSEvent("activateOnstalled").Preserve();
            _onStalled += value;
        }
        remove {
            _onStalled -= value;
            if (_onStalled == null)
                _ = DeactivateJSEvent("deactivateOnstalled").Preserve();
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
                _ = ActivateJSEvent("activateOnsuspend").Preserve();
            _onSuspend += value;
        }
        remove {
            _onSuspend -= value;
            if (_onSuspend == null)
                _ = DeactivateJSEvent("deactivateOnsuspend").Preserve();
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
                _ = ActivateJSEvent("activateOnwaiting").Preserve();
            _onWaiting += value;
        }
        remove {
            _onWaiting -= value;
            if (_onWaiting == null)
                _ = DeactivateJSEvent("deactivateOnwaiting").Preserve();
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
                _ = ActivateJSEvent("activateOnabort").Preserve();
            _onAbort += value;
        }
        remove {
            _onAbort -= value;
            if (_onAbort == null)
                _ = DeactivateJSEvent("deactivateOnabort").Preserve();
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
                _ = ActivateJSEvent("activateOnemptied").Preserve();
            _onEmptied += value;
        }
        remove {
            _onEmptied -= value;
            if (_onEmptied == null)
                _ = DeactivateJSEvent("deactivateOnemptied").Preserve();
        }
    }


    // Timing Events

    private Action? _onPlay;
    /// <summary>
    /// <para>Fired when the paused property is changed from true to false, as a result of the <see cref="Play">Play()</see> method, or the autoplay attribute.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnPlay {
        add {
            if (_onPlay == null)
                _ = ActivateJSEvent("activateOnplay").Preserve();
            _onPlay += value;
        }
        remove {
            _onPlay -= value;
            if (_onPlay == null)
                _ = DeactivateJSEvent("deactivateOnplay").Preserve();
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
                _ = ActivateJSEvent("activateOnpause").Preserve();
            _onPause += value;
        }
        remove {
            _onPause -= value;
            if (_onPause == null)
                _ = DeactivateJSEvent("deactivateOnpause").Preserve();
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
                _ = ActivateJSEvent("activateOnended").Preserve();
            _onEnded += value;
        }
        remove {
            _onEnded -= value;
            if (_onEnded == null)
                _ = DeactivateJSEvent("deactivateOnended").Preserve();
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
                _ = ActivateJSEvent("activateOnseeking").Preserve();
            _onSeeking += value;
        }
        remove {
            _onSeeking -= value;
            if (_onSeeking == null)
                _ = DeactivateJSEvent("deactivateOnseeking").Preserve();
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
                _ = ActivateJSEvent("activateOnseeked").Preserve();
            _onSeeked += value;
        }
        remove {
            _onSeeked -= value;
            if (_onSeeked == null)
                _ = DeactivateJSEvent("deactivateOnseeked").Preserve();
        }
    }

    private Action? _onTimeUpdate;
    /// <summary>
    /// <para>Fired when the time indicated by the currentTime attribute has been updated.</para>
    /// <para>
    /// The event frequency is dependent on the system load, but will be thrown between about 4Hz and 66Hz (assuming the event handlers don't take longer than 250ms to run).
    /// User agents are encouraged to vary the frequency of the event based on the system load and the average cost of processing the event each time,
    /// so that the UI updates are not any more frequent than the user agent can comfortably handle while decoding the video.
    /// </para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnTimeUpdate {
        add {
            if (_onTimeUpdate == null)
                _ = ActivateJSEvent("activateOntimeupdate").Preserve();
            _onTimeUpdate += value;
        }
        remove {
            _onTimeUpdate -= value;
            if (_onTimeUpdate == null)
                _ = DeactivateJSEvent("deactivateOntimeupdate").Preserve();
        }
    }


    // Setting Events

    private Action? _onVolumeChange;
    /// <summary>
    /// <para>Fired when either the volume attribute or the muted attribute has changed.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnVolumeChange {
        add {
            if (_onVolumeChange == null)
                _ = ActivateJSEvent("activateOnvolumechange").Preserve();
            _onVolumeChange += value;
        }
        remove {
            _onVolumeChange -= value;
            if (_onVolumeChange == null)
                _ = DeactivateJSEvent("deactivateOnvolumechange").Preserve();
        }
    }

    private Action? _onRateChange;
    /// <summary>
    /// <para>Fired when the playback rate has changed.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnRateChange {
        add {
            if (_onRateChange == null)
                _ = ActivateJSEvent("activateOnratechange").Preserve();
            _onRateChange += value;
        }
        remove {
            _onRateChange -= value;
            if (_onRateChange == null)
                _ = DeactivateJSEvent("deactivateOnratechange").Preserve();
        }
    }

    private Action? _onDurationChange;
    /// <summary>
    /// Fired when the duration attribute has been updated.
    /// </summary>
    public event Action OnDurationChange {
        add {
            if (_onDurationChange == null)
                _ = ActivateJSEvent("activateOndurationchange").Preserve();
            _onDurationChange += value;
        }
        remove {
            _onDurationChange -= value;
            if (_onDurationChange == null)
                _ = DeactivateJSEvent("deactivateOndurationchange").Preserve();
        }
    }


    // Video Events

    private Action? _onResize;
    /// <summary>
    /// <para>Fires when one or both of the videoWidth and videoHeight properties have just been updated.</para>
    /// <para>This event is not cancelable but may bubble.</para>
    /// </summary>
    public event Action OnResize {
        add {
            if (_onResize == null)
                _ = ActivateJSEvent("activateOnresize").Preserve();
            _onResize += value;
        }
        remove {
            _onResize -= value;
            if (_onResize == null)
                _ = DeactivateJSEvent("deactivateOnresize").Preserve();
        }
    }

    // (IPictureInPictureWindow | IPictureInPictureWindowInProcess) pictureInPictureWindow
    private protected abstract void InvokeEnterPictureInPicture(IJSObjectReference pictureInPictureWindow);

    // (IPictureInPictureWindow | IPictureInPictureWindowInProcess) pictureInPictureWindow
    private protected abstract void InvokeLeavePictureInPicture(IJSObjectReference pictureInPictureWindow);

    #endregion
}

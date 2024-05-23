using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base class for <see cref="HTMLMediaElement"/> and <see cref="HTMLMediaElementInProcess"/>.
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


    // Ready
    
    #region Error event

    private DotNetObjectReference<ErrorTrigger>? objectReferenceErrorTrigger;

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
            if (objectReferenceErrorTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceErrorTrigger = DotNetObjectReference.Create(new ErrorTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnerror", default, [objectReferenceErrorTrigger]);
                });

            _onError += value;
        }
        remove {
            _onError -= value;

            if (_onError == null && objectReferenceErrorTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnerror", default);
                    objectReferenceErrorTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class ErrorTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger(int code, string message) => htmlMediaElement._onError?.Invoke(code, message);
    }

    #endregion


    #region Canplay event

    private DotNetObjectReference<CanplayTrigger>? objectReferenceCanplayTrigger;

    private Action? _onCanplay;
    /// <summary>
    /// <para>Fired when the user agent can play the media, but estimates that not enough data has been loaded to play the media up to its end without having to stop for further buffering of content.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnCanplay {
        add {
            if (objectReferenceCanplayTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceCanplayTrigger = DotNetObjectReference.Create(new CanplayTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOncanplay", default, [objectReferenceCanplayTrigger]);
                });

            _onCanplay += value;
        }
        remove {
            _onCanplay -= value;

            if (_onCanplay == null && objectReferenceCanplayTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOncanplay", default);
                    objectReferenceCanplayTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class CanplayTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onCanplay?.Invoke();
    }

    #endregion


    #region Canplaythrough event

    private DotNetObjectReference<CanplaythroughTrigger>? objectReferenceCanplaythroughTrigger;

    private Action? _onCanplaythrough;
    /// <summary>
    /// <para>Fired when the user agent can play the media, and estimates that enough data has been loaded to play the media up to its end without having to stop for further buffering of content.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnCanplaythrough {
        add {
            if (objectReferenceCanplaythroughTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceCanplaythroughTrigger = DotNetObjectReference.Create(new CanplaythroughTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOncanplaythrough", default, [objectReferenceCanplaythroughTrigger]);
                });

            _onCanplaythrough += value;
        }
        remove {
            _onCanplaythrough -= value;

            if (_onCanplaythrough == null && objectReferenceCanplaythroughTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOncanplaythrough", default);
                    objectReferenceCanplaythroughTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class CanplaythroughTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onCanplaythrough?.Invoke();
    }

    #endregion


    #region Playing event

    private DotNetObjectReference<PlayingTrigger>? objectReferencePlayingTrigger;

    private Action? _onPlaying;
    /// <summary>
    /// <para>Fired after playback is first started, and whenever it is restarted. For example it is fired when playback resumes after having been paused or delayed due to lack of data.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnPlaying {
        add {
            if (objectReferencePlayingTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferencePlayingTrigger = DotNetObjectReference.Create(new PlayingTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnplaying", default, [objectReferencePlayingTrigger]);
                });

            _onPlaying += value;
        }
        remove {
            _onPlaying -= value;

            if (_onPlaying == null && objectReferencePlayingTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnplaying", default);
                    objectReferencePlayingTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class PlayingTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onPlaying?.Invoke();
    }

    #endregion


    // Data

    #region Loadstart event

    private DotNetObjectReference<LoadstartTrigger>? objectReferenceLoadstartTrigger;

    private Action? _onLoadstart;
    /// <summary>
    /// Fired when the browser has started to load a resource.
    /// </summary>
    public event Action OnLoadstart {
        add {
            if (objectReferenceLoadstartTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceLoadstartTrigger = DotNetObjectReference.Create(new LoadstartTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnloadstart", default, [objectReferenceLoadstartTrigger]);
                });

            _onLoadstart += value;
        }
        remove {
            _onLoadstart -= value;

            if (_onLoadstart == null && objectReferenceLoadstartTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnloadstart", default);
                    objectReferenceLoadstartTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class LoadstartTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onLoadstart?.Invoke();
    }

    #endregion


    #region Progress event

    private DotNetObjectReference<ProgressTrigger>? objectReferenceProgressTrigger;

    private Action? _onProgress;
    /// <summary>
    /// <para>Fired periodically as the browser loads a resource.></para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnProgress {
        add {
            if (objectReferenceProgressTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceProgressTrigger = DotNetObjectReference.Create(new ProgressTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnprogress", default, [objectReferenceProgressTrigger]);
                });

            _onProgress += value;
        }
        remove {
            _onProgress -= value;

            if (_onProgress == null && objectReferenceProgressTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnprogress", default);
                    objectReferenceProgressTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class ProgressTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onProgress?.Invoke();
    }

    #endregion


    #region Loadeddata event

    private DotNetObjectReference<LoadeddataTrigger>? objectReferenceLoadeddataTrigger;

    private Action? _onLoadeddata;
    /// <summary>
    /// Fired when the first frame of the media has finished loading; often the first frame.
    /// </summary>
    public event Action OnLoadeddata {
        add {
            if (objectReferenceLoadeddataTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceLoadeddataTrigger = DotNetObjectReference.Create(new LoadeddataTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnloadeddata", default, [objectReferenceLoadeddataTrigger]);
                });

            _onLoadeddata += value;
        }
        remove {
            _onLoadeddata -= value;

            if (_onLoadeddata == null && objectReferenceLoadeddataTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnloadeddata", default);
                    objectReferenceLoadeddataTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class LoadeddataTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onLoadeddata?.Invoke();
    }

    #endregion


    #region Loadedmetadata event

    private DotNetObjectReference<LoadedmetadataTrigger>? objectReferenceLoadedmetadataTrigger;

    private Action? _onLoadedmetadata;
    /// <summary>
    /// Fired when the metadata has been loaded.
    /// </summary>
    public event Action OnLoadedmetadata {
        add {
            if (objectReferenceLoadedmetadataTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceLoadedmetadataTrigger = DotNetObjectReference.Create(new LoadedmetadataTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnloadedmetadata", default, [objectReferenceLoadedmetadataTrigger]);
                });

            _onLoadedmetadata += value;
        }
        remove {
            _onLoadedmetadata -= value;

            if (_onLoadedmetadata == null && objectReferenceLoadedmetadataTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnloadedmetadata", default);
                    objectReferenceLoadedmetadataTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class LoadedmetadataTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onLoadedmetadata?.Invoke();
    }

    #endregion


    #region Stalled event

    private DotNetObjectReference<StalledTrigger>? objectReferenceStalledTrigger;

    private Action? _onStalled;
    /// <summary>
    /// <para>Fired when the user agent is trying to fetch media data, but data is unexpectedly not forthcoming.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnStalled {
        add {
            if (objectReferenceStalledTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceStalledTrigger = DotNetObjectReference.Create(new StalledTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnstalled", default, [objectReferenceStalledTrigger]);
                });

            _onStalled += value;
        }
        remove {
            _onStalled -= value;

            if (_onStalled == null && objectReferenceStalledTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnstalled", default);
                    objectReferenceStalledTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class StalledTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onStalled?.Invoke();
    }

    #endregion


    #region Suspend event

    private DotNetObjectReference<SuspendTrigger>? objectReferenceSuspendTrigger;

    private Action? _onSuspend;
    /// <summary>
    /// <para>Fired when the media data loading has been suspended.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnSuspend {
        add {
            if (objectReferenceSuspendTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceSuspendTrigger = DotNetObjectReference.Create(new SuspendTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnsuspend", default, [objectReferenceSuspendTrigger]);
                });

            _onSuspend += value;
        }
        remove {
            _onSuspend -= value;

            if (_onSuspend == null && objectReferenceSuspendTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnsuspend", default);
                    objectReferenceSuspendTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class SuspendTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onSuspend?.Invoke();
    }

    #endregion


    #region Waiting event

    private DotNetObjectReference<WaitingTrigger>? objectReferenceWaitingTrigger;

    private Action? _onWaiting;
    /// <summary>
    /// <para>Fired when playback has stopped because of a temporary lack of data.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnWaiting {
        add {
            if (objectReferenceWaitingTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceWaitingTrigger = DotNetObjectReference.Create(new WaitingTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnwaiting", default, [objectReferenceWaitingTrigger]);
                });

            _onWaiting += value;
        }
        remove {
            _onWaiting -= value;

            if (_onWaiting == null && objectReferenceWaitingTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnwaiting", default);
                    objectReferenceWaitingTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class WaitingTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onWaiting?.Invoke();
    }

    #endregion


    #region Abort event

    private DotNetObjectReference<AbortTrigger>? objectReferenceAbortTrigger;

    private Action? _onAbort;
    /// <summary>
    /// <para>Fired when the resource was not fully loaded, but not as the result of an error.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnAbort {
        add {
            if (objectReferenceAbortTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceAbortTrigger = DotNetObjectReference.Create(new AbortTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnabort", default, [objectReferenceAbortTrigger]);
                });

            _onAbort += value;
        }
        remove {
            _onAbort -= value;

            if (_onAbort == null && objectReferenceAbortTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnabort", default);
                    objectReferenceAbortTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class AbortTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onAbort?.Invoke();
    }

    #endregion


    #region Emptied event

    private DotNetObjectReference<EmptiedTrigger>? objectReferenceEmptiedTrigger;

    private Action? _onEmptied;
    /// <summary>
    /// <para>Fired when the media has become empty; for example, when the media has already been loaded (or partially loaded), and the <see cref="HTMLMediaElement.Load">Load()</see> method is called to reload it.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnEmptied {
        add {
            if (objectReferenceEmptiedTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceEmptiedTrigger = DotNetObjectReference.Create(new EmptiedTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnemptied", default, [objectReferenceEmptiedTrigger]);
                });

            _onEmptied += value;
        }
        remove {
            _onEmptied -= value;

            if (_onEmptied == null && objectReferenceEmptiedTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnemptied", default);
                    objectReferenceEmptiedTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class EmptiedTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onEmptied?.Invoke();
    }

    #endregion


    // Timing

    #region Play event

    private DotNetObjectReference<PlayTrigger>? objectReferencePlayTrigger;

    private Action? _onPlay;
    /// <summary>
    /// <para>Fired when the paused property is changed from true to false, as a result of the <see cref="Play">Play()</see> method, or the autoplay attribute.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnPlay {
        add {
            if (objectReferencePlayTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferencePlayTrigger = DotNetObjectReference.Create(new PlayTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnplay", default, [objectReferencePlayTrigger]);
                });

            _onPlay += value;
        }
        remove {
            _onPlay -= value;

            if (_onPlay == null && objectReferencePlayTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnplay", default);
                    objectReferencePlayTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class PlayTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onPlay?.Invoke();
    }

    #endregion


    #region Pause event

    private DotNetObjectReference<PauseTrigger>? objectReferencePauseTrigger;

    private Action? _onPause;
    /// <summary>
    /// <para>Fired when a request to pause play is handled and the activity has entered its paused state, most commonly occurring when the media's <see cref="HTMLMediaElement.Pause">Pause()</see> method is called.</para>
    /// <para>The event is sent once the <see cref="HTMLMediaElement.Pause">Pause()</see> method returns and after the media element's paused property has been changed to true.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnPause {
        add {
            if (objectReferencePauseTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferencePauseTrigger = DotNetObjectReference.Create(new PauseTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnpause", default, [objectReferencePauseTrigger]);
                });

            _onPause += value;
        }
        remove {
            _onPause -= value;

            if (_onPause == null && objectReferencePauseTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnpause", default);
                    objectReferencePauseTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class PauseTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onPause?.Invoke();
    }

    #endregion


    #region Ended event

    private DotNetObjectReference<EndedTrigger>? objectReferenceEndedTrigger;

    private Action? _onEnded;
    /// <summary>
    /// <para>Fired when playback stops when end of the media (&lt;audio&gt; and &lt;video&gt;) is reached or because no further data is available.</para>
    /// <para>This event occurs based upon HTMLMediaElement (&lt;audio&gt; and &lt;video&gt;) fire ended when playback reaches the end of the media.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnEnded {
        add {
            if (objectReferenceEndedTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceEndedTrigger = DotNetObjectReference.Create(new EndedTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnended", default, [objectReferenceEndedTrigger]);
                });

            _onEnded += value;
        }
        remove {
            _onEnded -= value;

            if (_onEnded == null && objectReferenceEndedTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnended", default);
                    objectReferenceEndedTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class EndedTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onEnded?.Invoke();
    }

    #endregion


    #region Seeking event

    private DotNetObjectReference<SeekingTrigger>? objectReferenceSeekingTrigger;

    private Action? _onSeeking;
    /// <summary>
    /// <para>Fired when a seek operation starts, meaning the Boolean seeking attribute has changed to true and the media is seeking a new position.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnSeeking {
        add {
            if (objectReferenceSeekingTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceSeekingTrigger = DotNetObjectReference.Create(new SeekingTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnseeking", default, [objectReferenceSeekingTrigger]);
                });

            _onSeeking += value;
        }
        remove {
            _onSeeking -= value;

            if (_onSeeking == null && objectReferenceSeekingTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnseeking", default);
                    objectReferenceSeekingTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class SeekingTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onSeeking?.Invoke();
    }

    #endregion


    #region Seeked event

    private DotNetObjectReference<SeekedTrigger>? objectReferenceSeekedTrigger;

    private Action? _onSeeked;
    /// <summary>
    /// <para>Fired when a seek operation completed, the current playback position has changed, and the Boolean seeking attribute is changed to false.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnSeeked {
        add {
            if (objectReferenceSeekedTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceSeekedTrigger = DotNetObjectReference.Create(new SeekedTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnseeked", default, [objectReferenceSeekedTrigger]);
                });

            _onSeeked += value;
        }
        remove {
            _onSeeked -= value;

            if (_onSeeked == null && objectReferenceSeekedTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnseeked", default);
                    objectReferenceSeekedTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class SeekedTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onSeeked?.Invoke();
    }

    #endregion


    #region Timeupdate event

    private DotNetObjectReference<TimeupdateTrigger>? objectReferenceTimeupdateTrigger;

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
            if (objectReferenceTimeupdateTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceTimeupdateTrigger = DotNetObjectReference.Create(new TimeupdateTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOntimeupdate", default, [objectReferenceTimeupdateTrigger]);
                });

            _onTimeupdate += value;
        }
        remove {
            _onTimeupdate -= value;

            if (_onTimeupdate == null && objectReferenceTimeupdateTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOntimeupdate", default);
                    objectReferenceTimeupdateTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class TimeupdateTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onTimeupdate?.Invoke();
    }

    #endregion


    // Setting

    #region Volumechange event

    private DotNetObjectReference<VolumechangeTrigger>? objectReferenceVolumechangeTrigger;

    private Action? _onVolumechange;
    /// <summary>
    /// <para>Fired when either the volume attribute or the muted attribute has changed.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnVolumechange {
        add {
            if (objectReferenceVolumechangeTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceVolumechangeTrigger = DotNetObjectReference.Create(new VolumechangeTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnvolumechange", default, [objectReferenceVolumechangeTrigger]);
                });

            _onVolumechange += value;
        }
        remove {
            _onVolumechange -= value;

            if (_onVolumechange == null && objectReferenceVolumechangeTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnvolumechange", default);
                    objectReferenceVolumechangeTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class VolumechangeTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onVolumechange?.Invoke();
    }

    #endregion


    #region Ratechange event

    private DotNetObjectReference<RatechangeTrigger>? objectReferenceRatechangeTrigger;

    private Action? _onRatechange;
    /// <summary>
    /// <para>Fired when the playback rate has changed.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnRatechange {
        add {
            if (objectReferenceRatechangeTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceRatechangeTrigger = DotNetObjectReference.Create(new RatechangeTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOnratechange", default, [objectReferenceRatechangeTrigger]);
                });

            _onRatechange += value;
        }
        remove {
            _onRatechange -= value;

            if (_onRatechange == null && objectReferenceRatechangeTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOnratechange", default);
                    objectReferenceRatechangeTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class RatechangeTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onRatechange?.Invoke();
    }

    #endregion


    #region Durationchange event

    private DotNetObjectReference<DurationchangeTrigger>? objectReferenceDurationchangeTrigger;

    private Action? _onDurationchange;
    /// <summary>
    /// Fired when the duration attribute has been updated.
    /// </summary>
    public event Action OnDurationchange {
        add {
            if (objectReferenceDurationchangeTrigger == null)
                Task.Factory.StartNew(async () => {
                    objectReferenceDurationchangeTrigger = DotNetObjectReference.Create(new DurationchangeTrigger(this));
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("activateOndurationchange", default, [objectReferenceDurationchangeTrigger]);
                });

            _onDurationchange += value;
        }
        remove {
            _onDurationchange -= value;

            if (_onDurationchange == null && objectReferenceDurationchangeTrigger != null)
                Task.Factory.StartNew(async () => {
                    await (await HTMLMediaElementTask).InvokeVoidTrySync("deactivateOndurationchange", default);
                    objectReferenceDurationchangeTrigger.Dispose();
                });
        }
    }

    [method: DynamicDependency(nameof(Trigger))]
    private sealed class DurationchangeTrigger(HTMLMediaElementBase htmlMediaElement) {
        [JSInvokable]
        public void Trigger() => htmlMediaElement._onDurationchange?.Invoke();
    }

    #endregion
}

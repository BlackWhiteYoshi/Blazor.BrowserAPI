using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "INetworkInformation")]
[AutoInterface(Namespace = "BrowserAPI", Name = "INetworkInformationInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class NetworkInformationBase(IModuleManager moduleManager) : IDisposable {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;

    /// <summary>
    /// Releases the <see cref="EventTrigger"/> object used to trigger the events.
    /// </summary>
    public void Dispose() => _objectReferenceEventTrigger?.Dispose();


    #region Events

    [method: DynamicDependency(nameof(InvokeOnline))]
    [method: DynamicDependency(nameof(InvokeOffline))]
    [method: DynamicDependency(nameof(InvokeChange))]
    private sealed class EventTrigger(NetworkInformationBase networkInformation) {
        [JSInvokable] public void InvokeOnline() => networkInformation._onOnline?.Invoke();
        [JSInvokable] public void InvokeOffline() => networkInformation._onOffline?.Invoke();
        [JSInvokable] public void InvokeChange() => networkInformation._onChange?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return moduleManager.InvokeTrySync("NetworkInformationAPI.initEvents", default, [_objectReferenceEventTrigger]);
    }


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await moduleManager.InvokeTrySync(jsMethodName, default);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => moduleManager.InvokeTrySync(jsMethodName, default);


    private Action? _onOnline;
    /// <summary>
    /// Fired when the browser has gained access to the network and the value of <i>navigator.onLine</i> has switched to true.
    /// </summary>
    public event Action OnOnline {
        add {
            if (_onOnline == null)
                _ = ActivateJSEvent("NetworkInformationAPI.activateOnonline").Preserve();
            _onOnline += value;
        }
        remove {
            _onOnline -= value;
            if (_onOnline == null)
                _ = DeactivateJSEvent("NetworkInformationAPI.deactivateOnonline").Preserve();
        }
    }

    private Action? _onOffline;
    /// <summary>
    /// Fired when the browser has lost access to the network and the value of <i>navigator.onLine</i> has switched to false.
    /// </summary>
    public event Action OnOffline {
        add {
            if (_onOffline == null)
                _ = ActivateJSEvent("NetworkInformationAPI.activateOnoffline").Preserve();
            _onOffline += value;
        }
        remove {
            _onOffline -= value;
            if (_onOffline == null)
                _ = DeactivateJSEvent("NetworkInformationAPI.deactivateOnoffline").Preserve();
        }
    }

    private Action? _onChange;
    /// <summary>
    /// Is fired when connection information changes, and the event is received by the NetworkInformation object.
    /// </summary>
    /// <remarks>That does not include the property <i>navigator.onLine</i>, for tracking changes of that property use the <see cref="OnOnline"/>/<see cref="OnOffline"/> events.</remarks>
    public event Action OnChange {
        add {
            if (_onChange == null)
                _ = ActivateJSEvent("NetworkInformationAPI.activateOnchange").Preserve();
            _onChange += value;
        }
        remove {
            _onChange -= value;
            if (_onChange == null)
                _ = DeactivateJSEvent("NetworkInformationAPI.deactivateOnchange").Preserve();
        }
    }

    #endregion
}

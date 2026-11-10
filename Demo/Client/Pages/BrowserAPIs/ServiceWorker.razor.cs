using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class ServiceWorker : ComponentBase, IAsyncDisposable {
    [Inject]
    public required IServiceWorkerContainer ServiceWorkerContainer { private get; init; }

    private IServiceWorkerRegistration? serviceWorkerRegistration;

    private Task<IServiceWorker>? _serviceWorkerTask;
    private Task<IServiceWorker> ServiceWorkerTask => _serviceWorkerTask ??= ServiceWorkerContainer.Controller.AsTask()!;

    public async ValueTask DisposeAsync() {
        try {
            if (_serviceWorkerTask is not null) {
                await (await _serviceWorkerTask).DisposeAsync();
                _serviceWorkerTask = null;
            }

            if (serviceWorkerRegistration is not null) {
                await serviceWorkerRegistration.Unregister();
                await serviceWorkerRegistration.DisposeAsync();
                serviceWorkerRegistration = null;
            }
        }
        catch (JSDisconnectedException) { }
    }


    private async Task Register() {
        serviceWorkerRegistration = await ServiceWorkerContainer.RegisterWithWorkerRegistration("service-worker.js");
    }

    private async Task Unregister() => await DisposeAsync();


    private bool? active = null;
    private async Task IsActive() {
        IServiceWorker? serviceWorker = await serviceWorkerRegistration!.Active;
        active = serviceWorker is not null;
        if (active == true)
            await serviceWorker!.DisposeAsync();
    }

    private bool? installing = null;
    private async Task IsInstalling() {
        IServiceWorker? serviceWorker = await serviceWorkerRegistration!.Installing;
        installing = serviceWorker is not null;
        if (installing == true)
            await serviceWorker!.DisposeAsync();
    }

    private bool? waiting = null;
    private async Task IsWaiting() {
        IServiceWorker? serviceWorker = await serviceWorkerRegistration!.Waiting;
        waiting = serviceWorker is not null;
        if (waiting == true)
            await serviceWorker!.DisposeAsync();
    }

    private string? scope = null;
    private async Task GetScope() => scope = await serviceWorkerRegistration!.Scope;

    private string? updateViaCache = null;
    private async Task GetUpdateViaCache() => updateViaCache = await serviceWorkerRegistration!.UpdateViaCache;


    private string? scriptUrl = null;
    private async Task GetScriptUrl() => scriptUrl = await (await ServiceWorkerTask).ScriptUrl;

    private string? state = null;
    private async Task GetState() => state = await (await ServiceWorkerTask).State;
}

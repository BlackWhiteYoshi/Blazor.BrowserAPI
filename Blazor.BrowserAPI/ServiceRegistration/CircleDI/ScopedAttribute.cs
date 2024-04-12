#nullable disable
#nullable enable annotations

namespace CircleDIAttributes;

/// <summary>
/// <para>Specifies a scoped service. That means this service will only be available in the ScopedProvider and there will be a single instance of that service in every ScopedProvider instance.</para>
/// <para>If <see cref="ServiceProviderAttribute"/> is used at the same class, this service will be added to the provider.</para>
/// </summary>
/// <typeparam name="TService">Type of the service.</typeparam>
/// <typeparam name="TImplementation">Type of the implementation.</typeparam>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = true)]
internal sealed class ScopedAttribute<TService, TImplementation> : Attribute where TImplementation : TService {
    /// <summary>
    /// <para>Fieldname, propertyname or methodname that will be the implementation supplier for the given service.</para>
    /// <para>The parameters of the method will be dependency injected.</para>
    /// </summary>
    public string Implementation { get; init; }

    /// <summary>
    /// <para>The name of this service.</para>
    /// <para>If omitted, it will be the name of TImplementation.</para>
    /// <para>If the getter is a method, for the identifier a "Get" prefix will be used, but this does not affect the name.</para>
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// <para>Decides whether this service will be lazy constructed or instantiated inside the constructor.</para>
    /// <para>Defaults to <see cref="ServiceProviderAttribute.CreationTime"/> or <see cref="ScopedProviderAttribute.CreationTime"/>.</para>
    /// </summary>
    public CreationTiming CreationTime { get; init; }

    /// <summary>
    /// <para>Decides whether the type of the member to access this service will be a property or method.</para>
    /// <para>Defaults to <see cref="ServiceProviderAttribute.GetAccessor"/> or <see cref="ScopedProviderAttribute.GetAccessor"/>.</para>
    /// </summary>
    public GetAccess GetAccessor { get; init; }

    /// <summary>
    /// <para>When true, the ServiceProvider does not dispose this service on <see cref="System.IDisposable.Dispose">Dispose()</see> or <see cref="System.IAsyncDisposable.DisposeAsync">DisposeAsync()</see>,
    /// regardless the service implements <see cref="System.IDisposable">IDisposable</see> or <see cref="System.IAsyncDisposable">IAsyncDisposable</see>.</para>
    /// <para>If the service does not implement <see cref="System.IDisposable">IDisposable</see>/<see cref="System.IAsyncDisposable">IAsyncDisposable</see>, this will have no effect.</para>
    /// <para>Default is false.</para>
    /// </summary>
    public bool NoDispose { get; init; }
}

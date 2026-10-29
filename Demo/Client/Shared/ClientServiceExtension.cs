namespace BrowserAPI.Demo.Client;

public static class ClientServiceExtension {
    public static IServiceCollection AddClientServices(this IServiceCollection services) {
        services.AddScoped<GetUniqueId>(_ => new UniqueIdGenerator().GetUniqueId);

        return services;
    }
}

using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ling.Tools.Wasm.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddToolServices(this IServiceCollection services)
    {
        services.AddLocalization();
        services.AddSingleton<IStringLocalizer>(sp => sp.GetRequiredService<IStringLocalizer<SharedResource>>());

        services.AddFluentUIComponents();
        services.AddBrowserStorage();

        return services;
    }

    private static IServiceCollection AddBrowserStorage(this IServiceCollection services)
    {
        services.TryAddScoped<LocalStorage>();
        services.TryAddScoped<SessionStorage>();

        return services;
    }
}

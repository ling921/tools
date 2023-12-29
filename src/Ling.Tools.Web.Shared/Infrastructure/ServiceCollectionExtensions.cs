using Ling.Tools.Web.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ling.Tools.Web.Shared.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddToolServices(this IServiceCollection services)
    {
        var toolService = new ToolService(AppDefaults.Tools);
        services.TryAddSingleton(toolService);

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

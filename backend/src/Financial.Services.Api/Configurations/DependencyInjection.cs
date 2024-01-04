using Financial.Services.Core.Communication.Mediator;
using Financial.Services.Core.Notifications;

namespace Financial.Services.Api.Configurations;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        Application(services);
        Repository(services);
        Services(services);
    }

    private static void Application(IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();
        services.AddScoped<INotificator, Notificator>();
    }

    private static void Repository(IServiceCollection services)
    {

    }

    private static void Services(IServiceCollection services)
    {

    }
}

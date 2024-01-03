using Financial.Services.Core.Communication.Mediator;
using Financial.Services.Core.Data.EventSourcing;
using Financial.Services.Core.Messages.CommonMessages.Notifications;
using MediatR;

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
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        services.AddSingleton<IEventStoreService, EventStoreService>();
        services.AddSingleton<IEventSourcingRepository, EventSourcingRepository>();
    }

    private static void Repository(IServiceCollection services)
    {

    }

    private static void Services(IServiceCollection services)
    {

    }
}

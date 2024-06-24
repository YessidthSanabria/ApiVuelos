using FlightsHumano.Domain.Ports;
using FlightsHumano.Domain.Services;
using FlightsHumano.Infrastructure.Adapters;
using FlightsHumano.Infrastructure.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace FlightsHumano.Infrastructure.Extensions;

public static class AutoLoadServices
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        // generic repository
        services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));        
                        
        services.AddTransient(typeof(IReservaRepository), typeof(ReservaRepository));
        services.AddTransient(typeof(IDestinoRepository), typeof(DestinoRepository));
        services.AddTransient(typeof(IOrigenRespository), typeof(OrigenRespository));
        services.AddTransient(typeof(IVueloRepository), typeof(VueloRepository));
        services.AddTransient(typeof(IOutboxRepository), typeof(OutboxRepository));
        services.AddTransient(typeof(IEmailService), typeof(SendGridEmailService));
        services.AddScoped<SendGridEmailService>();
        services.AddScoped<MessageBrokerConsumerService>();


        // all services with domain service attribute, we can also do this "by convention",
        // naming services with suffix "Service" if decide to remove the domain service decorator
        var _services = AppDomain.CurrentDomain.GetAssemblies()
              .Where(assembly =>
              {
                  return (assembly.FullName is null) || assembly.FullName.Contains("Domain", StringComparison.InvariantCulture);
              })
              .SelectMany(s => s.GetTypes())
              .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(DomainServiceAttribute)));

        // Ditto, but repositories
        var _repositories = AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly =>
            {
                return (assembly.FullName is null) || assembly.FullName.Contains("Infrastructure", StringComparison.InvariantCulture);
            })
            .SelectMany(s => s.GetTypes())
            .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(RepositoryAttribute)));

        // svc
        foreach (var service in _services)
        {
            services.AddTransient(service);
        }

        // repos
        foreach (var repo in _repositories)
        {
            Type iface = repo.GetInterfaces().Single();
            services.AddTransient(iface, repo);
        }

        return services;
    }
}

using FlightsHumano.Domain.Ports;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace FlightsHumano.Domain.Services
{
    public class MessageBrokerPublishService:IHostedService
    {        
        private readonly IServiceProvider _serviceProvider;
        private readonly IBus _bus;
        private readonly ILogger<MessageBrokerPublishService> _logger;

        public MessageBrokerPublishService(IServiceProvider serviceProvider, IBus bus, ILogger<MessageBrokerPublishService> logger) 
        {            
            _serviceProvider = serviceProvider;
            _bus = bus;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var outboxRepository = scope.ServiceProvider.GetRequiredService<IOutboxRepository>();
                var mensajes = await outboxRepository.LeerOutboxPendientes();

                foreach (var mensaje in mensajes)
                {
                    _logger.LogInformation("Publicando mensaje: {MensajeId}, Contenido: {Contenido}", mensaje.Id, mensaje.Origen);
                    await _bus.Publish(mensaje, cancellationToken);
                }
            }
        }   

        public Task StopAsync(CancellationToken cancellationToken)
        {            
            return Task.CompletedTask;
        }
    }
}
   


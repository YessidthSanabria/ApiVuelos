using FlightsHumano.Domain.Ports;
using MassTransit;
using RabbitMQ.Client;
using System.Text;

namespace FlightsHumano.Domain.Services
{
    [DomainService]
    public class MessageRabbitService
    {
        private readonly IOutboxRepository _outboxRepository;

        public MessageRabbitService(IOutboxRepository outboxRepository)
        {
            _outboxRepository = outboxRepository;
        }    

        public async Task PublicarMensajeCola()
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host("rabbitmq://localhost:5672", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            await busControl.StartAsync();

            try
            {
                var mensajes= await _outboxRepository.LeerOutboxPendientes();



                Console.WriteLine("OrderSubmitted event published");
            }
            finally
            {
               
                await busControl.StopAsync();
            }


         

        }
    }
}

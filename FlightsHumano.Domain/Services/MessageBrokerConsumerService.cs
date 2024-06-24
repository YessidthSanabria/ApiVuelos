using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Ports;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FlightsHumano.Domain.Services
{
    public class MessageBrokerConsumerService: IConsumer<Outbox>
    {
        private readonly ILogger<MessageBrokerConsumerService> _logger;
        private readonly ConstruirMailService _construirMailService;
        private readonly SendGridEmailService _sendGridEmailService;
        private readonly IOutboxRepository _outboxRepository;

        public MessageBrokerConsumerService(ILogger<MessageBrokerConsumerService> logger, ConstruirMailService construirMailService, SendGridEmailService sendGridEmailService,
            IOutboxRepository outboxRepository)
        {
            _logger = logger;
            _construirMailService = construirMailService;
            _sendGridEmailService = sendGridEmailService;
            _outboxRepository = outboxRepository;
        }
        public async Task Consume(ConsumeContext<Outbox> context)
        {
            var mensaje = context.Message;
            _logger.LogInformation("Mensaje recibido: {MensajeId}, Contenido: {Contenido}", mensaje.Id, mensaje.Name);
                   
            var mensajeHtml = await _construirMailService.ConstruirCorreo(mensaje);

            var respuestaSendEmail = await _sendGridEmailService.SendEmailJetAsync(mensaje.Mail, mensaje.TipoOutbox, mensajeHtml);

            if (respuestaSendEmail.IsSuccessStatusCode)
            {
                await _outboxRepository.ActualizarEstadoEnvio(mensaje.Id);
            }
            
        }
    }
}

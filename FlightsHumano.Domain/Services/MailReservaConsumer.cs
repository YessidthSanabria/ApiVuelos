using FlightsHumano.Domain.Dtos;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsHumano.Domain.Services
{
    public class MailReservaConsumer : IConsumer<MailReservaDto>
    {
        public Task Consume(ConsumeContext<MailReservaDto> context)
        {
            var message = context.Message;
            Console.WriteLine($"Received message: To={message.Name}, Subject={message.FechaSalida}, Body={message.Name}");
            return Task.CompletedTask;
        }
    }
}

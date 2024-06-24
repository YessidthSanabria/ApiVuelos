using FlightsHumano.Application.Reserva.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FlightsHumano.Application.Reserva.Commands
{
    public record ActualizarReservaCommand(
       [Required] Guid Id,
       DateTime FechaSalida,
       int NumeroAsiento       
       ) : IRequest<Unit>;    
}

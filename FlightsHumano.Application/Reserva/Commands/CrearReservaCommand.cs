using FlightsHumano.Application.Reserva.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FlightsHumano.Application.Reserva.Commands
{
    public record CrearReservaCommand(
        [Required] DateTime FechaSalida,
        [Required] int NumeroAsiento,
        [Required] string NombreUsuario,
        [Required] string MailUsuario,
        [Required] Guid IdVuelo) : IRequest<CrearReservaDto>;

}

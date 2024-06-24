using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FlightsHumano.Application.Reserva.Commands
{
    public record EliminarReservaPorIdCommand(
        [Required] Guid id) : IRequest<Unit>;

}

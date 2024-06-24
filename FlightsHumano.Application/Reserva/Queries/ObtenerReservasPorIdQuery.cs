using FlightsHumano.Application.Reserva.Dto;
using MediatR;

namespace FlightsHumano.Application.Reserva.Queries
{
    public record ObtenerReservasPorIdQuery(Guid id) : IRequest<TodasReservaDto>;

}

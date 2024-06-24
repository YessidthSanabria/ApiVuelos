using FlightsHumano.Application.Reserva.Dto;
using MediatR;

namespace FlightsHumano.Application.Reserva.Queries
{
    public record ObtenerTodasReservasQuery() : IRequest<List<TodasReservaDto>>;

}

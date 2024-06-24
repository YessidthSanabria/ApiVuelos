using FlightsHumano.Application.Vuelos.Dtos;
using MediatR;

namespace FlightsHumano.Application.Vuelos.Queries
{
    public record ObtenerVuelosPorIdQuery(Guid id) : IRequest<TodosVuelosDto>;
}

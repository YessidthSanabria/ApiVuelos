using FlightsHumano.Application.Vuelos.Dtos;
using MediatR;

namespace FlightsHumano.Application.Vuelos.Queries
{
    public record ObtenerTodosVuelosQuery() : IRequest<List<TodosVuelosDto>>;

}

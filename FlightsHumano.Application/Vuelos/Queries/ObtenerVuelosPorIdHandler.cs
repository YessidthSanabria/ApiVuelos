using AutoMapper;
using FlightsHumano.Application.Reserva.Dto;
using FlightsHumano.Application.Reserva.Queries;
using FlightsHumano.Application.Vuelos.Dtos;
using FlightsHumano.Domain.Services;
using MediatR;

namespace FlightsHumano.Application.Vuelos.Queries
{
    public class ObtenerVuelosPorIdHandler : IRequestHandler<ObtenerVuelosPorIdQuery, TodosVuelosDto>
    {
        private readonly IMapper _mapper;
        private readonly VuelosService _vuelosService;

        public ObtenerVuelosPorIdHandler(IMapper mapper, VuelosService vuelosService)
        {
            _mapper = mapper;
            _vuelosService = vuelosService;
        }
        public async Task<TodosVuelosDto> Handle(ObtenerVuelosPorIdQuery request, CancellationToken cancellationToken)
        {
            var vuelosPorId = await _vuelosService.ObtenerVuelosPorId(request.id);
            return _mapper.Map<TodosVuelosDto>(vuelosPorId);
        }
    }
}
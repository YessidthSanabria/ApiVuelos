using AutoMapper;
using FlightsHumano.Application.Reserva.Dto;
using FlightsHumano.Application.Vuelos.Dtos;
using FlightsHumano.Domain.Services;
using MediatR;

namespace FlightsHumano.Application.Vuelos.Queries
{
    public class ObtenerTodosVuelosHandler : IRequestHandler<ObtenerTodosVuelosQuery, List<TodosVuelosDto>>
    {
        private readonly IMapper _mapper;
        private readonly VuelosService _vuelosService;

        public ObtenerTodosVuelosHandler(IMapper mapper, VuelosService vuelosService)
        {
            this._mapper = mapper;
            this._vuelosService = vuelosService;
        }
        public async Task<List<TodosVuelosDto>> Handle(ObtenerTodosVuelosQuery request, CancellationToken cancellationToken)
        {
            var vuelos = await _vuelosService.ObtenerasTodosVuelos();            

            return _mapper.Map<List<TodosVuelosDto>>(vuelos);
        }
    }

}

using AutoMapper;
using FlightsHumano.Application.Reserva.Dto;
using FlightsHumano.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FlightsHumano.Application.Reserva.Queries
{
    public class ObtenerReservasPorIdHandler : IRequestHandler<ObtenerReservasPorIdQuery, TodasReservaDto>
    {
        private readonly IMapper _mapper;
        private readonly ReservaService _reservaService;

        public ObtenerReservasPorIdHandler(IMapper mapper, ReservaService reservaService)
        {
            _mapper = mapper;
            _reservaService = reservaService;
        }
        public async Task<TodasReservaDto> Handle(ObtenerReservasPorIdQuery request, CancellationToken cancellationToken)
        {
            var reservasPorId = await _reservaService.ObtenerReservasPorId(request.id);
            return _mapper.Map<TodasReservaDto>(reservasPorId);
        }
    }
}

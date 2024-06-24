using AutoMapper;
using FlightsHumano.Application.Reserva.Dto;
using FlightsHumano.Domain.Services;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlightsHumano.Application.Reserva.Queries
{
    public class ObtenerTodasReservasHandler : IRequestHandler<ObtenerTodasReservasQuery, List<TodasReservaDto>>
    {
        private readonly IMapper _mapper;
        private readonly ReservaService _reservaService;
        private readonly MessageRabbitService _messageRabbitService;

        public ObtenerTodasReservasHandler(IMapper mapper, ReservaService reservaService, MessageRabbitService messageRabbitService)
        {
            _mapper = mapper;
            _reservaService = reservaService;
            _messageRabbitService = messageRabbitService;
        }
        public async Task<List<TodasReservaDto>> Handle(ObtenerTodasReservasQuery request, CancellationToken cancellationToken)
        {
            var reservas = await _reservaService.ObtenerTodasReservas();

            await _messageRabbitService.PublicarMensajeCola();

            return _mapper.Map<List<TodasReservaDto>>(reservas);
        }
    }
}

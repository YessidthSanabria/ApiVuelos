using AutoMapper;
using FlightsHumano.Application.Reserva.Dto;
using FlightsHumano.Application.Reserva.Dtos;
using FlightsHumano.Domain.Dtos;
using FlightsHumano.Domain.Services;
using MediatR;

namespace FlightsHumano.Application.Reserva.Commands
{
    public class ActualizarReservaHandler : IRequestHandler<ActualizarReservaCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ReservaService _reservaService;
        public ActualizarReservaHandler(IMapper mapper, ReservaService reservaService)
        {
            _mapper = mapper;
            _reservaService = reservaService;
        }

        public async Task<Unit> Handle(ActualizarReservaCommand request, CancellationToken cancellationToken)
        {
            var actualizarReserva = new ActualizarReservasDto(request.Id, request.FechaSalida, request.NumeroAsiento);
            var reserva = _mapper.Map<ActualizarReservaDto>(actualizarReserva);

            await _reservaService.ActualizarReserva(reserva);

            return Unit.Value;
        }
    }
}

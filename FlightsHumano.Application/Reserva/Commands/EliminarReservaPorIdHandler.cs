using AutoMapper;
using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Enums;
using FlightsHumano.Domain.Ports;
using FlightsHumano.Domain.Services;
using MediatR;

namespace FlightsHumano.Application.Reserva.Commands
{
    public class EliminarReservaPorIdHandler : IRequestHandler<EliminarReservaPorIdCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ReservaService _reservaService;
        private readonly VuelosService _vuelosService;
        private readonly IOutboxRepository _outboxRepository;

        public EliminarReservaPorIdHandler(IMapper mapper, ReservaService reservaService, VuelosService vuelosService, IOutboxRepository outboxRepository)
        {
            _mapper = mapper;
            _reservaService = reservaService;
            _vuelosService = vuelosService;
            _outboxRepository = outboxRepository;
        }

        public async Task<Unit> Handle(EliminarReservaPorIdCommand request, CancellationToken cancellationToken)
        {
            var reservasPorId = await _reservaService.ObtenerReservasPorId(request.id);

            await _reservaService.EliminarReservasPorId(request.id);

            var vuelo = await _vuelosService.ObtenerVuelosPorId(reservasPorId.IdVuelo);  
            
            var outboxMessage = new Outbox(
                reservasPorId.NombreUsuario, 
                reservasPorId.Id, 
                reservasPorId.FechaSalida, 
                vuelo.NombreOrigen,
                vuelo.NombreDestino,
                reservasPorId.NumeroAsiento,
                ConstTipoOutbox.CANCELAR_RESERVA_OUTBOX.ToString(),
                false,
                reservasPorId.MailUsuario);

            await _outboxRepository.CrearOutbox(outboxMessage);

            return Unit.Value;
        }
    }
}

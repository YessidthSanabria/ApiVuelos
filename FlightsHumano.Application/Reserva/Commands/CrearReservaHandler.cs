using AutoMapper;
using FlightsHumano.Application.Reserva.Dto;
using FlightsHumano.Domain.Dtos;
using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Enums;
using FlightsHumano.Domain.Ports;
using FlightsHumano.Domain.Services;
using MediatR;
using System.Security.Principal;

namespace FlightsHumano.Application.Reserva.Commands
{
    public class CrearReservaHandler : IRequestHandler<CrearReservaCommand, CrearReservaDto>
    {
        private readonly IMapper _mapper;
        private readonly ReservaService _reservaService;
        private readonly IOutboxRepository _outboxRepository;
        private readonly VuelosService _vuelosService;        

        public CrearReservaHandler(IMapper mapper, ReservaService reservaService, IOutboxRepository outboxRepository, VuelosService vuelosService)
        {
            _mapper = mapper;
            _reservaService = reservaService;
            _outboxRepository = outboxRepository;
            _vuelosService = vuelosService;            
        }

        public async Task<CrearReservaDto> Handle(CrearReservaCommand request, CancellationToken cancellationToken)
        {            
            var Reserva = new Domain.Entities.Reserva(request.FechaSalida, request.NumeroAsiento, request.NombreUsuario, request.MailUsuario, request.IdVuelo);

            Domain.Entities.Reserva reservaCreada = await _reservaService.CrearReserva(Reserva);

           

            var vuelo = await _vuelosService.ObtenerVuelosPorId(reservaCreada.IdVuelo);
            var outboxMessage = new Outbox(
                reservaCreada.NombreUsuario,
                reservaCreada.Id, 
                reservaCreada.FechaSalida, 
                vuelo.NombreOrigen, 
                vuelo.NombreDestino,
                reservaCreada.NumeroAsiento,
                ConstTipoOutbox.CREAR_RESERVA_OUTBOX.ToString(),
                false,
                reservaCreada.MailUsuario);

            await _outboxRepository.CrearOutbox(outboxMessage);         

            return _mapper.Map<CrearReservaDto>(reservaCreada);
        }
    }
}

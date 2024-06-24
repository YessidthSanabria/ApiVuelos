using FlightsHumano.Domain.Dtos;
using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Ports;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FlightsHumano.Domain.Services
{
    [DomainService]
    public class ReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            this._reservaRepository = reservaRepository;
        }

        public async Task<IEnumerable<Reserva>> ObtenerTodasReservas()
        {
            return await _reservaRepository.ObtenerReservas();
        }
        public async Task<Reserva> ObtenerReservasPorId(Guid id)
        {
            return await _reservaRepository.ObtenerReservasPorId(id);
        }
        public async Task EliminarReservasPorId(Guid id)
        {
            await _reservaRepository.EliminarReservasPorId(id);
        }
        public async Task<Reserva> CrearReserva(Reserva reserva)
        {
            return await _reservaRepository.CrearReserva(reserva);
        } 

        public async Task ActualizarReserva(ActualizarReservaDto actualizarReservaDto)
        {
            await _reservaRepository.ActualizarReserva(actualizarReservaDto);
        }
    }
}

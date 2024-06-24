using FlightsHumano.Domain.Dtos;
using FlightsHumano.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FlightsHumano.Domain.Ports
{
    public interface IReservaRepository
    {
        public Task<IEnumerable<Reserva>> ObtenerReservas();
        public Task<Reserva> ObtenerReservasPorId(Guid id);
        public Task EliminarReservasPorId(Guid id);
        public Task<Reserva> CrearReserva(Reserva reserva);
        public Task ActualizarReserva(ActualizarReservaDto actualizarReservaDto);
    }
}

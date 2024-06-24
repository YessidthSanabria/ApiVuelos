using FlightsHumano.Domain.Dtos;
using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Ports;
using FlightsHumano.Infrastructure.Ports;
using System.Diagnostics.Metrics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FlightsHumano.Infrastructure.Adapters
{
    public class ReservaRepository : IReservaRepository
    {
        readonly IRepository<Reserva> _dataSource;
        public ReservaRepository(IRepository<Reserva> dataSource) => _dataSource = dataSource 
            ?? throw new ArgumentNullException(nameof(dataSource));
               

        public async Task<IEnumerable<Reserva>> ObtenerReservas()
        {
            Func<IQueryable<Reserva>, IOrderedQueryable<Reserva>> orderBy = (reserva => reserva.OrderBy(order => order.NombreUsuario));
            return await _dataSource.GetManyAsync(null,orderBy);            
        }

        public async Task<Reserva> ObtenerReservasPorId(Guid id)
        {
            return await _dataSource.GetOneAsync(id);
            
        }
        public async Task EliminarReservasPorId(Guid id)
        {
            var reserva = await _dataSource.GetOneAsync(id);
            if(reserva != null)
            {
                _dataSource.DeleteAsync(reserva);
                
            }
        }
        public async Task<Reserva> CrearReserva(Reserva reserva)
        {
            try {
                var reservaCreada = await _dataSource.AddAsync(reserva);
                return reservaCreada;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public async Task ActualizarReserva(ActualizarReservaDto actualizarReservaDto)
        {
          var reserva  = await _dataSource.GetOneAsync(actualizarReservaDto.Id);
            if (reserva != null)
            {
                reserva.FechaSalida = actualizarReservaDto.FechaSalida;
                reserva.NumeroAsiento = actualizarReservaDto.NumeroAsiento;
                
                _dataSource.UpdateAsync(reserva);
            }

        }
    }
}

using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Ports;
using FlightsHumano.Infrastructure.Ports;

namespace FlightsHumano.Infrastructure.Adapters
{
    public class VueloRepository : IVueloRepository
    {

        readonly IRepository<Vuelos> _dataSource;
        public VueloRepository(IRepository<Vuelos> dataSource) => _dataSource = dataSource
            ?? throw new ArgumentNullException(nameof(dataSource));

        public async Task<IEnumerable<Vuelos>> ObtenerVuelos()
        {
            Func<IQueryable<Vuelos>, IOrderedQueryable<Vuelos>> orderBy = (reserva => reserva.OrderBy(order => order.IdVuelo));
            return await _dataSource.GetManyAsync(null, orderBy);            
        }

        public async Task<Vuelos> ObtenerVuelosPorId(Guid id)
        {
            return await _dataSource.GetOneAsync(id);
        }      
    }
}

using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Ports;
using FlightsHumano.Infrastructure.Ports;

namespace FlightsHumano.Infrastructure.Adapters
{
    public class DestinoRepository : IDestinoRepository
    {

        readonly IRepository<Destino> _dataSource;
        public DestinoRepository(IRepository<Destino> dataSource) => _dataSource = dataSource
            ?? throw new ArgumentNullException(nameof(dataSource));
        public async Task<Destino> ObtenerDestinosPorId(Guid id)
        {
            return await _dataSource.GetOneAsync(id);
        }
    }
}

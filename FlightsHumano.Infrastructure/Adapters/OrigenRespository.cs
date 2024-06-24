using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Ports;
using FlightsHumano.Infrastructure.Ports;

namespace FlightsHumano.Infrastructure.Adapters
{
    internal class OrigenRespository : IOrigenRespository
    {

        readonly IRepository<Origen> _dataSource;
        public OrigenRespository(IRepository<Origen> dataSource) => _dataSource = dataSource
            ?? throw new ArgumentNullException(nameof(dataSource));
        public async Task<Origen> ObtenerOrigenPorId(Guid id)
        {
            return await _dataSource.GetOneAsync(id);
        }
    }
}

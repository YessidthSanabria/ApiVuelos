using FlightsHumano.Domain.Entities;

namespace FlightsHumano.Domain.Ports
{
    public interface IOrigenRespository
    {
        public Task<Origen> ObtenerOrigenPorId(Guid id);
    }
}

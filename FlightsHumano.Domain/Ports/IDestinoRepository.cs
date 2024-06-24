using FlightsHumano.Domain.Entities;

namespace FlightsHumano.Domain.Ports
{
    public interface IDestinoRepository
    {
        public Task<Destino> ObtenerDestinosPorId(Guid id);
    }
}

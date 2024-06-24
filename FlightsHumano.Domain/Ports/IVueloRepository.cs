using FlightsHumano.Domain.Entities;

namespace FlightsHumano.Domain.Ports
{
    public interface IVueloRepository
    {
        public Task<IEnumerable<Vuelos>> ObtenerVuelos();
        public Task<Vuelos> ObtenerVuelosPorId(Guid id);
    }
}

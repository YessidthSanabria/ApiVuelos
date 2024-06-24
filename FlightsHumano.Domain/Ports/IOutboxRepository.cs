using FlightsHumano.Domain.Entities;

namespace FlightsHumano.Domain.Ports
{
    public interface IOutboxRepository
    {
        public Task<Outbox> CrearOutbox(Outbox outbox);
        public Task<IEnumerable<Outbox>> LeerOutboxPendientes();
        public Task ActualizarEstadoEnvio(Guid id);
    }
}

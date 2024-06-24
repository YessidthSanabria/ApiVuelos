using FlightsHumano.Domain.Dtos;
using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Ports;
using FlightsHumano.Infrastructure.Ports;

namespace FlightsHumano.Infrastructure.Adapters
{
    public class OutboxRepository : IOutboxRepository
    {
        private readonly IRepository<Outbox> _dataSource;

        public OutboxRepository(IRepository<Outbox> dataSource)
        {
            this._dataSource = dataSource;
        }        

        public async Task<Outbox> CrearOutbox(Outbox outbox)
        {
            var outboxCreado = await _dataSource.AddAsync(outbox);
            return outboxCreado;
        }

        public async Task<IEnumerable<Outbox>> LeerOutboxPendientes()
        {
            Func<IQueryable<Outbox>, IOrderedQueryable<Outbox>> orderBy = reserva => reserva.Where(r=> !r.Enviado).OrderBy(order => order.IdReserva);
            return await _dataSource.GetManyAsync(null, orderBy);
        }
        public async Task ActualizarEstadoEnvio(Guid id)
        {
            var outbox = await _dataSource.GetOneAsync(id);
            if (outbox != null)
            {
                outbox.Enviado = true;                

                _dataSource.UpdateAsync(outbox);
            }           
        }
    }
}

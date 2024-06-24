using FlightsHumano.Domain.Entities;

namespace FlightsHumano.Domain.Tests.VueloTest.DataBuilder
{
    public class VuelosBuilder
    {
        private int _id = 0;
        private Guid _idDestino = Guid.NewGuid();
        private Guid _idOrigen = Guid.NewGuid();
        private DateTime _fechaSalida = DateTime.Now;
        private DateTime _fechaLlegada = DateTime.Now.AddHours(2);

        public VuelosBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public VuelosBuilder WithIdDestino(Guid idDestino)
        {
            _idDestino = idDestino;
            return this;
        }

        public VuelosBuilder WithIdOrigen(Guid idOrigen)
        {
            _idOrigen = idOrigen;
            return this;
        }

        public VuelosBuilder WithFechaSalida(DateTime fechaSalida)
        {
            _fechaSalida = fechaSalida;
            return this;
        }

        public VuelosBuilder WithFechaLlegada(DateTime fechaLlegada)
        {
            _fechaLlegada = fechaLlegada;
            return this;
        }

        public Vuelos Build()
        {
            return new Domain.Entities.Vuelos(_id, _idOrigen, _idDestino, _fechaSalida, _fechaLlegada);
        }
    }
}

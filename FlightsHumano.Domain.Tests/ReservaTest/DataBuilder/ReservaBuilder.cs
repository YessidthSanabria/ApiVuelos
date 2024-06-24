using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Tests.VueloTest.DataBuilder;

namespace FlightsHumano.Domain.Tests.ReservaTest.DataBuilder
{
    public class ReservaBuilder
    {

        private int _idReserva = 0;
        private DateTime _fechaSalida  = DateTime.Now;
        private int _numeroAsiento = 1;
        private string _nombreUsuario = "Usuario";
        private string _mailUsuario = "Usuario@Usuario.com";
        private Guid _idVuelo = Guid.NewGuid();

        public ReservaBuilder WithIdReserva(int idReserva)
        {
            _idReserva = idReserva;
            return this;
        }
        public ReservaBuilder WithFechaLlegada(DateTime fechaSalida)
        {
            _fechaSalida = fechaSalida;
            return this;
        }

        public ReservaBuilder WithNumeroAsiento(int numeroAsiento)
        {
            _numeroAsiento = numeroAsiento;
            return this;
        }
        public ReservaBuilder WithNombreUsuario(string nombreUsuario)
        {
            _nombreUsuario = nombreUsuario;
            return this;
        }
        public ReservaBuilder WithMailUsuario(string mailUsuario)
        {
            _mailUsuario = mailUsuario;
            return this;
        }
        public ReservaBuilder WithIdVuelo(Guid idVuelo)
        {
            _idVuelo = idVuelo;
            return this;
        }

        public Reserva Build()
        {
            return new Domain.Entities.Reserva(_fechaSalida, _numeroAsiento, _nombreUsuario, _mailUsuario, _idVuelo);
        }

       
    }
}

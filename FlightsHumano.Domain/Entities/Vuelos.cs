namespace FlightsHumano.Domain.Entities
{
    public class Vuelos: DomainEntity
    {
        public Vuelos(int idVuelo, Guid idOrigen, Guid idDestino, DateTime fechaSalida, DateTime fechaLlegada)
        {
            IdVuelo = idVuelo;
            IdOrigen = idOrigen;
            IdDestino = idDestino;
            FechaSalida = fechaSalida;
            FechaLlegada = fechaLlegada;
        }

        public int IdVuelo { get; set; }
        public Guid IdOrigen { get; set; }
        public Guid IdDestino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
    }
}

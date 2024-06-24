namespace FlightsHumano.Domain.Entities
{
    public class Reserva : DomainEntity
    {
        public int IdReserva { get; set; }
        public DateTime FechaSalida { get; set; }
        public int NumeroAsiento { get; set; }
        public string NombreUsuario { get; set; }
        public string MailUsuario { get; set; }
        public Guid IdVuelo { get; set; }

        public Reserva(DateTime fechaSalida, int numeroAsiento, string nombreUsuario, string mailUsuario, Guid idVuelo)
        {
            FechaSalida = fechaSalida;
            NumeroAsiento = numeroAsiento;
            NombreUsuario = nombreUsuario;
            MailUsuario = mailUsuario;
            IdVuelo = idVuelo;            
        }
    }
}

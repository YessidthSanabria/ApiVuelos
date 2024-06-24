namespace FlightsHumano.Application.Reserva.Dtos
{
    public class ActualizarReservasDto
    {
        public Guid Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public int NumeroAsiento { get; set; }

        public ActualizarReservasDto(Guid id, DateTime fechaSalida, int numeroAsiento)
        {
            Id = id;
            FechaSalida = fechaSalida;
            NumeroAsiento = numeroAsiento;            
        }
    }
}

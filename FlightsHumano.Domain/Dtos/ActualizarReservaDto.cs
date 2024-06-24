namespace FlightsHumano.Domain.Dtos
{
    public class ActualizarReservaDto
    {
        public Guid Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public int NumeroAsiento { get; set; }
    }
}

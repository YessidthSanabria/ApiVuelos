namespace FlightsHumano.Application.Reserva.Dto
{
    public class TodasReservaDto
    {
        public Guid Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public int NumeroAsiento { get; set; }
        public string NombreUsuario { get; set; }
        public string MailUsuario { get; set; }
        public Guid IdVuelo { get; set; }
    }
}

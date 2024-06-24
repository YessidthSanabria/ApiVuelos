namespace FlightsHumano.Application.Vuelos.Dtos
{
    public class TodosVuelosDto
    {
        public Guid Id { get; set; }
        public string NombreOrigen { get; set; }
        public string NombreDestino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
    }
}

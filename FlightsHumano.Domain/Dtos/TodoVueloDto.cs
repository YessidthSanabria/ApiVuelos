namespace FlightsHumano.Domain.Dtos
{
    public class TodoVueloDto
    {
        public Guid Id { get; set; }
        public string NombreOrigen { get; set; }
        public string NombreDestino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public TodoVueloDto() { }
        public TodoVueloDto(Guid id, string nombreOrigen , string nombreDestino, DateTime fechaSalida, DateTime fechaLlegada)
        {
            Id = id;
            NombreOrigen = nombreOrigen;
            NombreDestino = nombreDestino;
            FechaSalida = fechaSalida;
            FechaLlegada = fechaLlegada;
        }        
    }
}

namespace FlightsHumano.Domain.Entities
{
    public class Outbox : DomainEntity
    {
        public string Name { get; set; }
        public Guid IdReserva { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int NumeroAsiento { get; set; }
        public string TipoOutbox { get; set; }
        public string Mail { get; set; }
        public bool Enviado { get; set; }        

        public Outbox(string name, Guid idReserva, DateTime fechaSalida, string origen, string destino, int numeroAsiento, string tipoOutbox, bool enviado, string mail)
        {
            Name = name;
            IdReserva = idReserva;
            FechaSalida = fechaSalida;
            Origen = origen;
            Destino = destino;
            NumeroAsiento = numeroAsiento;
            TipoOutbox = tipoOutbox;
            Enviado = enviado;
            Mail = mail;
        }
    }
}

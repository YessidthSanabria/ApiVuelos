﻿namespace FlightsHumano.Domain.Dtos
{
    public class MailReservaDto
    {        

        public string Name { get; set; }
        public Guid IdReserva { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int NumeroAsiento { get; set; }

        public MailReservaDto(string name, Guid idReserva, DateTime fechaSalida, string origen, string destino, int numeroAsiento)
        {
            Name = name;
            IdReserva = idReserva;
            FechaSalida = fechaSalida;
            Origen = origen;
            Destino = destino;
            NumeroAsiento = numeroAsiento;
        }

    }
}

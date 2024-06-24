using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsHumano.Application.Reserva.Dto
{
    public class CrearReservaDto
    {
        public Guid id { get; set; }
        public DateTime FechaSalida { get; set; }
        public int NumeroAsiento { get; set; }
        public string NombreUsuario { get; set; }
        public string MailUsuario { get; set; }
        public Guid IdVuelo { get; set; }
    }
}

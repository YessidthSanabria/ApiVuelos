using FlightsHumano.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsHumano.Domain.Tests.ReservaTest.DataBuilder
{
    public class ActualizarReservaDtoBuilder
    {
        
        private Guid _id = Guid.NewGuid();
        private int _numeroAsiento = 10;
        private DateTime _fechaSalida = DateTime.Now;

        public ActualizarReservaDtoBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public ActualizarReservaDtoBuilder WithNumeroAsiento(int numeroAsiento)
        {
            _numeroAsiento = numeroAsiento;
            return this;
        }

        public ActualizarReservaDtoBuilder WithFechaSalida(DateTime fechaSalida)
        {
            _fechaSalida = fechaSalida;
            return this;
        }

        public ActualizarReservaDto Build()
        {
            return new ActualizarReservaDto
            {
                Id = _id,
                FechaSalida= _fechaSalida,
                NumeroAsiento= _numeroAsiento                
            };
        }
    }
}

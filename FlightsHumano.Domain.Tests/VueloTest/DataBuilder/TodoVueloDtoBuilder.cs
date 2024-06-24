using FlightsHumano.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsHumano.Domain.Tests.VueloTest.DataBuilder
{
    public class TodoVueloDtoBuilder
    {
        private Guid _id = Guid.NewGuid();
        private string _nombreOrigen = "DefaultOrigen";
        private string _nombreDestino = "DefaultDestino";
        private DateTime _fechaSalida = DateTime.Now;
        private DateTime _fechaLlegada = DateTime.Now.AddHours(2);

        public TodoVueloDtoBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }
        public TodoVueloDtoBuilder WithNombreOrigen(string nombreOrigen)
        {
            _nombreOrigen = nombreOrigen;
            return this;
        }
        public TodoVueloDtoBuilder WithNombreDestino(string nombreDestino)
        {
            _nombreDestino = nombreDestino;
            return this;
        }

        public TodoVueloDtoBuilder WithFechaSalida(DateTime fechaSalida)
        {
            _fechaSalida = fechaSalida;
            return this;
        }

        public TodoVueloDtoBuilder WithFechaLlegada(DateTime fechaLlegada)
        {
            _fechaLlegada = fechaLlegada;
            return this;
        }

        public TodoVueloDto Build()
        {
            return new TodoVueloDto(_id, _nombreOrigen, _nombreDestino, _fechaSalida, _fechaLlegada);
        }
    }
}

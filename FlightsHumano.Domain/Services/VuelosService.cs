using FlightsHumano.Domain.Dtos;
using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Ports;

namespace FlightsHumano.Domain.Services
{
    [DomainService]
    public class VuelosService
    {
        private readonly IVueloRepository _vueloRepository;
        private readonly IDestinoRepository _destinoRepository;
        private readonly IOrigenRespository _origenRespository;

        public VuelosService(IVueloRepository vueloRepository, IDestinoRepository destinoRepository, IOrigenRespository origenRespository)
        {
            _vueloRepository = vueloRepository;
            _destinoRepository = destinoRepository;
            _origenRespository = origenRespository;
        }

        public async Task<List<TodoVueloDto>> ObtenerasTodosVuelos()
        {
            var vueloRta = new TodoVueloDto();
            var vueloRtaList = new List<TodoVueloDto>();
            var Vuelos = await _vueloRepository.ObtenerVuelos();

            if(Vuelos.Any())
            {
                foreach (var vuelo in Vuelos)
                {
                    vueloRta = await RetornarOrigenDestino(vuelo);
                    vueloRtaList.Add(vueloRta);
                }               
            }
            return vueloRtaList;
            
        }
        private async Task<TodoVueloDto> RetornarOrigenDestino(Vuelos vuelos)
        {
            var returnVuelo = new TodoVueloDto();

            var destino = await _destinoRepository.ObtenerDestinosPorId(vuelos.IdDestino);
            var origen = await _origenRespository.ObtenerOrigenPorId(vuelos.IdOrigen);

            returnVuelo = new TodoVueloDto(vuelos.Id, origen.NombreOrigen, destino.NombreDestino, vuelos.FechaSalida, vuelos.FechaLlegada);

            return returnVuelo;
        }

        public async Task<TodoVueloDto> ObtenerVuelosPorId(Guid id)
        {
            var vueloRta = new TodoVueloDto();
            var Vuelos = await _vueloRepository.ObtenerVuelosPorId(id);

            if (Vuelos != null)
            {
                vueloRta = await RetornarOrigenDestino(Vuelos);
            }

            return vueloRta;
                                   
        }

     
    }
}

using AutoMapper;
using FlightsHumano.Application.Vuelos.Dtos;

namespace FlightsHumano.Application.Vuelos
{
    public class VuelosProfile : Profile
    {
        public VuelosProfile()
        {
            CreateMap<FlightsHumano.Domain.Dtos.TodoVueloDto, TodosVuelosDto>().ReverseMap();
        }

    }
}

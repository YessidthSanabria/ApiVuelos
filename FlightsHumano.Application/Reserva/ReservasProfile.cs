using AutoMapper;
using FlightsHumano.Application.Reserva.Dto;
using FlightsHumano.Application.Reserva.Dtos;

namespace FlightsHumano.Application.Reserva
{
    public class ReservasProfile : Profile
    {
        public ReservasProfile()
        {
            CreateMap<FlightsHumano.Domain.Entities.Reserva, TodasReservaDto>().ReverseMap();
            CreateMap<FlightsHumano.Domain.Entities.Reserva, CrearReservaDto>().ReverseMap();
            CreateMap<FlightsHumano.Domain.Dtos.ActualizarReservaDto, ActualizarReservasDto>().ReverseMap();
        }
    }
}

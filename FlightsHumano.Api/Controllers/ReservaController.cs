using FlightsHumano.Application.Reserva.Commands;
using FlightsHumano.Application.Reserva.Dto;
using FlightsHumano.Application.Reserva.Queries;
using FlightsHumano.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightsHumano.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController: ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<List<TodasReservaDto>> ObtenerTodasReservas()
        {
            return await _mediator.Send(new ObtenerTodasReservasQuery());
        }

        [HttpGet("id")]
        public async Task<TodasReservaDto> ObtenerReservasPorId(Guid id)
        {
            return await _mediator.Send(new ObtenerReservasPorIdQuery(id));
        }

        [HttpDelete]
        public async Task EliminarReservasPorId(Guid id)
        {
            await _mediator.Send(new EliminarReservaPorIdCommand(id));
        }

        [HttpPost]
        public async Task<CrearReservaDto> CrearReserva(CrearReservaCommand crearReservaCommand)
        {
            return await _mediator.Send(crearReservaCommand);
        }
        [HttpPut]
        public async Task ActualizarReserva(ActualizarReservaCommand actualizarReservaCommand)
        {
            await _mediator.Send(actualizarReservaCommand);
        }

    }
}

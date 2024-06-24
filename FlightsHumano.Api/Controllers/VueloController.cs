using FlightsHumano.Application.Vuelos.Dtos;
using FlightsHumano.Application.Vuelos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightsHumano.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VueloController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<List<TodosVuelosDto>> ObtenerTodosVuelos()
        {
            return await _mediator.Send(new ObtenerTodosVuelosQuery());
        }

        [HttpGet("id")]
        public async Task<TodosVuelosDto> ObtenerVuelosPorId(Guid id)
        {
            return await _mediator.Send(new ObtenerVuelosPorIdQuery(id));
        }
    }
}

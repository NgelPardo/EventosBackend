using Eventos.Application.Eventos.CrearEvento;
using Eventos.Application.Eventos.DeleteEvento;
using Eventos.Application.Eventos.GetEvento;
using Eventos.Application.Eventos.UpdateEvento;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Eventos
{
    [ApiController]
    [Route("api/eventos")]
    public class EventosController : ControllerBase
    {
        private readonly ISender _sender;

        public EventosController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("disponibles/{id}")]
        public async Task<IActionResult> GetEventos(
            Guid id,
            CancellationToken cancellationToken)
        {
            var query = new GetEventosQuery(id);
            var resultados = await _sender.Send(query, cancellationToken);

            return Ok(resultados.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvento(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var query = new GetEventoQuery(id);
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetEventosByUser(
            Guid id,
            CancellationToken cancellationToken
            )
        {
            var query = new GetEventosByUserQuery(id);
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CrearEvento(
            EventoRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new CrearEventoCommand(
                request.idUsuario,
                request.nombre,
                request.descripcion,
                request.ubicacion,
                request.capacidadMaxima,
                request.fechaEvento,
                request.fechaCreacion
            );

            var resultado = await _sender.Send(command, cancellationToken);

            if(resultado.IsFailure)
            {
                return BadRequest(resultado.Error);
            }

            return CreatedAtAction(nameof(GetEvento), new { id = resultado.Value }, resultado.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEvento(
            Guid id,
            [FromBody] ActualizarEventoRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new UpdateEventoCommand(
                id,
                request.capacidadMaxima,
                request.fechaEvento,
                request.ubicacion
            );

            var result = await _sender.Send(command,cancellationToken);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEvento(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var command = new DeleteEventoCommand(id);

            var result = await _sender.Send(command,cancellationToken);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }
    }
}

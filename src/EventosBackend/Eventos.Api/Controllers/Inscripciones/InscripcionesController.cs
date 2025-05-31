using Eventos.Application.Inscripciones.GetInscripcion;
using Eventos.Application.Inscripciones.InscribirEvento;
using Eventos.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Inscripciones
{
    [ApiController]
    [Route("api/inscripciones")]
    public class InscripcionesController : ControllerBase
    {
        private readonly ISender _sender;

        public InscripcionesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInscripcion(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            GetInscripcionQuery query = new GetInscripcionQuery(id);
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetInscripcionesByUser(
            Guid id,
            CancellationToken cancellationToken
            )
        {
            GetInscripcionesByUserQuery query = new GetInscripcionesByUserQuery(id);
            var resultados = await _sender.Send(query, cancellationToken);

            return resultados.IsSuccess ? Ok(resultados.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> InscribirEvento(
            InscripcionRequest request,
            CancellationToken cancellationToken
        )
        {
            InscribirEventoCommand command = new InscribirEventoCommand(
                request.usuarioId,
                request.eventoId,
                request.fechaCreacion
            );

            var resultado = await _sender.Send( command, cancellationToken );
        
            if(resultado.IsFailure)
            {
                return BadRequest(resultado.Error);
            }

            return CreatedAtAction(nameof(GetInscripcion), new { id = resultado.Value }, resultado.Value);
        }
    }
}

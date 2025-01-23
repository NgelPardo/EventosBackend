using Eventos.Application.Inscripciones.GetInscripcion;
using Eventos.Application.Inscripciones.InscribirEvento;
using MediatR;
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
            var query = new GetInscripcionQuery(id);
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> InscribirEvento(
            InscripcionRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new InscribirEventoCommand(
                request.userId,
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

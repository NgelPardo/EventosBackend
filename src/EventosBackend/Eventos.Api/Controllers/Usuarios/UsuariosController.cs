using Eventos.Application.Usuarios.CrearUsuario;
using Eventos.Application.Usuarios.GetUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Usuarios
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly ISender _sender;
        public UsuariosController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var query = new GetUsuarioQuery(id);
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario(
            UsuarioRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new CrearUsuarioCommand(
                request.nombre,
                request.apellido,
                request.email,
                request.fechaCreacion
            );

            var resultado = await _sender.Send( command, cancellationToken );

            if( resultado.IsFailure )
            {
                return BadRequest(resultado.Error );
            }

            return CreatedAtAction(nameof(GetUsuario), new { id = resultado.Value }, resultado.Value);
        }

    }
}

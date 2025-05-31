using Eventos.Application.Usuarios.GetUsuario;
using Eventos.Application.Usuarios.LoginUsuario;
using Eventos.Application.Usuarios.RegistrarUsuario;
using Eventos.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginUserRequest request,
            CancellationToken cancellationToken
        )
        {
            LoginCommand command = new LoginCommand(request.email, request.password);

            Result result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return Unauthorized(result.Error);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            GetUsuarioQuery query = new GetUsuarioQuery(id);
            Result resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado) : NotFound();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUsuario(
            [FromBody] RegisterUserRequest request,
            CancellationToken cancellationToken
        )
        {
            RegistrarUsuarioCommand command = new RegistrarUsuarioCommand(
                request.nombre,
                request.apellido,
                request.email,
                request.password,
                request.fechaCreacion
            );

            var resultado = await _sender.Send( command, cancellationToken );

            if( resultado.IsFailure )
            {
                return BadRequest(resultado.Error);
            }

            return CreatedAtAction(nameof(GetUsuario), new { id = resultado.Value }, resultado.Value);
        }

    }
}

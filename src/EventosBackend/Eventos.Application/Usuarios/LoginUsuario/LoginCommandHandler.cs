using BCrypt.Net;
using Eventos.Application.Abstractions.Authentication;
using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;
using Eventos.Domain.Entities.Users;
using Eventos.Domain.Entities.Usuarios;
using Eventos.Domain.Ports;

namespace Eventos.Application.Usuarios.LoginUsuario
{
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IUsuarioRepository usuarioRepository, IJwtProvider jwtProvider)
        {
            _usuarioRepository = usuarioRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //1. Verificar que el usuario existe
            Usuario usuario = await _usuarioRepository.GetByEmailAsync(request.Email, cancellationToken);

            if (usuario is null) 
            {
                return Result.Failure<LoginResponse>(UsuarioErrors.NotFound);
            }

            //2. Validar password
            if(!BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
            {
                return Result.Failure<LoginResponse>(UsuarioErrors.InvalidCredentials);
            }

            //3. Generar JWT
            string token = await _jwtProvider.GenerateTokenAsync(usuario);

            LoginResponse response = new LoginResponse(usuario.Id, usuario.Nombre, usuario.Apellido, token);

            return Result.Success(response);
        }
    }
}

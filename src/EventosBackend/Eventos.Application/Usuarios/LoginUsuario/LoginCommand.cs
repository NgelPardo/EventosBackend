using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Usuarios.LoginUsuario
{
    public record LoginCommand(string Email, string Password) : ICommand<LoginResponse>;
}

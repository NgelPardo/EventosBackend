using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Usuarios.RegistrarUsuario
{
    public sealed record RegistrarUsuarioCommand(
        string Nombre,
        string Apellido,
        string Email,
        string Password,
        DateTime FechaCreacion
    ) : ICommand<Guid>;
}

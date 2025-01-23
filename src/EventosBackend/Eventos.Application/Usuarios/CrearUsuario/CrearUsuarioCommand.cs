using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Usuarios.CrearUsuario
{
    public record CrearUsuarioCommand(
        string Nombre,
        string Apellido,
        string Email,
        DateTime FechaCreacion
    ) : ICommand<Guid>;
}

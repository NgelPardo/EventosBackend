using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Usuarios.GetUsuario
{
    public sealed record GetUsuarioQuery(Guid UsuarioId) : IQuery<UsuarioResponse>
    {
    }
}

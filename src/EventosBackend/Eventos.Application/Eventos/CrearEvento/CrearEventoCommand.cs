using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Eventos.CrearEvento
{
    public record CrearEventoCommand(
        Guid IdUsuario,
        string Nombre,
        string Descripcion,
        string Ubicacion,
        int CapacidadMaxima,
        DateTime FechaEvento,
        DateTime FechaCreacion
    ) : ICommand<Guid>;
}

using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Eventos.UpdateEvento
{
    public record UpdateEventoCommand
    (
        Guid Id,
        int CapacidadMaxima,
        DateTime FechaEvento,
        string Ubicacion
    ) : ICommand<Guid>;
}

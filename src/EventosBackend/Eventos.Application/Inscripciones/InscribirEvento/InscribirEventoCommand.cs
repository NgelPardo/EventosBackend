using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Inscripciones.InscribirEvento
{
    public record InscribirEventoCommand(
        Guid UsuarioId,
        Guid EventoId,
        DateTime FechaCreacion
    ) : ICommand<Guid>;
}

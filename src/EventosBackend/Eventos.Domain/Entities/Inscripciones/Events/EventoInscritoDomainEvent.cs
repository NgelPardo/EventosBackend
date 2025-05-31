using Eventos.Domain.Abstractions;

namespace Eventos.Domain.Entities.Inscripciones.Events
{
    public sealed record EventoInscritoDomainEvent(Guid EventoId, Guid UserId) : IDomainEvent;
}

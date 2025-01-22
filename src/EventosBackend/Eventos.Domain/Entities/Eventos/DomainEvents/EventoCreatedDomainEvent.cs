using Eventos.Domain.Abstractions;

namespace Eventos.Domain.Entities.Eventos.Events
{
    public sealed record EventoCreatedDomainEvent(Guid EventoId) : IDomainEvent
    {
    }
}

using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Eventos.GetEvento
{
    public sealed record GetEventosQuery(Guid UserId) : IQuery<IReadOnlyList<EventoResponse>>;
    
}

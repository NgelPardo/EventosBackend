using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Eventos.GetEvento
{
    public sealed record GetEventosByUserQuery(Guid IdUser) : IQuery<IReadOnlyList<EventoResponse>>;
 
}

using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Eventos.GetEvento
{
    public sealed record GetEventoQuery(Guid EventoId) : IQuery<EventoResponse>
    {
    }
}

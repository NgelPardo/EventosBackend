
using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Eventos.DeleteEvento
{
    public sealed record DeleteEventoCommand(Guid Id) : ICommand<Guid>;
}

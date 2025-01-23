using Eventos.Domain.Entities.Eventos.Events;
using MediatR;

namespace Eventos.Application.Eventos.CrearEvento
{
    internal sealed class CrearEventoDomainEventHandler
        : INotificationHandler<EventoCreatedDomainEvent>
    {
        public async Task Handle(EventoCreatedDomainEvent notification, CancellationToken cancellationToken)
        {            
            try
            {
                // Código del evento que se dispara cuando se crea un evento
                throw new NotImplementedException("Esta funcionalidad no está implementada aún.");
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            await Task.CompletedTask;
        }
    }
}

using Eventos.Domain.Entities.Eventos;

namespace Eventos.Domain.Puertos
{
    public interface IEventoRepository
    {
        Task<Evento?> GetyIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<int> GetMaxCapacityEvent(Guid id, CancellationToken cancellationToken = default);
        void Add(Evento entity);
    }
}

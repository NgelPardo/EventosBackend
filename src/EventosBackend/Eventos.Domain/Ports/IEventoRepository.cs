using Eventos.Domain.Entities.Eventos;

namespace Eventos.Domain.Ports
{
    public interface IEventoRepository
    {
        Task<Evento?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        //Task<int> GetMaxCapacityEvent(Guid id, CancellationToken cancellationToken = default);
        Task<List<Evento>> GetListEventsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task Update(Evento evento, CancellationToken cancellationToken = default);
        void Remove(Evento evento);
        void Add(Evento entity);
    }
}

using Eventos.Domain.Entities.Inscripciones;

namespace Eventos.Domain.Ports
{
    public interface IInscripcionRepository
    {
        Task<Inscripcion?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Inscripcion>> GetEventsByUserAsync(Guid userId, CancellationToken cancellationToken = default);
        void Add(Inscripcion inscripcion);  
    }
}

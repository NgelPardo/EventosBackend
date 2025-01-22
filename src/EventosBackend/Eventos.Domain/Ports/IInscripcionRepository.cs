using Eventos.Domain.Entities.Inscripciones;

namespace Eventos.Domain.Ports
{
    public interface IInscripcionRepository
    {
        Task<Inscripcion?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Add(Inscripcion inscripcion);  
    }
}

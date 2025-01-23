using Eventos.Domain.Entities.Inscripciones;
using Eventos.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infrastructure.Repositories
{
    internal sealed class InscripcionRepository : Repository<Inscripcion>, IInscripcionRepository
    {
        public InscripcionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Inscripcion>> GetEventsByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<Inscripcion>()
                .Where(x => x.UsuarioId == userId)
                .ToListAsync(cancellationToken);
        }
    }
}

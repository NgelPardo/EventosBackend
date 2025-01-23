using Eventos.Domain.Entities.Eventos;
using Eventos.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infrastructure.Repositories
{
    internal sealed class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Evento>> GetListEventsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<Evento>()
                .Where(x => x.IdUsuario == userId)
                .ToListAsync(cancellationToken);
        }

        public void Remove(Evento evento)
        {
            DbContext.Remove(evento);
        }

        public  async Task Update(Evento evento, CancellationToken cancellationToken = default)
        {
            DbContext.Set<Evento>().Update(evento);
            await Task.CompletedTask;
        }
    }
}

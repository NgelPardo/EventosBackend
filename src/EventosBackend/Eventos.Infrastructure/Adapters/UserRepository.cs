using Eventos.Domain.Entities.Users;
using Eventos.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<bool> IsUserExists(string email, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<Usuario>()
                .AnyAsync(x => x.Email == email);
        }
    }
}

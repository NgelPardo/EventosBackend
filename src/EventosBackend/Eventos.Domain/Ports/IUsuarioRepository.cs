using Eventos.Domain.Entities.Users;

namespace Eventos.Domain.Ports
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByIdAsync(Guid? id, CancellationToken cancellationToken = default);
        Task<bool> IsUserExists(
            string email,
            CancellationToken cancellationToken = default
        );
        void Add(Usuario usuario);
        Task<Usuario?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}

using Eventos.Domain.Entities.Users;

namespace Eventos.Application.Abstractions.Authentication
{
    public interface IJwtProvider
    {
        Task<string> GenerateTokenAsync(Usuario usuario);
    }
}

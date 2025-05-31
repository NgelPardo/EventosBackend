namespace Eventos.Api.Controllers.Usuarios
{
    public record RegisterUserRequest(
        string nombre,
        string apellido,
        string email,
        string password,
        DateTime fechaCreacion);
}

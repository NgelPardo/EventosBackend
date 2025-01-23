namespace Eventos.Api.Controllers.Usuarios
{
    public sealed record UsuarioRequest(
        string nombre,
        string apellido,
        string email,
        DateTime fechaCreacion
    );
}

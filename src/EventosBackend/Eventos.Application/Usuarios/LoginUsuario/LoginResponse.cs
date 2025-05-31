namespace Eventos.Application.Usuarios.LoginUsuario
{
    public sealed class LoginResponse
    {
        public LoginResponse(Guid id, string? nombre, string? apellido, string? token)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Token = token;
        }

        public Guid Id { get; init; }
        public string? Nombre { get; init; }
        public string? Apellido { get; init; }
        public string? Token { get; init; }
    }
}

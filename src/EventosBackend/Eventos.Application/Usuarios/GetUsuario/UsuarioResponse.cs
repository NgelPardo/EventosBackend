namespace Eventos.Application.Usuarios.GetUsuario
{
    public sealed class UsuarioResponse
    {
        public Guid Id { get; init; }
        public string? Nombre { get; init; }
        public string? Apellido { get; init; }
        public string? Email { get; init; }
        public DateTime? FechaCreacion {  get; init; }  
    }
}

namespace Eventos.Application.Inscripciones.GetInscripcion
{
    public sealed class InscripcionesUsuarioResponse
    {
        public Guid Id { get; init; }
        public Guid? UsuarioId { get; init; }
        public Guid? EventoId { get; init; }
        public DateTime? FechaCreacion { get; init; }
        public string? Nombre { get; init; }
        public string? Descripcion { get; init; }
        public string? Ubicacion { get; init; }
        public DateTime? FechaEvento { get; init; }
    }
}

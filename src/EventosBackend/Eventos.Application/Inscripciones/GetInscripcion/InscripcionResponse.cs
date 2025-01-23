namespace Eventos.Application.Inscripciones.GetInscripcion
{
    public sealed class InscripcionResponse
    {
        public Guid Id { get; init; }
        public Guid? UsuarioId { get; init; }
        public Guid? EventoId { get; init; }
        public DateTime? FechaCreacion {  get; init; } 
    }
}

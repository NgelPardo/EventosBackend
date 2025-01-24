namespace Eventos.Application.Eventos.GetEvento
{
    public sealed class EventoResponse
    {
        public Guid Id { get; init; }
        public string? Nombre { get; init; }
        public string? Descripcion { get; init; }
        public string? Ubicacion { get; init; }
        public int? CapacidadMaxima { get; init; }
        public int? CapacidadActual {  get; init; }
        public DateTime? FechaEvento { get; init; }
    }
}

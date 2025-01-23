namespace Eventos.Api.Controllers.Eventos
{
    public sealed record EventoRequest
    (
        Guid idUsuario,
        string nombre,
        string descripcion,
        string ubicacion,
        int capacidadMaxima,
        int capacidadActual,
        DateTime fechaEvento,
        DateTime fechaCreacion
    );
}

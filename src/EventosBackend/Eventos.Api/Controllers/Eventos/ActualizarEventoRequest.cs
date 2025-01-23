namespace Eventos.Api.Controllers.Eventos
{
    public sealed record ActualizarEventoRequest
    (
        int capacidadMaxima,
        DateTime fechaEvento,
        string ubicacion
    );
}

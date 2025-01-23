namespace Eventos.Api.Controllers.Inscripciones
{
    public sealed record InscripcionRequest(
        Guid eventoId,
        Guid userId,
        DateTime fechaCreacion
    );
}

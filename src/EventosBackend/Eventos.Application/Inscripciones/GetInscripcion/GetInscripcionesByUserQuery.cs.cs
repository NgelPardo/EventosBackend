using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Inscripciones.GetInscripcion
{
    public sealed record GetInscripcionesByUserQuery(Guid UserId) : IQuery<IReadOnlyList<InscripcionesUsuarioResponse>>;
}

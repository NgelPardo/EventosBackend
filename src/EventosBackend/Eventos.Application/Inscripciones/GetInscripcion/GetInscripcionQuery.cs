using Eventos.Application.Abstractions.Messaging;

namespace Eventos.Application.Inscripciones.GetInscripcion
{
    public sealed record GetInscripcionQuery(Guid InscripcionId) : IQuery<InscripcionResponse>
    {
    }
}

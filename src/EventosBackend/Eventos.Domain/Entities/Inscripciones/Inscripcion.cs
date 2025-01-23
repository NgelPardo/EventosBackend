using Eventos.Domain.Abstractions;

namespace Eventos.Domain.Entities.Inscripciones
{
    public sealed class Inscripcion : Entity
    {
        private Inscripcion() { }
        private Inscripcion(
            Guid id,
            Guid usuarioId,
            Guid eventoId,
            DateTime fechaCreacion
        ) : base(id ,fechaCreacion) 
        {
            UsuarioId = usuarioId;
            EventoId = eventoId;
        }

        public Guid? UsuarioId {  get; private set; }
        public Guid? EventoId { get; private set; }
    
        public static Inscripcion Inscribir(
            Guid usuarioId,
            Guid eventoId,
            DateTime fechaCreacion
        )
        {
            var inscripcion = new Inscripcion(Guid.NewGuid(), usuarioId, eventoId, fechaCreacion);
            return inscripcion;
        }
    }
}

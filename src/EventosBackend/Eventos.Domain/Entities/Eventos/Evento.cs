using Eventos.Domain.Abstractions;
using Eventos.Domain.Entities.Eventos.Events;

namespace Eventos.Domain.Entities.Eventos
{
    public sealed class Evento : Entity
    {
        public Evento(
            Guid id,
            string nombre,
            string descripcion,
            DateTime fechaCreacion,
            int capacidadMaxima
            ) : base(id, fechaCreacion) 
        { 
            Nombre = nombre;
            Descripcion = descripcion;
            CapacidadMaxima = capacidadMaxima;
        }
        public string? Nombre { get; private set; }
        public string? Descripcion { get; private set; }
        public string? Ubicacion { get; private set; }
        public int? CapacidadMaxima { get; private set; } 

        public static Evento Create(
            string nombre,
            string descripcion,
            DateTime fechaCreacion,
            int capacidadMaxima
        )
        {
            var evento = new Evento(Guid.NewGuid(), nombre, descripcion, fechaCreacion, capacidadMaxima);
            evento.RaiseDomainEvent(new EventoCreatedDomainEvent(evento.Id));
            return evento; 
        }

    }
}

using Eventos.Domain.Abstractions;
using Eventos.Domain.Entities.Eventos.Events;

namespace Eventos.Domain.Entities.Eventos
{
    public sealed class Evento : Entity
    {
        private Evento() { }
        private Evento(
            Guid id,
            Guid idUsuario,
            string nombre,
            string descripcion,
            string ubicacion,
            int capacidadMaxima,
            int capacidadActual,
            DateTime fechaEvento,
            DateTime fechaCreacion
            ) : base(id, fechaCreacion) 
        { 
            IdUsuario = idUsuario;
            Nombre = nombre;
            Descripcion = descripcion;
            Ubicacion = ubicacion;
            CapacidadMaxima = capacidadMaxima;
            CapacidadActual = capacidadActual;
            FechaEvento = fechaEvento;
        }
        public Guid? IdUsuario {  get; private set; } 
        public string? Nombre { get; private set; }
        public string? Descripcion { get; private set; }
        public string? Ubicacion { get; private set; }
        public int? CapacidadMaxima { get; private set; } 
        public int? CapacidadActual { get; private set; }
        public DateTime? FechaEvento { get; private set; }

        public static Evento Create(
            Guid idUsuario,
            string nombre,
            string descripcion,
            string ubicacion,
            int capacidadMaxima,
            DateTime fechaEvento,
            DateTime fechaCreacion
        )
        {
            const int capacidadInicial = 0;
            Evento evento = new(Guid.NewGuid(), idUsuario, nombre, descripcion, ubicacion, capacidadMaxima, capacidadInicial, fechaEvento, fechaCreacion);
            evento.RaiseDomainEvent(new EventoCreatedDomainEvent(evento.Id));
            return evento; 
        }

        public void Actualizar(
            int? capacidadMaxima,
            int? capacidadActual,
            DateTime? fechaEvento,
            string? ubicacion
        )
        {
            CapacidadMaxima = capacidadMaxima;
            CapacidadActual = capacidadActual;
            FechaEvento = fechaEvento;
            Ubicacion = ubicacion;
        }

    }
}

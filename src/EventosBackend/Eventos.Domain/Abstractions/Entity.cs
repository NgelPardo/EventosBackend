namespace Eventos.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity() { }

        public readonly List<IDomainEvent> _domainEvents = new();
        protected Entity(
            Guid id,
            DateTime fechaCreacion
            ) 
        {
            Id = id;
            FechaCreacion = fechaCreacion;
        }

        public Guid Id { get; init; }
        public DateTime FechaCreacion { get; init; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents() 
        { 
            return _domainEvents.ToList();
        }
        
        protected void RaiseDomainEvent(IDomainEvent domainEvents) 
        {
            _domainEvents.Add(domainEvents);
        }
    }
}

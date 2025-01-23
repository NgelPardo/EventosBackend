using Eventos.Domain.Abstractions;

namespace Eventos.Domain.Entities.Users
{
    public sealed class Usuario : Entity
    {
        private Usuario() { }
        private Usuario(
            Guid id,
            string nombre,
            string apellido,
            string email,
            DateTime fechaCreacion
            ) : base(id, fechaCreacion)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }

        public string? Nombre { get; private set; }
        public string? Apellido { get; private set; }
        public string? Email { get; private set; }

        //ocultando logica del constructor por seguridad - encapsulacion
        public static Usuario Create(
            string nombre,
            string apellido,
            string email,
            DateTime fechaCreacion
        ) 
        {
            var user = new Usuario(Guid.NewGuid(), nombre, apellido, email, fechaCreacion);
            return user;
        }
    }
}

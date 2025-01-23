using Eventos.Domain.Abstractions;

namespace Eventos.Domain.Entities.Usuarios
{
    public static class UsuarioErrors
    {
        public static Error NotFound = new Error(
            "Usuario.NotFound",
            "Usuario no encontrado."
        );

        public static Error AlreadyExists = new Error(
            "Usuario.AlreadyExists",
            "El usuario ya existe"
        );
    }
}

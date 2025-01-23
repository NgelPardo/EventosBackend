using Eventos.Domain.Abstractions;

namespace Eventos.Domain.Entities.Eventos
{
    public static class EventoErrors
    {
        public static Error NotFound = new Error(
            "Evento.NotFound",
            "Evento no encontrado"
        );

        public static Error CurrentUsers = new Error(
            "Evento.CurrentUsers",
            "No puedes eliminar un evento con usuarios actualmente inscritos"
        );
    }
}

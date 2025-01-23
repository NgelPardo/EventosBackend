using Eventos.Domain.Abstractions;

namespace Eventos.Domain.Entities.Inscripciones
{
    public static class InscripcionErrors
    {
        public static Error OwnerEvent = new Error(
            "Incripcion.Owner",
            "La inscripcion a eventos propios no esta permitida."
        );

        public static Error UserEventLimitExceeded = new Error(
            "Inscripcion.UserEventLimitExceeded",
            "No puedes inscribirte en mas de 3 eventos diferentes al mismo tiempo."
        );

        public static Error EventCapacityLimitError = new Error(
            "Inscripcion.EventCapacityLimitError",
            "No puedes inscribirte en este evento porque se ha alcanzado la capacidad máxima de asistentes."
        );

        public static Error AlreadyRegisteredForEvent = new Error(
            "Inscripcion.AlreadyRegisteredForEvent",
            "Ya estas inscrito en este evento."
        );
    }
}

using Eventos.Application.Abstractions.Messaging;
using Eventos.Application.Eventos.GetEvento;
using Eventos.Domain.Abstractions;
using Eventos.Domain.Entities.Eventos;
using Eventos.Domain.Entities.Inscripciones;
using Eventos.Domain.Entities.Usuarios;
using Eventos.Domain.Ports;

namespace Eventos.Application.Inscripciones.InscribirEvento
{
    internal sealed class InscribirEventoCommandHandler : ICommandHandler<InscribirEventoCommand, Guid>
    {
        private readonly IInscripcionRepository _inscripcionRepository;
        private readonly IUsuarioRepository _userRepository;
        private readonly IEventoRepository _eventoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InscribirEventoCommandHandler(
            IInscripcionRepository inscripcionRepository, 
            IUsuarioRepository usuarioRepository, 
            IEventoRepository eventoRepository, 
            IUnitOfWork unitOfWork)
        {
            _inscripcionRepository = inscripcionRepository;
            _userRepository = usuarioRepository;
            _eventoRepository = eventoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(
            InscribirEventoCommand request, 
            CancellationToken cancellationToken
            )
        {
            var user = await _userRepository.GetByIdAsync(request.UsuarioId, cancellationToken);

            if (user is null)
            {
                return Result.Failure<Guid>(UsuarioErrors.NotFound);
            }

            var evento = await _eventoRepository.GetByIdAsync(request.EventoId);

            if (evento.IdUsuario == user.Id)
            {
                //Dueño del evento se inscribe a su evento
                return Result.Failure<Guid>(InscripcionErrors.OwnerEvent);
            }

            var eventosByUserResult = await _inscripcionRepository.GetEventsByUserAsync(user.Id, cancellationToken);

            if (eventosByUserResult.Count >= 3)
            {
                // Máximo de eventos permitidos
                return Result.Failure<Guid>(InscripcionErrors.UserEventLimitExceeded);
            }
            

            evento.Actualizar(
                evento.CapacidadMaxima,
                evento.CapacidadActual + 1,
                evento.FechaEvento,
                evento.Ubicacion
            );

            //Actualizar capacidad actual evento 
            await _eventoRepository.Update(evento);

            var inscripcion = Inscripcion.Inscribir(
                request.UsuarioId, 
                request.EventoId, 
                request.FechaCreacion
            );

            _inscripcionRepository.Add( inscripcion );

            await _unitOfWork.SaveChangesAsync();

            return inscripcion.Id!;
        }
    }
}

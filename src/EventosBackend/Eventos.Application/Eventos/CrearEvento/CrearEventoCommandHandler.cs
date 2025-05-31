using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;
using Eventos.Domain.Entities.Eventos;
using Eventos.Domain.Entities.Users;
using Eventos.Domain.Entities.Usuarios;
using Eventos.Domain.Ports;

namespace Eventos.Application.Eventos.CrearEvento
{
    internal sealed class CrearEventoCommandHandler
        : ICommandHandler<CrearEventoCommand, Guid>
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IEventoRepository _eventoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearEventoCommandHandler(
            IUsuarioRepository userRepository,
            IEventoRepository eventoRepository, 
            IUnitOfWork unitOfWork
            )
        {
            _userRepository = userRepository;
            _eventoRepository = eventoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CrearEventoCommand request, CancellationToken cancellationToken)
        {
            Usuario user = await _userRepository.GetByIdAsync(request.IdUsuario, cancellationToken);

            if(user is null)
            {
                return Result.Failure<Guid>(UsuarioErrors.NotFound);
            }

            Evento evento = Evento.Create(
                request.IdUsuario,
                request.Nombre,
                request.Descripcion,
                request.Ubicacion,
                request.CapacidadMaxima,
                request.FechaEvento,
                DateTime.UtcNow
            );

            _eventoRepository.Add( evento );

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return evento.Id;
        }
    }
}

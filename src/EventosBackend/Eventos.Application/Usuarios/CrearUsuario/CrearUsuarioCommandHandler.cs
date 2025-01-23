using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;
using Eventos.Domain.Entities.Users;
using Eventos.Domain.Entities.Usuarios;
using Eventos.Domain.Ports;

namespace Eventos.Application.Usuarios.CrearUsuario
{
    internal sealed class CrearUsuarioCommandHandler
        : ICommandHandler<CrearUsuarioCommand, Guid>
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearUsuarioCommandHandler(
            IUsuarioRepository userRepository, 
            IUnitOfWork unitOfWork
            )
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(
            CrearUsuarioCommand request, 
            CancellationToken cancellationToken
            )
        {
            var userExists = await _userRepository.IsUserExists(request.Email);

            if (userExists)
            {
                return Result.Failure<Guid>(UsuarioErrors.AlreadyExists);
            }

            var user = Usuario.Create(
                request.Nombre,
                request.Apellido,
                request.Email,
                DateTime.UtcNow
            );

            _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync();

            return user.Id!;
        }
    }
}

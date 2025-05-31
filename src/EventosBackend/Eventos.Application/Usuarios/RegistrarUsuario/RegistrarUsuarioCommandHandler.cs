using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;
using Eventos.Domain.Entities.Users;
using Eventos.Domain.Entities.Usuarios;
using Eventos.Domain.Ports;

namespace Eventos.Application.Usuarios.RegistrarUsuario
{
    internal sealed class RegistrarUsuarioCommandHandler
        : ICommandHandler<RegistrarUsuarioCommand, Guid>
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarUsuarioCommandHandler(
            IUsuarioRepository userRepository, 
            IUnitOfWork unitOfWork
            )
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(
            RegistrarUsuarioCommand request, 
            CancellationToken cancellationToken
            )
        {
            bool userExists = await _userRepository.IsUserExists(request.Email);

            if (userExists)
            {
                return Result.Failure<Guid>(UsuarioErrors.AlreadyExists);
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            Usuario user = Usuario.Create(
                request.Nombre,
                request.Apellido,
                request.Email,
                passwordHash,
                DateTime.UtcNow
            );

            _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync();

            return user.Id!;
        }
    }
}

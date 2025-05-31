using FluentValidation;

namespace Eventos.Application.Usuarios.RegistrarUsuario
{
    internal sealed class RegistrarUsuarioCommandValidator : AbstractValidator<RegistrarUsuarioCommand>
    {
        public RegistrarUsuarioCommandValidator()
        {
            RuleFor(c => c.Nombre).NotEmpty().WithMessage("El nombre no puede ser nulo");
            RuleFor(c => c.Apellido).NotEmpty().WithMessage("Los apellidos no pueden ser nulo");
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Password).NotEmpty().MinimumLength(5); 
        }
    }
}

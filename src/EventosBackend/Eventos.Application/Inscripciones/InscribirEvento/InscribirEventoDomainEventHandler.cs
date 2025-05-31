using Eventos.Application.Abstractions.Email;
using Eventos.Domain.Entities.Inscripciones.Events;
using Eventos.Domain.Ports;
using MediatR;

namespace Eventos.Application.Inscripciones.InscribirEvento
{
    internal sealed class InscribirEventoDomainEventHandler : INotificationHandler<EventoInscritoDomainEvent>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailService _emailService;

        public InscribirEventoDomainEventHandler(IEventoRepository eventoRepository, IUsuarioRepository usuarioRepository, IEmailService emailService)
        {
            _eventoRepository = eventoRepository;
            _usuarioRepository = usuarioRepository;
            _emailService = emailService;
        }

        public async Task Handle(
            EventoInscritoDomainEvent notification, 
            CancellationToken cancellationToken
            )
        {
            var evento = await _eventoRepository
                .GetByIdAsync(notification.EventoId, cancellationToken);

            if(evento is null)
            {
                return;
            }

            var user = await _usuarioRepository
                .GetByIdAsync(notification.UserId, cancellationToken);

            if(user is null)
            {
                return;
            }

            _emailService.Send(
                user.Email!,
                "Evento inscrito",
                "Te has inscrito a un nuevo evento"
            );
        }
    }
}

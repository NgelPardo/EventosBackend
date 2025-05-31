using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;
using Eventos.Domain.Entities.Eventos;
using Eventos.Domain.Ports;

namespace Eventos.Application.Eventos.UpdateEvento
{
    internal class UpdateEventoCommandHandler : ICommandHandler<UpdateEventoCommand, Guid>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUnitOfWork _unitOfwork;

        public UpdateEventoCommandHandler(IEventoRepository eventoRepository, IUnitOfWork unitOfwork)
        {
            _eventoRepository = eventoRepository;
            _unitOfwork = unitOfwork;
        }

        public async Task<Result<Guid>> Handle(UpdateEventoCommand request, CancellationToken cancellationToken)
        {
            Evento evento = await _eventoRepository.GetByIdAsync(request.Id);

            if ( evento is null)
            {
                return Result.Failure<Guid>(EventoErrors.NotFound);
            }

            evento.Actualizar(
                request.CapacidadMaxima,
                evento.CapacidadActual,
                request.FechaEvento,
                request.Ubicacion
            );

            await _eventoRepository.Update(evento, cancellationToken);

            await _unitOfwork.SaveChangesAsync();

            return evento.Id!;
        }
    }
}

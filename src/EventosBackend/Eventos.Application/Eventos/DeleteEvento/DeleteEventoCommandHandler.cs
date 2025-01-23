using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;
using Eventos.Domain.Entities.Eventos;
using Eventos.Domain.Ports;

namespace Eventos.Application.Eventos.DeleteEvento
{
    internal sealed class DeleteEventoCommandHandler : ICommandHandler<DeleteEventoCommand, Guid>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEventoCommandHandler(IEventoRepository eventoRepository, IUnitOfWork unitOfWork)
        {
            _eventoRepository = eventoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(DeleteEventoCommand request, CancellationToken cancellationToken)
        {
            var evento = await _eventoRepository.GetByIdAsync(request.Id);

            if (evento is null)
            {
                return Result.Failure<Guid>(EventoErrors.NotFound);
            }

            if (evento.CapacidadActual != 0)
            {
                return Result.Failure<Guid>(EventoErrors.CurrentUsers);
            }

            _eventoRepository.Remove(evento);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(evento.Id);
        }
    }
}

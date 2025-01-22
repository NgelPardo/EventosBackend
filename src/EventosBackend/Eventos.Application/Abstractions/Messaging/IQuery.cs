using Eventos.Domain.Abstractions;
using MediatR;

namespace Eventos.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}

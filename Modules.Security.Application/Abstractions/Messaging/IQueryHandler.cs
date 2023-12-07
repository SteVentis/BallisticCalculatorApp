using MediatR;
using Modules.Security.Domain.Shared;

namespace Modules.Security.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResult<TResponse>> where TQuery : IQuery<TResponse>
{
}

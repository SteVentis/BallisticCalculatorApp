using MediatR;
using Modules.Security.Domain.Shared;

namespace Modules.Security.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<TResult<TResponse>>
{

}
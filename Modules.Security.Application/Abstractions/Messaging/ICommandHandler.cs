using MediatR;
using Modules.Security.Domain.Shared;

namespace Modules.Security.Application.Abstractions.Messaging;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResult<TResponse>> where TCommand : ICommand<TResponse>
{

}
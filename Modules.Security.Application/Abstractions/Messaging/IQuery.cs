using MediatR;
using Modules.Security.Domain.Shared;

namespace Modules.Security.Application.Abstractions.Messaging;

public interface IQuery<TRsponse> : IRequest<TResult<TRsponse>> 
{
}

using Modules.Security.Application.Abstractions.AuthProviders;
using Modules.Security.Application.Abstractions.Messaging;
using Modules.Security.Domain.Shared;

namespace Modules.Security.Application.AuthService.Commands.RefreshToken
{
    internal sealed class RefreshTokenCommandHandler : ICommandHandler<RefreshTokenCommand, TokenResponse>
    {
        private readonly IJwtProvider _jwtProvider;

        public RefreshTokenCommandHandler(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }

        public async Task<TResult<TokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var tokenResponse = await _jwtProvider.VerifyAndGenerateTokenAsync(request.TokenRequest);

            return TResult<TokenResponse>.Success(tokenResponse);
        }
    }
}

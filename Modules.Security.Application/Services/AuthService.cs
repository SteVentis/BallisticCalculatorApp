using Modules.Security.Application.Abstractions;
using Modules.Security.Application.Dtos;
using Modules.Security.Domain.Shared;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Application.Abstractions.Authentication;
using AutoMapper;
using Modules.Security.Domain.Models;

namespace Modules.Security.Application.Services;

public sealed class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtProvider _jwtProvider;
    private readonly IMapper _mapper;
    public AuthService(
        IJwtProvider jwtProvider, 
        IUserRepository userRepo, 
        IMapper mapper)
    {
        _jwtProvider = jwtProvider;
        _userRepo = userRepo;
        _mapper = mapper;
    }

    public async Task<TResult<TokenResponse>> Login(UserLoginForm userLogin)
    {
        var user = await _userRepo.FindExistedUserByEmailAsync(userLogin.Username);

        if (user is null)
        {
            // Error

            return null!;
        }

        var isPasswordValid = await _userRepo.CheckPasswordAsync(user, userLogin.Password);

        if (!isPasswordValid)
        {
            // Error

            return null!;
        }

        TokenResponse tokenResponse = await _jwtProvider.GenerateJwtTokenAsync(user, null!);

        return TResult<TokenResponse>.Success(tokenResponse);
    }

    public async Task<TResult<TokenResponse>> RefreshToken(TokenRequest tokenRequest)
    {
        var tokenResponse = await _jwtProvider.VerifyAndGenerateTokenAsync(tokenRequest);

        return TResult<TokenResponse>.Success(tokenResponse);
    }

    public async Task<Result> Register(UserRegistrationForm registerUser)
    {
        var checkIfUserExists = await _userRepo.FindExistedUserByEmailAsync(registerUser.Email);

        if (checkIfUserExists is not null) 
        {
            // Error

            return null!;
        }

        var userToBeAdded = _mapper.Map<User>(registerUser);

        var result = await _userRepo.CreateUserAsync(userToBeAdded, registerUser.Password);

        if (!result.Succeeded)
        {
            return null!;
        }

        return Result.Success();
    }
}

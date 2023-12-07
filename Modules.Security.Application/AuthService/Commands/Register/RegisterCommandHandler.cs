using AutoMapper;
using Modules.Security.Application.Abstractions.Messaging;
using Modules.Security.Domain.Models;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Domain.Shared;


namespace Modules.Security.Application.AuthService.Commands.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand>
{
    private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(
        IUserRepository userRepo, 
        IMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }

    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var checkIfUserExists = await _userRepo.FindExistedUserByEmailAsync(request.UserRegistration.Email);

        if (checkIfUserExists is not null)
        {
            // Error

            return null!;
        }

        var userToBeAdded = _mapper.Map<User>(request.UserRegistration);

        var result = await _userRepo.CreateUserAsync(userToBeAdded, request.UserRegistration.Password);

        if (!result.Succeeded)
        {
            return null!;
        }

        return Result.Success();
    }
}

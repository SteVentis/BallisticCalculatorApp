using AutoMapper;
using Modules.Security.Application.Abstractions.AuthProviders;
using Modules.Security.Application.Abstractions.Messaging;
using Modules.Security.Domain.Errors;
using Modules.Security.Domain.Models;
using Modules.Security.Domain.Repositories.Interfaces;
using Modules.Security.Domain.Shared;


namespace Modules.Security.Application.AuthService.Commands.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, EmailToken>
{
    private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;
    private readonly IEmailProvider _emailProvider;

    public RegisterCommandHandler(
        IUserRepository userRepo, 
        IMapper mapper,
        IEmailProvider emailProvider)
    {
        _userRepo = userRepo;
        _mapper = mapper;
        _emailProvider = emailProvider;
    }

    public async Task<TResult<EmailToken>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var checkIfUserExists = await _userRepo.FindExistedUserByEmailAsync(request.UserRegistration.Email);

        EmailToken tokenResponse = null!;

        if (checkIfUserExists is not null)
        {
            return TResult<EmailToken>.Failure(RegisterError.UserExists, tokenResponse);
        }

        var userToBeAdded = _mapper.Map<User>(request.UserRegistration);

        var result = await _userRepo.CreateUserAsync(userToBeAdded, request.UserRegistration.Password);

        if (!result.Succeeded)
        {
            return TResult<EmailToken>.Failure(RegisterError.CannotRegister, tokenResponse);
        }

        tokenResponse = new EmailToken
        {
            EmailAddress = request.UserRegistration.Email,
            Token = await _emailProvider.GenerateEmailConfirmationTokenAsync(userToBeAdded)
        };

        var confirmationLink = "";

        await _emailProvider.SendEmailMessageAsync(request.UserRegistration.UserName, 
                                                   request.UserRegistration.Email, 
                                                   "Confirmation email link", 
                                                   confirmationLink, 
                                                   null!);
        await _userRepo.AddUserToRole(userToBeAdded);

        return TResult<EmailToken>.Success(tokenResponse);
    }
}

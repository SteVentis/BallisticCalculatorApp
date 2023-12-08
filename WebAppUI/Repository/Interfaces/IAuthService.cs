using Modules.Security.Domain.Dtos;
using Modules.Security.Domain.Shared;

namespace WebAppUI.Repository.Interfaces;

public interface IAuthService
{
    Task<Result> RegisterUser(UserRegistrationForm userRegistration);
}

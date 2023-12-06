using AutoMapper;
using Modules.Security.Application.Dtos;
using Modules.Security.Domain.Models;

namespace Modules.Security.Application.Mapping;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRegistrationForm, User>();
    }
}

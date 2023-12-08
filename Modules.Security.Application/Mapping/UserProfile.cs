using AutoMapper;
using Modules.Security.Domain.Dtos;
using Modules.Security.Domain.Models;

namespace Modules.Security.Application.Mapping;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRegistrationForm, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
    }
}

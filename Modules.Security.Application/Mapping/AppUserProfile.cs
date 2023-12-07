using AutoMapper;
using Modules.Security.Application.Dtos;
using Modules.Security.Domain.Models;

namespace Modules.Security.Application.Mapping;

public sealed class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<UserRegistrationForm, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
    }
}

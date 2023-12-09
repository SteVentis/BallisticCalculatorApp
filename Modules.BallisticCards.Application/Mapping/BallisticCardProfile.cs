using AutoMapper;
using Modules.BallisticCards.Domain.Dtos;
using Modules.BallisticCards.Domain.Models;
using Newtonsoft.Json;

namespace Modules.BallisticCards.Application.Mapping;

public class BallisticCardProfile : Profile
{
    public BallisticCardProfile()
    {
        CreateMap<BallisticCardDto, BallisticCard>().ForMember(model => model.TrajectoryValuesJson,
           opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.TrajectoryValues, Formatting.Indented)));

        CreateMap<BallisticCard, BallisticCardDto>().ForMember(model => model.TrajectoryValues,
            opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<TrajectoryValues>>(src.TrajectoryValuesJson)));

    }
}

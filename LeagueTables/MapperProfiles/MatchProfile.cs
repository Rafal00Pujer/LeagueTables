using AutoMapper;
using LeagueTables.Data.Entities;
using LeagueTables.Models.Match;

namespace LeagueTables.MapperProfiles;

public class MatchProfile : Profile
{
    public MatchProfile()
    {
        CreateMap<MatchEntity, MatchModel>()
            .ForMember(m => m.Scores,
                o => o.MapFrom(s => s.TeamsEntries));
    }
}

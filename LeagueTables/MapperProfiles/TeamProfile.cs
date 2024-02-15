using AutoMapper;
using LeagueTables.Data.Entities;
using LeagueTables.Models.Table;
using LeagueTables.Models.Team;

namespace LeagueTables.MapperProfiles;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<TeamTableScoreEntity, TeamTableScoreModel>()
            /*.ForMember(d => d.TeamName, o => o.MapFrom(s => s.Team.Name))*/;
    }
}

using AutoMapper;
using LeagueTables.Data.Entities;
using LeagueTables.Models.Team;

namespace LeagueTables.MapperProfiles;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<TeamTableScoreEntity, TeamTableScoreModel>();

        CreateMap<TeamMatchEntryEntity, TeamMatchScoreModel>();
    }
}

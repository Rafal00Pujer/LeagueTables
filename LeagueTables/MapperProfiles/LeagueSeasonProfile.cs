using AutoMapper;
using LeagueTables.Data.Entities;
using LeagueTables.Models.LeagueSeason;

namespace LeagueTables.MapperProfiles;

public class LeagueSeasonProfile : Profile
{
    public LeagueSeasonProfile()
    {
        CreateMap<LeagueSeasonEntity, LeagueSeasonBasicModel>();

        CreateMap<LeagueSeasonEntity, LeagueSeasonTablesModel>();
    }
}

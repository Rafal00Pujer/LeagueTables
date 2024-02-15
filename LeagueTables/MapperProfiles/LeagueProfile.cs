using AutoMapper;
using LeagueTables.Data.Entities;
using LeagueTables.Models.League;

namespace LeagueTables.MapperProfiles;

public class LeagueProfile : Profile
{
    public LeagueProfile()
    {
        CreateMap<LeagueEntity, LeagueModel>();
    }
}

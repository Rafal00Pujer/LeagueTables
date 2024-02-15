using AutoMapper;
using LeagueTables.Data.Entities;
using LeagueTables.Models.Rounds;

namespace LeagueTables.MapperProfiles;

public class RoundProfile : Profile
{
    public RoundProfile()
    {
        CreateMap<RoundEntity, RoundModel>();
    }
}

using AutoMapper;
using LeagueTables.Data.Entities;
using LeagueTables.Models.League;
using LeagueTables.Models.Table;

namespace LeagueTables.MapperProfiles;

public class TableProfile : Profile
{
    public TableProfile()
    {
        CreateMap<TableEntity, TableScoresModel>();

        CreateMap<TableEntity, TableRoundsModel>()
            .ForMember(m => m.TableName, 
                o => o.MapFrom(s => $"{s.Season.League.Name} {s.Season.Name} {s.Name}"));
    }
}

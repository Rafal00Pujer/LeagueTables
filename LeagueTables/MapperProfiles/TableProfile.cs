using AutoMapper;
using LeagueTables.Data.Entities;
using LeagueTables.Models.League;
using LeagueTables.Models.Table;

namespace LeagueTables.MapperProfiles;

public class TableProfile : Profile
{
    public TableProfile()
    {
        CreateMap<TableEntity, TableModel>();
    }
}

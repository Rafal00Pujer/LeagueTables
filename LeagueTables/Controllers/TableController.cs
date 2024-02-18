using AutoMapper;
using LeagueTables.Data.Context;
using LeagueTables.Models.Table;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Controllers;

public class TableController(LeagueTablesContext context, IMapper mapper) : Controller
{
    private readonly LeagueTablesContext _context = context;
    private readonly IMapper _mapper = mapper;

    [HttpGet("Table/{tableId:Guid}/Rounds")]
    public async Task<IActionResult> Rounds(Guid tableId)
    {
        var query = _context.TableEntities
            .Include(e => e.Season)
                .ThenInclude(e => e.League)
            .Include(e => e.Rounds)
                .ThenInclude(e => e.Matches)
                    .ThenInclude(e => e.TeamsEntries)
                        .ThenInclude(e => e.Team)
           .AsSplitQuery();

        var model = await _mapper.ProjectTo<TableRoundsModel>(query)
            .FirstOrDefaultAsync(e => e.Id == tableId);

        if (model is null)
        {
            return NotFound();
        }

        return View(model);
    }
}

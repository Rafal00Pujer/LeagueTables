using AutoMapper;
using LeagueTables.Data.Context;
using LeagueTables.Models.Match;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Controllers;

public class MatchController(LeagueTablesContext context, IMapper mapper) : Controller
{
    private readonly LeagueTablesContext _context = context;
    private readonly IMapper _mapper = mapper;
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Test dziala.");
    }

    [HttpGet("Match/MatchesForTeamInTable/{tableId:guid}/{teamId:guid}")]
    public async Task<IActionResult> MatchesForTeamInTable(Guid tableId, Guid teamId)
    {
        var query = _context.MatchEntities
            .Where(match => match.Round.TableId == tableId)
            .Where(match => match.TeamsEntries.Any(teamEntry => teamEntry.TeamId == teamId))
            .Include(match => match.Round)
            .Include(match => match.TeamsEntries)
                .ThenInclude(teamEntry => teamEntry.Team);

        var model = await _mapper.ProjectTo<MatchModel>(query).ToListAsync();

        return PartialView("Matches/_MatchesForTeamInTable", model);
    }
}

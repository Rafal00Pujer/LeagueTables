using AutoMapper;
using LeagueTables.Data.Context;
using LeagueTables.Data.Entities;
using LeagueTables.Models.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Controllers;

public class TeamController(UserManager<UserEntity> userManager, LeagueTablesContext context, IMapper mapper) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly LeagueTablesContext _context = context;
    private readonly IMapper _mapper = mapper;

    [HttpPut("Team/{teamId:guid}/AddTeamToFavorite")]
    [Authorize]
    public async Task<IActionResult> AddTeamToFavorite(Guid teamId)
    {
        var userEntity = await _userManager.GetUserAsync(HttpContext.User);

        var team = await _context.TeamEntities
            .Include(team => team.LikedBy.Where(user => user.Id == userEntity!.Id))
            .FirstOrDefaultAsync(team => team.Id == teamId);

        if (team is null)
        {
            return NotFound();
        }

        if (!team.LikedBy.Contains(userEntity!))
        {
            team.LikedBy.Add(userEntity!);
            await _context.SaveChangesAsync();
        }

        return Ok();
    }

    [HttpPut("Team/{teamId:guid}/RemoveTeamFromFavorite")]
    [Authorize]
    public async Task<IActionResult> RemoveTeamFromFavorite(Guid teamId)
    {
        var userEntity = await _userManager.GetUserAsync(HttpContext.User);

        var team = await _context.TeamEntities
            .Include(team => team.LikedBy.Where(user => user.Id == userEntity!.Id))
            .FirstOrDefaultAsync(team => team.Id == teamId);

        if (team is null)
        {
            return NotFound();
        }

        team.LikedBy.Remove(userEntity!);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> UserFavoriteTeams()
    {
        var userId = Guid.Parse(_userManager.GetUserId(HttpContext.User)!);

        var query = _context.TeamEntities
            .Where(team => team.LikedBy.Any(user => user.Id == userId));

        var model = await _mapper.ProjectTo<TeamModel>(query).ToListAsync();

        return View(model);
    }

    [HttpGet("Team/TeamsInSeason/{seasonId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> TeamsInSeason(Guid seasonId)
    {
        var seasonName = await _context.LeagueSeasonEntities
            .Where(season => season.Id == seasonId)
            .Select(season => season.League.Name + " " + season.Name)
            .FirstOrDefaultAsync();

        if (seasonName is null)
        {
            return NotFound();
        }

        ViewBag.SeasonName = seasonName;

        var query = _context.TeamEntities
            .Where(team => team.Seasons.Any(season => season.Id == seasonId));

        var model = await _mapper.ProjectTo<TeamModel>(query).ToListAsync();

        return View(model);
    }
}

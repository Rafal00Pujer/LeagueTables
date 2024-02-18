using AutoMapper;
using LeagueTables.Data.Context;
using LeagueTables.Models.LeagueSeason;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Controllers
{
    public class LeagueSeasonController(LeagueTablesContext context, IMapper mapper) : Controller
    {
        private readonly LeagueTablesContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpGet("LeagueSeason/{seasonId:Guid}/Tables")]
        public async Task<IActionResult> Tables(Guid seasonId)
        {
            var query = _context.LeagueSeasonEntities
                .Include(e => e.League)
                .Include(e => e.Tables)
                    .ThenInclude(e => e.TableScores)
                        .ThenInclude(e => e.Team)
                .AsSplitQuery();

            var model = await _mapper.ProjectTo<LeagueSeasonTablesModel>(query)
                .FirstOrDefaultAsync(e => e.Id == seasonId);

            if (model is null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}

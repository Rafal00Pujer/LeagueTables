using AutoMapper;
using LeagueTables.Data.Context;
using LeagueTables.Models;
using LeagueTables.Models.League;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LeagueTables.Controllers
{
    public class HomeController(LeagueTablesContext context, IMapper mapper) : Controller
    {

        private readonly LeagueTablesContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<IActionResult> Index()
        {
            var Query = _context.LeagueEntities
                .Include(x => x.Seasons);

            var model = await _mapper.ProjectTo<LeagueModel>(Query)
                .ToListAsync();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

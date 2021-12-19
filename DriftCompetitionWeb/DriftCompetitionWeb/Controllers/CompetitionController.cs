using DriftCompetitionWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DriftCompetitionWeb.Data;
using Microsoft.AspNetCore.Identity;

namespace DriftCompetitionWeb.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DriftCompetitionDevice driftCompetitionDevice;

        public CompetitionController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            driftCompetitionDevice = new DriftCompetitionDevice(dbContext);
        }

        public IdentityUser CurrentUser()
        {
            var userTmp = _userManager.GetUserAsync(HttpContext.User);
            return userTmp.Result;
        }

        public IActionResult AllCompetitions()
        {
            IEnumerable<Competition> allCompetitions = driftCompetitionDevice.competitionRepository.AllCompetitions();
            ViewBag.Competitions = allCompetitions.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddCompetition()
        {
            Competition competition = new Competition { Name = "Первое соревнование на сайте", StagesNumber = 2, PrizePool = 10000, Format = "Single Elimination"};
            driftCompetitionDevice.competitionRepository.AddCompetition(competition);
            return RedirectToRoute(new { controller = "Competition", action = "AllCompetitions" });
        }

        public IActionResult Info(Guid competitionID)
        {
            Competition competition = driftCompetitionDevice.competitionRepository.CompetitionByID(competitionID);
            IEnumerable<Stage> competitionStages = driftCompetitionDevice.stageRepository.AllCompetitionStages(competition);

            ViewBag.Competition = competition;
            ViewBag.Stages = competitionStages;
            ViewBag.CompetitionID = competitionID;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
    public class StageController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DriftCompetitionDevice driftCompetitionDevice;

        public StageController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            driftCompetitionDevice = new DriftCompetitionDevice(dbContext);
        }

        public IdentityUser CurrentUser()
        {
            var userTmp = _userManager.GetUserAsync(HttpContext.User);
            return userTmp.Result;
        }

        public IActionResult AllStages()
        {
            IEnumerable<Stage> stages = driftCompetitionDevice.stageRepository.AllStages();
            foreach (Stage stage in stages)
                stage.Competition = driftCompetitionDevice.competitionRepository.CompetitionByID(stage.CompetitionID);
            ViewBag.Stages = stages.ToList();
            return View();
        }

        public IActionResult Info(Guid stageID)
        {
            Stage stage = driftCompetitionDevice.stageRepository.StageByID(stageID);
            stage.Competition = driftCompetitionDevice.competitionRepository.CompetitionByID(stage.CompetitionID);

            ViewBag.Stage = stage;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

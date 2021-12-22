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

        public IActionResult SelectCompetitionParams()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCompetition(
            string Name,
            string Requirements,
            DateTime BeginTime,
            DateTime EndTime,
            float PrizePool,
            string Format,
            int StagesNumber,
            string Status)
        {
            Competition competition = new Competition { 
                Name = Name,
                Requirements = Requirements,
                BeginTime = BeginTime,
                EndTime = EndTime,
                StagesNumber = StagesNumber, 
                PrizePool = PrizePool, 
                Format = Format,
                Status = Status};
            driftCompetitionDevice.competitionRepository.AddCompetition(competition);
            return RedirectToRoute(new { controller = "Competition", action = "AllCompetitions" });
        }

        public IActionResult SelectStageParams(Guid CompetitionID)
        {
            Competition competition = driftCompetitionDevice.competitionRepository.CompetitionByID(CompetitionID);
            if (competition == null)
                return RedirectToRoute(new { controller = "Competition", action = "Info", competitionID = CompetitionID });
            ViewBag.CompetitionID = CompetitionID;
            return View();
        }

        [HttpPost]
        public IActionResult AddStage(
            Guid CompetitionID,
            string Address,
            DateTime RegistrationStartTime,
            DateTime RegistrationEndTime,
            float ParticipaitonPrice,
            float ViewPrice)
        {
            IdentityUser currentUser = CurrentUser();
            if (currentUser == null)
                return RedirectToRoute(new { controller = "Competition", action = "Info", competitionID = CompetitionID });
            Competition competition = driftCompetitionDevice.competitionRepository.CompetitionByID(CompetitionID);
            if (competition == null)
                return RedirectToRoute(new { controller = "Competition", action = "Info", competitionID = CompetitionID });
            Stage stage = new Stage { 
                Competition = competition,
                Address = Address,
                RegistrationStartTime = RegistrationStartTime,
                RegistrationEndTime = RegistrationEndTime,
                ParticipationPrice = ParticipaitonPrice,
                ViewPrice = ViewPrice
            };
            driftCompetitionDevice.stageRepository.AddStage(stage);
            driftCompetitionDevice.AddStageOrganizer(currentUser, stage);
            return RedirectToRoute(new { controller = "Competition", action = "Info", competitionID = CompetitionID});
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

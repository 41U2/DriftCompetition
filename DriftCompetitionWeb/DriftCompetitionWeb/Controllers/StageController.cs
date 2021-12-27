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

            IdentityUser organizer = driftCompetitionDevice.StageOrganizer(stage);
            ViewBag.Organizer = organizer;
            ViewBag.Stage = stage;

            List<List<Tuple<IdentityUser, IdentityUser>>> roundsPairs = driftCompetitionDevice.allRoundsPairsOfStage(stage);
            List<List<Tuple<string, string>>> roundPairsNames = driftCompetitionDevice.RoundPairsUsersToRoundPairsNames(roundsPairs);
            ViewBag.RoundPairsNames = roundPairsNames;
            
            List<IdentityUser> participants = driftCompetitionDevice.StageParticipants(stage);
            List<string> carNumbers = driftCompetitionDevice.StageParticipantNumbers(stage);
            ViewBag.Participants = participants;
            ViewBag.CarNumbers = carNumbers;

            IdentityUser currentUser = CurrentUser();
            ViewBag.CurrentUser = currentUser;
            return View();
        }

        [HttpPost]
        public IActionResult SelectCarNumber(Guid stageID)
        {
            return RedirectToRoute(new { Controller = "Garage", action = "Cars", needToSelectCarNumber = true, stageID = stageID });
        }

        public IActionResult RegistrateToStage(Guid StageID, Guid CarNumberID)
        {
            IdentityUser currentUser = CurrentUser();
            if (currentUser == null)
                return RedirectToRoute(new { Controller = "Stage", action = "Info", stageID = StageID });
            Stage stage = driftCompetitionDevice.stageRepository.StageByID(StageID);
            if (stage == null)
                return RedirectToRoute(new { Controller = "Stage", action = "Info", stageID = StageID });
            CarNumber carNumber = driftCompetitionDevice.carsRepository.CarNumberByID(CarNumberID);
            driftCompetitionDevice.RegistrateUserToStage(currentUser, stage, carNumber);
            return RedirectToRoute(new { Controller = "Stage", action = "Info", stageID = StageID });
        }

        public IActionResult RemoveParticipantFromStage(string UserId, Guid StageID)
        { 
            IdentityUser participant = driftCompetitionDevice.userRepository.UserByID(UserId);
            Stage stage = driftCompetitionDevice.stageRepository.StageByID(StageID);
            driftCompetitionDevice.RemoveParticipantFromStage(participant, stage);
            return RedirectToRoute(new { Controller = "Stage", action = "Info", stageID = StageID });
        }

        [HttpPost]
        public IActionResult EventStage(Guid StageID)
        {
            Stage stage = driftCompetitionDevice.stageRepository.StageByID(StageID);
            driftCompetitionDevice.EventStage(stage);
            return RedirectToRoute(new { Controller = "Stage", action = "Info", stageID = StageID });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

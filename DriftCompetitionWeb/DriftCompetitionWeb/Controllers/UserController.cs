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
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DriftCompetitionDevice driftCompetitionDevice;

        public UserController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            driftCompetitionDevice = new DriftCompetitionDevice(dbContext);
        }

        public IdentityUser CurrentUser()
        {
            var userTmp = _userManager.GetUserAsync(HttpContext.User);
            return userTmp.Result;
        }

        public IActionResult Profile()
        {
            IdentityUser currentUser = CurrentUser();
            IEnumerable<StageResult> allStagesResults = driftCompetitionDevice.stageRepository.AllUsersStagesResults(currentUser);
            ViewBag.StagesResults = new List<StageResult> { };
            ViewBag.CurrentUser = currentUser;
            if (allStagesResults == null)
                return View();
            foreach (StageResult stageResult in allStagesResults)
            {
                if (stageResult == null)
                    continue;
                stageResult.Stage = driftCompetitionDevice.stageRepository.StageByID(stageResult.StageID);
            }
            ViewBag.StagesResults = allStagesResults.ToList();
            ViewBag.CurrentUser = currentUser;
            return View();
        }

        public IActionResult SetUserName(string name)
        {
            IdentityUser currentUser = CurrentUser();
            IdentityUser tmp = driftCompetitionDevice.userRepository.UserByID(currentUser.Id);
            tmp.UserName = name;
            driftCompetitionDevice.userRepository.SaveChanges();
            return RedirectToRoute(new { Controller = "User", action = "Profile" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

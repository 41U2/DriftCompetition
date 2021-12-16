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
    public class HomeController : Controller
    {
        private readonly DbRepository repository;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            repository = new DbRepository(dbContext);
            _userManager = userManager;
            
            //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            //bool check = this.User.Identity.IsAuthenticated;
            //var id = _userManager.GetUserId(this.User);
            //var user = _userManager.GetUserAsync(HttpContext.User);
            //repository.AddDefaultCar(user.Result, "CurrentUser");
            Car tmp = repository.CarByDescription("Request");
            // удалить все записи из car
            int prikol = 1;
        }

        public IdentityUser GetCurrentUser()
        {
            var userTmp = _userManager.GetUserAsync(HttpContext.User);
            return userTmp.Result;
        }

        public IActionResult Index()
        {
            IdentityUser user = GetCurrentUser();
            Car car = repository.CarByDescription("CurrentUser");
            return View();
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

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
        private readonly CarRepository carsRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            carsRepository = new CarRepository(dbContext);
            _userManager = userManager;
        }

        public IdentityUser GetCurrentUser()
        {
            var userTmp = _userManager.GetUserAsync(HttpContext.User);
            return userTmp.Result;
        }

        public IActionResult Index()
        {
            IdentityUser user = GetCurrentUser();
            carsRepository.AddNewCar(user, "Check add 2");
            carsRepository.AddNewCar(user, "Check add 3");
            IEnumerable<Car> usersCars = carsRepository.UsersCars(user);
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

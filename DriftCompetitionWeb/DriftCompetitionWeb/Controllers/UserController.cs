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
            ViewBag.Cars = new List<Car> { };
            IEnumerable<Car> usersCars = driftCompetitionDevice.carsRepository.UsersCars(currentUser);
            if (currentUser != null)
                ViewBag.Cars = usersCars.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddCar()
        {
            IdentityUser currentUser = CurrentUser();
            driftCompetitionDevice.carsRepository.AddCar(new Car { User = currentUser, Description = "Check add car from web-site."});
            return RedirectToRoute(new { controller = "User", action = "Profile" });
        }

        [HttpGet]
        public IActionResult CarInfo(Guid carID)
        {
            Car car = driftCompetitionDevice.carsRepository.CarByID(carID);
            ViewBag.Numbers = new List<Car> { };
            ViewBag.Description = "";
            ViewBag.carID = carID;
            IEnumerable<CarNumber> carNumbers = driftCompetitionDevice.carsRepository.CarNumbers(car);
            if (car != null)
            {
                ViewBag.Numbers = carNumbers.ToList();
                ViewBag.Description = car.Description;
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddCarNumber(Guid carID)
        {
            Car car = driftCompetitionDevice.carsRepository.CarByID(carID);
            driftCompetitionDevice.carsRepository.AddCarNumber(new CarNumber { Car = car, Number = "|mm123m|36|" });
            return RedirectToRoute(new { controller = "User", action = "CarInfo", carID = carID });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

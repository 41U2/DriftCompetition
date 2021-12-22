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
    public class GarageController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DriftCompetitionDevice driftCompetitionDevice;

        public GarageController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            driftCompetitionDevice = new DriftCompetitionDevice(dbContext);
        }

        public IdentityUser CurrentUser()
        {
            var userTmp = _userManager.GetUserAsync(HttpContext.User);
            return userTmp.Result;
        }

        public IActionResult Cars()
        {

            IdentityUser currentUser = CurrentUser();
            ViewBag.Cars = new List<Car> { };
            ViewBag.CarNumbers = new List<List<CarNumber>> { };
            IEnumerable<Car> usersCars = driftCompetitionDevice.carsRepository.UsersCars(currentUser);
            if (currentUser == null)
                return View();
            ViewBag.Cars = usersCars.ToList();
            List < List < CarNumber >> allCarsNumbers = new List<List<CarNumber>> { };
            foreach (Car car in usersCars) 
            {
                IEnumerable<CarNumber> carNumbers = driftCompetitionDevice.carsRepository.CarNumbers(car);
                allCarsNumbers.Add(carNumbers.ToList());
            }
            ViewBag.CarNumbers = allCarsNumbers;
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(string Name)
        {
            IdentityUser currentUser = CurrentUser();
            if (currentUser == null)
                return RedirectToRoute(new { controller = "Garage", action = "Cars" });
            driftCompetitionDevice.carsRepository.AddCar(new Car
            {
                User = currentUser,
                Description = Name
            });
            return RedirectToRoute(new { controller = "Garage", action = "Cars" });
        }

        [HttpPost]
        public IActionResult AddCarNumber(
            Guid CarID,
            string Number,
            int Region)
        {
            string resultNumber = "[" + Number + "|" + Region + "rus]";
            Car car = driftCompetitionDevice.carsRepository.CarByID(CarID);
            if (car == null)
                return RedirectToRoute(new { controller = "Garage", action = "Cars", carID = CarID });
            driftCompetitionDevice.carsRepository.AddCarNumber(new CarNumber
            {
                Car = car,
                Number = resultNumber
            });
            return RedirectToRoute(new { controller = "Garage", action = "Cars", carID = CarID });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

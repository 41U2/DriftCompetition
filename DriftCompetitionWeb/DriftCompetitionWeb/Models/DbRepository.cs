using DriftCompetitionWeb.Models;
using DriftCompetitionWeb.Data;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace DriftCompetitionWeb.Models
{
    public class DbRepository
    {
        private DriftCompetitionWeb.Data.ApplicationDbContext driftDbContext;

        public DbRepository(ApplicationDbContext dbContext)
        {
            this.driftDbContext = dbContext;
        }

        public Car GetFirstCar()
        {
            return driftDbContext.Cars.First();
        }
        public Car CarByDescription(string Description)
        {
            return driftDbContext.Cars.Include(c => c.User).FirstOrDefault(c => c.Description == Description) ;
        }

        public void RemoveCar()
        {
            driftDbContext.Remove(0);
        }

        public void AddDefaultCar(Microsoft.AspNetCore.Identity.IdentityUser user, string description)
        {
            Car car = new Car { Description = description, User = user};
            driftDbContext.Cars.Add(car);
            driftDbContext.SaveChanges();
        }
    }
}

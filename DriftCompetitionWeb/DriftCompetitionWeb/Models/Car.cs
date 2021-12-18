using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DriftCompetitionWeb.Data;
using DriftCompetitionWeb.Models;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace DriftCompetitionWeb.Models
{
    public class Car
    {
        public Guid CarID { set; get; }
        public virtual IdentityUser User { set; get; }
        public string Description { set; get; }
        public virtual ICollection<CarNumber> CarNumbers { set; get; }
    }

    public class CarNumber
    {
        public Guid CarNumberID { set; get; }
        public virtual Car Car { set; get; }
        public string Number { set; get; }
        public virtual ICollection<StageResult> StageResults { set; get; }
        public virtual ICollection<RaceResult> RaceResults { set; get; }
    }

    public class CarsRepository
    {
        private DriftCompetitionWeb.Data.ApplicationDbContext m_dbContext;

        public CarsRepository(ApplicationDbContext dbContext)
        {
            this.m_dbContext = dbContext;
        }

        public void RemoveCar(Car car)
        {
            m_dbContext.Remove(car);
            m_dbContext.SaveChanges();
        }

        public void AddNewCar(IdentityUser user, string description)
        {
            if (user == null)
                return;
            Car car = new Car { Description = description, User = user };
            m_dbContext.Cars.Add(car);
            m_dbContext.SaveChanges();
        }
        public IEnumerable<Car> UsersCars(IdentityUser user)
        {
            if (user == null)
                return null;
            return m_dbContext.Cars.
                Include(c => c.CarID).
                Include(c => c.User).
                Include(c => c.Description).
                Include(c => c.CarNumbers).
                Where(c => c.User == user);
        }
    }
}

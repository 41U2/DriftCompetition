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

    public class CarRepository
    {
        private ApplicationDbContext m_dbContext;

        public CarRepository(ApplicationDbContext dbContext)
        {
            this.m_dbContext = dbContext;
        }

        public void RemoveCar(Car car)
        {
            if (car == null)
                return;
            m_dbContext.Remove(car);
            m_dbContext.SaveChanges();
        }

        public void AddCar(Car car)
        {
            if (car == null)
                return;
            m_dbContext.Cars.Add(car);
            m_dbContext.SaveChanges();
        }

        public Car CarByID(Guid carID)
        {
            return m_dbContext.Cars.
                Include(c => c.User).
                Where(c => c.CarID == carID).
                FirstOrDefault();
        }
        public IEnumerable<Car> UsersCars(IdentityUser user)
        {
            if (user == null)
                return null;
            return m_dbContext.Cars.
                Include(c => c.CarID).
                Include(c => c.User).
                Include(c => c.CarNumbers).
                Where(c => c.User == user);
        }

        public void AddCarNumber(CarNumber carNumber)
        {
            if (carNumber == null)
                return;
            m_dbContext.CarNumbers.Add(carNumber);
            m_dbContext.SaveChanges();
        }

        public CarNumber CarNumberByID(Guid id)
        {
            return m_dbContext.CarNumbers.Where(cn => cn.CarNumberID == id).FirstOrDefault();
        }

        public void RemoveCarNumber(CarNumber carNumber)
        {
            if (carNumber == null)
                return;
            m_dbContext.CarNumbers.Remove(carNumber);
            m_dbContext.SaveChanges();
        }

        public IEnumerable<CarNumber> CarNumbers(Car car)
        {
            if (car == null)
                return null;
            return m_dbContext.CarNumbers.
                Include(cn => cn.Car).
                Where(cn => cn.Car == car);
        }
    }
}

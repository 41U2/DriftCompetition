using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DriftCompetitionWeb.Data;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Data.Entity;

namespace DriftCompetitionWeb.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Car> Cars { set; get; }
        public virtual ICollection<CompetitionResult> CompetitionResults { set; get; }
        public virtual ICollection<StageResult> StageResults { set; get; }
        public virtual ICollection<RaceResult> RaceResults { set; get; }
        public virtual ICollection<UserToRole> UserToRoles { set; get; }
    }

    public class UserRepository
    {
        private ApplicationDbContext m_dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public void SaveChanges()
        {
            m_dbContext.SaveChanges();
        }

        public IdentityUser UserByID(string userID)
        {
            return m_dbContext.Users.Where(u => u.Id == userID).FirstOrDefault();
        }
    }
}

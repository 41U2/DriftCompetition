using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DriftCompetitionWeb.Data;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace DriftCompetitionWeb.Models
{
    public class Competition
    {
        public Guid CompetitionID { set; get; }
        public string Name { set; get; }
        public string Requirements { set; get; }
        public DateTime BeginTime { set; get; }
        public DateTime EndTime { set; get; }
        public float PrizePool { set; get; }
        public string Format { set; get; }
        public int StagesNumber { set; get; }
        public bool IsOver { set; get; }
        public string Status { set; get; }
        public virtual ICollection<CompetitionResult> CompetitionResults { set; get; }
        public virtual ICollection<Stage> Stages { set; get; }
    }

    public class CompetitionResult
    {
        public Guid CompetitionResultID { set; get; }
        public virtual Competition Competition { set; get; }
        public Microsoft.AspNetCore.Identity.IdentityUser User { set; get; }
        public int NumberOfCompletedStages { set; get; }
        public float ResultGrade { set; get; }
        public int ResultPlace { set; get; }
    }

    public class CompetitionRepository
    {
        private ApplicationDbContext m_dbContext;

        public CompetitionRepository(ApplicationDbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public void AddCompetition(Competition competition)
        {
            if (competition == null)
                return;
            m_dbContext.Competitions.Add(competition);
            m_dbContext.SaveChanges();
        }
        public void RemoveCompetition(Competition competition)
        {
            m_dbContext.Remove(competition);
            m_dbContext.SaveChanges();
        }

        public IEnumerable<Competition> AllCompetitions()
        {
            return m_dbContext.Competitions.
                Include(c => c.Stages);
        }

        public void AddCompetitionResult(CompetitionResult competitionResult)
        {
            if (competitionResult == null)
                return;
            m_dbContext.CompetitionResults.Add(competitionResult);
            m_dbContext.SaveChanges();
        }

        public void RemoveCompetitionResult(CompetitionResult competitionResult)
        {
            if (competitionResult == null)
                return;
            m_dbContext.CompetitionResults.Remove(competitionResult);
            m_dbContext.SaveChanges();
        }

        public CompetitionResult UsersCompetitionResult(IdentityUser user, Competition competition)
        {
            return m_dbContext.CompetitionResults.
                Include(cr => cr.Competition).
                Include(cr => cr.User).
                Where(cr => cr.User == user).
                Where(cr => cr.Competition == competition).
                First();
        }

        public IEnumerable<CompetitionResult> GetAllUsersCompetitionResults(IdentityUser user)
        {
            return m_dbContext.CompetitionResults.
                Include(cr => cr.Competition).
                Include(cr => cr.User).
                Where(cr => cr.User == user);
        }

    }
}

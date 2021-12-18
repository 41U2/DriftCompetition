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

        public void AddCompetition(
            string name,
            string requirements,
            DateTime beginTime,
            DateTime endTime,
            float prizePool,
            string format,
            int stagesNumber,
            bool isOver,
            string status)
        {
            Competition competition = new Competition { 
                Name = name,
                Requirements = requirements,
                BeginTime = beginTime,
                EndTime = endTime,
                PrizePool = prizePool,
                Format = format,
                StagesNumber = stagesNumber,
                IsOver = isOver,
                Status = status
            };
            m_dbContext.Competitions.Add(competition);
            m_dbContext.SaveChanges();
        }
        public void RemoveCompetition(Competition competition)
        {
            m_dbContext.Remove(competition);
            m_dbContext.SaveChanges();
        }

        public IEnumerable<Competition> GetAllCompetitions()
        { 
            return m_dbContext.Competitions.
                Include(c=>c.Name).
                Include(c => c.Requirements).
                Include(c => c.BeginTime).
                Include(c => c.EndTime).
                Include(c => c.PrizePool).
                Include(c => c.Format).
                Include(c => c.StagesNumber).
                Include(c => c.IsOver).
                Include(c => c.Status);
        }

        public CompetitionResult GetUsersCompetitionResult(IdentityUser user, Competition competition)
        {
            return m_dbContext.CompetitionResults.
                Include(cr => cr.Competition).
                Include(cr => cr.User).
                Include(cr => cr.NumberOfCompletedStages).
                Include(cr => cr.ResultGrade).
                Include(cr => cr.ResultPlace).
                Where(cr => cr.User == user).
                Where(cr => cr.Competition == competition).
                First();
        }

        public IEnumerable<CompetitionResult> GetAllUsersCompetitionResults(IdentityUser user)
        {
            return m_dbContext.CompetitionResults.
                Include(cr => cr.Competition).
                Include(cr => cr.User).
                Include(cr => cr.NumberOfCompletedStages).
                Include(cr => cr.ResultGrade).
                Include(cr => cr.ResultPlace).
                Where(cr => cr.User == user);
        }

    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DriftCompetitionWeb.Data;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace DriftCompetitionWeb.Models
{
    public class Stage
    {
        public Guid StageID { set; get; }
        public virtual Competition Competition { set; get; }
        public virtual Guid CompetitionID { set; get; }
        public DateTime RegistrationStartTime { set; get; }
        public DateTime RegistrationEndTime { set; get; }
        public bool IsOver { set; get; }
        public float ViewPrice { set; get; }
        public float ParticipationPrice { set; get; }
        public string Address { set; get; }
        public virtual ICollection<StageResult> StageResults { set; get; }
        public virtual ICollection<Race> Races { set; get; }
    }

    public class StageResult
    {
        public Guid StageResultID { set; get; }
        public virtual Stage Stage { set; get; }
        public virtual Guid StageID { set; get; }
        public virtual IdentityUser User { set; get; }
        public virtual string UserId { set; get; }
        public virtual CarNumber CarNumber { set; get; }
        public int ResultPlace { set; get; }
    }

    public class StageRepository
    {
        private ApplicationDbContext m_dbContext;

        public StageRepository(ApplicationDbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public void SaveChanges() 
        {
            m_dbContext.SaveChanges();
        }

        public void AddStage(Stage stage)
        {
            if (stage == null)
                return;
            m_dbContext.Stages.Add(stage);
            m_dbContext.SaveChanges();
        }

        public void RemoveStage(Stage stage)
        {
            if (stage == null)
                return;
            m_dbContext.Stages.Remove(stage);
            m_dbContext.SaveChanges();
        }

        public Stage StageByID(Guid stageID) 
        {
            return m_dbContext.Stages.Where(s => s.StageID == stageID).FirstOrDefault();
        }

        public IEnumerable<Stage> AllStages()
        {
            return m_dbContext.Stages.Include(s=>s.Competition);
        }

        public Competition CompetitionOfStage(Stage stage)
        {
            if (stage == null)
                return null;
            return m_dbContext.Stages.FirstOrDefault().Competition;
        }

        public IEnumerable<Stage> AllCompetitionStages(Competition competition)
        {
            if (competition == null)
                return null;
            return m_dbContext.Stages.
                Include(s => s.Competition).
                Where(s => s.Competition == competition);
        }

        public void AddStageResult(StageResult stageResult)
        {
            if (stageResult == null)
                return;
            m_dbContext.StageResults.Add(stageResult);
            m_dbContext.SaveChanges();
        }

        public void RemoveStageResult(StageResult stageResult)
        {
            if (stageResult == null)
                return;
            m_dbContext.StageResults.Remove(stageResult);
            m_dbContext.SaveChanges();
        }

        public IEnumerable<StageResult> AllUsersStagesResults(IdentityUser user)
        {
            if (user == null)
                return null;
            return m_dbContext.StageResults.
                Where(sr => sr.User == user);
        }

        public StageResult UsersStageResult(IdentityUser user, Stage stage)
        {
            if (user == null || stage == null)
                return null;
            return m_dbContext.StageResults.
                Include(sr => sr.CarNumber).
                Include(sr => sr.Stage).
                Include(sr => sr.User).
                Where(sr => sr.User == user).
                Where(sr => sr.Stage == stage).
                FirstOrDefault();
        }
    }
}

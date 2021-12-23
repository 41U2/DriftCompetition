using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DriftCompetitionWeb.Data;
using System.Linq;
using System.Data.Entity;

namespace DriftCompetitionWeb.Models
{
    public class Race
    {
        public Guid RaceID { set; get; }
        public virtual Stage Stage { set; get; }
        public int IndexInOlympicSystemp { set; get; }
        public virtual ICollection<RaceResult> RaceResults { set; get; }
        //может добавить статус (прошла гонка или нет)
    }

    public class RaceResult
    {
        public Guid RaceResultID { set; get; }
        public virtual Race Race { set; get; }
        public virtual Guid RaceID { set; get; }
        public virtual IdentityUser User { set; get; }
        public virtual string UserId { set; get; }
        public virtual CarNumber CarNumber { set; get; }
        public bool SuccessfullyEnded { set; get; }
        public float AngleGrade { set; get; }
        public float StyleGrade { set; get; }
        public float TrajectoryGrade { set; get; }
        public int ResultPlace { set; get; }
    }

    public class RaceRepository
    {
        private ApplicationDbContext m_dbContext;

        public RaceRepository(ApplicationDbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public void AddRace(Race race)
        {
            if (race == null)
                return;
            m_dbContext.Races.Add(race);
            m_dbContext.SaveChanges();
        }

        public void RemoveRace(Race race)
        {
            if (race == null)
                return;
            m_dbContext.Races.Remove(race);
            m_dbContext.SaveChanges();
        }

        public IEnumerable<Race> AllStageRaces(Stage stage)
        {
            if (stage == null)
                return null;
            return m_dbContext.Races.
                Include(r => r.Stage).
                Where(r => r.Stage == stage);
        }

        public void AddRaceResult(RaceResult raceResult)
        {
            if (raceResult == null)
                return;
            m_dbContext.RaceResults.Add(raceResult);
            m_dbContext.SaveChanges();
        }

        public void RemoveRaceResult(RaceResult raceResult)
        {
            if (raceResult == null)
                return;
            m_dbContext.RaceResults.Remove(raceResult);
            m_dbContext.SaveChanges();
        }

        public IEnumerable<RaceResult> AllUsersRaceResultsInStage(IdentityUser user, Stage stage)
        {
            if (user == null || stage == null)
                return null;
            return m_dbContext.RaceResults.
                Include(rr => rr.Race).
                Include(rr => rr.User).
                Include(rr => rr.CarNumber).
                Where(rr => rr.User == user).
                Where(rr => rr.Race.Stage == stage);
        }
    }
}

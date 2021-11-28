using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DriftCompetitionWeb.Models
{
    public class User : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public int UserID { set; get; }
        public virtual ICollection<Car> Cars { set; get; }
        public virtual ICollection<CompetitionResult> CompetitionResults { set; get; }
        public virtual ICollection<StageResult> StageResults { set; get; }
        public virtual ICollection<RaceResult> RaceResults { set; get; }
        public virtual ICollection<UserToRole> UserToRoles { set; get; }
    }

    public class Car
    {
        public Guid CarID { set; get; }
        public virtual User User { set; get; }
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
        public User User { set; get; }
        public int NumberOfCompletedStages { set; get; }
        public float ResultGrade { set; get; }
        public int ResultPlace { set; get; }

    }

    public class Stage
    {
        public Guid StageID { set; get; }
        public virtual Competition Competition { set; get; }
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
        public virtual User User { set; get; }
        public virtual CarNumber CarNumber { set; get;}
        public int ResultPlace { set; get; }
    }

    public class Race
    { 
        public Guid RaceID { set; get; }
        public virtual Stage Stage { set; get; }
        public int IndexInOlympicSystemp { set; get; }
        public virtual ICollection<RaceResult> RaceResults { set; get; }

    }

    public class RaceResult
    { 
        public Guid RaceResultID { set; get; }
        public virtual Race Race { set; get; }
        public virtual User User { set; get; }
        public virtual CarNumber CarNumber { set; get; }
        public bool SuccessfullyEnded { set; get; }
        public float AngleGrade { set; get; }
        public float StyleGrade { set; get; }
        public float TrajectoryGrade { set; get; }
        public int ResultPlace { set; get; }
    }

    public class Role
    { 
        public Guid RoleID { set; get; }
        public string Name { set; get; }
    }

    public class UserToRole
    { 
        public Guid UserToRoleID { set; get; }
        public virtual User User { set; get; }
        public virtual Stage Stage { set; get; }
        public virtual Role Role { set; get; }
    }
}
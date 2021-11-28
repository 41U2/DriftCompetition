using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DriftCompetitionWeb.Models
{
    public class User: Microsoft.AspNetCore.Identity.IdentityUser
    {
        //public virtual ICollection<Car> Cars { set; get; }
        public int UserID { set; get; }

    }

    public class Car
    {
        public Guid CarID { set; get; }
        public int UserID { set; get; }
        public string Description { set; get; }
        public virtual ICollection<CarNumber> CarNumbers { set; get; }
    }

    public class CarNumber
    {
        public Guid CarNumberID { set; get; }
        public int CarID { set; get; }
        public virtual Car Car { set; get; }
        public string Number { set; get; }
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

    }

    public class CompetitionResult
    {
        public int CompetitionID { set; get; }
        public int UserID { set; get; }
        public int NumberOfCompletedStages { set; get; }
        public float ResultGrade { set; get; }
        public int ResultPlace { set; get; }

    }

    public class Stage
    {
        public Guid StageID { set; get; }
        public int CompetitionID { set; get; }
        public DateTime RegistrationStartTime { set; get; }
        public DateTime RegistrationEndTime { set; get; }
        public Guid TechCommissionerID { set; get; }
        public bool IsOver { set; get; }
        public float ViewPrice { set; get; }
        public float ParticipationPrice { set; get; }
        public string Address { set; get; }
    }

    public class StageResult
    {
        public int StageID { set; get; }
        public int UserID { set; get; }
        public int CarNumberID { set; get; }
        public int ResultPlace { set; get; }
    }

    public class Race
    { 
        public Guid RaceID { set; get; }
        public int StageID { set; get; }
        public int IndexInOlympicSystemp { set; get; }
    }

    public class RaceResult
    { 
        public int RaceID { set; get; }
        public int UserID { set; get; }
        public int CarNumberID { set; get; }
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

}
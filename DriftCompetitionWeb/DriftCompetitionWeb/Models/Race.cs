using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DriftCompetitionWeb.Models
{
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
        public virtual Microsoft.AspNetCore.Identity.IdentityUser User { set; get; }
        public virtual CarNumber CarNumber { set; get; }
        public bool SuccessfullyEnded { set; get; }
        public float AngleGrade { set; get; }
        public float StyleGrade { set; get; }
        public float TrajectoryGrade { set; get; }
        public int ResultPlace { set; get; }
    }
}

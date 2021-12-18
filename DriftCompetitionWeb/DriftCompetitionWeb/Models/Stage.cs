using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DriftCompetitionWeb.Models
{
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
        public virtual Microsoft.AspNetCore.Identity.IdentityUser User { set; get; }
        public virtual CarNumber CarNumber { set; get; }
        public int ResultPlace { set; get; }
    }
}

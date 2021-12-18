using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DriftCompetitionWeb.Models
{
    public class User : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public virtual ICollection<Car> Cars { set; get; }
        public virtual ICollection<CompetitionResult> CompetitionResults { set; get; }
        public virtual ICollection<StageResult> StageResults { set; get; }
        public virtual ICollection<RaceResult> RaceResults { set; get; }
        public virtual ICollection<UserToRole> UserToRoles { set; get; }
    }
}

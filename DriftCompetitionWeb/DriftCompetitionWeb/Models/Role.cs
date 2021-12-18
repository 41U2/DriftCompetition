using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DriftCompetitionWeb.Models
{
    public class Role
    {
        public Guid RoleID { set; get; }
        public string Name { set; get; }
    }

    public class UserToRole
    {
        public Guid UserToRoleID { set; get; }
        public virtual Microsoft.AspNetCore.Identity.IdentityUser User { set; get; }
        public virtual Stage Stage { set; get; }
        public virtual Role Role { set; get; }
    }
}

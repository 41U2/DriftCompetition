using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using DriftCompetitionWeb.Data;
using System.Linq;
using System.Data.Entity;

namespace DriftCompetitionWeb.Models
{
    public class Role
    {
        public Guid RoleID { set; get; }
        public string Name { set; get; }
    }
    //Обозначения:
    //Participant - участник
    //Organizer - организатор
    //Referee - судья
    //TBD

    public class UserToRole
    {
        public Guid UserToRoleID { set; get; }
        public virtual IdentityUser User { set; get; }
        public virtual Stage Stage { set; get; }
        public virtual Role Role { set; get; }
    }

    public class RoleRepository
    {
        private ApplicationDbContext m_dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public void AddRole(Role role)
        {
            if (role == null)
                return;
            m_dbContext.DriftCompetitionRoles.Add(role);
            m_dbContext.SaveChanges();
        }

        public void RemoveRole(Role role)
        {
            if (role == null)
                return;
            m_dbContext.DriftCompetitionRoles.Remove(role);
            m_dbContext.SaveChanges();
        }
        public void AddDefaultRoles()
        {
            m_dbContext.DriftCompetitionRoles.Add(new Role { Name = "Participant"});
            m_dbContext.DriftCompetitionRoles.Add(new Role { Name = "Organizer" });
            m_dbContext.DriftCompetitionRoles.Add(new Role { Name = "Referee" });
            m_dbContext.SaveChanges();
        }

        public Role RoleByName(string name)
        {
            return m_dbContext.DriftCompetitionRoles.Where(r => r.Name == name).FirstOrDefault();
        }

        public void AddUserToRole(UserToRole userToRole) 
        {
            if (userToRole == null)
                return;
            m_dbContext.UsersToRoles.Add(userToRole);
            m_dbContext.SaveChanges();
        }

        public void RemoveUserToRole(UserToRole userToRole)
        {
            if (userToRole == null)
                return;
            m_dbContext.UsersToRoles.Remove(userToRole);
            m_dbContext.SaveChanges();
        }

        public IEnumerable<UserToRole> AllUsersWithRoleInStage(Stage stage, string role)
        {
            if (stage == null || role == null)
                return null;
            return m_dbContext.UsersToRoles.
                Include(utr => utr.User).
                Include(utr => utr.Stage).
                Include(utr => utr.Role).
                Where(utr => utr.Stage == stage).
                Where(utr => utr.Role.Name == role);
        }

        public IEnumerable<UserToRole> AllUsersRoles(IdentityUser user)
        {
            if (user == null)
                return null;
            return m_dbContext.UsersToRoles.
                Include(utr => utr.Stage).
                Include(utr => utr.User).
                Include(utr => utr.Role).
                Where(utr => utr.User == user);
        }
    }
}

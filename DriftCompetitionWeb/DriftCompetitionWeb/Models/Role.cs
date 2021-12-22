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
    //�����������:
    //Participant - ��������
    //Organizer - �����������
    //Referee - �����
    //TBD

    public class UserToRole
    {
        public Guid UserToRoleID { set; get; }
        public virtual IdentityUser User { set; get; }
        public virtual string UserId { set; get; }
        public virtual Stage Stage { set; get; }
        public virtual Guid StageID { set; get; }
        public virtual Role Role { set; get; }
        public virtual Guid RoleID { set; get; }
    }

    public class RoleRepository
    {
        private ApplicationDbContext m_dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        private void AddRole(Role role)
        {
            if (role == null)
                return;
            m_dbContext.DriftCompetitionRoles.Add(role);
            m_dbContext.SaveChanges();
        }

        private void RemoveRole(Role role)
        {
            if (role == null)
                return;
            m_dbContext.DriftCompetitionRoles.Remove(role);
            m_dbContext.SaveChanges();
        }
        private void AddDefaultRoles()
        {
            m_dbContext.DriftCompetitionRoles.Add(new Role { Name = "Participant"});
            m_dbContext.DriftCompetitionRoles.Add(new Role { Name = "Organizer" });
            m_dbContext.DriftCompetitionRoles.Add(new Role { Name = "Referee" });
            m_dbContext.SaveChanges();
        }

        private Role RoleByName(string name)
        {
            return m_dbContext.DriftCompetitionRoles.Where(r => r.Name == name).FirstOrDefault();
        }
        public Role ParticipantRole()
        {
            return RoleByName("Participant");
        }

        public Role OrganizerRole()
        {
            return RoleByName("Organizer");
        }

        public Role RefereeRole()
        {
            return RoleByName("Referee");
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

        public IEnumerable<UserToRole> AllUsersWithRoleInStage(Stage stage, Role role)
        {
            if (stage == null || role == null)
                return null;
            return m_dbContext.UsersToRoles.
                Include(utr => utr.User).
                Include(utr => utr.Stage).
                Include(utr => utr.Role).
                Where(utr => utr.Stage == stage).
                Where(utr => utr.Role == role);
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

        public UserToRole UserToRoleByAllParams(IdentityUser user, Role role, Stage stage)
        {
            return m_dbContext.UsersToRoles.
                Include(utr => utr.Stage).
                Include(utr => utr.User).
                Include(utr => utr.Role).
                Where(utr => utr.User == user).
                Where(utr => utr.Stage == stage).
                Where(utr => utr.Role == role).FirstOrDefault();
        }
    }
}

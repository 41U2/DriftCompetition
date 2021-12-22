using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DriftCompetitionWeb.Data;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNetCore.Identity;


namespace DriftCompetitionWeb.Models
{
    public class DriftCompetitionDevice
    {
        public CarRepository carsRepository;
        public CompetitionRepository competitionRepository;
        public RaceRepository raceRepository;
        public RoleRepository roleRepository;
        public StageRepository stageRepository;
        public UserRepository userRepository;

        public DriftCompetitionDevice(ApplicationDbContext dbContext) 
        {
            carsRepository = new CarRepository(dbContext);
            competitionRepository = new CompetitionRepository(dbContext);
            raceRepository = new RaceRepository(dbContext);
            roleRepository = new RoleRepository(dbContext);
            stageRepository = new StageRepository(dbContext);
            userRepository = new UserRepository(dbContext);
        }

        public IdentityUser StageOrganizer(Stage stage)
        {
            Role organizerRole = roleRepository.OrganizerRole();
            UserToRole kek =  roleRepository.AllUsersWithRoleInStage(stage, organizerRole).FirstOrDefault();
            IdentityUser user = userRepository.UserByID(kek.UserId);
            return user;
        }

        public void AddStageOrganizer(IdentityUser user, Stage stage)
        {
            Role organizer = roleRepository.OrganizerRole();
            UserToRole userToRole = new UserToRole { 
                User = user, 
                Stage = stage, 
                Role = organizer 
            };
            roleRepository.AddUserToRole(userToRole);
        }

        public void RegistrateUserToStage(IdentityUser user, Stage stage)
        {
            Role participant = roleRepository.ParticipantRole();
            UserToRole userToRole = new UserToRole {
                User = user,
                Stage = stage,
                Role = participant
            };
            UserToRole checkExistance = roleRepository.UserToRoleByAllParams(user, participant, stage);
            if (checkExistance != null)
                return;
            roleRepository.AddUserToRole(userToRole);
        }

        public List<IdentityUser> StageParticipants(Stage stage)
        {
            Role participant = roleRepository.ParticipantRole();
            IEnumerable<UserToRole> usersToParticipantRole = roleRepository.AllUsersWithRoleInStage(stage, participant);
            List<IdentityUser> users = new List<IdentityUser> { };
            foreach (UserToRole userToParticipantRole in usersToParticipantRole)
            {
                IdentityUser user = userRepository.UserByID(userToParticipantRole.UserId);
                users.Add(user);
            }
            return users;
        }
    }
}

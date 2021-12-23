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
            UserToRole kek = roleRepository.AllUsersWithRoleInStage(stage, organizerRole).FirstOrDefault();
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

        //Возвращает число раундов в олимпийской сетке
        private int NRounds(int nParticipants)
        {
            int power = 1;
            while (nParticipants > Math.Pow(2, power))
                power++;
            return power;
        }

        //Возвращает список пар участников для стартового раунда
        private List<Tuple<IdentityUser, IdentityUser>> listOfPairsForStartRound(List<IdentityUser> roundParticipants, int iRound)
        {
            int nRacesInRound = ((int)Math.Pow(2, iRound - 1));
            List<Tuple<IdentityUser, IdentityUser>> resultList = new List<Tuple<IdentityUser, IdentityUser>> { };
            //for (int iRace = 0; iRace < nRacesInRound; ++iRace)
            //    resultList.Add(new Tuple<IdentityUser, IdentityUser>(null, null));
            for (int iPair = 0; iPair < nRacesInRound; ++iPair)
            {
                IdentityUser firstParticipant = null;
                if (iPair < roundParticipants.Count)
                    firstParticipant = roundParticipants[iPair];
                IdentityUser secondParticipant = null;
                if (iPair + nRacesInRound < roundParticipants.Count)
                    secondParticipant = roundParticipants[iPair + nRacesInRound];
                resultList.Add(new Tuple<IdentityUser, IdentityUser>(firstParticipant, secondParticipant));
            }
            return resultList;
        }

        private List<Tuple<IdentityUser, IdentityUser>> listOfPairsForNonStartRound(List<IdentityUser> roundParticipants, int iRound)
        {
            if (iRound == 0)
                return null;

            int nRacesInRound = ((int)Math.Pow(2, iRound - 1));
            List<Tuple<IdentityUser, IdentityUser>> resultList = new List<Tuple<IdentityUser, IdentityUser>> { };
            for (int iPair = 0; iPair < nRacesInRound; ++iPair)
            {
                IdentityUser firstParticipant = null;
                if (iPair * 2 < roundParticipants.Count)
                    firstParticipant = roundParticipants[iPair];
                IdentityUser secondParticipant = null;
                if (iPair * 2 + 1 < roundParticipants.Count)
                    secondParticipant = roundParticipants[iPair + nRacesInRound];
                resultList.Add(new Tuple<IdentityUser, IdentityUser>(firstParticipant, secondParticipant));
            }
            return resultList;
        }

        //Подсчет раундов в обратном порядке: 1 - финал, 2 - полуфинал, 3 - четвертьфинал и тд...
        private List<IdentityUser> EventRoundAndGetListOfWinners(List<Tuple<IdentityUser, IdentityUser>> roundPairs, int iRound, Stage stage)
        {
            List<IdentityUser> resultList = new List<IdentityUser> { };
            //foreach (Tuple<IdentityUser, IdentityUser> racePair in roundPairs)
            for (int iPair = 0; iPair < roundPairs.Count; ++iPair)
                resultList.Add(EventRaceAndGetWinner(roundPairs[iPair], iRound, iPair, stage));
            return resultList;
        }

        private IdentityUser EventRaceAndGetWinner(
            Tuple<IdentityUser, IdentityUser> racePair, 
            int iRound, 
            int iRaceInRound, 
            Stage stage)
        {
            IdentityUser loser = null;
            IdentityUser winner = null;
            if (racePair.Item1 != null)
            {
                winner = racePair.Item1;
                loser = racePair.Item2;
            }
            else 
            {
                winner = racePair.Item2;
                loser = racePair.Item1;
            }
            Race race = new Race 
            { 
                Stage = stage,
                IndexInOlympicSystemp = ((int)Math.Pow(2, iRound - 1)) + iRaceInRound
            };
            raceRepository.AddRace(race);

            RaceResult loserRaceResult = new RaceResult 
            {
                User = loser,
                Race = race,
                ResultPlace = 2
            };
            raceRepository.AddRaceResult(loserRaceResult);

            RaceResult winnerRaceResult = new RaceResult
            {
                User = winner,
                Race = race,
                ResultPlace = 1
            };
            raceRepository.AddRaceResult(winnerRaceResult);

            StageResult loserStageResult = new StageResult
            {
                User = loser,
                Stage = stage,
                ResultPlace = ((int)Math.Pow(2, iRound))
            };
            stageRepository.AddStageResult(loserStageResult);

            return winner;
        }


        public void EventStage(Stage stage)
        {
            List<IdentityUser> stageParticipants = StageParticipants(stage);
            int nRounds = NRounds(stageParticipants.Count);
            List<Tuple<IdentityUser, IdentityUser>> roundPairs = listOfPairsForStartRound(stageParticipants, nRounds);
            List<IdentityUser> winnersList = new List<IdentityUser> { };
            for (int iRound = nRounds; iRound > 0; --iRound) 
            {
                winnersList = EventRoundAndGetListOfWinners(roundPairs, iRound, stage);
                roundPairs = listOfPairsForNonStartRound(winnersList, iRound - 1);
            }
            IdentityUser winner = winnersList[0];
            StageResult winnerStageResult = new StageResult
            {
                User = winner,
                Stage = stage,
                ResultPlace = 1
            };
            stageRepository.AddStageResult(winnerStageResult);
            stage.IsOver = true;
            stageRepository.SaveChanges();
        }
    }
}

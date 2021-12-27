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

        public void RegistrateUserToStage(IdentityUser user, Stage stage, CarNumber carNumber)
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

            StageResult stageResult = new StageResult
            {
                Stage = stage,
                User = user,
                CarNumber = carNumber
            };
            stageRepository.AddStageResult(stageResult);

            Competition competition = competitionRepository.CompetitionByID(stage.CompetitionID);
            CompetitionResult currentCompetitionResult = competitionRepository.UsersCompetitionResult(user, competition);
            if (currentCompetitionResult == null)
            {
                currentCompetitionResult = new CompetitionResult { User = user, Competition = competition };
                competitionRepository.AddCompetitionResult(currentCompetitionResult);
            }
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

        public List<string> StageParticipantNumbers(Stage stage)
        {
            Role participant = roleRepository.ParticipantRole();
            IEnumerable<UserToRole> usersToParticipantRole = roleRepository.AllUsersWithRoleInStage(stage, participant);
            List<string> carNumbers = new List<string> { };
            foreach (UserToRole userToParticipantRole in usersToParticipantRole)
            {
                IdentityUser user = userRepository.UserByID(userToParticipantRole.UserId);
                StageResult result = stageRepository.UsersStageResult(user, stage);
                CarNumber number = carsRepository.CarNumberByID(result.CarNumberID);
                carNumbers.Add(number.Number);
            }
            return carNumbers;
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

            if (loser != null)
            {
                RaceResult loserRaceResult = new RaceResult
                {
                    User = loser,
                    Race = race,
                    ResultPlace = 2
                };
                raceRepository.AddRaceResult(loserRaceResult);
                StageResult loserStageResult = stageRepository.UsersStageResult(loser, stage);
                loserStageResult.ResultPlace = ((int)Math.Pow(2, iRound));
                stageRepository.SaveChanges();
            }

            if (winner != null)
            {
                RaceResult winnerRaceResult = new RaceResult
                {
                    User = winner,
                    Race = race,
                    ResultPlace = 1
                };
                raceRepository.AddRaceResult(winnerRaceResult);
            }
           
            return winner;
        }

        private void UpdateCompetitonResultsAfterStage(Stage stage)
        {
            List<StageResult> stageResults = stageRepository.AllStageResults(stage).ToList();
            Competition competition = competitionRepository.CompetitionByID(stage.CompetitionID);
            for (int iStageResult = 0; iStageResult < stageResults.Count; ++iStageResult)
            {
                StageResult stageResult = stageResults[iStageResult];
                IdentityUser user = userRepository.UserByID(stageResults[iStageResult].UserId);
                CompetitionResult competitionResult = competitionRepository.UsersCompetitionResult(user, competition);
                if (stageResult.ResultPlace == 4)
                    competitionResult.ResultGrade += 1;
                if (stageResult.ResultPlace == 2)
                    competitionResult.ResultGrade += 2;
                if (stageResult.ResultPlace == 1)
                    competitionResult.ResultGrade += 4;
                competitionRepository.SaveChanges();
            }
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
            if (winner != null)
            {
                StageResult winnerStageResult = stageRepository.UsersStageResult(winner, stage);
                winnerStageResult.ResultPlace = 1;
                stageRepository.SaveChanges();
            }
            stage.IsOver = true;
            stageRepository.SaveChanges();
            UpdateCompetitonResultsAfterStage(stage);
        }

        public List<List<Tuple<IdentityUser, IdentityUser>>> allRoundsPairsOfStage(Stage stage)
        {
            if (stage == null)
                return new List<List<Tuple<IdentityUser, IdentityUser>>>{ };
            if (!stage.IsOver)
                return new List<List<Tuple<IdentityUser, IdentityUser>>> { };

            List<IdentityUser> stageParticipants = StageParticipants(stage);
            int nRounds = NRounds(stageParticipants.Count);

            List<List<Tuple<IdentityUser, IdentityUser>>> resultList = new List<List<Tuple<IdentityUser, IdentityUser>>> { };
            for (int iRound = 0; iRound < nRounds; ++iRound)
            {
                List<Tuple<IdentityUser, IdentityUser>> roundList = new List<Tuple<IdentityUser, IdentityUser>> { };
                int nRacesInRound = ((int)Math.Pow(2, nRounds - iRound - 1));
                for (int iRace = 0; iRace < nRacesInRound; ++iRace)
                {
                    Race race = raceRepository.RaceInStageByOlympicNumber(stage, ((int)Math.Pow(2, nRounds - iRound - 1)) + iRace);
                    if (race == null)
                    {
                        roundList.Add(new Tuple<IdentityUser, IdentityUser>(null, null));
                        continue;
                    }

                    RaceResult loserResult = raceRepository.ResultByPlace(race, 2);
                    RaceResult winnerResult = raceRepository.ResultByPlace(race, 1);

                    IdentityUser loser = null;
                    IdentityUser winner = null;

                    if (loserResult != null)
                    {
                        string loserID = loserResult.UserId;
                        loser = userRepository.UserByID(loserID);
                    }
                    if (winnerResult != null)
                    {
                        string winnerID = winnerResult.UserId;
                        winner = userRepository.UserByID(winnerID);
                    }
                    roundList.Add(new Tuple<IdentityUser, IdentityUser>(winner, loser));
                }
                resultList.Add(roundList);
            }
            return resultList;
        }

        public List<List<Tuple<string, string>>> RoundPairsUsersToRoundPairsNames(
            List<List<Tuple<IdentityUser, IdentityUser>>> roundPairsUsers)
        {
            List<List<Tuple<string, string>>> resultList = new List<List<Tuple<string, string>>> { };
            for (int iRow = 0; iRow < roundPairsUsers.Count; ++iRow)
            {
                List<Tuple<string, string>> rowList = new List<Tuple<string, string>> { };
                for (int iCol = 0; iCol < roundPairsUsers[iRow].Count; ++iCol)
                {
                    string firstStr = "Отсутствует";
                    string secondStr = "Отсутствует";
                    if (roundPairsUsers[iRow][iCol].Item1 != null)
                        firstStr = roundPairsUsers[iRow][iCol].Item1.UserName;
                    if (roundPairsUsers[iRow][iCol].Item2 != null)
                        secondStr = roundPairsUsers[iRow][iCol].Item2.UserName;
                    rowList.Add(new Tuple<string, string>(firstStr, secondStr));
                }
                resultList.Add(rowList);
            }
            return resultList;
        }

        public void RemoveParticipantFromStage(IdentityUser participant, Stage stage)
        {
            Role participantRole = roleRepository.ParticipantRole();
            UserToRole utr = roleRepository.UserToRoleByAllParams(participant, participantRole, stage);
            StageResult result = stageRepository.UsersStageResult(participant, stage);
            roleRepository.RemoveUserToRole(utr);
            stageRepository.RemoveStageResult(result);
        }
    }
}

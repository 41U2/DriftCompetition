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

        public DriftCompetitionDevice(ApplicationDbContext dbContext) 
        {
            carsRepository = new CarRepository(dbContext);
            competitionRepository = new CompetitionRepository(dbContext);
            raceRepository = new RaceRepository(dbContext);
            roleRepository = new RoleRepository(dbContext);
            stageRepository = new StageRepository(dbContext);
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DriftCompetitionWeb.Models;

namespace DriftCompetitionWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Car> Cars { set; get; }
        public DbSet<CarNumber> CarNumbers { set; get; }
        public DbSet<Competition> Competitions { set; get; }
        public DbSet<CompetitionResult> CompetitionResults { set; get; }
        public DbSet<Stage> Stages { set; get; }
        public DbSet<StageResult> StageResults { set; get; }
        public DbSet<Race> Races { set; get; }
        public DbSet<RaceResult> RaceResults { set; get; }
        public DbSet<Role> DriftCompetitionRoles { set; get; }
        public DbSet<UserToRole> UsersToRoles { set; get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

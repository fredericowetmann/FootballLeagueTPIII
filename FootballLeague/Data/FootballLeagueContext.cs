using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FootballLeague.Data
{
    public class FootballLeagueContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FootballLeagueContext() : base("name=FootballLeagueContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Desativa delete em cascata nas FK de Match para Team
            modelBuilder.Entity<Match>()
                .HasRequired(m => m.HomeTeam)
                .WithMany()
                .HasForeignKey(m => m.HomeTeamId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.AwayTeam)
                .WithMany()
                .HasForeignKey(m => m.AwayTeamId)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<FootballLeague.Models.Team> Teams { get; set; }

        public System.Data.Entity.DbSet<FootballLeague.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<FootballLeague.Models.Commission> Commissions { get; set; }

        public System.Data.Entity.DbSet<FootballLeague.Models.League> Leagues { get; set; }

        public System.Data.Entity.DbSet<FootballLeague.Models.LeagueStanding> LeagueStandings { get; set; }

        public System.Data.Entity.DbSet<Round> Rounds { get; set; }

        public System.Data.Entity.DbSet<Match> Matchs { get; set; }

    }
}

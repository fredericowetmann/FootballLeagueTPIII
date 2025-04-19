using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballLeague.Models
{
    public class Match
    {
        public int Id { get; set; }

        [Display(Name = "Time da Casa")]
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }

        [Display(Name = "Time Visitante")]
        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }

        [Display(Name = "Gols Casa")]
        public int? HomeGoals { get; set; }

        [Display(Name = "Gols Visitante")]
        public int? AwayGoals { get; set; }

        [Display(Name = "Data da Partida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:N2}",
        ApplyFormatInEditMode = true)]
        public DateTime MatchDate { get; set; }

        [Display(Name = "Estádio Jogado")]
        public string Stadium { get; set; }

        public int RoundId { get; set; }
        public virtual Round Round { get; set; }

        public virtual ICollection<Goal> Goals { get; set; }
    }
}
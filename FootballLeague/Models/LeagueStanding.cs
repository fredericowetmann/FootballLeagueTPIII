using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballLeague.Models
{
    public class LeagueStanding
    {
        public int Id { get; set; }

        public int TimeId { get; set; }
        [Display(Name = "Time")]
        public virtual Team Time { get; set; }

        public int LeagueId { get; set; }
        public virtual League League { get; set; }

        [Display(Name = "Pontos")]
        public int Points { get; set; }
        [Display(Name = "Vitórias")]
        public int Victories { get; set; }
        [Display(Name = "Empate")]
        public int Draw { get; set; }
        [Display(Name = "Derrotas")]
        public int Defeats { get; set; }
        [Display(Name = "Gols a Favor")]
        public int GolsFor { get; set; }
        [Display(Name = "Gols Contra")]
        public int GolsAgainst { get; set; }

        [Display(Name = "Saldo de Gols")]
        public int GolsDifference    => GolsFor - GolsAgainst;
    }
}
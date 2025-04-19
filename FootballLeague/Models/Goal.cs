using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballLeague.Models
{
    public class Goal
    {
        public int Id { get; set; }

        [Display(Name = "Jogador")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        [Display(Name = "Partida")]
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        [Display(Name = "Minuto do Gol")]
        [Range(0, 120)]
        public int? Minute { get; set; }  // Opcional

        [Display(Name = "Gol Contra")]
        public bool IsOwnGoal { get; set; }  // true se for gol contra
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FootballLeague.Models
{
    public class League
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }

        // Relacionamento: uma liga possui vários times
        public virtual ICollection<LeagueStanding> Classification { get; set; }

        public virtual ICollection<Team> Times { get; set; } = new List<Team>();

        [NotMapped]
        public bool Status => Times != null && Times.Count == 20 && Times.All(t => t.Status);
    }
}
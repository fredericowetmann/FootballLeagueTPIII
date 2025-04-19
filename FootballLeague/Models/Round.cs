using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballLeague.Models
{
    public class Round
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
    }
}
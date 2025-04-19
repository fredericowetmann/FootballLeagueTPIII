using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FootballLeague.Models
{

    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
            Coaches = new List<Commission>();
        }

        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Cidade")]
        public string City { get; set; }
        [Display(Name = "Estado")]
        public string State { get; set; }
        [Display(Name = "Ano de Fundação")]
        public int? FoundationYear { get; set; }
        [Display(Name = "Estádio")]
        public string Stadium { get; set; }
        [Display(Name = "Capacidade Estádio")]
        public int? CapacityStadium { get; set; }
        [Display(Name = "Cores Principais")]
        public string MainColors { get; set; }
        [Display(Name = "Cores Secundarias")]
        public string SecondaryColors { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Commission> Coaches { get; set; }
        public int? LeagueId { get; set; }
        public virtual League Liga { get; set; }

        [NotMapped]
        public bool Status
        {
            get
            {
                // Verifica se há 30 jogadores
                bool tem30Jogadores = Players != null && Players.Count >= 30;

                // Verifica se todas as funções estão preenchidas
                var funcoesNecessarias = Enum.GetValues(typeof(Function)).Cast<Function>().ToList();
                var funcoesPresentes = Coaches
                    .Where(c => c.Function.HasValue)
                    .Select(c => c.Function.Value)
                    .Distinct()
                    .ToList();

                bool todasFuncoesPreenchidas = !funcoesNecessarias.Except(funcoesPresentes).Any();

                return tem30Jogadores && todasFuncoesPreenchidas;
            }
        }

        [NotMapped]
        [Display(Name = "Status")]
        public string StatusText => Status ? "Completo" : "Incompleto";
    }
}
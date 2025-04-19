using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballLeague.Models
{
    public enum Position
    {
        Goleiro, Zagueiro, LateralEsquerdo, LateralDireito, Volante, AlaEsquerdo, AlaDireito, MeioCampoEsquerdo, MeioCampoDireito, MeiaCentral, MeiaLateral, MeiaAtacanteEsquerdo, MeiaAtacanteDireito, Ponta, AtacanteEsquerdo, AtacanteDireito
    }

    public enum MainFeet
    {
        Direito, Esquerdo, Ambidestro
    }

    public class Player
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Nacionalidade")]
        public string Nacionality { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Posição")]
        public Position? Position { get; set; }
        [Display(Name = "Número da Camisa")]
        public int? ShirtNumber { get; set; }
        [Display(Name = "Altura")]
        [DisplayFormat(DataFormatString = "{0:N2}",
        ApplyFormatInEditMode = true)]
        public decimal? Height { get; set; }
        [Display(Name = "Peso")]
        [DisplayFormat(DataFormatString = "{0:N2}",
        ApplyFormatInEditMode = true)]
        public decimal? Weight { get; set; }
        [Display(Name = "Pé Principal")]
        public MainFeet? MainFeet { get; set; }

        public int? TeamId { get; set; }  // FK
        [Display(Name = "Time")]
        public virtual Team Team { get; set; }  // Navegação

        public virtual ICollection<Goal> Goals { get; set; }
    }
}
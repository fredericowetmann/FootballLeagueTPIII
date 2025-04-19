using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballLeague.Models
{
    public enum Function
    {
        Treinador, Auxiliar, PreparadorFisico, Fisiologista, TreinadorGoleiros, Fisioterapeuta
    }

    public class Commission
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Função")]
        public Function? Function { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public int? TeamId { get; set; }  // FK
        [Display(Name = "Time")]
        public virtual Team Team { get; set; }  // Navegação
    }
}
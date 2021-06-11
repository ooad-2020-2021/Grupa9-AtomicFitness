using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static AtomicFitness.Models.Enums;

namespace AtomicFitness.Models
{
    public class Vjezba
    {
        [Key]
        public int VjezbaID { get; set; }

        public int FitnesProgramID { get; set; }

        [Display(Name = "Name")]  
        [Required]
        public string Naziv { get; set; }

        [EnumDataType(typeof(Oprema))]
        [Display(Name = "Equipment")]
        [Required]
        public Oprema Oprema { get; set; }

        [EnumDataType(typeof(Level))]
        [Display(Name = "Level")]
        [Required]
        public Level Level { get; set; }

        [EnumDataType(typeof(Misici))]
        [Display(Name = "Muscles")]
        [Required]
        public Misici Misici { get; set; }

        [Display(Name = "Reps")]
        [Required]
        public int BrojPonavljanja { get; set; }

        [Display(Name = "Sets")]
        [Required]
        public int BrojSerija { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Opis { get; set; }

        [Display(Name = "Link to picture")]
        [Required]
        public string Link { get; set; }

        public Vjezba() { }

    }
}

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
        public string Naziv { get; set; }

        [EnumDataType(typeof(Oprema))]
        [Display(Name = "Equipment")]
        public Oprema Oprema { get; set; }

        [EnumDataType(typeof(Level))]
        [Display(Name = "Fitness Level")]
        public Level Level { get; set; }

        [EnumDataType(typeof(Misici))]
        [Display(Name = "Muscles Worked")]
        public Misici Misici { get; set; }

        [Display(Name = "Recommended Reps")]
        public int BrojPonavljanja { get; set; }

        [Display(Name = "Receommended Sets")]
        public int BrojSerija { get; set; }

        [Display(Name = "Description")]
        public string Opis { get; set; }

        public Vjezba() { }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicFitness.Models
{
    public class Vjezba
    {
        [Key]
        public int VjezbaID { get; set; }

        public int FitnesProgramID { get; set; }

        [Display(Name = "Name")]        
        public string Naziv { get; set; }

        [Display(Name = "Equipment")]
        public string Oprema { get; set; }

        [Display(Name = "Fitness Level")]
        public string Level { get; set; }

        [Display(Name = "Muscles Worked")]
        [NotMapped]
        public List<string> Misici { get; set; }

        [Display(Name = "Recommended Reps")]
        public int BrojPonavljanja { get; set; }

        [Display(Name = "Receommended Sets")]
        public int BrojSerija { get; set; }

        [Display(Name = "Description")]
        [NotMapped]
        public string Opis { get; set; }

        public Vjezba() { }

    }
}

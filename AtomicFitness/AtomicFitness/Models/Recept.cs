using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicFitness.Models
{
    public class Recept
    {
        [Key]
        public int ReceptID { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Naziv { get; set; }

        [Display(Name = "Ingredients")]
        [Required]
        public string Sastojci { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Opis { get; set; }

        [Display(Name = "Link to picture")]
        [Required]
        public string Link { get; set; }

        public Recept() { }

    }
}

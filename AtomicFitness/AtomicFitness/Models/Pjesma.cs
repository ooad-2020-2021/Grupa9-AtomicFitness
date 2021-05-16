using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicFitness.Models
{
    public class Pjesma
    {
        [Key]
        public int PjesmaID { get; set; }

        [Display(Name = "Name")]
        public string Naziv { get; set; }

        [Display(Name = "Singers")]
        [NotMapped]
        public List<string> Pjevaci { get; set; }

        [Display(Name = "Genre")]
        public string Zanr { get; set; }

        [Display(Name = "Release Date")]
        public DateTime GodinaIzdanja { get; set; }

        public Pjesma() { }
    }
}

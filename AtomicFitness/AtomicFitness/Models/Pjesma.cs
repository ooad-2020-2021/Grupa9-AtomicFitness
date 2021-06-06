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
        [Required]
        public string Naziv { get; set; }

        [Display(Name = "Singers")]
        [Required]
        public string Pjevaci { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public string Zanr { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [Display(Name = "Release date")]
        [Required]
        public DateTime GodinaIzdanja { get; set; }

        [Display(Name = "Link to YouTube")]
        [Required]
        public string Link { get; set; }

        public Pjesma() { }
    }
}

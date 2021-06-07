using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static AtomicFitness.Models.Enums;

namespace AtomicFitness.Models
{
    public class FitnesProfil
    {
        [Key]
        public int FitnesProfilID { get; set; }

        [EnumDataType(typeof(Spol))]
        [Display(Name = "Gender")]
        [Required]
        public Spol Spol { get; set; }

        [EnumDataType(typeof(Level))]
        [Display(Name = "Level")]
        [Required]
        public Level Level { get; set; }

        [Range(15,80,ErrorMessage = "Your age should be in the range 15 to 80")]
        [Display(Name = "Age")]
        [Required]
        public int Starost { get; set; }

        [Range(50,120,ErrorMessage = "Your weight should be in the range 50kg to 120kg")]
        [Display(Name = "Weight")]
        [Required]
        public int Kilaza { get; set; }

        [Range(150,200,ErrorMessage = "Your height should be in the range 150cm to 200cm")]
        [Display(Name = "Height")]
        [Required]
        public int Visina { get; set; }

        [EnumDataType(typeof(Oprema))]
        [Display(Name = "Equipment")]
        [Required]
        public Oprema Oprema { get; set; }

        [EnumDataType(typeof(Ciljevi))]
        [Display(Name = "Goals")]
        [Required]
        public Ciljevi Ciljevi { get; set; }

        [EnumDataType(typeof(Misici))]
        [Display(Name = "Muscles")]
        [Required]
        public Misici Misici { get; set; }

        public int Id { get; set; }

        public FitnesProfil() { }
    }
}

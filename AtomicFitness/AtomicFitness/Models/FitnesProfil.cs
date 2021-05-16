using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicFitness.Models
{
    public enum Spol
    {
        [Display(Name = "Male")]
        M,
        [Display(Name = "Female")]
        F
    }

    public enum Level
    {
        [Display(Name = "Beginner")]
        Beginner,
        [Display(Name = "Intermediate")]
        Intermediate,
        [Display(Name = "Advanced")]
        Advanced
    }

    public enum Oprema
    {
        [Display(Name = "Dumbbell")]
        Dumbbell,
        [Display(Name = "Barbell")]
        Barbell,
        [Display(Name = "Kettlebell")]
        Kettlebell,
        [Display(Name = "Weight Machine")]
        WeightMachine,
        [Display(Name = "Cardio Machine")]
        CardioMachine,
        [Display(Name = "Resistance Band")]
        ResistanceBand
    }

    public enum Ciljevi
    {
        [Display(Name = "Loose Weight")]
        LooseWeight,
        [Display(Name = "Gain Muscle")]
        GainMuscle,
        [Display(Name = "Improve Health")]
        ImproveHealth
    }
    public class FitnesProfil
    {
        [Key]
        public int FitnesProfilID { get; set; }

        [EnumDataType(typeof(Spol))]
        [Display(Name = "Gender")]
        [Required]
        public char Spol { get; set; }

        [EnumDataType(typeof(Level))]
        [Display(Name = "Fitness Level")]
        [Required]
        public string Level { get; set; }

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
        [Display(Name = "Equipment You Have Access To")]
        [Required]
        [NotMapped]
        public List<string> Oprema { get; set; }

        [EnumDataType(typeof(Ciljevi))]
        [Display(Name = "Goals")]
        [Required]
        public string Ciljevi { get; set; }

        public FitnesProfil() { }
    }
}

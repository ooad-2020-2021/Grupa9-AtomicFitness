using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicFitness.Models
{
    public class Enums
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
            [Display(Name = "Lose Weight")]
            LoseWeight,
            [Display(Name = "Gain Muscle")]
            GainMuscle,
            [Display(Name = "Improve Health")]
            ImproveHealth
        }

        public enum Misici
        {
            [Display(Name = "Neck")]
            Neck,
            [Display(Name = "Shoulders")]
            Shoulders,
            [Display(Name = "Chest")]
            Chest,
            [Display(Name = "Back")]
            Back,
            [Display(Name = "Waist")]
            Waist,
            [Display(Name = "Hips")]
            Hips,
            [Display(Name = "Thighs")]
            Thighs,
            [Display(Name = "Calves")]
            Calves,
            [Display(Name = "Arms")]
            Arms
        }
    }
}

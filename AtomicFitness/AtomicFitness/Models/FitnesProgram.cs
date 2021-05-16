using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicFitness.Models
{
    public class FitnesProgram
    {
        [Key]
        public int FitnesProgramID { get; set; }

        public int KorisnikID { get; set; }

        public FitnesProgram() { }
    }
}

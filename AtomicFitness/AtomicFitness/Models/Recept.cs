﻿using System;
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
        public string Naziv { get; set; }

        [Display(Name = "Ingredients")]
        public string Sastojci { get; set; }

        [Display(Name = "Description")]
        public string Opis { get; set; }

        public Recept() { }

    }
}
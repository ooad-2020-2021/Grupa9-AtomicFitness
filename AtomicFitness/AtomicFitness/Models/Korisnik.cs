using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicFitness.Models
{
    public class Korisnik
    {
        [Key]
        public int KorisnikID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Your first name should have at least 3 characters and no more than 20")]
        [RegularExpression(@"[A-Z|a-z]*")]
        public string Ime { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Your last name should have at least 3 characters and no more than 20")]
        [RegularExpression(@"[A-Z|a-z]*")]
        [Required]
        public string Prezime { get; set; }

        [Display(Name = "Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([azA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Your email address is not valid")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [StringLength(20,MinimumLength = 5, ErrorMessage = "Your password should have at least 5 characters and no more than 20")]
        [Required]
        public string Sifra { get; set; }

        public int FitnesProfilID { get; set; }
        public FitnesProfil FitnesProfil { get; set; }

        public Korisnik() { }

    }
}

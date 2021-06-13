using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AtomicFitness.Models
{
    public class Korisnik: IdentityUser
    {

        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Your first name should have at least 3 characters and no more than 20")]
        [RegularExpression(@"[A-Z|a-z]*", ErrorMessage = "You can only use letters from the English alphabet")]
        [Required]
        public string Ime { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Your last name should have at least 3 characters and no more than 20")]
        [RegularExpression(@"[A-Z|a-z]*", ErrorMessage = "You can only use letters from the English alphabet")]
        [Required]
        public string Prezime { get; set; }

        public Korisnik() { }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetPFE.Server.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Nom { get; set; }
        [Required]
        [StringLength(100)]
        public string Prenom { get; set; }
        public DateOnly DateNaiss { get; set; }
        public string Poste { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        [Required]
        public int Matricule { get; set; }
        public bool IsActive { get; set; } = false;

    }
}

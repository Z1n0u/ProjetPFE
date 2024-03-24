using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class User
    {
        [Key]
        [StringLength(100)]
        public string? Username { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nom { get; set; }
        [Required]
        [StringLength(100)]
        public string? Prenom { get; set; }
        public DateOnly DateNaiss { get; set; }
        [Required]
        public string? Poste { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? Adresse { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string? Tel { get; set; }
        [Required]
        public string? Matricule { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? Motdepasse { get; set; }
        public bool IsActive { get; set; } = false;
        public List<Fiche>? Fiches { get; set; }
        public Agence? Agence { get; set; }
        public List<Admin>? Admins { get; set; }

    }
}

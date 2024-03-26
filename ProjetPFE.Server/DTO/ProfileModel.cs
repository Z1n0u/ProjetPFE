using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.DTO
{
    public class ProfileModel
    {



        [EmailAddress]
        public string? Email { get; set; }


        [DataType(DataType.Password)]
        [MinLength(11)]
        public string? Motdepasse { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Motdepasse))]

        public string? ConfirmMotdepasse { get; set; }

        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public DateOnly DateNaiss { get; set; }

        public string? Poste { get; set; }

        public string? Adresse { get; set; }
        [Required]
        public string? Matricule { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [MinLength(10)]
        public string? Tel { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Personne
    {
        [Key]
        public int Id_Personne { get; set; }
        [Required]
        [StringLength(50)]
        public string? Occupation { get; set; }
        [Required]
        [StringLength(50)]
        public string? Nom { get; set; }
        [Required]
        [StringLength(50)]
        public string? prenom { get; set; }
        public Partie_mise_en_cause? Partie_Mise { get; set; }

    }
}

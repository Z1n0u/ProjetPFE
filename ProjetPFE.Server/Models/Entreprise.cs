using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Entreprise
    {
        [Key] 
        public int Id_Entreprise { get; set; }
        [Required]
        [StringLength(50)]
        public string? Occupation { get; set; }
        public Partie_mise_en_cause? Partie_Mise { get; set; }
    }
}

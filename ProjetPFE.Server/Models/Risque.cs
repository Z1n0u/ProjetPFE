using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Risque
    {
        [Key] 
        public int Id_Risque { get; set; }
        [Required]
        [StringLength(50)]
        public string? Label_Risque { get; set; }
        public Sous_Categorie? Sous_Categorie { get; set; }
        public Fiche? Fiche { get; set; }
    }
}

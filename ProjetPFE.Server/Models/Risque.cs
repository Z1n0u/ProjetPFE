using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetPFE.Server.Models
{
    public class Risque
    {
        [Key]
        public int Id_Risque { get; set; }
        [Required]
        [StringLength(120)]
        public string? Label_Risque { get; set; }

        // Clé étrangère pour la sous-catégorie (libellé)
        [ForeignKey("Sous_Categorie")]
        [Required]
        public string? Sous_CategorieLabel_Sous_Categorie { get; set;}
        public Sous_Categorie? Sous_Categorie { get; set;}

        // Propriété de navigation vers la fiche si nécessaire
        public Fiche? Fiche { get; set; }
    }
}

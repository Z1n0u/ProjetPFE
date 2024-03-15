using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Categorie
    {
        [Key]
        [StringLength(50)]
        public string? Label_Categorie { get; set; }
        public List<Sous_Categorie>? Sous_Categories { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Sous_Categorie
    {
        [Key]
        public string? Label_Sous_Categorie { get; set; }
        public Categorie? Categorie { get; set; }
        public List<Risque>? Risques { get; set; }
    }
}

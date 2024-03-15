using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Famille
    {
        [Key]
        [StringLength(100)]
        [MaxLength(100)]
        public string? Nom_Famille { get; set; }
        public List<Domaine>? Domaines { get; set; }
        public List<Fiche>? Fiches { get; set; }
    }
}

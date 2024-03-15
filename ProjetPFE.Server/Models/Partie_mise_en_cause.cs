using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Partie_mise_en_cause
    {
        [Key]
        [StringLength(50)]
        public string? Statut { get; set; }
        public List<Entreprise>? Entreprises { get; set; }
        public List<Personne>? Personnes { get; set; }
        public Fiche? Fiche { get; set; }
    }
}

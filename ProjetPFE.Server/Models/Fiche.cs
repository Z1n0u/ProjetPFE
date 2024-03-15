using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Fiche
    {
        [Key]
        public int Id_incident { get; set; }
        public int Compte_dzd_devise { get; set; }
        [StringLength(50)]
        public string? Types_comptes { get; set; }
        [StringLength(50)]
        public string? Types_Sous_Comptes { get; set; }
        [StringLength(50)]
        public List<string>? Types_impacte { get; set; }
        public float Montant_Perte { get; set; }
        public string? Devise { get; set; }
        public string? Mesures_Prise { get; set; }
        public string? Description { get; set; }
        public string? Categorie_incident { get; set; }
        public User? User { get; set; }
        public Service? Service_Defaillant { get; set; }
        public List<Service>? Services_Affecter { get; set; }
        public Famille? Famille { get; set; }
        public List<Partie_mise_en_cause>? Partie_Mise_En_Causes { get; set; }
        public List<Risque>? Risques { get; set; }

    }
}

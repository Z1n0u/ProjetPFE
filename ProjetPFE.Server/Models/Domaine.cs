using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Domaine
    {
        [Key]
        [StringLength(100)]
        public string? Nom_Domaine { get; set; }
        public List<Processus>? Processus { get; set; }
        public Famille? Famille { get; set; }
    }
}

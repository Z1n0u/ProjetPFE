using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Processus
    {
        [Key]
        [StringLength(100)]
        [MaxLength(100)]
        public string? Nom_Processus { get; set; }
        public Domaine? Domaine { get; set; }
    }
}

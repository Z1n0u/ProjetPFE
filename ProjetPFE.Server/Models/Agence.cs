using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Agence
    {
        [Key]
        public int Code_Agence { get; set; }
        [Required]
        public string? Libelle { get; set; }
        public List<User>? Users { get; set; }
        public Dre? Direction { get; set; }
    }
}

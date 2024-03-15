using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Dre
    {
        [Key]
        public int Code_Direction { get; set; }
        [Required]
        [StringLength(250)]
        public string? Libelle { get; set; }
        public List<Agence>? Agences { get; set; }
        public List<Admin>? Admins { get; set; }
    }
}

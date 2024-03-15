using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Admin
    {
        [Key]
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? mot_de_passe { get; set; }
        public List<User>? Users { get; set; }
        public Dre? Direction { get; set; }
    }
}

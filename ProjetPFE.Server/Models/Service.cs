using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.Models
{
    public class Service
    {
        [Key]
        public int Id_Service { get; set; }
        [Required]
        [StringLength(50)]
        public string? Label_Service { get; set; }
    }
}

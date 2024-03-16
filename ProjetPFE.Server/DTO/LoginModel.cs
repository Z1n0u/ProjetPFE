using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? motdepasse { get; set; }
    }
}

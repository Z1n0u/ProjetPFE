using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.DTO
{
    public class LoginModel
    {
        
        public string? Username { get; set; }
        [DataType(DataType.Password)]
        public string? motdepasse { get; set; }
    }
}

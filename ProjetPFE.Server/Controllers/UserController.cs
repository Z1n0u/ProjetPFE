using Microsoft.AspNetCore.Mvc;
using ProjetPFE.Server.Data;
using ProjetPFE.Server.DTO;
using ProjetPFE.Server.Models;
using System.Linq;
using System.Security.Claims;

namespace ProjetPFE.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("UpdateProfile")]
        public IActionResult UpdateProfile([FromBody] RegisterModel userProfile)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { message = "User not authorized" });
            }

            var username = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "username")?.Value;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return NotFound(new { message = " User not found" });
            }

            user.Nom = userProfile.Nom;
            user.Email = userProfile.Email;
            user.Adresse = userProfile.Adresse;
            user.Tel = userProfile.Tel;
            user.Prenom = userProfile.Prenom;
            user.Matricule = userProfile.Matricule;
            user.Motdepasse = userProfile.Motdepasse;
            user.DateNaiss = userProfile.DateNaiss;

            _context.SaveChanges();
            return Ok(new { message = "Profile updated" });
        }
    }
}

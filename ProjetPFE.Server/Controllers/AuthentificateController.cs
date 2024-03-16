using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetPFE.Server.Data;
using ProjetPFE.Server.DTO;
using ProjetPFE.Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetPFE.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificateController : ControllerBase
    {
       private readonly ApplicationDbContext _context;

        public AuthentificateController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid || registerModel == null)
            {
                return StatusCode(400,new Response {Status="Error", Message = "User Registration Failed" });
            }
            var user = _context.Users.FirstOrDefault(u=> u.Username == registerModel.Username);
            if (user != null)
                return StatusCode(401, new Response { Status = "Error", Message = "UserName already Taken please chose another username" });
           
            var Newuser = new User()
                {
                    Username = registerModel.Username,
                    Nom = registerModel.Nom,
                    Prenom = registerModel.Prenom,
                    DateNaiss = registerModel.DateNaiss,
                    Poste = registerModel.Poste,
                    Adresse = registerModel.Adresse,
                    Matricule = registerModel.Matricule,
                    Email = registerModel.Email,
                    Tel = registerModel.Tel,
                    Motdepasse = registerModel.Motdepasse,
                };
            try
            {
                _context.Users.Add(Newuser);
                _context.SaveChanges(); // Save changes to the database

                return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            }
            catch (DbUpdateException ex)
            {
                // Handle database-related errors (e.g., log the error, return a generic error message)
                return StatusCode(500, "Une erreur s'est produite lors de l'ajout de l'utilisateur : " +ex.InnerException);
            }
            catch (Exception ex) // Catch other unexpected exceptions
            {
                // Log the error, return a generic error message
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel loginmodel)
        {
            if (!ModelState.IsValid || loginmodel == null)
                return StatusCode(400, new Response { Status = "Error", Message = "login Failed" });

            var Existser = _context.Users.FirstOrDefault(u => u.Username == loginmodel.Username && u.Motdepasse == loginmodel.motdepasse);
            if (Existser == null)
                return StatusCode(400, new Response { Status = "Error", Message = "login Failed make sure you entre the required information" });
            

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using ProjetPFE.Server.Data;
using ProjetPFE.Server.DTO;
using ProjetPFE.Server.Models;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetPFE.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificateController : ControllerBase
    {
       private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthentificateController(ApplicationDbContext context , IConfiguration config)
        {
            _context = context;
            _config = config;
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
        public async Task<IActionResult> Login([FromBody] LoginModel loginmodel)
        {
            if (!ModelState.IsValid || loginmodel == null)
                return StatusCode(400, new Response { Status = "Error", Message = "login Failed" });

            var Existser = _context.Users.FirstOrDefault(u => u.Username == loginmodel.Username && u.Motdepasse == loginmodel.motdepasse);
            if (Existser == null)
                return StatusCode(400, new Response { Status = "Error", Message = "login Failed make sure you entre the required information" });

            // hado claims homa li fihom les info li 7andirohom fi coockies hana 3and user normal ukon 3ando role user
            //bach na9adro njiriw washm les page li ya9der yadkhol lihom
            var claims = new List<Claim> {
                new Claim("role", "user"),
                new Claim("username",loginmodel.Username)
            };
            //hadi ghir var bach nrécupiri el coockiename mil appsettings.json
            var Thecoockiename = _config.GetValue<string>("Thecoockiename");
            //bil claims  ncreeyiw Identities 
            var Identity = new ClaimsIdentity(claims, Thecoockiename);
            
            // wa hado les indentities na7atohom fi claimsprincipal 
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(Identity);
           
            //ombe3da hadok les claims principale nakhdmo bihom el coockie bi singinasync hiya les 7at codi el coockie 
            //3ala 7asab 7ana wash khayarna coockie scheme li howa hana 'thecoockiename'
            await HttpContext.SignInAsync(Thecoockiename, claimsPrincipal);

            var session = HttpContext.Session;

            return Ok(new Response { Status = "Success", Message = "Login seccessesful" });
        }

        //NOTE : lazem la logout button mwrapiya fi <form> khatach hada endpoint post tsema yposti lil endpoint
        //hadi "api/authentificate/logout", yeclicki 3ala logout button bach yetssuprima el coockie tsema
        //lazem ya3awad ylogi in bach ya9der yaddkhol lil les page li fihom [authorize]
        //[NonAction]
        
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(_config.GetValue<string>("Thecoockiename"));
            return Ok(new Response { Status = "seccess", Message = "logout seccessesful" });
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
            user.Tel=userProfile.Tel;
            user.Prenom=userProfile.Prenom;
            user.Matricule = userProfile.Matricule;
            user.Motdepasse = userProfile.Motdepasse;
            user.DateNaiss = userProfile.DateNaiss;

            _context.SaveChanges();
            return Ok(new {message ="Profile updated"});
        }


    }
}

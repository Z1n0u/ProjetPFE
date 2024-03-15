using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetPFE.Server.Data;
using ProjetPFE.Server.Models;

namespace ProjetPFE.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
                

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(User ObjUser)
        {
            var user = new User
            {
                Username = ObjUser.Username,
                Email = ObjUser.Email,
                Poste = ObjUser.Poste,
                Motdepasse = ObjUser.Motdepasse,
                Tel = ObjUser.Tel,
                Matricule = ObjUser.Matricule,
                Nom = ObjUser.Nom,
                Prenom = ObjUser.Prenom,
                Adresse = ObjUser.Adresse,
            };




            await _applicationDbContext.Users.AddAsync(user);
            await _applicationDbContext.SaveChangesAsync();
            return (IActionResult)user;
        }
            //[HttpPost]
            //public async Task<User> UpdateUser(User objUser)
            //{
            //
            //}


    }
}

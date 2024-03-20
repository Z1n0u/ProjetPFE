﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetPFE.Server.Data;
using ProjetPFE.Server.DTO;
using ProjetPFE.Server.Models;
using System.Linq;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpGet]
        [Route("GetProfile")]
        public IActionResult GetProfile()
        {
            // Vérifier si l'utilisateur est authentifié
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { message = "User not authorized" });
            }

            // Récupérer le nom d'utilisateur de l'utilisateur connecté
            var username = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "username")?.Value;

            // Rechercher l'utilisateur dans la base de données
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            // Vérifier si l'utilisateur existe
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            // Retourner les informations du profil de l'utilisateur
            return Ok(new ProfileModel
            {
                Nom = user.Nom,
                Prenom = user.Prenom,
                Email = user.Email,
                Adresse = user.Adresse,
                Tel = user.Tel,
                Matricule = user.Matricule,
                DateNaiss = user.DateNaiss,
                Poste = user.Poste,
                Motdepasse =  user.Motdepasse.Substring(0, Math.Min(user.Motdepasse.Length, 3)) +
                             new string('*', Math.Max(0, user.Motdepasse.Length - 3))
        });
        }

        [HttpPost]
        [Route("UpdateProfile")]
        public IActionResult UpdateProfile([FromBody] ProfileModel userProfile)
        {
            // Vérifier si l'utilisateur est authentifié
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { message = "User not authorized" });
            }

            // Récupérer le nom d'utilisateur de l'utilisateur connecté
            var username = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "username")?.Value;

            // Rechercher l'utilisateur dans la base de données
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            // Vérifier si l'utilisateur existe
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            // Mettre à jour les propriétés du profil avec les nouvelles valeurs fournies
            if (!string.IsNullOrWhiteSpace(userProfile.Nom))
            {
                user.Nom = userProfile.Nom;
            }
            if (!string.IsNullOrWhiteSpace(userProfile.Prenom))
            {
                user.Prenom = userProfile.Prenom;
            }
            if (!string.IsNullOrWhiteSpace(userProfile.Email))
            {
                user.Email = userProfile.Email;
            }
            if (!string.IsNullOrWhiteSpace(userProfile.Adresse))
            {
                user.Adresse = userProfile.Adresse;
            }
            if (!string.IsNullOrWhiteSpace(userProfile.Tel))
            {
                user.Tel = userProfile.Tel;
            }
            if (!string.IsNullOrWhiteSpace(userProfile.Matricule))
            {
                user.Matricule = userProfile.Matricule;
            }
            if (userProfile.DateNaiss != default)
            {
                user.DateNaiss = userProfile.DateNaiss;
            }
            if (!string.IsNullOrWhiteSpace(userProfile.Motdepasse))
            {
                // Note : Cette logique de mise à jour du mot de passe peut nécessiter une implémentation différente en fonction de vos besoins de sécurité
                user.Motdepasse = userProfile.Motdepasse;
            }

            // Sauvegarder les modifications dans la base de données
            _context.SaveChanges();

            // Retourner un message de succès
            return Ok(new { message = "Profile updated" });
        }
    }
}

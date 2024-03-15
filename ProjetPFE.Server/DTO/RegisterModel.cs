﻿using System.ComponentModel.DataAnnotations;

namespace ProjetPFE.Server.DTO
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
        [Required(ErrorMessage = "nom is required")]
        public string? Nom { get; set; }
        [Required(ErrorMessage = "prenom is required")]
        public string? Prenom { get; set; }
        [Required(ErrorMessage = "date de naissance is required")]
        public DateOnly DateNaiss { get; set; }
        [Required(ErrorMessage = "poste is required")]
        public string? Poste { get; set; }
        [Required(ErrorMessage = "adresse is required")]
        public string? Adresse { get; set; }
        [Required(ErrorMessage = "matricule is required")]
        public int Matricule { get; set; }
    }
}
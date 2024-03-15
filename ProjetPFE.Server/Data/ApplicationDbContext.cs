using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetPFE.Server.Models;

namespace ProjetPFE.Server.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //hana t9der tconfigurer la base de donne kima ta7ab tabad asim les tables....

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Agence> Agences { get; set; }
        public DbSet<Dre> Dres { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Fiche> Fiches { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Partie_mise_en_cause> Partie_Mise_En_Causes { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Risque> Risques { get; set; }
        public DbSet<Sous_Categorie> Sous_Categories { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Famille> Familles { get; set; }
        public DbSet<Domaine> Domaines { get; set; }
        public DbSet<Processus> Processus { get; set; }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetPFE.Server.Migrations
{
    /// <inheritdoc />
    public partial class first_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Label_Categorie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Label_Categorie);
                });

            migrationBuilder.CreateTable(
                name: "Dres",
                columns: table => new
                {
                    Code_Direction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dres", x => x.Code_Direction);
                });

            migrationBuilder.CreateTable(
                name: "Familles",
                columns: table => new
                {
                    Nom_Famille = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familles", x => x.Nom_Famille);
                });

            migrationBuilder.CreateTable(
                name: "Sous_Categories",
                columns: table => new
                {
                    Label_Sous_Categorie = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategorieLabel_Categorie = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sous_Categories", x => x.Label_Sous_Categorie);
                    table.ForeignKey(
                        name: "FK_Sous_Categories_Categories_CategorieLabel_Categorie",
                        column: x => x.CategorieLabel_Categorie,
                        principalTable: "Categories",
                        principalColumn: "Label_Categorie");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    mot_de_passe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectionCode_Direction = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Admins_Dres_DirectionCode_Direction",
                        column: x => x.DirectionCode_Direction,
                        principalTable: "Dres",
                        principalColumn: "Code_Direction");
                });

            migrationBuilder.CreateTable(
                name: "Agences",
                columns: table => new
                {
                    Code_Agence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectionCode_Direction = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agences", x => x.Code_Agence);
                    table.ForeignKey(
                        name: "FK_Agences_Dres_DirectionCode_Direction",
                        column: x => x.DirectionCode_Direction,
                        principalTable: "Dres",
                        principalColumn: "Code_Direction");
                });

            migrationBuilder.CreateTable(
                name: "Domaines",
                columns: table => new
                {
                    Nom_Domaine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FamilleNom_Famille = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domaines", x => x.Nom_Domaine);
                    table.ForeignKey(
                        name: "FK_Domaines_Familles_FamilleNom_Famille",
                        column: x => x.FamilleNom_Famille,
                        principalTable: "Familles",
                        principalColumn: "Nom_Famille");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateNaiss = table.Column<DateOnly>(type: "date", nullable: false),
                    Poste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Matricule = table.Column<int>(type: "int", nullable: false),
                    Motdepasse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AgenceCode_Agence = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Users_Agences_AgenceCode_Agence",
                        column: x => x.AgenceCode_Agence,
                        principalTable: "Agences",
                        principalColumn: "Code_Agence");
                });

            migrationBuilder.CreateTable(
                name: "Processus",
                columns: table => new
                {
                    Nom_Processus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DomaineNom_Domaine = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processus", x => x.Nom_Processus);
                    table.ForeignKey(
                        name: "FK_Processus_Domaines_DomaineNom_Domaine",
                        column: x => x.DomaineNom_Domaine,
                        principalTable: "Domaines",
                        principalColumn: "Nom_Domaine");
                });

            migrationBuilder.CreateTable(
                name: "AdminUser",
                columns: table => new
                {
                    AdminsUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersUsername = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUser", x => new { x.AdminsUsername, x.UsersUsername });
                    table.ForeignKey(
                        name: "FK_AdminUser_Admins_AdminsUsername",
                        column: x => x.AdminsUsername,
                        principalTable: "Admins",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminUser_Users_UsersUsername",
                        column: x => x.UsersUsername,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entreprises",
                columns: table => new
                {
                    Id_Entreprise = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Occupation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Partie_MiseStatut = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprises", x => x.Id_Entreprise);
                });

            migrationBuilder.CreateTable(
                name: "Fiches",
                columns: table => new
                {
                    Id_incident = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Compte_dzd_devise = table.Column<int>(type: "int", nullable: false),
                    Types_comptes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Types_Sous_Comptes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Types_impacte = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Montant_Perte = table.Column<float>(type: "real", nullable: false),
                    Devise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mesures_Prise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categorie_incident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Service_DefaillantId_Service = table.Column<int>(type: "int", nullable: true),
                    FamilleNom_Famille = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiches", x => x.Id_incident);
                    table.ForeignKey(
                        name: "FK_Fiches_Familles_FamilleNom_Famille",
                        column: x => x.FamilleNom_Famille,
                        principalTable: "Familles",
                        principalColumn: "Nom_Famille");
                    table.ForeignKey(
                        name: "FK_Fiches_Users_Username",
                        column: x => x.Username,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "Partie_Mise_En_Causes",
                columns: table => new
                {
                    Statut = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FicheId_incident = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partie_Mise_En_Causes", x => x.Statut);
                    table.ForeignKey(
                        name: "FK_Partie_Mise_En_Causes_Fiches_FicheId_incident",
                        column: x => x.FicheId_incident,
                        principalTable: "Fiches",
                        principalColumn: "Id_incident");
                });

            migrationBuilder.CreateTable(
                name: "Risques",
                columns: table => new
                {
                    Id_Risque = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label_Risque = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sous_CategorieLabel_Sous_Categorie = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FicheId_incident = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risques", x => x.Id_Risque);
                    table.ForeignKey(
                        name: "FK_Risques_Fiches_FicheId_incident",
                        column: x => x.FicheId_incident,
                        principalTable: "Fiches",
                        principalColumn: "Id_incident");
                    table.ForeignKey(
                        name: "FK_Risques_Sous_Categories_Sous_CategorieLabel_Sous_Categorie",
                        column: x => x.Sous_CategorieLabel_Sous_Categorie,
                        principalTable: "Sous_Categories",
                        principalColumn: "Label_Sous_Categorie");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id_Service = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label_Service = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FicheId_incident = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id_Service);
                    table.ForeignKey(
                        name: "FK_Services_Fiches_FicheId_incident",
                        column: x => x.FicheId_incident,
                        principalTable: "Fiches",
                        principalColumn: "Id_incident");
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id_Personne = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Occupation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Partie_MiseStatut = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id_Personne);
                    table.ForeignKey(
                        name: "FK_Personnes_Partie_Mise_En_Causes_Partie_MiseStatut",
                        column: x => x.Partie_MiseStatut,
                        principalTable: "Partie_Mise_En_Causes",
                        principalColumn: "Statut");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_DirectionCode_Direction",
                table: "Admins",
                column: "DirectionCode_Direction");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUser_UsersUsername",
                table: "AdminUser",
                column: "UsersUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Agences_DirectionCode_Direction",
                table: "Agences",
                column: "DirectionCode_Direction");

            migrationBuilder.CreateIndex(
                name: "IX_Domaines_FamilleNom_Famille",
                table: "Domaines",
                column: "FamilleNom_Famille");

            migrationBuilder.CreateIndex(
                name: "IX_Entreprises_Partie_MiseStatut",
                table: "Entreprises",
                column: "Partie_MiseStatut");

            migrationBuilder.CreateIndex(
                name: "IX_Fiches_FamilleNom_Famille",
                table: "Fiches",
                column: "FamilleNom_Famille");

            migrationBuilder.CreateIndex(
                name: "IX_Fiches_Service_DefaillantId_Service",
                table: "Fiches",
                column: "Service_DefaillantId_Service");

            migrationBuilder.CreateIndex(
                name: "IX_Fiches_Username",
                table: "Fiches",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Partie_Mise_En_Causes_FicheId_incident",
                table: "Partie_Mise_En_Causes",
                column: "FicheId_incident");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_Partie_MiseStatut",
                table: "Personnes",
                column: "Partie_MiseStatut");

            migrationBuilder.CreateIndex(
                name: "IX_Processus_DomaineNom_Domaine",
                table: "Processus",
                column: "DomaineNom_Domaine");

            migrationBuilder.CreateIndex(
                name: "IX_Risques_FicheId_incident",
                table: "Risques",
                column: "FicheId_incident");

            migrationBuilder.CreateIndex(
                name: "IX_Risques_Sous_CategorieLabel_Sous_Categorie",
                table: "Risques",
                column: "Sous_CategorieLabel_Sous_Categorie");

            migrationBuilder.CreateIndex(
                name: "IX_Services_FicheId_incident",
                table: "Services",
                column: "FicheId_incident");

            migrationBuilder.CreateIndex(
                name: "IX_Sous_Categories_CategorieLabel_Categorie",
                table: "Sous_Categories",
                column: "CategorieLabel_Categorie");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AgenceCode_Agence",
                table: "Users",
                column: "AgenceCode_Agence");

            migrationBuilder.AddForeignKey(
                name: "FK_Entreprises_Partie_Mise_En_Causes_Partie_MiseStatut",
                table: "Entreprises",
                column: "Partie_MiseStatut",
                principalTable: "Partie_Mise_En_Causes",
                principalColumn: "Statut");

            migrationBuilder.AddForeignKey(
                name: "FK_Fiches_Services_Service_DefaillantId_Service",
                table: "Fiches",
                column: "Service_DefaillantId_Service",
                principalTable: "Services",
                principalColumn: "Id_Service");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agences_Dres_DirectionCode_Direction",
                table: "Agences");

            migrationBuilder.DropForeignKey(
                name: "FK_Fiches_Users_Username",
                table: "Fiches");

            migrationBuilder.DropForeignKey(
                name: "FK_Fiches_Familles_FamilleNom_Famille",
                table: "Fiches");

            migrationBuilder.DropForeignKey(
                name: "FK_Fiches_Services_Service_DefaillantId_Service",
                table: "Fiches");

            migrationBuilder.DropTable(
                name: "AdminUser");

            migrationBuilder.DropTable(
                name: "Entreprises");

            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "Processus");

            migrationBuilder.DropTable(
                name: "Risques");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Partie_Mise_En_Causes");

            migrationBuilder.DropTable(
                name: "Domaines");

            migrationBuilder.DropTable(
                name: "Sous_Categories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Dres");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Agences");

            migrationBuilder.DropTable(
                name: "Familles");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Fiches");
        }
    }
}

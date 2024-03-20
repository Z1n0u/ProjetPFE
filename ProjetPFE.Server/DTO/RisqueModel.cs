
using ProjetPFE.Server.Models;

namespace ProjetPFE.Server.DTO
{
    public class RisqueDTO
    {
        public int Id_Risque { get; set; }
        public string Label_Risque { get; set; }
        public Sous_Categorie SousCategorie { get; set; }
        public Categorie Categorie { get; set; }
    }
}

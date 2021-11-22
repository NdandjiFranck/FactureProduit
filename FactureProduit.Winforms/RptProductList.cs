using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactureProduit.Winforms
{
    public class RptProductList
    {
        public string Reference { get; set; }
        public string TVA { get; set; }
        public string PrixUnitaire { get; set; }
        public string Nom { get; set; }
        public byte [] Photo { get; set; }
        public byte[] Logo { get; set; }

        public RptProductList(string reference, string nom, string prixUnitaire, string Tva, byte[] photo, byte[] logo)
        {
            this.Reference = reference;
            Nom = nom;
            PrixUnitaire = prixUnitaire;
            TVA = Tva;
            Photo = photo;
            Logo = logo;
        }
    }
}

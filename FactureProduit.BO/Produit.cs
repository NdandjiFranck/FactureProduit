using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactureProduit.BO
{
    public class Produit
    {

        private const int NUMBER_OF_PROPERTIES = 5;
        public string Reference { get; set; }
        public string TVA { get; set; }
        public string PrixUnitaire { get; set; }
        public string Nom { get; set; }
        public Produit()
        {
        }

        public Produit(string reference, string tVA, string prixUnitaire, string nom)
        {
            Reference = reference;
            TVA = tVA;
            PrixUnitaire = prixUnitaire;
            Nom = nom;
        }

        public void Add(Produit produit)
        {

        }

        public string Serialize(Produit u)
        {
            return $"{Reference}|{Nom}|{PrixUnitaire}|{TVA}";
        }

        public void Deserialise(string value)
        {
            string[] tab = value?.Split('|');
            if (tab != null && tab.Length >= NUMBER_OF_PROPERTIES)
            {
                Reference = tab[0];
                Nom = tab[1];
                PrixUnitaire = tab[2];
                TVA = tab[3];
            }
        }
    }
}

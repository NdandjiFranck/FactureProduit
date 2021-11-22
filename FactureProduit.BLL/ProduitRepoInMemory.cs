using FactureProduit.BO;
using FactureProduit.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactureProduit.BLL
{
    public class ProduitRepoInMemory : ProduitRepository
    {
        private List<Produit> prod;


        public ProduitRepoInMemory()
        {
            if (prod == null)
                prod = new List<Produit> {new Produit("001", "17", "1678", "Mambo")};
        }
        public void Add(Produit produit, Action<IEnumerable<Produit>> callBack)
        {
            prod.Add(produit);
            if (callBack != null)
                callBack(prod);
        }

        public void Delete(Produit produit, Action<IEnumerable<Produit>> callBack)
        {
            prod.Remove(produit);
            if (callBack != null)
                callBack(prod);
        }

        public void Delete(IEnumerable<Produit> produits, Action<IEnumerable<Produit>> callBack)
        {
            foreach (Produit p in produits)
            {

                prod.Remove(p);
            }
            if (callBack != null)
                callBack(prod);
        }

        public IEnumerable<Produit> Find(Func<Produit, bool> predicate, Action<IEnumerable<Produit>> callBack)
        {
            var produits = prod.Where(predicate);
            if (callBack != null)
                callBack(prod);
            return produits;
        }

        public IEnumerable<Produit> GetAll()
        {
            return prod;
        }

        public void Set(Produit oldProduit, Produit NewProduit, Action<IEnumerable<Produit>> callBack)
        {
            prod[prod.IndexOf(oldProduit)] = NewProduit;

            if (callBack != null)
                callBack(prod);
        }
    }
}

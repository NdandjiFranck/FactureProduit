using FactureProduit.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactureProduit.DAL
{
    public interface ProduitRepository
    {
        void Add(Produit produit, Action<IEnumerable<Produit>> callBack);
        IEnumerable<Produit> GetAll();
        void Delete(Produit produit, Action<IEnumerable<Produit>> callBack);
        //void Delete(Action<IEnumerable<Produit>> loadGrid);
        void Delete(IEnumerable<Produit> produit, Action<IEnumerable<Produit>> callBack);
        void Set(Produit oldProduit, Produit NewProduit, Action<IEnumerable<Produit>> loadGrid);
        IEnumerable<Produit> Find(Func<Produit, bool> predicate, Action<IEnumerable<Produit>> loadGrid);

    }
}

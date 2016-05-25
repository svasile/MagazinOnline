using MagazinOnline.Domeniu.Abstract;
using System.Collections.Generic;
using MagazinOnline.Domeniu.Entitati;

namespace MagazinOnline.Domeniu.Concret
{
    public class EFDepozitProduse : IDepozitProduse
    {
        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Produs> Produse
        {
            get{return context.Produse;}
        }

        public void SalveazaProdus(Produs produs)
        {
            if(produs.ProdusID==0)
            {
                context.Produse.Add(produs);
            }
            else
            {
                Produs dbEntry = context.Produse.Find(produs.ProdusID);
                if(dbEntry!=null)
                {
                    dbEntry.Denumire = produs.Denumire;
                    dbEntry.Descriere = produs.Descriere;
                    dbEntry.Pret = produs.Pret;
                    dbEntry.Categorie = produs.Categorie;
                }
            }
            context.SaveChanges();
        }

        public Produs StergeProdus(int produsId)
        {
            Produs dbEntry = context.Produse.Find(produsId);
            if (dbEntry != null)
            {
                context.Produse.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

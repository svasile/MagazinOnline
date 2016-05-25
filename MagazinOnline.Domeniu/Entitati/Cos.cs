using System.Collections.Generic;
using System.Linq;

namespace MagazinOnline.Domeniu.Entitati
{
    public class Cos
    {
        private List<CosCoada> coadaColectie = new List<CosCoada>();

        public void AddItem(Produs produs,int cantitate)
        {
            CosCoada coada = coadaColectie.Where(p => p.Produs.ProdusID == produs.ProdusID)
                .FirstOrDefault();
            if(coada==null)
            {
                coadaColectie.Add(
                    new CosCoada
                    {
                        Produs=produs,
                        Cantitate=cantitate
                    });
            }
            else
            {
                coada.Cantitate += cantitate;
            }
        }

        public void StergeCoada(Produs produs)
        {
            coadaColectie.RemoveAll(p => p.Produs.ProdusID == produs.ProdusID);
        }

        public decimal CalculareValoareTotala()
        {
            return coadaColectie.Sum(p => p.Produs.Pret * p.Cantitate);
        }

        public IEnumerable<CosCoada>rand
        {
            get { return coadaColectie; }
        }

        public void Golire()
        {
            coadaColectie.Clear();
        }
    }
}

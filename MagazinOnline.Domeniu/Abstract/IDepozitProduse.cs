using MagazinOnline.Domeniu.Entitati;
using System.Collections.Generic;

namespace MagazinOnline.Domeniu.Abstract
{
    public interface IDepozitProduse
    {
        IEnumerable<Produs>Produse { get; }

        void SalveazaProdus(Produs produs);
        Produs StergeProdus(int produsId);
    }
}

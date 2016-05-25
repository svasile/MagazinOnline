using MagazinOnline.Domeniu.Entitati;
using System.Collections.Generic;

namespace MagazinOnline.UI.Models
{
    public class ListaProduse
    {
        public IEnumerable<Produs> Produse { get; set; }
        public InfoPaginare InfoPaginare { get; set; }
        public string CategoriaCurenta { get; set; }
    }
}
